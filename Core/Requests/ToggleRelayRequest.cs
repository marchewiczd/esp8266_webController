namespace ApiCommunication.Requests
{
    public class ToggleRelayRequest : RequestBase
    {
        public ToggleRelayRequest()
        {
            Resource = "relay/0";
            HttpMethod = RestSharp.Method.Get;
            UseParameters = true;

            Parameters = new Dictionary<string, string>
            {
                { "turn", "toggle" },
                { "timer", "0" }
            };
        }

        public ToggleRelayRequest(string turn, string timer, bool useParameters = true)
        {
            Resource = "/relay/0";
            HttpMethod = RestSharp.Method.Get;
            UseParameters = useParameters;

            Parameters = new Dictionary<string, string>
            {
                { "turn", turn },
                { "timer", timer }
            };
        }
    }
}
