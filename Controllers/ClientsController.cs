using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_MVC.Models;

namespace Library_MVC.Controllers
{
    //[Authorize(Roles ="Administrator, Librarian")]


    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients

        [Authorize(Roles = "Administrator, Librarian, User")]
        public ActionResult Index()
        {
           

            return View(db.Clients.ToList());
        }


        // GET: Clients/Details/5
        
        [Authorize(Roles = "Administrator, Librarian, User")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        [Authorize(Roles = "Administrator, Librarian")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name,Address,LibraryCard,ExpirationDate,PackageType,HomeAddress,Age,Telephone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        [Authorize(Roles = "Administrator, Librarian")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,Address,LibraryCard,ExpirationDate,PackageType,HomeAddress,Age,Telephone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        /*
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] */
        [Authorize(Roles = "Administrator, Librarian")]
        public ActionResult Delete(int id)
        {
            if (!(db.Clients.Find(id).books.Count is 0))
            {
                db.Clients.Find(id).books.Clear();

            }
            if (!(db.Clients.Find(id).borrowedBooks.Count is 0))
            {
                db.Clients.Find(id).borrowedBooks.Clear();

            }
            Client client = db.Clients.Find(id);


            db.Clients.Remove(client);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Clients/AddBookToClient/5
        [Authorize(Roles = "Administrator,Librarian")]
        public ActionResult AddBookToClient(int? id)
        {
            var model = new AddBookToClientModel();  //sekogash pishuvaj go kako var
            model.ClientId = id ?? 0;   //int variable shto moze da ima null vrednost
            model.books = db.Books.ToList();  //site mozhni albumi od BAZATA
            ViewBag.ClientName = db.Clients.Find(id).Name;

            return View(model);
        }

        // POST: Clients/AddBookToClient/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddBookToClient(AddBookToClientModel model)
        {
            var client = db.Clients.Find(model.ClientId);
            if(db.Books.Find(model.BookId).Status == 0)
            {
                return RedirectToAction("NoCopiesView", db.Books.Find(model.BookId));
            }
            db.Books.Find(model.BookId).Status = db.Books.Find(model.BookId).Status- 1;
            var book = db.Books.Find(model.BookId);

            client.books.Add(book);
            client.borrowedBooks.Add(book);


            db.SaveChanges(); //za da se zachuvaat promenite
            return View("Index", db.Clients.ToList()); //MORA DA IMA I MODEL SOODVETNO ZA DA SE PRIKAZE VIEW!!
        }

        public ActionResult NoCopiesView(Book model)
        {
            
            return View(model); //MORA DA IMA I MODEL SOODVETNO ZA DA SE PRIKAZE VIEW!!
        }


        // GET: Clients/RemoveBookFromClient/5
        [Authorize(Roles = "Administrator, Librarian")]
        public ActionResult RemoveBookFromClient(int? id)
        {
            var model = new AddBookToClientModel();  //sekogash pishuvaj go kako var
            model.ClientId = id ?? 0;   //int variable shto moze da ima null vrednost
            
            model.books =(List<Book>) db.Clients.Find(id).books;  //site mozhni knigi od BAZATA
            ViewBag.ClientName = db.Clients.Find(id).Name;

            return View(model);
        }

        // POST: Clients/RemoveBookFromClient/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RemoveBookFromClient(AddBookToClientModel model)
        {
            var client = db.Clients.Find(model.ClientId);
            db.Books.Find(model.BookId).Status = db.Books.Find(model.BookId).Status + 1;
            var book = db.Books.Find(model.BookId);

            client.books.Remove(book);
            //client.borrowedBooks.Add(book);


            db.SaveChanges(); //za da se zachuvaat promenite
            return View("Index", db.Clients.ToList()); //MORA DA IMA I MODEL SOODVETNO ZA DA SE PRIKAZE VIEW!!
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
