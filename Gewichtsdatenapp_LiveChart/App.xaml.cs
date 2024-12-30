using Gewichtsdatenapp_LiveChart.Service;


namespace Gewichtsdatenapp_LiveChart
{ 
     public partial class App : Application
{

    public static JsonStorageService? StorageService { get; private set; }

    public App()
    {
        InitializeComponent();

        // JSON-Dateipfad definieren
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gewichtsdaten.json");
        StorageService = new JsonStorageService(filePath);

        MainPage = new AppShell();
    }
}
}