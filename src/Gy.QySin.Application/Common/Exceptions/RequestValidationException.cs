using System;
using System.Collections.Generic;
using System.Linq;

namespace Gy.QySin.Application.Common.Exceptions
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException(FluentValidation.ValidationException ex)
            : base(ex.Message, ex)
        {
            Errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(e => e.Key, e => e.Select(x => x.ErrorMessage));
        }
        public IReadOnlyDictionary<string, IEnumerable<string>> Errors { get; set; }
    }
}