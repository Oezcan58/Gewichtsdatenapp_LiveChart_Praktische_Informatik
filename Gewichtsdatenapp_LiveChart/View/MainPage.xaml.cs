using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(BaseViewModel baseViewModel)
        {
            BindingContext = baseViewModel;
            InitializeComponent();
        }

    }
}


