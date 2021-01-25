using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_MVC.Models
{
    public class AddBookToClientModel
    {

        // pravime ViewModel za da moze polesno da se dodava Kniga na daden Klient
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public List<Book> books { get; set; }  //lista od site knigi vo bibliotekata

        public AddBookToClientModel()
        {
            books = new List<Book>();
        }
    }
}