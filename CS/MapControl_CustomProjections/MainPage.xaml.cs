using DevExpress.UI.Xaml.Map;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace MapControl_CustomProjections
{
    public sealed partial class MainPage : Page
    {
        ProjectionRatio[] projectionRatios = { 
                                                 new ProjectionRatio("Lambert", 3.14),
                                                 new ProjectionRatio("Behrmann", 2.36),
                                                 new ProjectionRatio("Trystan Edwards", 2),
                                                 new ProjectionRatio("Gall-Peters", 1.57),
                                                 new ProjectionRatio("Balthasart", 1.3),
                                                 new ProjectionRatio("Default", 1)
                                             };

        int sizeValue = 512;

        public  ProjectionRatio[] ProjectionRatios{ get { return projectionRatios; } }

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListView listView = sender as ListView;
            if (listView == null) return;

            ((VectorFileLayer)mapControl.Layers[0]).InitialMapSize = new Size(
                ((ProjectionRatio)listView.SelectedItem).Value * sizeValue, sizeValue
            );
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            listView.SelectedIndex = ProjectionRatios.Length - 1;
        }
    }

    public class ProjectionRatio {
        public ProjectionRatio(string name, double value) {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public double Value { get; set; }
    }
}
