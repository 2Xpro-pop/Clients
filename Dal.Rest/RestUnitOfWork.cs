using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;
using Dal.Rest.Repositories;
using RestSharp;

namespace Dal.Rest;
public class RestUnitOfWork : IUnitOfWork
{
    public RestUnitOfWork(RestClient restClient, Action<ResourceApi> resourceApiOptions)
    {
        var resourceApi = new ResourceApi();
        resourceApiOptions(resourceApi);

        Offices = new OfficesRestRepository(restClient, resourceApi);
        BudgetHistories = new BudgetHistoriesRestRepository(restClient, resourceApi);
        Invenotries = new InventoryRestRepository(restClient, resourceApi);
        Patients = new PatientsRestRepository(restClient, resourceApi);
        Personals = new PersonalRestRepository(restClient, resourceApi);
        Schedules = new ScheduleRestRepository(restClient, resourceApi);
    }

    public RestUnitOfWork(RestClient restClient, ResourceApi resourceApi)
    {
        Offices = new OfficesRestRepository(restClient, resourceApi);
        BudgetHistories = new BudgetHistoriesRestRepository(restClient, resourceApi);
        Invenotries = new InventoryRestRepository(restClient, resourceApi);
        Patients = new PatientsRestRepository(restClient, resourceApi);
        Personals = new PersonalRestRepository(restClient, resourceApi);
        Schedules = new ScheduleRestRepository(restClient, resourceApi);
    }

    public IRepository<Office> Offices { get; }

    public IRepository<BudgetHistory> BudgetHistories { get; }

    public IRepository<Inventory> Invenotries { get; }

    public IRepository<Patient> Patients { get; }

    public IRepository<Personal> Personals { get; }

    public IRepository<Schedule> Schedules { get; }
}
