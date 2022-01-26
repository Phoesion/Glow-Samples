using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Foompany.Services.BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Address Location { get; set; }
    }
}
