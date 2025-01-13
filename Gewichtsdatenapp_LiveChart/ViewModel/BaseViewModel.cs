using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gewichtsdatenapp_LiveChart.Model;
using Gewichtsdatenapp_LiveChart.Services;


namespace Gewichtsdatenapp_LiveChart.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        private readonly ISpeicherplatz _speicherplatz;

        [ObservableProperty]
        private double _weight;

        [ObservableProperty]
        private double _height;

        [ObservableProperty]
        private int _age;

        [ObservableProperty]
        private string _gender = string.Empty;
        [ObservableProperty]
        private DateTime _Date = DateTime.Now;
        /*[ObservableProperty]
        private bool _isRefreshing;*/
        [ObservableProperty]
        private ObservableCollection<Werte> _gewichtsdaten;

        public BaseViewModel()
        {
            _speicherplatz = App.Speicherplatz;
            _gewichtsdaten = new ObservableCollection<Werte>(_speicherplatz.LoadData());
        }

        [RelayCommand]
        public async Task SaveDataAsync()
        {
            await _speicherplatz.SaveDataAsync(Gewichtsdaten.ToList());
        }

        [RelayCommand]
        public async Task ReloadDataAsync()
        {
            try
            {
                /*IsRefreshing = true;*/
                var data = await _speicherplatz.LoadDataAsync();
                Gewichtsdaten.Clear();
                foreach (var item in data)
                {
                    Gewichtsdaten.Add(item);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Fehler", "Laden fehlgeschlagen", "OK");
                System.Diagnostics.Debug.WriteLine($"Reload error: {ex.Message}");
            }
           /* finally
            {
                IsRefreshing = false;
            }*/
        }


        [RelayCommand/*(CanExecute = nameof(CanAddWerte))*/]
        public async Task AddWerteAsync()
        {
           
            if (Weight > 0 &&Weight<590 && Height > 0 && Height<2.80 && Age > 18 && Age<120 && !string.IsNullOrEmpty(Gender))
            {
                var neueWerte = new Werte
                {
                    Weight = Weight,
                    Height = Height,
                    Age = Age,
                    Gender = Gender
                };

                Gewichtsdaten.Add(neueWerte);
                await SaveDataAsync();
                /*ReloadData();*/
                /*var grafenViewModel = new GrafenViewModel();
                grafenViewModel.LoadChartData();*/

                Weight = 0;
                Height = 0;
                Age = 0;
                Gender = string.Empty;

                

                App.Current.MainPage.DisplayAlert("Gespeicherte Daten", "Gespeichert", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Fehler", "Daten konnten nicht gespeichert werden", "OK");
            }
        }
       /* private bool CanAddWerte()
        {
            return Weight > 0 && Height > 0 && Age > 18 && !string.IsNullOrEmpty(Gender);
        }*/
        [RelayCommand]
        public void ShowData()
        {
            /*ReloadData();*/

            var Ausgabe = new StringBuilder();
            foreach (var Eingabe in Gewichtsdaten)
            {
                Ausgabe.AppendLine($"Datum: {Eingabe.Date:dd.MM.yyyy}, Gewicht: {Eingabe.Weight} kg, Größe: {Eingabe.Height} m, Alter: {Eingabe.Age}, Geschlecht: {Eingabe.Gender}, BMI: {Eingabe.Bmi}, Gewichtsklasse: {Eingabe.Gewichtsklasse}");
            }

            App.Current.MainPage.DisplayAlert("Gespeicherte Daten", Ausgabe.ToString(), "OK");
        }

        [RelayCommand]
        public async Task DeleteWerteAsync(Werte werte)
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
        /* [RelayCommand]
         public void SaveData()
         {
             App.Speicherplatz.SaveData(Gewichtsdaten.ToList());
         }
         [RelayCommand]
         public void ReloadData()
         {
             var updatedData = App.Speicherplatz.LoadData();
             Gewichtsdaten.Clear(); 
             foreach (var Element in updatedData)
             {
                 Gewichtsdaten.Add(Element);
             }
         }*/
    }
    }