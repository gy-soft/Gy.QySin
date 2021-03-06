using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Gy.QySin.Application.Common.Exceptions;
using MediatR;

namespace Gy.QySin.Application.Common
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            IEnumerable<ValidationFailure> errores = validators
                .Select(val => val.Validate(context))
                .SelectMany(res => res.Errors)
                .Where(e => e is not null)
                .ToArray();

            if (errores.Any())
            {
                throw new RequestValidationException(
                    new ValidationException(
                        $"Error validando la petición {typeof(TRequest).Name}",
                        errores
                    )
                );
            }

            return await next();
        }
    }
}