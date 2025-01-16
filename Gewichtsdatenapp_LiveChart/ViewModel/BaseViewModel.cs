using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gewichtsdatenapp_LiveChart.Model;
using Gewichtsdatenapp_LiveChart.Services;
using Gewichtsdatenapp_LiveChart.Enums;


namespace Gewichtsdatenapp_LiveChart.ViewModel
{
    public partial class BaseViewModel : ObservableObject // ViewModel für die MainPage und Werte-Seite
    {
        private readonly ISpeicherplatz _speicherplatz;

        [ObservableProperty]
        private double _weight;

        [ObservableProperty]
        private double _height;

        [ObservableProperty]
        private int _age;

        [ObservableProperty]
        private Gender? gender;

        public Array GenderValues => Enum.GetValues(typeof(Gender));

        [ObservableProperty]
        private ObservableCollection<Werte> _gewichtsdaten;

        public BaseViewModel()
        {
            _speicherplatz = App.Speicherplatz;
            InitGewichtsdatenFromFile();
        }

        [RelayCommand]
        public async Task SaveDataAsync()//Speichert die aktuellen Daten der Sammlung asynchron
        {
            await _speicherplatz.SaveDataAsync(Gewichtsdaten.ToList());
        }

        [RelayCommand]
        public async Task InitGewichtsdatenFromFile()//Lädt die gespeicherten Daten aus der Datei und initialisiert die Sammlung
        {


            var data = await _speicherplatz.LoadDataAsync();
            Gewichtsdaten = new ObservableCollection<Werte>(data);

        }


        [RelayCommand/*(CanExecute = nameof(CanAddWerte))*/]
        public async Task AddWerteAsync()//Fügt einen neuen Eintrag hinzu, wenn die Daten den Bedingungen entsprechen
        {

            if (Weight is > 0 and < 590 && Height is > 0 and < 2.80 && Age is > 18 and < 120 && Gender != null)
            {
                var neueWerte = Werte.CreateWerte(Weight, Height, Age, Gender.Value, DateTime.Now);

                Gewichtsdaten.Add(neueWerte);
                await SaveDataAsync();

                App.Current.MainPage.DisplayAlert("Gespeicherte Daten", "Gespeichert", "OK");
            }
            else
            {
                var data = new StringBuilder();
                foreach (Werte value in Gewichtsdaten)
                {
                    string genderString = String.Empty;

                    switch (value.Gender)
                    {
                        case Enums.Gender.Männlich:
                            genderString = "Männlich";
                            break;
                        case Enums.Gender.Weiblich:
                            genderString = "Weiblich";
                            break;
                    }

                    data.AppendLine($"Datum: {value.Date:dd.MM.yyyy}, Gewicht: {value.Weight} kg, Größe: {value.Height} m, Alter: {value.Age}, Geschlecht: {genderString}, BMI: {value.Bmi}, Gewichtsklasse: {value.Gewichtsklasse}");
                }


                App.Current.MainPage.DisplayAlert("Gespeicherte Daten", data.ToString(), "OK");
            }
        }


        [RelayCommand]
        public void ShowData()//Zeigt alle gespeicherten Daten in einer Nachricht an
        {


            var Ausgabe = new StringBuilder();
            foreach (var Eingabe in Gewichtsdaten)
            {
                Ausgabe.AppendLine($"Datum: {Eingabe.Date:dd.MM.yyyy}, Gewicht: {Eingabe.Weight} kg, Größe: {Eingabe.Height} m, Alter: {Eingabe.Age}, Geschlecht: {Eingabe.Gender}, BMI: {Eingabe.Bmi}, Gewichtsklasse: {Eingabe.Gewichtsklasse}");
            }

            App.Current.MainPage.DisplayAlert("Gespeicherte Daten", Ausgabe.ToString(), "OK");
        }

        [RelayCommand]
        public async Task DeleteWerteAsync(Werte werte)//Löscht einen Eintrag nach Bestätigung des Benutzers
        {
            if (werte == null) return;

            bool answer = await App.Current.MainPage.DisplayAlert(
                "Löschen bestätigen",
                "Möchten Sie diesen Eintrag wirklich löschen?",
                "Ja",
                "Nein");

            if (answer)
            {
                try
                {
                    Gewichtsdaten.Remove(werte);
                    await SaveDataAsync();
                    await App.Current.MainPage.DisplayAlert("Erfolg", "Eintrag wurde gelöscht", "OK");
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Fehler", "Löschen fehlgeschlagen", "OK");
                    System.Diagnostics.Debug.WriteLine($"Delete error: {ex.Message}");
                }
            }
        }

    }
}
