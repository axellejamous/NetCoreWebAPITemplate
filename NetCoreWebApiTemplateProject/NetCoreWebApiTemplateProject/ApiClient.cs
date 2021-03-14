using NetCoreWebApiTemplateProject.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace NetCoreWebApiTemplateProject
{
    public class ApiClient : IApiClient
    {
        private readonly IRestClient _client;

        internal ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator("", "")
            };

            BaseUrl = AddForwardSlash(baseUrl);
        }

        public string BaseUrl { get; set; }

        private string AddForwardSlash(string baseUrl)
        {
            return baseUrl + "/";
        }

        public async Task<IRestResponse<ExampleResponseObject>> GetDataAsync(string parameter)
        {
            RestRequest restRequest = new RestRequest("/get/" + parameter, Method.GET);

            var response = await _client.ExecuteAsync<ExampleResponseObject>(restRequest);

            return response;
        }

        public async Task<IRestResponse<ExampleResponseObject>> PostDataAsync(string parameter, ExampleRequestObject request)
        {
            RestRequest restRequest = new RestRequest("/post/" + parameter + "/create", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            restRequest.AddJsonBody(JsonConvert.SerializeObject(request));

            var response = await _client.ExecuteAsync<ExampleResponseObject>(restRequest);
            return response;
        }
    }
}
