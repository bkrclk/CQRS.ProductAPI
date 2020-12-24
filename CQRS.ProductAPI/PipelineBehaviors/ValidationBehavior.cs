using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public readonly IEnumerable<IValidator<TRequest>> Validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = Validators
                .Select(x => x.Validate(context))
                .SelectMany(x=>x.Errors)
                .Where(x=>x!= null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
