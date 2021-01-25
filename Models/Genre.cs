using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_MVC.Models
{
    public class Genre
    {

        public Genre()
        {
            books = new List<Book>();
        }

        [Key]
        public int GenreId { get; set; }

        [Display(Name = "Genre Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Book> books { get; set; }


        public virtual ICollection<Book> books { get; set; }


        

    }
}