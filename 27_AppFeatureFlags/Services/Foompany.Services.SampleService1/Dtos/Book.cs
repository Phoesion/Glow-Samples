using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Foompany.Services.SampleService1.Dtos
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public DateTime DatePublished { get; set; }

        public Address Location { get; set; }
    }
}
