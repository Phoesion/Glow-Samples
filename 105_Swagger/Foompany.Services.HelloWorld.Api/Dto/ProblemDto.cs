using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.HelloWorld.API.Dto
{
    /// <summary>
    /// The sample problem Dto
    /// </summary>
    public class ProblemDto
    {
        /// <summary>
        /// The problem error code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The problem message
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}
