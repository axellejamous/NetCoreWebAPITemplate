using NetCoreWebApiTemplateProject.Model;
using RestSharp;
using System.Threading.Tasks;

namespace NetCoreWebApiTemplateProject
{
    public interface IApiClient
    {
        /// <summary>
        /// This summary will get shown when you hover over the call
        /// </summary>     
        /// <param name="parameter">A string parameter</param>
        /// <returns>JSON object</returns>
        Task<IRestResponse<ExampleResponseObject>> GetDataAsync(string parameter);
        /// <summary>
        /// This summary will get shown when you hover over the call
        /// </summary>     
        /// <param name="parameter">A string parameter</param>
        /// <param name="request">A ExampleRequestObject object parameter</param>
        /// <returns>JSON object</returns>
        Task<IRestResponse<ExampleResponseObject>> PostDataAsync(string parameter, ExampleRequestObject request);
    }
}
