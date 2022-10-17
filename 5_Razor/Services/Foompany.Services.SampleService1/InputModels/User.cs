using System.ComponentModel.DataAnnotations;

namespace Foompany.Services.SampleService1.InputModels
{
    public class UserInput
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
    }
}
