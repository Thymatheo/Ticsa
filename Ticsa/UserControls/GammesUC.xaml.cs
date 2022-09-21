using System.Windows;
using System.Windows.Controls;
using Ticsa.DAL.Models;

namespace Ticsa.UserControls {
    /// <summary>
    /// Logique d'interaction pour GammesUC.xaml
    /// </summary>
    public partial class GammesUC : UserControl {
        public GammesUC() {
            InitializeComponent();
        }

        private async void AddGammes_Click(object sender, RoutedEventArgs e) {
            if (PartnerComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un Producteur");
            else {
                await Model.GammesBS.Add(new() {
                    IdPartner = (PartnerComboBox.SelectedItem as Partners)!.Id,
                    Label = GammeLabelTextBox.Text,
                    Summary = SummaryTextBox.Text
                });
                await Model.LoadGammes();
            }
        }

        private async void AddLots_Click(object sender, RoutedEventArgs e) {

            if (GammesComboBox.SelectedItem is null) MessageBox.Show("Veuillez selectionner un Producteur");
            else if (!int.TryParse(QuantityTextBox.Text, out int quantity)) MessageBox.Show("Veuillez selectionner une quantité valide");
            else if (ExpirationDateLotsDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date d'expiration");
            else if (EntryDateLotsDatePicker.SelectedDate is null) MessageBox.Show("Veuillez selectionner une date d'entrée");
            else {
                await Model.LotsBS.Add(new() {
                    IdGamme = (GammesComboBox.SelectedItem as Gammes)!.Id,
                    Label = LotLabelTextBox.Text,
                    EntryDate = EntryDateLotsDatePicker.SelectedDate.Value,
                    ExpirationDate = ExpirationDateLotsDatePicker.SelectedDate.Value,
                    Quantity = quantity
                });
                await Model.LoadLots();
            }
        }

        private async void GammesListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            await Model.LoadLots(GammesListView.SelectedItem is not null ? () => Model.LotsBS.GetByIdGamme((GammesListView.SelectedItem as Gammes)!.Id) : null);
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            GammesListView.SelectedItem = null;
        }
    }
}
