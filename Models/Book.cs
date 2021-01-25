using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_MVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Genre name")]
        public int GenreId { get; set; }

        [Display(Name = "Author name")]
        public int AuthorId { get; set; }

        [Range(0, 5000)]
        public decimal Price { get; set; }

        [Display(Name = "Available copies")]
        public int Status { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } //url za slika od knigata

        public Genre Genre { get; set; }

        public Author Author { get; set; }

       


        //public enum BookStatus
        //{
        //   Borrowed,     // 0
        //  Free    // 1

        //}



        //public virtual List<Store> stores { get; set; }  //virtual e radi AJAX??, za da moze DB da napravi many to many relacija vo pozadina
        //public Album()
        //{
        //    stores = new List<Store>();
        //}
    }
}