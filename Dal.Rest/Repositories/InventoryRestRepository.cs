using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Dal.Rest.Repositories;
public class InventoryRestRepository : BaseRestRepository<Inventory>
{
    public InventoryRestRepository(RestClient restClient, ResourceApi resourceApi) : base(restClient, resourceApi)
    {
    }

    public override Task AddAsync(Inventory item) => SimpleGet(ResourceApi.InventoryAdd).AddParameter("name", item.Name)
                                                                                        .AddParameter("amount", item.Amount)
                                                                                        .AddParameter("price", 0)
                                                                                        .AddParameter("BranchOfficeId", item.BranchOfficeId)
                                                                                        .Request();
    public override async Task<IEnumerable<Inventory>> GetAllAsync() => await SimpleGet(ResourceApi.InventoryAll).Request<List<Inventory>>();
    public override Task<Inventory> SelectById(int id) => SimpleGet(ResourceApi.OfficeSelect).AddParameter("id", id)
                                                                                             .Request<Inventory>();
    public override Task DeleteAsync(Inventory item) => throw new NotImplementedException();
    public override Task UpdateAsync(Inventory item) => throw new NotImplementedException();
}
