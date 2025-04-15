using FluentValidation;
using MediatR;

namespace Ollyware.Flowlly.Core.API.Application.PipelineBehaviours;

public class ValidationBehaviour<TIn, TOut>(IEnumerable<IValidator<TIn>> validators) : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
{
    private readonly IEnumerable<IValidator<TIn>> _validators = validators;

    public async Task<TOut> Handle(TIn request, RequestHandlerDelegate<TOut> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TIn>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.SelectMany(err => err.Errors).Where(f => f is not null).ToList();

            if (failures.Any())
            {
                throw new Domain.Errors.ValidationException(failures);
            }
        }

        return await next();
    }
}
