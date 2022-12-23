using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;
using Dal.Models;
using ReactiveUI;
using System;

namespace AvaloniaClient.Views;

public partial class PersonalsView : ReactiveUserControl<RoutedPersonalsViewModel>
{
	public PersonalsView ()
	{
		InitializeComponent ();
        dataGrid.RowEditEnded += OffieceEdited;
    }

    private async void OffieceEdited(object? sender, DataGridRowEditEndedEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            dataGrid.IsReadOnly = true;
            try
            {

                var personal = (Personal)e.Row.DataContext!;
                await ViewModel!.UpdatePersonal(personal);
            }
            finally
            {
                dataGrid.IsReadOnly = false;
            }

        }
    }
}