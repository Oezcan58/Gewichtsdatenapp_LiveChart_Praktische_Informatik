using System.Collections.ObjectModel;
using Gewichtsdatenapp_LiveChart.Model;
using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View;

public partial class WerteSeite : ContentPage
{
    private ObservableCollection<Werte> _werteListe;

    public WerteSeite()
    {
        InitializeComponent();
        BindingContext = new BaseViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as BaseViewModel)?.ReloadData(); // Daten neu laden
    }
}