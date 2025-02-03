using Gewichtsdatenapp_LiveChart.Service;
using Gewichtsdatenapp_LiveChart.Services;
namespace Gewichtsdatenapp_LiveChart
{
    public partial class App : Application
    {
        private static ISpeicherplatz _speicherplatz;//Singleton für den Speicherplatz-Service
        public static ISpeicherplatz Speicherplatz => _speicherplatz ??= CreateSpeicherplatz();//Initialisiert den Speicherplatz-Service, falls nicht vorhanden

        public App()
        {
            InitializeComponent();


            MainPage = new AppShell();//

        }

        private static ISpeicherplatz CreateSpeicherplatz()//Erstellt den Speicherplatz-Service mit einem Dateipfad
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Gewichtsdaten.json");
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

