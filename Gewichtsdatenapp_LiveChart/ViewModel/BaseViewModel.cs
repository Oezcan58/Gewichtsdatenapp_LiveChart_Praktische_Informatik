using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gewichtsdatenapp_LiveChart.Model;

namespace Gewichtsdatenapp_LiveChart.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private double weight;

        [ObservableProperty]
        private double height;

        [ObservableProperty]
        private int age;

        [ObservableProperty]
        private string gender = string.Empty;

        // Private Feld für die Collection
        private ObservableCollection<Werte> _gewichtsdaten;

        // Öffentliche Property
        public ObservableCollection<Werte> Gewichtsdaten
        {
            get => _gewichtsdaten;
            set => SetProperty(ref _gewichtsdaten, value);
        }

        public BaseViewModel()
        {
            _gewichtsdaten = new ObservableCollection<Werte>(App.StorageService.LoadData());
            Age = 0;
            Gender = string.Empty;
        }

        [RelayCommand]
        public void AddWerte()
        {
            if (Weight > 0 && Height > 0 && Age > 0 && !string.IsNullOrEmpty(Gender))
            {
                var newWerte = new Werte
                {
                    Weight = Weight,
                    Height = Height,
                    Age = Age,
                    Gender = Gender
                };

                Gewichtsdaten.Add(newWerte);
                SaveData();
                ReloadData(); // Daten neu laden

                // Felder zurücksetzen
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

        [RelayCommand]
        public void ShowData()
        {
            ReloadData(); // Daten vor dem Anzeigen neu laden

            var dataString = new StringBuilder();
            foreach (var entry in Gewichtsdaten)
            {
                dataString.AppendLine($"Datum: {entry.Date:dd.MM.yyyy}, Gewicht: {entry.Weight} kg, Größe: {entry.Height} m, Alter: {entry.Age}, Geschlecht: {entry.Gender}, BMI: {entry.BMI}, Gewichtsklasse: {entry.Gewichtsklasse}");
            }

            App.Current.MainPage.DisplayAlert("Gespeicherte Daten", dataString.ToString(), "OK");
        }

        [RelayCommand]
        public void DeleteWerte(Werte werte)
        {
            if (werte != null)
            {
                Gewichtsdaten.Remove(werte);
                SaveData();
                ReloadData(); // Daten nach dem Löschen neu laden
                App.Current.MainPage.DisplayAlert("Erfolg", "Eintrag wurde gelöscht", "OK");
            }
        }

        public void SaveData()
        {
            App.StorageService.SaveData(Gewichtsdaten.ToList());
        }

        public void ReloadData()
        {
            var updatedData = App.StorageService.LoadData();
            Gewichtsdaten.Clear(); // Bestehende Daten löschen
            foreach (var item in updatedData)
            {
                Gewichtsdaten.Add(item);
            }
        }
    }
}