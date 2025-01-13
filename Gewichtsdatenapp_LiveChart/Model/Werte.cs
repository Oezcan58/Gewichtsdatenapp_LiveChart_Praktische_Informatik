
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Gewichtsdatenapp_LiveChart.Model
{
    public partial class Werte : ObservableObject
    {
        [ObservableProperty]
        private double _weight;
        [ObservableProperty]
        private double _height;
        [ObservableProperty]
        private double _bmi;
        [ObservableProperty]
        private string _gewichtsklasse;
        [ObservableProperty]
        private int _age;
        [ObservableProperty]
        private string _gender;

        [ObservableProperty]
        private DateTime _Date = DateTime.Now;


        partial void OnWeightChanged(double value) => BerechneBMI();

        partial void OnHeightChanged(double value) => BerechneBMI();

        partial void OnGenderChanged(string value) => BerechneBMI();

        

        private void BerechneBMI()
        {
            if (Height > 0)
            {
                Bmi = Math.Round(Weight / (Height * Height), 2);
                Gewichtsklasse = BestimmeGewichtsklasse(Bmi, Gender, Age);
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


      
    }
}
