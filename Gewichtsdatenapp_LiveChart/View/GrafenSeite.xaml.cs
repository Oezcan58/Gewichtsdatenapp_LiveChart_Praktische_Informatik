using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using Gewichtsdatenapp_LiveChart.Model;
using Gewichtsdatenapp_LiveChart.ViewModel;
using CommunityToolkit.Mvvm.Input;
using Gewichtsdatenapp_LiveChart.Services;


namespace Gewichtsdatenapp_LiveChart.View
{
    public partial class GrafenSeite : ContentPage
    {
        public GrafenSeite()
        {
            InitializeComponent();
            /*BindingContext = new GrafenViewModel();*/
            LoadChartData();
        }
    

            /**/
protected override void OnAppearing()
{
    base.OnAppearing();
    LoadChartData();
}

public async void LoadChartData()
{
            try
            {
                var werte = await App.Speicherplatz.LoadDataAsync();

                if (werte == null || werte.Count == 0)
                {
                    WeightChart.Series = new ISeries[]
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
                var dates = werte.Select(w => w.Date).ToList();
                var bmis = werte.Select(w => w.Bmi).ToList();

                var series = new ISeries[]
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

                var x = new Axis[]
                                {
                new Axis
                {
                    Labels = dates.Select(d => d.ToString("dd.MM.")).ToList(),

                    LabelsRotation = 0
                }
                                };

                var y = new Axis[]
                {
                new Axis
                {
                    Name = "Gewicht (kg)",
                    NamePaint = new SolidColorPaint(SKColors.Blue),
                    LabelsPaint = new SolidColorPaint(SKColors.Blue),
                    TextSize = 14
                }
                                };
                var z = new Axis[]
                {
                new Axis
                  {
                     Name = "Bmi",
                     NamePaint = new SolidColorPaint(SKColors.Green),
                     LabelsPaint = new SolidColorPaint(SKColors.Green),
                     TextSize = 14
                    }

                };
                WeightChart.Series = series;
                WeightChart.XAxes = x;
                WeightChart.YAxes = y;

                BmiChart.Series = new ISeries[]
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
                BmiChart.XAxes = x;
                BmiChart.YAxes = z;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in LoadChartData: {ex.Message}");
              
            }
        }
    }
}
