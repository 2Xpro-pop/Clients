using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Dal.Rest.Repositories;
public abstract class BaseRestRepository<T> : IRepository<T> where T: IIdPickable
{
    public BaseRestRepository(RestClient restClient, ResourceApi resourceApi)
    {
        RestClient = restClient;
        ResourceApi = resourceApi;
    }

    protected RestClient RestClient { get; set; }
    protected ResourceApi ResourceApi { get; set; }

    protected RestGetter SimpleGet(string api) => new(RestClient, api);

    protected class RestGetter
    {
        private readonly RestClient _client;
        private readonly RestRequest _restRequest;

        public RestGetter(RestClient client, string api)
        {
            _client = client;
            _restRequest = new RestRequest(api);
        }

        public RestGetter AddParameter(string name, string value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }

        public RestGetter AddParameter(string name, double value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }

        public RestGetter AddParameter(string name, int value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }

        public Task Request() => _client.GetAsync(_restRequest);

        public Task<U> Request<U>() => _client.GetAsync<U>(_restRequest);
    }

    public abstract Task AddAsync(T item);
    public abstract Task DeleteAsync(T item);
    public abstract Task<IEnumerable<T>> GetAllAsync();
    public abstract Task<T> SelectById(int id);
    public abstract Task UpdateAsync(T item);
}
