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
using Ticsa.BLL.DTOs;
using Ticsa.Filters.ViewModels;
using Ticsa.ViewModels;

namespace Ticsa.Filters.UserControls {
    /// <summary>
    /// Logique d'interaction pour FilterUC.xaml
    /// </summary>
    public partial class FilterUC : UserControl {
        public IFiltrableCollection FiltrableCollection { get; set; }
        public FilterUC(IFiltrableCollection filtrableCollection) {
            InitializeComponent();
            FiltrableCollection = filtrableCollection;
            foreach (IMemberFilter filter in FiltrableCollection.Filters)
                FiltersStackPanel.Children.Add(new MemberFilterUC(filter, this));
        }
        public void Apply() {
            FiltrableCollection.ApplyFilter();
        }
    }
}
