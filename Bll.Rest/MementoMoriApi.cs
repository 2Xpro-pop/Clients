using Dal.Rest;
using RestSharp;

namespace Bll.Rest;
public class MementoMoriApi: ResourceApi
{
    public RestClient RestClient { get; set; }

    public string Login { get; set; }
    public string CreateUser { get; set; }
    public string GetAccessToken { get; set; }
    public string ChangeBudget { get; set; }
    public string InventoryDecrease { get; set; }
}
