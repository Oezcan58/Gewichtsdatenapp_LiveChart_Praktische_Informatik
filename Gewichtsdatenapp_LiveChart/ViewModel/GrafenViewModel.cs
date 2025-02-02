u﻿sing CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using Gewichtsdatenapp_LiveChart.Model;
using System.Collections.Specialized;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace Gewichtsdatenapp_LiveChart.ViewModel
{
    public partial class GraphViewModel : ObservableObject //ViewModel für die Graphenseite
    {
        [ObservableProperty]
        private ObservableCollection<ISeries> _weightSeries;

        [ObservableProperty]
        private ObservableCollection<ISeries> _bmiSeries;

        [ObservableProperty]
        private ObservableCollection<Axis> _xAxes;

        [ObservableProperty]
        private ObservableCollection<Axis> _yAxesWeight;

        [ObservableProperty]
        private ObservableCollection<Axis> _yAxesBmi;

        public GraphViewModel(BaseViewModel baseViewModel)
        {
            var weightData = baseViewModel.Gewichtsdaten;

            WeightSeries = new ObservableCollection<ISeries>();//
            BmiSeries = new ObservableCollection<ISeries>();
            XAxes = new ObservableCollection<Axis>();
            YAxesWeight = new ObservableCollection<Axis>();
            YAxesBmi = new ObservableCollection<Axis>();

            GenerateGraphData(weightData); // Generiert die Daten für die Diagramme

            weightData.CollectionChanged += Gewichtsdaten_CollectionChanged;//Aktualisiert Diagrammdaten bei Änderungen
        }


        private void GenerateGraphData(IEnumerable<Werte> weightData)//Generiert Diagrammdaten aus Gewichtsdaten
        {
            WeightSeries.Clear();
            BmiSeries.Clear();
            XAxes.Clear();
            YAxesWeight.Clear();
            YAxesBmi.Clear();

            if (!weightData.Any())
            {
                WeightSeries.Add(new LineSeries<double>
                {
                    Values = new List<double>(),
                    Name = "Keine Daten vorhanden",
                    Fill = null,
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 }
                });

                BmiSeries.Add(new LineSeries<double>
                {
                    Values = new List<double>(),
                    Name = "Keine Daten vorhanden",
                    Fill = null,
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 }
                });

                return;
            }

            WeightSeries.Add(new LineSeries<double>
            {
                Values = weightData.Select(w => w.Weight).ToList(),
                Name = "Gewicht",
                Fill = null,
                GeometrySize = 15,
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                GeometryStroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 }
            });

            BmiSeries.Add(new LineSeries<double>
            {
                Values = weightData.Select(w => w.Bmi).ToList(),
                Name = "BMI",
                Fill = null,
                GeometrySize = 15,
                Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 },
                GeometryStroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 }
            });

            XAxes.Add(new Axis
            {
                Labels = weightData.Select(w => w.Date.ToString("dd.MM.")).ToList(),
                LabelsRotation = 0,
                LabelsPaint = new SolidColorPaint(SKColors.White)
            });

            YAxesWeight.Add(new Axis
            {
                Name = "Gewicht (kg)",
                NamePaint = new SolidColorPaint(SKColors.LightBlue),
                LabelsPaint = new SolidColorPaint(SKColors.LightBlue),
                TextSize = 14
            });

            YAxesBmi.Add(new Axis
            {
                Name = "BMI",
                NamePaint = new SolidColorPaint(SKColors.LightGreen),
                LabelsPaint = new SolidColorPaint(SKColors.LightGreen),
                TextSize = 14
            });
        }

        private void Gewichtsdaten_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)//Aktualisiert Diagramme bei Datenänderungen
        {
            if (sender is IEnumerable<Werte> weightData)
            {
                GenerateGraphData(weightData);
            }
        }
    }
}
