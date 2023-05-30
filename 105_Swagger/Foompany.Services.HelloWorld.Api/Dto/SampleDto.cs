using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.HelloWorld.API.Dto.SampleDto
{
    /// <summary>
    /// The sample request Dto
    /// </summary>
    public class Request
    {
        /// <summary>
        /// The First name of the user
        /// </summary>
        [Required, MaxLength(255)]
        public string FirstName { get; set; }

        /// <summary>
        /// The Last name of the user
        /// </summary>
        [Required, MaxLength(255)]
        public string LastName { get; set; }
    }


    /// <summary>
    /// The sample response Dto
    /// </summary>
    public class Response
    {
        /// <summary>
        /// A message
        /// </summary>
        public string Message { get; set; }
    }
}
