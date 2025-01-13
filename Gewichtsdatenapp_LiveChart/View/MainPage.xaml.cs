using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
}

