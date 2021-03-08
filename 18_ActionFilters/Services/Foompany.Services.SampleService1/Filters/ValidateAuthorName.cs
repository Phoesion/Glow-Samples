using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.SampleService1.Filters
{
    class ValidateAuthorName : ActionFilter
    {
        public string FieldToCheck = null;

        public override ValueTask<object> InvokeAsync(IActionFilterChain chain, IActionFilterContext context)
        {
            //ignore filter if not field set by user
            if (FieldToCheck == null)
                return chain.InvokeNextAsync();

            //get authorName
            var authorName = context.ActionArguments[FieldToCheck]?.ToString()?.Trim();

            //null/whitespace check
            if (string.IsNullOrWhiteSpace(authorName))
                throw PhotonException.NotAcceptable.WithMessage("Author name cannot be null, empty or whitespace");

            //character check
            if (authorName.Length < 2)
                throw PhotonException.NotAcceptable.WithMessage("Author name must be at least 2 characters");

            //TODO: character set check, etc..

            //continue execution
            return chain.InvokeNextAsync();
        }
    }
}
