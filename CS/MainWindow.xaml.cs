using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ArgumentBasedMarkerTypeSelector {
    public partial class MainWindow : Window {
        public List<ChartDataItem> DataItems { get; set; } = new List<ChartDataItem>();
        public MainWindow() {
            InitializeComponent();
            DataItems.AddRange(GenerateRandomData());
        }        
        IEnumerable<ChartDataItem> GenerateRandomData() {
            var random = new Random();
            for (var i = 0; i < 90; i++) {
                yield return new ChartDataItem() {
                    DateTimeStamp = DateTime.Today.AddDays(i),
                    Value = random.Next(0, 100)
                };
            }
        }
    }
    public class ChartDataItem {
        public DateTime DateTimeStamp { get; set; }
        public double Value { get; set; }
    }
    public class MarkerDataTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (container is FrameworkElement element && item is SeriesPoint seriesPoint) {
                var dayOfWeek = seriesPoint.DateTimeArgument.DayOfWeek;
                if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
                    return element.FindResource("squareModel") as DataTemplate;
                else
                    return element.FindResource("circleModel") as DataTemplate;
            }
            return null;
        }
    }
}
