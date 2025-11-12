using Anidream.Application.Exceptions;
using Anidream.Application.UseCases.Handlers.Storage.UploadMediaVideo;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anidream.Application.UseCases.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            
            var validationResults = await 
                Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)))
                .ConfigureAwait(false);

            var failures = validationResults
                .Where(x => x.Errors.Count > 0)
                .SelectMany(x => x.Errors)
                .ToList();
            
            if(failures.Any())
                throw new ValidationException(failures);
        }
        
        return await next().ConfigureAwait(false);
    }
}