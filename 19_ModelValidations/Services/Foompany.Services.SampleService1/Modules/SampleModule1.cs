using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    /// <summary>
    /// A sample module with model validations.
    /// If the validation fails the server will return a BadRequest 400 with error details.
    /// 
    /// Notes : 
    ///     - To ignore request failure on error you can decorate the method or module with [IgnoreModelValidationErrors], or set ActionAttribute IgnoreModelValidationErrors to true
    ///       You can then examine the results using ModelState.IsValid and ModelState.Errors
    ///     - To skip validation entirely you can decorate the method or module with [SkipModelValidations]
    /// </summary>
    public class SampleModule1 : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "SampleModule1 default method";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// You can add ValidationAttributes to the action parameters
        /// </summary>
        [Action(Methods.GET)]
        public string Action1([Required] string Description, [Range(5, 10)] int value)
        {
            return "ok!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// The model of type 'Models.Movie' has validation attributes that will be validated before calling this action.
        /// </summary>
        [Action(Methods.POST)]
        public string Action2(Models.Movie movie)
        {
            return "ok!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// In this action, using [IgnoreModelValidationErrors] we can manually respond to errors using the ModelState.isValid and ModelState.Errors
        /// </summary>
        [Action(Methods.GET), IgnoreModelValidationErrors]
        public string Action3([Required] string Description, [Range(5, 10)] int value)
        {
            if (!ModelState.IsValid)
            {
                return "Errors : " + Environment.NewLine + string.Join(Environment.NewLine, ModelState.Errors.Select(e => e.Message));
            }

            return "ok!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Model validations can run on collections themselves and their content
        /// </summary>
        [Action(Methods.POST)]
        public string Action4(IEnumerable<Models.Movie> movies)
        {
            return "ok!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Validate an arbitrary model
        /// </summary>
        [Action(Methods.GET)]
        public async Task<string> Action5(string title, string description, Models.Genre genre = Models.Genre.Classic, int price = 0)
        {
            //create model
            var model = new Models.Movie()
            {
                Title = title,
                Description = description,
                Genre = genre,
                Price = price,
            };

            //validate it manually
            if (!await TryValidateModel(model, nameof(model), out IList<ModelValidationResults.Result> errors))
                throw PhotonException.BadRequest.WithMessage("Errors : " + Environment.NewLine + string.Join(Environment.NewLine, errors.Select(e => e.Message)));

            return "ok!";
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
