namespace NetCoreWebApiTemplateProject
{
    public class ApiClientFactory
    {
        public IApiClient CreateApiClient()
        {
            return CreateDevApiClient(); // ENV
        }

        private IApiClient CreateDevApiClient()
        {
            var baseUrl = "http://localhost:8080/backend/webapi";
            return new ApiClient(baseUrl);
        }

        private IApiClient CreateProductionApiClient()
        {
            var baseUrl = "";
            return new ApiClient(baseUrl);
        }
    }
}
