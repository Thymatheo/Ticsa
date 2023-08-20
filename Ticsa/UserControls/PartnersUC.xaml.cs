﻿using System.Windows;
using System.Windows.Controls;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.Models;

namespace Ticsa.UserControls {
    /// <summary>
    /// Logique d'interaction pour PartenersUC.xaml
    /// </summary>
    public partial class PartenersUC : UserControl {
        public PartenersUC() {
            InitializeComponent();
            Model.LoadData();
        }

        private void AddParteners_Click(object sender, RoutedEventArgs e) {
            if (PartnerTypesComboBox.SelectedItem is null)
                MessageBox.Show("Veuillez selectionner un type de partenaire avant d'ajouter");
            else if (!int.TryParse(PhoneNumberTextBox.Text, out int phoneNumber))
                MessageBox.Show("Veuillez verifier la syntax du numéro de téléphone");
            else if (!int.TryParse(PostalCodeTextBox.Text, out int postalCode))
                MessageBox.Show("Veuillez verifier la syntax du code postal");
            else {
                _ = Model.PartnersBS.Add(new() {
                    IdPartnerType = (PartnerTypesComboBox.SelectedItem as PartnerTypesDTO)!.Id,
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    CompanyName = CompanyNameTextBox.Text,
                    Email = EmailTextBox.Text,
                    PhoneNumber = phoneNumber,
                    PostalAddress = PostalAddressTextBox.Text,
                    PostalCode = postalCode,
                });
                Model.LoadData();
            }
        }
    }
}
