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
            DatabaseConfig.DBConnectionString = "Server = (localdb)\\MSSQLLocalDB; Database = Ticsa; Integrated Security = True";
            InitializeComponent();
            GammesUC = new();
            PartenersUC = new();
            OrdersUC = new();
        }

        private async void GammesMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = GammesUC;
            await GammesUC.Model.LoadData();
        }

        private async void OrdersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = OrdersUC;
            await OrdersUC.Model.LoadData();
        }

        private async void PartnersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = PartenersUC;
            await PartenersUC.Model.LoadData();
        }
    }
}
