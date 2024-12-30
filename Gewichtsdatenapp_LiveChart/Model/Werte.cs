using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gewichtsdatenapp_LiveChart.Model
{
    public class Werte : INotifyPropertyChanged
    {
        private double _weight;
        private double _height;
        private double _bmi;
        private string _gewichtsklasse;
        private int _age;           // Neue private Felder
        private string _gender;     // Neue private Felder

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Date { get; set; } = DateTime.Now;


        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                    BerechneBMI(); // Berechnet BMI automatisch
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                    BerechneBMI(); // Berechnet BMI automatisch
                }
            }
        }

        public double BMI
        {
            get => _bmi;
            private set
            {
                if (_bmi != value)
                {
                    _bmi = value;
                    OnPropertyChanged(nameof(BMI));
                }
            }
        }

        public string Gewichtsklasse
        {
            get => _gewichtsklasse;
            private set
            {
                if (_gewichtsklasse != value)
                {
                    _gewichtsklasse = value;
                    OnPropertyChanged(nameof(Gewichtsklasse));
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                    BerechneBMI();
                }
            }
        }

        private void BerechneBMI()
        {
            if (Height > 0)
            {
                BMI = Math.Round(Weight / (Height * Height), 2);
                Gewichtsklasse = BestimmeGewichtsklasse(BMI, Gender, Age);
            }
        }

        private string BestimmeGewichtsklasse(double bmi, string gender, int Age)
        {
            if (Age < 18)
            {
                return "BMI für Kinder nicht geeignet";
            }
            if (string.IsNullOrEmpty(gender))
            {
                return "Geschlecht nicht angegeben";
            }
            if (gender.ToLower() == "männlich")
            {
                if (Age >= 19 && Age <= 24)
                {
                    if (bmi < 20) return "Untergewicht";
                    if (bmi < 25) return "Normalgewicht";
                    if (bmi < 30) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 25 && Age <= 34)
                {
                    if (bmi < 21) return "Untergewicht";
                    if (bmi < 26) return "Normalgewicht";
                    if (bmi < 31) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 35 && Age <= 44)
                {
                    if (bmi < 22) return "Untergewicht";
                    if (bmi < 27) return "Normalgewicht";
                    if (bmi < 32) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 45 && Age <= 54)
                {
                    if (bmi < 23) return "Untergewicht";
                    if (bmi < 28) return "Normalgewicht";
                    if (bmi < 33) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 55 && Age <= 64)
                {
                    if (bmi < 24) return "Untergewicht";
                    if (bmi < 29) return "Normalgewicht";
                    if (bmi < 34) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 65)
                {
                    if (bmi < 25) return "Untergewicht";
                    if (bmi < 30) return "Normalgewicht";
                    if (bmi < 35) return "Übergewicht";
                    return "Adipositas";
                }
            }
            else if (gender.ToLower() == "weiblich")
            {
                // Altersgruppen für Frauen
                if (Age >= 19 && Age <= 24)
                {
                    if (bmi < 19) return "Untergewicht";
                    if (bmi < 24) return "Normalgewicht";
                    if (bmi < 29) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 25 && Age <= 34)
                {
                    if (bmi < 20) return "Untergewicht";
                    if (bmi < 25) return "Normalgewicht";
                    if (bmi < 30) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 35 && Age <= 44)
                {
                    if (bmi < 21) return "Untergewicht";
                    if (bmi < 26) return "Normalgewicht";
                    if (bmi < 31) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 45 && Age <= 54)
                {
                    if (bmi < 22) return "Untergewicht";
                    if (bmi < 27) return "Normalgewicht";
                    if (bmi < 32) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 55 && Age <= 64)
                {
                    if (bmi < 23) return "Untergewicht";
                    if (bmi < 28) return "Normalgewicht";
                    if (bmi < 33) return "Übergewicht";
                    return "Adipositas";
                }
                if (Age >= 65)
                {
                    if (bmi < 24) return "Untergewicht";
                    if (bmi < 29) return "Normalgewicht";
                    if (bmi < 34) return "Übergewicht";
                    return "Adipositas";
                }
            }

            return "nicht bestimmbar";
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
