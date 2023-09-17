using System.Windows;
using Ticsa.DAL;
using Ticsa.UserControls;

namespace Ticsa {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MainContentControl.Content = new GammesUC();
        }

        private void GammesMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = new GammesUC();
        }

        private void OrdersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = new OrdersUC();
        }

        private void PartnersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = new PartenersUC();
        }
    }
}
