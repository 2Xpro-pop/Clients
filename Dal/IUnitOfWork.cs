using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal;
public interface IUnitOfWork
{
    IRepository<Office> Offices { get; }
    IRepository<BudgetHistory> BudgetHistories { get; }
    IRepository<Inventory> Invenotries { get; }
    IRepository<Patient> Patients { get; }
    IRepository<Personal> Personals { get; }
    IRepository<Schedule> Schedules { get; }
}
