using System.Windows;
using Ticsa.DAL;
using Ticsa.UserControls;

namespace Ticsa {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private GammesUC GammesUC { get; set; }
        private OrdersUC OrdersUC { get; set; }
        private PartenersUC PartenersUC { get; set; }
        public MainWindow() {
            InitializeComponent();
            MainContentControl.Content = GammesUC = new();
            OrdersUC = new();
            PartenersUC = new();
        }

        private void GammesMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = GammesUC;
        }

        private void OrdersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = OrdersUC;
        }

        private void PartnersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = PartenersUC;
        }
    }
}
