using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Bll.Rest;
internal class RestInventoryController : IInventoryController
{
    private readonly MementoMoriApi _api;

    public RestInventoryController(MementoMoriApi api)
    {
        _api = api;
    }

    public Task DecreaseAsync(Inventory inventory, int amount)
    {
        var rest = new RestRequest(_api.InventoryDecrease).AddParameter("id", inventory.Id)
                                                          .AddParameter("amount",amount);

        return _api.RestClient.GetAsync(rest);
    }
}
