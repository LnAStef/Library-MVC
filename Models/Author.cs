using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_MVC.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Display(Name = "Author Name")]
        public string Name { get; set; }

        public virtual ICollection<Book> books { get; set; }
        

        public Author()
        {
            books = new List<Book>();
        }
       
    }
}