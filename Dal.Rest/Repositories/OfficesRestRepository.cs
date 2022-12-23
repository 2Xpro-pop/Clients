using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Dal.Rest.Repositories;
public class OfficesRestRepository : BaseRestRepository<Office>
{
    public OfficesRestRepository(RestClient restClient, ResourceApi resourceApi) : base(restClient, resourceApi)
    {
    }

    public override Task AddAsync(Office item) => SimpleGet(ResourceApi.OfficeAdd).AddParameter("name", item.Name)
                                                                                  .AddParameter("address", item.Address)
                                                                                  .AddParameter("budget", item.Budget)
                                                                                  .Request();

    public override Task DeleteAsync(Office item) => SimpleGet(ResourceApi.OfficeDelete).AddParameter("id", item.Id)
                                                                                        .Request();
    public async override Task<IEnumerable<Office>> GetAllAsync() => await SimpleGet(ResourceApi.OfficeAll)
                                                                                        .Request<List<Office>>();
    public override Task<Office> SelectById(int id) => SimpleGet(ResourceApi.OfficeSelect).AddParameter("id", id)
                                                                                          .Request<Office>();
    public override Task UpdateAsync(Office item) => SimpleGet(ResourceApi.OfficeUpdate).AddParameter("id", item.Id)
                                                                                        .AddParameter("name", item.Name)
                                                                                        .AddParameter("address", item.Address)
                                                                                        .AddParameter("budget", item.Budget)
                                                                                        .Request();
}
