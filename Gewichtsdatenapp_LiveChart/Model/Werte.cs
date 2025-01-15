using Gewichtsdatenapp_LiveChart.Enums;


namespace Gewichtsdatenapp_LiveChart.Model
{
    public class Werte // Model-Klasse für Gewichtsdaten und zugehörige Berechnungen
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Bmi { get; set; }
        public WeightClass Gewichtsklasse { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public DateTime Date { get; set; }

        public static Werte? CreateWerte(double weight, double height, int age, Gender gender, DateTime creationTime)
        {
            if (height == 0)
            {
                return null;
            }
            if (weight == 0)
            {
                return null;
            }
            var bmi = BerechneBmi(weight, height);
            var weightClass = BestimmeGewichtsklasse(bmi, gender, age);
            Werte newWerte = new Werte()
            {
                Weight = weight,
                Height = height,
                Age = age,
                Gender = gender,
                Date = creationTime,
                Bmi = bmi,
                Gewichtsklasse = weightClass
            };
            return newWerte;
        }


        private static double BerechneBmi(double weight, double height)
        {
            return Math.Round(weight / (height * height), 2);
        }

        private static WeightClass BestimmeGewichtsklasse(double bmi, Gender gender, int age)//Bestimmt die Gewichtsklasse basierend auf dem BMI, Alter und Geschlecht
        {
            if (age < 18)
            {
                return WeightClass.NichtGeeignet;
            }
            var bmiRanges = new (double Untergewicht, double Normalgewicht, double Übergewicht)[]
            {
                (20, 25, 30), // Männlich Alter 19-24
                (21, 26, 31), // Männlich Alter 25-34
                (22, 27, 32), // Männlich Alter 35-44
                (23, 28, 33), // Männlich Alter 45-54
                (24, 29, 34), // Männlich Alter 55-64
                (25, 30, 35), // Männlich Alter 65+
                (19, 24, 29), // Weiblich Alter 19-24
                (20, 25, 30), // Weiblich Alter 25-34
                (21, 26, 31), // Weiblich Alter 35-44
                (22, 27, 32), // Weiblich Alter 45-54
                (23, 28, 33), // Weiblich Alter 55-64
                (24, 29, 34)  // Weiblich Alter 65+
            };
            int index = gender == Gender.Männlich ? 0 : 6;
            if (age >= 19 && age <= 24) index += 0;
            else if (age >= 25 && age <= 34) index += 1;
            else if (age >= 35 && age <= 44) index += 2;
            else if (age >= 45 && age <= 54) index += 3;
            else if (age >= 55 && age <= 64) index += 4;
            else if (age >= 65) index += 5;

            var (untergewicht, normalgewicht, übergewicht) = bmiRanges[index];


            if (bmi < untergewicht) return WeightClass.Untergewicht;
            if (bmi < normalgewicht) return WeightClass.Normalgewicht;
            if (bmi < übergewicht) return WeightClass.Übergewicht;
            return WeightClass.Adipositas;
        }
    }
}


}
