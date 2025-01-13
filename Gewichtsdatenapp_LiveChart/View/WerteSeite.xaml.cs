using System.Collections.ObjectModel;
using Gewichtsdatenapp_LiveChart.Model;
using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View;

public partial class WerteSeite : ContentPage
{
    public WerteSeite()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
       if (BindingContext is BaseViewModel viewModel) // Daten neu laden
        {
            await viewModel.ReloadDataAsync();
        }
    }
}