using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using RestSharp;

namespace Dal.Rest.Repositories;
public class PatientsRestRepository : BaseRestRepository<Patient>
{
    public PatientsRestRepository(RestClient restClient, ResourceApi resourceApi) : base(restClient, resourceApi)
    {
    }

    public override Task AddAsync(Patient item) => SimpleGet(ResourceApi.PatientAdd).AddParameter("name", item.Name)
                                                                                    .AddParameter("surname", item.Surname)
                                                                                    .AddParameter("phoneNumber", item.PhoneNumber)
                                                                                    .AddParameter("address", item.Address)
                                                                                    .AddParameter("email", item.Email)
                                                                                    .Request();
    public override Task DeleteAsync(Patient item) => SimpleGet(ResourceApi.PatientDelete).AddParameter("id", item.Id)
                                                                                          .Request();
    public async override Task<IEnumerable<Patient>> GetAllAsync() => await SimpleGet(ResourceApi.PatientAll).Request<List<Patient>>();
    public override Task<Patient> SelectById(int id) => SimpleGet(ResourceApi.PatientSelect).AddParameter("id", id)
                                                                                            .Request<Patient>();
    public override Task UpdateAsync(Patient item) => SimpleGet(ResourceApi.PatientUpdate).AddParameter("id", item.Id)
                                                                                          .AddParameter("name", item.Name)
                                                                                          .AddParameter("surname", item.Surname)
                                                                                          .AddParameter("phoneNumber", item.PhoneNumber)
                                                                                          .AddParameter("address", item.Address)
                                                                                          .AddParameter("email", item.Email)
                                                                                          .Request();
}
