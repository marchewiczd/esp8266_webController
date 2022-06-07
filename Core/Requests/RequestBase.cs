using RestSharp;

namespace ApiCommunication.Requests
{
    public abstract class RequestBase
    {
        public Dictionary<string, string> Parameters { get; init; }
        public Method HttpMethod { get; init; }        
        public bool UseParameters { get; set; }
        public string Resource { get; init; }


        public RestRequest GetRestRequest()
        {
            var request = new RestRequest(Resource);
            request.Method = HttpMethod;

            if (UseParameters)
            {
                foreach (var parameter in Parameters)
                {
                    if (string.IsNullOrEmpty(parameter.Value))
                        continue;

                    request.AddParameter(parameter.Key, parameter.Value);
                }
            }

            return request;
        }
    }
}
