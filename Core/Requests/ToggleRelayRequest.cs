using Core.DataModels.Enums;
using Core.Extensions;

namespace Core.Requests
{
    public class ToggleRelayRequest : RequestBase
    {
        public ToggleRelayRequest()
        {
            Resource = "relay/0";
            HttpMethod = RestSharp.Method.Get;
            UseParameters = false;
        }

        public ToggleRelayRequest(ToggleType toggleType, string timer)
        {
            Resource = "/relay/0";
            HttpMethod = RestSharp.Method.Get;
            UseParameters = true;

            Parameters = new Dictionary<string, string>
            {
                { "turn", toggleType.GetParameterName() },
                { "timer", timer }
            };
        }
    }
}
