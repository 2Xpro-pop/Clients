using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Bll.Rest;
using Dal.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Bll;
public class MainSchedule: ReactiveObject
{
    [Reactive]
    public ObservableCollection<Schedule> Today
    {
        get;
        set;
    }

    [Reactive]
    public ObservableCollection<Schedule> All
    {
        get;
        set;
    }

    public ReactiveCommand<int, Unit> DoneTask
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> AddTask
    {
        get;
    }

    public MainSchedule(MementoMori mementoMori, Func<Task<Schedule>> inputSchedule)
    {
        Setup(mementoMori);

        DoneTask = ReactiveCommand.CreateFromTask(async (int id) =>
        {
            var schedules = mementoMori.UnitOfWork.Schedules;

            var schedule = await schedules.SelectById(id);
            await schedules.DeleteAsync(schedule);

            var personal = await mementoMori.UnitOfWork.Personals.SelectById(schedule.PostId);
            var officeId = personal.BranchOfficeId;

            if (personal.SalaryType == 1)
            {
                var salary = (personal.SalaryPercent / 100d) * schedule.Price;
                await mementoMori.OfficeController.ChangeBudget(officeId, -salary, $"{personal.Name} {personal.Surname} salary");
            }

            await mementoMori.OfficeController.ChangeBudget(officeId, schedule.Price, $"Profit from task done!");
        });

        AddTask = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await inputSchedule();

            if (result == null)
            {
                return;
            }

            await mementoMori.UnitOfWork.Schedules.AddAsync(result);
        });
    }

    private async void Setup(MementoMori mementoMori)
    {
        var all = await mementoMori.UnitOfWork.Schedules.GetAllAsync();

        All = new(all);
        Today = new(all.Where(s => (DateTime.Now - s.Date).Days == 0));
    }
}
