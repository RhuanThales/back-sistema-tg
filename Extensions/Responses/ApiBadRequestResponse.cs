using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace back_sistema_tg.Extensions.Responses
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }

        public ApiBadRequestResponse(ModelStateDictionary modelState) : base(400)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState está inválido", nameof(modelState));
            }

            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}