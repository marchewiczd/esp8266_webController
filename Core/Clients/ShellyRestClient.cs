using Core.Helpers;
using Core.Requests;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Core.Clients
{
    public class ShellyRestClient
    {
        private readonly string _apiUrl;
        private readonly ILogger _logger;
        private readonly RestClient _restClient;

        public ShellyRestClient(string apiUrl, ILogger<ShellyRestClient> logger)
        {
            _apiUrl = apiUrl;
            _logger = logger ?? throw new ArgumentNullException();
            _restClient = new RestClient(apiUrl);
            
            _logger.Log(LogLevel.Information, 
                $"ShellyRestClient for {apiUrl} has been created.");
        }

        public async Task<RestResponse> SendAsync<T>(T request) where T : RequestBase, new()
        {
            _logger.Log(LogLevel.Trace, $"SendAsync<{typeof(T).Name}> sends request");
            _logger.Log(LogLevel.Information, 
                $"Sending {typeof(T).Name} to {_apiUrl} at {request.Resource}");
            var response = await _restClient.ExecuteAsync(request.GetRestRequest());
            _logger.Log(LogLevel.Trace, $"Response received");        
            _logger.Log(response.IsSuccessful ? LogLevel.Information : LogLevel.Error,
                $"Response status: {response.ResponseStatus}({(int)response.StatusCode})");
            _logger.Log(LogLevel.Trace, $"Response content: {response.Content})");
            
            return response;
        }

        public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : RequestBase, new()
        {
            _logger.Log(LogLevel.Trace, 
                $"SendAsync<{typeof(TRequest).Name}, {typeof(TResponse).Name}> sends request");
            _logger.Log(LogLevel.Information, 
                $"Sending {typeof(TRequest).Name} to {_apiUrl} at {request.Resource}");
            
            var response = await _restClient.ExecuteAsync<TResponse>(request.GetRestRequest());
            
            _logger.Log(LogLevel.Trace, 
                $"SendAsync<{typeof(TRequest).Name}, {typeof(TResponse).Name}> received response");
            _logger.Log(response.IsSuccessful ? LogLevel.Information : LogLevel.Error,
                $"Response status: {response.ResponseStatus}({response.StatusCode})");
            _logger.Log(LogLevel.Trace, $"Response content: {response.Content})");
            
            return response.Data;
        }

        public RestResponse Send<T>(T request) where T : RequestBase, new()
        {
            _logger.Log(LogLevel.Trace, $"Send<{typeof(T).Name}> called");
            _logger.Log(LogLevel.Trace, $"Calling SendAsync<{typeof(T).Name}> synchronously");
            return AsyncHelper.RunSync(() => SendAsync(request));
        }

        public TResponse Send<TRequest, TResponse>(TRequest request) where TRequest : RequestBase, new()
        {
            _logger.Log(LogLevel.Trace, $"Send<{typeof(TRequest).Name}, {typeof(TResponse).Name}> called");
            _logger.Log(LogLevel.Trace, 
                $"Calling SendAsync<{typeof(TRequest).Name}, {typeof(TResponse).Name}> synchronously");
            return AsyncHelper.RunSync(() => SendAsync<TRequest, TResponse>(request));
        }
    }
}
