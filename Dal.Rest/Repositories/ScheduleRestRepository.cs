using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Dal.Rest.Repositories;
public class ScheduleRestRepository : BaseRestRepository<Schedule>
{
    public ScheduleRestRepository(RestClient restClient, ResourceApi resourceApi) : base(restClient, resourceApi)
    {
    }

    public override Task AddAsync(Schedule item) => SimpleGet(ResourceApi.ScheduleAdd).AddParameter("patientId", item.PatientId)
                                                                                      .AddParameter("postId", item.PostId)
                                                                                      .AddParameter("date", item.Date.ToString())
                                                                                      .AddParameter("price", item.Price)
                                                                                      .Request();
    public override Task DeleteAsync(Schedule item) => SimpleGet(ResourceApi.ScheduleDelete).AddParameter("id", item.Id)
                                                                                            .Request();
    public async override Task<IEnumerable<Schedule>> GetAllAsync() => await SimpleGet(ResourceApi.ScheduleAll).Request<List<Schedule>>();
    public override Task<Schedule> SelectById(int id) => SimpleGet(ResourceApi.ScheduleSelect).AddParameter("id", id)
                                                                                              .Request<Schedule>();
    public override Task UpdateAsync(Schedule item) => SimpleGet(ResourceApi.ScheduleUpdate).AddParameter("id", item.Id)
                                                                                            .AddParameter("patientId", item.PatientId)
                                                                                            .AddParameter("postId", item.PostId)
                                                                                            .AddParameter("date", item.Date.ToString("yyyy-MM-dd"))
                                                                                            .AddParameter("price", item.Price)
                                                                                            .Request();
}
