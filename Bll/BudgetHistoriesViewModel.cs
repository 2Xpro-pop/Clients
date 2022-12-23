using System.Collections.ObjectModel;
using Bll.Rest;
using Dal.Models;
using Dal;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Bll.Dao;

namespace Bll;
public class BudgetHistoriesViewModel: ReactiveObject
{
    [Reactive]
    public ObservableCollection<BudgetHistoryDao> BudgetHistories
    {
        get; set;
    }
    private readonly IUnitOfWork _unitOfWork;

    public BudgetHistoriesViewModel(MementoMori mementoMori)
    {
        _unitOfWork = mementoMori.UnitOfWork;

        Task.Run(async () => await LoadHistory());
    }

    private async Task LoadHistory()
    {
        var offices = await _unitOfWork.Offices.GetAllAsync();
        BudgetHistories = null;
        BudgetHistories = new((await _unitOfWork.BudgetHistories.GetAllAsync()).Select(b => new BudgetHistoryDao()
        {
            Fillial = offices.First(o => o.Id == b.BranchOfficeId).Name,
            Description = b.Description,
            Currency = b.Action
        }));
    }
}
