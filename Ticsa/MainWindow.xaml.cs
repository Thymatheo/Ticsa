﻿using System.Windows;
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
        }

        private void GammesMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = GammesUC = new();
            GammesUC.Model.LoadData();
        }

        private void OrdersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = OrdersUC = new();
            OrdersUC.Model.LoadData();
        }

        private void PartnersMenuItem_Click(object sender, RoutedEventArgs e) {
            MainContentControl.Content = PartenersUC = new();
            PartenersUC.Model.LoadData();
        }
    }
}
