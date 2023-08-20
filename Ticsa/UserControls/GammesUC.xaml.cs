using System.Windows;
using System.Windows.Controls;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.Models;

namespace Ticsa.UserControls {
    /// <summary>
    /// Logique d'interaction pour GammesUC.xaml
    /// </summary>
    public partial class GammesUC : UserControl {
        private ContextMenu _menu;
        public GammesUC() {
            InitializeComponent();
            _menu = (ContextMenu)Resources["ManagerConnectionContextMenu"];
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
                Model.LoadGammes();

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
                Model.LoadLots();
            }
        }

        private void GammesListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Model.LoadLots(GammesListView.SelectedItem is not null ? () => Model.LotsBS.GetByIdGamme((GammesListView.SelectedItem as GammesDTO)!.Id) : null);
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            GammesListView.SelectedItem = null;
        }
        private void UpdateGamme_OnClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("Update Gamme");
        }
        private void RemoveGamme_OnClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("Remove Gamme");
        }
        private void UpdateLot_OnClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("Update Lot");
        }
        private void RemoveLot_OnClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("Remove Lot");
        }

        private void GammesListView_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            GammesListView.ContextMenu = (ContextMenu)Resources["ManageGammeContextMenu"];
        }

        private void GammesListView_Unselected(object sender, RoutedEventArgs e) {
            GammesListView.SelectedItem = null;
        }

        private void LotsListView_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            LotsListView.ContextMenu = (ContextMenu)Resources["ManageLotContextMenu"];
        }
    }
}
