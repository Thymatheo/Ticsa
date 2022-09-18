using System.Windows;
using System.Windows.Controls;
using Ticsa.DAL.Models;

namespace Ticsa.UserControls {
    /// <summary>
    /// Logique d'interaction pour OrdersUC.xaml
    /// </summary>
    public partial class OrdersUC : UserControl {
        public OrdersUC() {
            InitializeComponent();
        }

        private async void OrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            await Model.LoadOrderContents(OrderListView.SelectedItem is not null ? () => Model.OrderContentsBS.GetByIdOrder((OrderListView.SelectedItem as Orders)!.Id) : null);
        }

        private void Reset_Click(object sender, System.Windows.RoutedEventArgs e) {
            OrderListView.SelectedItem = null;
        }

        private async void AddContent_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (LotsComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un lot");
            else if (OrdersComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner une commande");
            else if (!int.TryParse(QuantityTextBox.Text, out int quantity)) MessageBox.Show("Veuillez verifié que la quantité possede une valeur de type numérique");
            else {
                await Model.OrderContentsBS.Add(new() {
                    IdLot = (LotsComboBox.SelectedItem as Lots)!.Id,
                    IdOrder = (OrdersComboBox.SelectedItem as Orders)!.Id,
                    Quantity = quantity
                });
                await Model.LoadOrderContents();
            }
        }

        private async void AddOrder_click(object sender, System.Windows.RoutedEventArgs e) {
            if (ClientComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner une client");
            else if (OrderDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date");
            else {
                await Model.OrdersBS.Add(new() {
                    IdPartner = (ClientComboBox.SelectedItem as Partners)!.Id,
                    OrderDate = OrderDatePicker.SelectedDate.Value,
                    OrderTag = OrderTagTextBox.Text,
                });
                await Model.LoadOrders();
            }
        }
    }
}
