using MediatR;
using Project.Contracts.Common;

namespace Project.Application.Behaviours;
public class UnhandledException<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
		try
		{
			return await next();
		}
		catch (Exception ex)
		{
            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = typeof(TResponse).GetGenericArguments()[0];
                var failureMethod = typeof(Result<>).MakeGenericType(resultType).GetMethod("Failure");
                return (TResponse)failureMethod.Invoke(null, new object[] { $"An unhandled exception occurred: {ex.Message}" });
            }

            if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(object)Result.Failure($"An unhandled exception occurred: {ex.Message}");
            }

            throw;
        }
    }
}
