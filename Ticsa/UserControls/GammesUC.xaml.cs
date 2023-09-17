using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.Models;
using Ticsa.Filters;
using Ticsa.Filters.UserControls;
using Ticsa.Filters.ViewModels;
using Ticsa;

namespace Ticsa.UserControls {
    /// <summary>
    /// Logique d'interaction pour GammesUC.xaml
    /// </summary>
    public partial class GammesUC : UserControl {
        private ContextMenu _menu;
        public GammesUC() {
            InitializeComponent();
            _menu = (ContextMenu)Resources["ManagerConnectionContextMenu"];
            FilterPopupGammesContent.Content = new FilterUC(Model.Gammes!);
            FilterPopupLotsContent.Content = new FilterUC(Model.Lots!);
            Model.LoadData();
        }

        private void AddGammes_Click(object sender, RoutedEventArgs e) {
            if (PartnerComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un Producteur");
            else {
                Model.GammesBS.Add(new() {
                    IdPartner = (PartnerComboBox.SelectedItem as PartnersDTO)!.Id,
                    Label = GammeLabelTextBox.Text,
                    Summary = SummaryTextBox.Text
                });
                (FilterPopupGammesContent.Content as FilterUC)?.Apply();
            }
        }

        private void AddLots_Click(object sender, RoutedEventArgs e) {

            if (GammesComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un Producteur");
            else if (!int.TryParse(QuantityTextBox.Text, out int quantity)) MessageBox.Show("Veuillez selectionner une quantité valide");
            else if (ExpirationDateLotsDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date d'expiration");
            else if (EntryDateLotsDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date d'entrée");
            else {
                Model.LotsBS.Add(new() {
                    IdGamme = (GammesComboBox.SelectedItem as GammesDTO)!.Id,
                    Label = LotLabelTextBox.Text,
                    EntryDate = EntryDateLotsDatePicker.SelectedDate.Value,
                    ExpirationDate = ExpirationDateLotsDatePicker.SelectedDate.Value,
                    Quantity = quantity
                });
                (FilterPopupLotsContent.Content as FilterUC)?.Apply();
            }
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

        private void RemoveGammeMenuItem_Click(object sender, RoutedEventArgs e) {
            if ((GammesListView.SelectedItem is GammesDTO dto))
                if (MessageBox.Show($"Etes-vous sur de vouloir suprimer la gamme {dto!.Label}", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    Model.GammesBS.Delete(dto.Id);
                    (FilterPopupLotsContent.Content as FilterUC)?.Apply();
                    (FilterPopupGammesContent.Content as FilterUC)?.Apply();
                }
        }

        private void UpdateGammeMenuItem_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("udpate");
        }
        private void GammesListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            GammesListView.ContextMenu = (ContextMenu)Resources["GammeContextMenu"];
        }

        private void FilterMenuItem_Click(object sender, RoutedEventArgs e) {
            GammesListView.UpdateFilter<GammesDTO>(FilterPopupLotsContent.Content as FilterUC, dto => dto.Label);
        }

        private void UpdateLotMenuItem_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("udpate");
        }

        private void RemoveLotMenuItem_Click(object sender, RoutedEventArgs e) {
            if ((LotsListView.SelectedItem is LotsDTO dto))
                if (MessageBox.Show($"Etes-vous sur de vouloir suprimer le lots {dto!.Label}", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    Model.LotsBS.Delete(dto.Id);
                    (FilterPopupLotsContent.Content as FilterUC)?.Apply();
                    (FilterPopupGammesContent.Content as FilterUC)?.Apply();
                }
        }

        private void LotsListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            LotsListView.ContextMenu = (ContextMenu)Resources["LotContextMenu"];
        }
    }
}
