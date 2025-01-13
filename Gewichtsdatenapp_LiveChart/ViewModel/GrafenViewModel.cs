/*using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Gewichtsdatenapp_LiveChart.Model;

namespace Gewichtsdatenapp_LiveChart.ViewModel
{
    public partial class GrafenViewModel : ObservableObject
    {
        [ObservableProperty]
        private ISeries[] _weightSeries;

        [ObservableProperty]
        private ISeries[] _bmiSeries;

        [ObservableProperty]
        private Axis[] _xAxes;

        [ObservableProperty]
        private Axis[] _yAxesWeight;  // Separate Y-Achse für Gewicht

        [ObservableProperty]
        private Axis[] _yAxesBmi;     // Separate Y-Achse für BMI

        public GrafenViewModel()
        {
            LoadChartData();
        }
        [RelayCommand]
        public void LoadChartData()
        {
            var werte = App.Speicherstand.LoadData();

            if (werte == null || werte.Count == 0)
            {
                WeightSeries = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = new List<double>(),
                        Name = "Keine Daten vorhanden",
                        Fill = null,
                        Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 }
                    }
                };

                BmiSeries = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = new List<double>(),
                        Name = "Keine Daten vorhanden",
                        Fill = null,
                        Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 }
                    }
                };

                return;
            }

            var values = werte.Select(w => w.Weight).ToList();
            var dates = werte.Select(w => w.Date.ToString("dd.MM.")).ToList();
            var bmis = werte.Select(w => w.BMI).ToList();

            WeightSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = values,
                    Name = "Gewicht",
                    Fill = null,
                    GeometrySize = 15,
                    Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                    GeometryStroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 }
                }
            };

            BmiSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = bmis,
                    Name = "BMI",
                    Fill = null,
                    GeometrySize = 15,
                    Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 },
                    GeometryStroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 }
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = dates,
                    LabelsRotation = 0
                }
            };

            YAxesWeight = new Axis[]
       {
            new Axis
            {
                Name = "Gewicht (kg)",
                NamePaint = new SolidColorPaint(SKColors.Blue),
                LabelsPaint = new SolidColorPaint(SKColors.Blue),
                TextSize = 14
            }
       };

            YAxesBmi = new Axis[]
            {
            new Axis
            {
                Name = "BMI",
                NamePaint = new SolidColorPaint(SKColors.Green),
                LabelsPaint = new SolidColorPaint(SKColors.Green),
                TextSize = 14
            }
            };
        }
    }
}*/