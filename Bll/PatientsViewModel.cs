using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll.Dao;
using Bll.Rest;
using Dal;
using Dal.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Bll;
public class PatientsViewModel: ReactiveObject
{
    [Reactive]
    public ObservableCollection<Patient> Patients
    {
        get; set;
    }
    private readonly IUnitOfWork _unitOfWork;

    public PatientsViewModel(MementoMori mementoMori)
    {
        _unitOfWork = mementoMori.UnitOfWork;

        Task.Run(async () => await LoadHistory());
    }

    private async Task LoadHistory()
    {
        var patients = await _unitOfWork.Patients.GetAllAsync();
        Patients = null;
        Patients = new(patients);
    }
}
