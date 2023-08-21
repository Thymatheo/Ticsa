using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Ticsa.BLL.DTOs;
using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.Models;
using Ticsa.Filters.UserControls;
using Ticsa.Filters.ViewModels;

namespace Ticsa.UserControls {
    /// <summary>
    /// Logique d'interaction pour OrdersUC.xaml
    /// </summary>
    public partial class OrdersUC : UserControl {
        public OrdersUC() {
            InitializeComponent();

            FilterPopupOrdersContent.Content = new FilterUC(Model.Orders);
            FilterPopupOrderContentsContent.Content = new FilterUC(Model.OrderContents);
            FilterPopupDeliveryCouponsContent.Content = new FilterUC(Model.DeliveryCoupons);
        }

        private async void OrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UdpateFilter(OrderListView, FilterPopupOrderContentsContent?.Content as FilterUC);
            UdpateFilter(OrderListView, FilterPopupDeliveryCouponsContent?.Content as FilterUC);
            Model.LastOrderSelected = OrderListView.SelectedItem as OrdersDTO;
        }
        private void UdpateFilter(ListView view, FilterUC? filterUC) {
            if (filterUC != null)
                if (view.SelectedItem is OrdersDTO dto) {
                    IMemberFilter memberFilter = filterUC!.FiltrableCollection.Filters[0];
                    if (memberFilter.IsEnable && memberFilter.Value == dto.OrderTag) {
                        memberFilter.UdpateFilterValue(false, "");
                    }
                    else {
                        memberFilter.UdpateFilterValue(true, dto.OrderTag);
                    }
                    filterUC?.Apply();
                    view.SelectedItem = null;
                }
        }

        private void Reset_Click(object sender, System.Windows.RoutedEventArgs e) {
            OrderListView.SelectedItem = null;
        }

        private void AddContent_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (LotsComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un lot");
            else if (OrdersComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner une commande");
            else if (!int.TryParse(QuantityTextBox.Text, out int quantity)) MessageBox.Show("Veuillez verifié que la quantité possede une valeur de type numérique");
            else {
                Model.OrderContentsBS.Add(new() {
                    IdLot = (LotsComboBox.SelectedItem as LotsDTO)!.Id,
                    IdOrder = (OrdersComboBox.SelectedItem as OrdersDTO)!.Id,
                    Quantity = quantity
                });
            }
        }

        private void AddOrder_click(object sender, System.Windows.RoutedEventArgs e) {
            if (ClientComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un client");
            else if (OrderDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date");
            else {
                Model.OrdersBS.Add(new() {
                    IdPartner = (ClientComboBox.SelectedItem as PartnersDTO)!.Id,
                    OrderDate = OrderDatePicker.SelectedDate.Value,
                    OrderTag = OrderTagTextBox.Text,
                });
            }
        }

        private void AddDC_Click(object sender, RoutedEventArgs e) {
            if (DC_ProducersComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un producteur");
            else if (DC_OrdersComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner une commande");
            else if (DC_RecieveDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date");
            else {
                try {
                    Model.DeliveryCouponsBS.Add(new() {
                        IdOrder = (DC_OrdersComboBox.SelectedItem as OrdersDTO)!.Id,
                        IdPartner = (DC_ProducersComboBox.SelectedItem as PartnersDTO)!.Id,
                        RecieveDate = DC_RecieveDatePicker.SelectedDate.Value,
                        Label = DC_LabelTextBox.Text,
                        FilePath = FileManager.Copy(Model.DeliveryCouponFileName!, FileManager.DELIVERYCOUPON_DIRECTORY)
                    });
                }
                catch {
                    MessageBox.Show("Veuillez fournir le coupon de livraison");
                }
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
            FileManager.Open(FileManager.DELIVERYCOUPON_DIRECTORY, (DeliveryCouponslistView.SelectedItem as DeliveryCoupons)?.FilePath);
        }
    }
}
