
using FluentValidation;
using MediatR;

namespace E_Association.Core.Domain.Pipelines
{

    public class RequestPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest
    {
        private IEnumerable<IValidator<TRequest>> _validators;
        public RequestPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // for Obtain Class or Type of Request
            var context = new ValidationContext<TRequest>(request);

            // user validator on request class
            var errors = _validators.Select(x => x.Validate(context))
                .SelectMany(_error => _error.Errors)
                .Where(x=>x is not null)
                .ToList();

            // cheek for any error 
            if (errors.Any())
                throw new ValidationException(errors);

            return next();

        }
    }
}