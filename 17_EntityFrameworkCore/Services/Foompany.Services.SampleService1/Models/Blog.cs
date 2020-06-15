using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Foompany.Services.SampleService1.Models
{
    public class Blog
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        //References
        public ICollection<Post> Posts { get; set; }
    }
}
