using System.Text.Json;
using Gewichtsdatenapp_LiveChart.Model;
using Gewichtsdatenapp_LiveChart.Services;


namespace Gewichtsdatenapp_LiveChart.Service
{
    public class Speicherplatz : ISpeicherplatz
    {
        private readonly string _filePath;

        public Speicherplatz(string filePath)
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
                var daten = JsonSerializer.Deserialize<List<Werte>>(json);
                return daten ?? new List<Werte>();
            }
            catch (Exception)
            {
                return new List<Werte>();
            }
        }

        public async Task<List<Werte>> LoadDataAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Werte>();

            try
            {
                using var stream = File.OpenRead(_filePath);
                var daten = await JsonSerializer.DeserializeAsync<List<Werte>>(stream);
                return daten ?? new List<Werte>();
            }
            catch (Exception)
            {
                return new List<Werte>();
            }
        }

        public void SaveData(List<Werte> daten)
        {
            try
            {
                string json = JsonSerializer.Serialize(daten, new JsonSerializerOptions
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

        public async Task SaveDataAsync(List<Werte> daten)
        {
            try
            {
                using var stream = File.Create(_filePath);
                await JsonSerializer.SerializeAsync(stream, daten, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Daten: {ex.Message}");
            }
        }
    }
}