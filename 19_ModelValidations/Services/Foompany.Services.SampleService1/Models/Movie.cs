using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Foompany.Services.SampleService1.Models.Validators;
using Phoesion.Glow.SDK;

namespace Foompany.Services.SampleService1.Models
{
    /// <summary>
    /// Sample input model with validation attributes.
    /// Notes : 
    ///     - If you disable recursive validations and you need the validator to continue into an inner-class you can :
    ///         1) decorate the model class with [EnableDeepValidation]
    ///         2) decorate a specific property with [ValidateObject]
    ///             eg. assuming a complex Director class with it's own validations
    ///                 [ValidateObject]
    ///                 public Director Director { get; set;}
    ///            
    ///     - For custom validation you can use the IValidatableObject interface, or IValidatableObjectAsync if validation will have IO operations (eg. querying a database)
    /// </summary>
    public class Movie : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [ClassicMovie(1960)]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        public Genre Genre { get; set; }

        public bool Preorder { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Preorder && Genre == Genre.None)
                yield return new ValidationResult("You can only pre-order for specific Genre");
        }
    }
}
