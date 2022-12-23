using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;
using Dal.Models;
using ReactiveUI;
using System;

namespace AvaloniaClient.Views;

public partial class InventoriesView : ReactiveUserControl<InventoriesViewModel>
{
	public InventoriesView()
	{
		InitializeComponent();

        dataGrid.RowEditEnded += InventoryEdited;
    }

    private async void InventoryEdited(object? sender, DataGridRowEditEndedEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            dataGrid.IsReadOnly = true;
            try
            {

                var office = (Inventory)e.Row.DataContext!;
                /*await ViewModel!.UpdateInventory(office);*/
            }
            finally
            {
                dataGrid.IsReadOnly = false;
            }

        }
    }
}