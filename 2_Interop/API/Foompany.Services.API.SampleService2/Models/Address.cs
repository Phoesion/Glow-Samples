using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Foompany.Services.API.SampleService2.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
    }
}
