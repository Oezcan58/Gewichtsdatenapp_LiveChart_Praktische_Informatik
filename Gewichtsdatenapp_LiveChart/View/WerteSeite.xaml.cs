using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View;

public partial class WerteSeite : ContentPage
{
    public WerteSeite(BaseViewModel baseViewModel)//Initialisiert die WerteSeite
    {
        BindingContext = baseViewModel;
        InitializeComponent();
    }


}
