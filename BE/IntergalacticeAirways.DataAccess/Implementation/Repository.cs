using IntergalacticAirways.DTO;
using IntergalacticeAirways.DataAccess.Contract;
using IntergalacticeAirways.DataAccess.Model;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticeAirways.DataAccess.Implementation
{
    public class Repository : IRepository
    {
        private readonly IRestClient _restClient;
        public Repository(IRestClient restClient) {
            _restClient = restClient;
        }
        public async Task<ResultOrError<T>> Retrieve<T>(string url) where T : class
        {
            var dataResp = new ResultOrError<T>();
           
            try {
                var cancellationTokenSource = new System.Threading.CancellationTokenSource();
                _restClient.BaseUrl = new Uri(url);

                //coould probably set this up on the startup pipeline
                _restClient.UseNewtonsoftJson();

                var request = new RestRequest(Method.GET);
                var response = await _restClient.ExecuteAsync(request, cancellationTokenSource.Token);
                var responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
                dataResp.Data = responseModel;
                dataResp.IsError = false;
            } catch (Exception ex) {
                dataResp.IsError = true;
                dataResp.Error = ex;
            }

            return dataResp;
        }
    }
}
