using Gewichtsdatenapp_LiveChart.Model;

namespace Gewichtsdatenapp_LiveChart.Services
{
    public interface ISpeicherplatz //Interface für Speicherplatz (Speicherung der Daten) 
    {
        List<Werte> LoadData();
        Task<List<Werte>> LoadDataAsync();
        void SaveData(List<Werte> daten);
        Task SaveDataAsync(List<Werte> daten);
    }
}
