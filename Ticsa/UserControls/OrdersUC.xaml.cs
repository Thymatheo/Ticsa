using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private void ResetFilter() {
            (FilterPopupOrdersContent.Content as FilterUC)?.Apply();
            (FilterPopupOrdersContent.Content as FilterUC)?.Apply();
            (FilterPopupDeliveryCouponsContent.Content as FilterUC)?.Apply();
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
                (FilterPopupOrderContentsContent.Content as FilterUC)?.Apply();
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
                (FilterPopupOrdersContent.Content as FilterUC)?.Apply();
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
                    (FilterPopupDeliveryCouponsContent.Content as FilterUC)?.Apply();
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
        private void OrdersListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            OrderListView.ContextMenu = (ContextMenu)Resources["OrderContextMenu"];
        }
        private void OrderContentsListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            OrderContentsListView.ContextMenu = (ContextMenu)Resources["OrderContentsContextMenu"];
        }


        private void OpenFile_Click(object sender, RoutedEventArgs e) {
            FileManager.Open(FileManager.DELIVERYCOUPON_DIRECTORY, (DeliveryCouponslistView.SelectedItem as DeliveryCoupons)?.FilePath);
        }


        private void UpdateOrderMenuItem_Click(object sender, RoutedEventArgs e) {

        }

        private void RemoveOrderMenuItem_Click(object sender, RoutedEventArgs e) {
            if ((OrderListView.SelectedItem is OrdersDTO dto))
                if (MessageBox.Show($"Etes-vous sur de vouloir suprimer la commande {dto!.OrderTag}", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    Model.OrdersBS.Delete(dto.Id);
                    ResetFilter();
                }
        }

        private void UpdateOrderContentsMenuItem_Click(object sender, RoutedEventArgs e) {

        }

        private void RemoveOrderContentsMenuItem_Click(object sender, RoutedEventArgs e) {
            if ((OrderContentsListView.SelectedItem is OrderContentsDTO dto))
                if (MessageBox.Show($"Etes-vous sur de vouloir suprimer le contenu de la commande {dto!.Order!.OrderTag}", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    Model.OrderContentsBS.Delete(dto.Id);
                    ResetFilter();
                }
        }
        private void FilterOrdersMenuItem_Click(object sender, RoutedEventArgs e) {
            OrderListView.UpdateFilter<OrdersDTO>(FilterPopupOrderContentsContent?.Content as FilterUC, (dto) => dto.OrderTag);
            OrderListView.UpdateFilter<OrdersDTO>(FilterPopupDeliveryCouponsContent?.Content as FilterUC, (dto) => dto.OrderTag);
        }

        private void FilterOrderContentsMenuItem_Click(object sender, RoutedEventArgs e) {
            OrderContentsListView.UpdateFilter<OrderContentsDTO>(FilterPopupOrdersContent?.Content as FilterUC, (dto) => dto.Order!.OrderTag);
            OrderContentsListView.UpdateFilter<OrderContentsDTO>(FilterPopupDeliveryCouponsContent?.Content as FilterUC, (dto) => dto.Order!.OrderTag);
        }

        private void RemoveDeliveryCouponsMenuItem_Click(object sender, RoutedEventArgs e) {

            OrderContentsListView.UpdateFilter<DeliveryCouponsDTO>(FilterPopupOrdersContent?.Content as FilterUC, (dto) => dto.Order!.OrderTag);
            OrderContentsListView.UpdateFilter<DeliveryCouponsDTO>(FilterPopupDeliveryCouponsContent?.Content as FilterUC, (dto) => dto.Order!.OrderTag);
        }

        private void FilterDeliveryCouponsMenuItem_Click(object sender, RoutedEventArgs e) {
            if ((DeliveryCouponslistView.SelectedItem is DeliveryCouponsDTO dto))
                if (MessageBox.Show($"Etes-vous sur de vouloir suprimer le coupon de livraison {dto!.Label}", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    Model.DeliveryCouponsBS.Delete(dto.Id);
                    ResetFilter();
                }
        }
    }
}