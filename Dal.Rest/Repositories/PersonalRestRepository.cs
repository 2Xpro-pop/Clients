using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Dal.Rest.Repositories;
public class PersonalRestRepository : BaseRestRepository<Personal>
{
    public PersonalRestRepository(RestClient restClient, ResourceApi resourceApi) : base(restClient, resourceApi)
    {
    }

    public override Task AddAsync(Personal item) => SimpleGet(ResourceApi.PersonalAdd).AddParameter("name", item.Name)
                                                                                      .AddParameter("surname", item.Surname)
                                                                                      .AddParameter("phoneNumber", item.PhoneNumber)
                                                                                      .AddParameter("address", item.Address)
                                                                                      .AddParameter("email", item.Email)
                                                                                      .AddParameter("officeId", item.BranchOfficeId)
                                                                                      .AddParameter("post", item.Post)
                                                                                      .AddParameter("salaryType", item.SalaryType)
                                                                                      .AddParameter("salaryPercent", item.SalaryPercent)
                                                                                      .AddParameter("salaryAmount", item.SalaryAmount)
                                                                                      .Request();
    public override Task DeleteAsync(Personal item) => SimpleGet(ResourceApi.PersonalDelete).AddParameter("id", item.Id)
                                                                                            .Request();
    public async override Task<IEnumerable<Personal>> GetAllAsync() => await SimpleGet(ResourceApi.PersonalAll).Request<List<Personal>>();
    public override Task<Personal> SelectById(int id) => SimpleGet(ResourceApi.PersonalSelect).AddParameter("id", id)
                                                                                              .Request<Personal>();
    public override Task UpdateAsync(Personal item) => SimpleGet(ResourceApi.PersonalUpdate).AddParameter("id", item.Id)
                                                                                            .AddParameter("name", item.Name)
                                                                                            .AddParameter("surname", item.Surname)
                                                                                            .AddParameter("phoneNumber", item.PhoneNumber)
                                                                                            .AddParameter("address", item.Address)
                                                                                            .AddParameter("email", item.Email)
                                                                                            .AddParameter("officeId", item.BranchOfficeId)
                                                                                            .AddParameter("post", item.Post)
                                                                                            .AddParameter("salaryType", item.SalaryType)
                                                                                            .AddParameter("salaryPercent", item.SalaryPercent)
                                                                                            .AddParameter("salaryAmount", item.SalaryAmount)
                                                                                            .Request();
}
