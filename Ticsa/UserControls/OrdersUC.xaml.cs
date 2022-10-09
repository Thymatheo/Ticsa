using System.Diagnostics;
using System.IO;
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
            if (ClientComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un client");
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

        private async void AddDC_Click(object sender, RoutedEventArgs e) {
            if (DC_ProducersComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un producteur");
            else if (DC_OrdersComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner une commande");
            else if (DC_RecieveDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date");
            else {
                await Model.DeliveryCouponsBS.Add(new() {
                    IdOrder = (DC_OrdersComboBox.SelectedItem as Orders)!.Id,
                    IdPartner = (DC_ProducersComboBox.SelectedItem as Partners)!.Id,
                    RecieveDate = DC_RecieveDatePicker.SelectedDate.Value,
                    Label = DC_LabelTextBox.Text,
                    FilePath = FileManager.Copy(Model.DeliveryCouponFileName!, FileManager.DELIVERYCOUPON_DIRECTORY)
                });
                await Model.LoadDeliveryCoupons();
            }
        }

        private void DeliveryCoupon_Drop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 1) MessageBox.Show("Veuillez ne selectionner qu'un seul fichier");
                else {
                    Model.DeliveryCouponFileName = files[0];
                }
            }
        }

        private void DeliveryCouponslistView_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            DeliveryCouponslistView.ContextMenu = (ContextMenu)Resources["DeliveryCouponContextMenu"];
        }


        private void OpenFile_Click(object sender, RoutedEventArgs e) {
            FileManager.Open(FileManager.DELIVERYCOUPON_DIRECTORY, (DeliveryCouponslistView.SelectedItem as DeliveryCoupons).FilePath);
        }
    }
}
