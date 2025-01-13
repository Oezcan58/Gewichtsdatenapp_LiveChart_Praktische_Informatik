using Gewichtsdatenapp_LiveChart.Service;
using Gewichtsdatenapp_LiveChart.Services;
using LiveChartsCore; 
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Maui;
namespace Gewichtsdatenapp_LiveChart
{
    public partial class App : Application
    {
        private static ISpeicherplatz _speicherplatz;
        public static ISpeicherplatz Speicherplatz => _speicherplatz ??= CreateSpeicherplatz();

        public App()
        {
            InitializeComponent();


            MainPage = new AppShell();

            /*
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"Unhandled Exception: {e.ExceptionObject}");
            };*/
        }

        private static ISpeicherplatz CreateSpeicherplatz()
        {
            try
            {
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Gewichtsdaten.json");

                return new Speicherplatz(filePath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in CreateSpeicherplatz: {ex.Message}");
                throw;
            }
        }
    }
}