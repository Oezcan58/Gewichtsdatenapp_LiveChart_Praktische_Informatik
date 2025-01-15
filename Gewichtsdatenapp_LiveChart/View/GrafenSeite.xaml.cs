using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View
{
    public partial class GrafenSeite : ContentPage
    {
        public GrafenSeite(GraphViewModel graphViewModel)
        {
            BindingContext = graphViewModel;
            InitializeComponent();
        }
    }
}
}
