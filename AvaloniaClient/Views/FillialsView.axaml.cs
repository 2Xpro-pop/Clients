using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;
using Dal.Models;
using ReactiveUI;
using System;

namespace AvaloniaClient.Views
{
	public partial class FillialsView : ReactiveUserControl<FillialsViewModel>
	{
		public FillialsView ()
		{
			InitializeComponent();

            fillialsDataGrid.RowEditEnded += OffieceEdited;
		}

        private async void OffieceEdited(object? sender, DataGridRowEditEndedEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                fillialsDataGrid.IsReadOnly = true;
                try
                {

                    var office = (Office)e.Row.DataContext!;
                    await ViewModel!.UpdateOffice(office);
                }
                finally
                {
                    fillialsDataGrid.IsReadOnly = false;
                }
                
            }
        }
    }
}