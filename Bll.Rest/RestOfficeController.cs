using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Bll.Rest;
public class RestOfficeController : IOfficeController
{
    private readonly MementoMoriApi _api;
    public RestOfficeController(MementoMoriApi api)
    {
        _api = api;
    }
    public Task ChangeBudget(int id, double budget, string description)
    {
        var rest = new RestRequest(_api.ChangeBudget).AddParameter("id", id)
                                                     .AddParameter("budget", budget)
                                                     .AddParameter("description", description);

        return _api.RestClient.GetAsync(rest);
    }
}
