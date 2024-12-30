using System.Text.Json;
using Gewichtsdatenapp_LiveChart.Model;


namespace Gewichtsdatenapp_LiveChart.Service
{
    public class JsonStorageService
    {
        private readonly string _filePath;

        public JsonStorageService(string filePath)
        {
            _filePath = filePath;
        }

        public List<Werte> LoadData()
        {
            if (!File.Exists(_filePath))
                return new List<Werte>();

            try
            {
                string json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<List<Werte>>(json);
                return data ?? new List<Werte>();
            }
            catch (Exception)
            {
                return new List<Werte>();
            }
        }

        public void SaveData(List<Werte> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Daten: {ex.Message}");
            }
        }
    }
}