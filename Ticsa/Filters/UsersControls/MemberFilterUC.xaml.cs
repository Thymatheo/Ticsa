using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ticsa.DAL.Models;
using Ticsa.Filters.ViewModels;

namespace Ticsa.Filters.UserControls {
    /// <summary>
    /// Logique d'interaction pour FilterUC.xaml
    /// </summary>
    public partial class MemberFilterUC : UserControl {
        private readonly FilterUC _parent;
        private IMemberFilter Filter;
        public MemberFilterUC(IMemberFilter filter, FilterUC parent) {
            InitializeComponent();
            DataContext = Filter = filter;
            _parent = parent;
            FilterTextBox.Text = Filter.Value.ToString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            _parent.Apply();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _parent.Apply();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            Filter.Value = (sender as TextBox)!.Text;
            _parent.Apply();
        }
    }
}
