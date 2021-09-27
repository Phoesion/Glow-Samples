using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.Services.SampleService1.Models
{
    public class Post
    {
        public long Id { get; set; }

        public long BlogId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //References
        public Blog Blog { get; set; }
    }
}
