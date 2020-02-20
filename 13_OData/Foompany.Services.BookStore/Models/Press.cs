using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.Services.BookStore.Models
{
    public class Press
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        Book,
        Magazine,
        EBook
    }
}
