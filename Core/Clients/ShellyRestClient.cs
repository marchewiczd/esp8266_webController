using ApiCommunication.Helpers;
using ApiCommunication.Requests;
using RestSharp;

namespace ApiCommunication.Clients
{
    public class ShellyRestClient
    {
        private RestClient _restClient;
        private RestResponse? _response;

        public ShellyRestClient(string apiUrl)
        {
            _restClient = new RestClient(apiUrl);
        }

        public async Task<RestResponse> SendAsync<T>(T request) where T : RequestBase, new()
        {
            Log.Print("pre execute async");
            _response = await _restClient.ExecuteAsync(request.GetRestRequest());
            Log.Print("post execute async");

            return _response;
        }

        public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : RequestBase, new()
        {
            var result = await _restClient.ExecuteAsync<TResponse>(request.GetRestRequest());

            if (result != null)
                return result.Data;

            return default;
        }

        public RestResponse Send<T>(T request) where T : RequestBase, new()
        {
            return AsyncHelper.RunSync<RestResponse>(() => SendAsync(request));
        }

        public TResponse Send<TRequest, TResponse>(TRequest request) where TRequest : RequestBase, new()
        {
            return AsyncHelper.RunSync(() => SendAsync<TRequest, TResponse>(request));
        }
    }
}
