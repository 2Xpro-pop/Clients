using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Dal.Rest.Repositories;
public class BudgetHistoriesRestRepository: BaseRestRepository<BudgetHistory>
{
    public BudgetHistoriesRestRepository(RestClient restClient, ResourceApi resourceApi) : base(restClient, resourceApi)
    {
    }

    public override Task AddAsync(BudgetHistory item) => SimpleGet(ResourceApi.BudgetHistoryAdd).AddParameter("moneyAmount", item.Action)
                                                                                                .AddParameter("description", item.Description)
                                                                                                .AddParameter("BranchOfficeId", item.BranchOfficeId)
                                                                                                .Request();
    public override Task DeleteAsync(BudgetHistory item) => SimpleGet(ResourceApi.BudgetHistoryDelete).AddParameter("id", item.Id)
                                                                                                      .Request();
    public async override Task<IEnumerable<BudgetHistory>> GetAllAsync() => await SimpleGet(ResourceApi.BudgetHistoryAll).Request<List<BudgetHistory>>();
    public override Task<BudgetHistory> SelectById(int id) => SimpleGet(ResourceApi.BudgetHistorySelect).AddParameter("id", id)
                                                                                                        .Request<BudgetHistory>();
    public override Task UpdateAsync(BudgetHistory item) => throw new NotSupportedException();
}
