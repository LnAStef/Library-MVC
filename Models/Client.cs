using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_MVC.Models
{
    public class Client
    {

        public Client()
        {
            books = new List<Book>();
            borrowedBooks = new List<Book>();
        }

        [Key]
        public int ClientId { get; set; }

        [Display(Name = "Library Card")]
        public string LibraryCard { get; set; }

        //expiration date
        //package A or B

        [Display(Name = "Home Address")]
        public string HomeAddress{ get; set; }

        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Package Type")]
        public string PackageType { get; set; }




        [Required]
        [Display(Name = "Client Name")]
        public string Name { get; set; }
        [Display(Name = "E-mail Address")]
        public string Address { get; set; }

     

        [Range(1, 99)]
        public int Age { get; set; }

        public string Telephone { get; set; }

        

        public virtual ICollection<Book> books { get; set; }

        public virtual ICollection<Book> borrowedBooks { get; set; }

    }
}