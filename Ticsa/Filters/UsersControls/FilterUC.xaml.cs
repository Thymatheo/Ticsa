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
        public List<IMemberFilter> Filters { get; set; }
        public Action ResetFilter { get; set; }
        public Action<Func<object, bool>> ApplyFilter { get; set; }
        public FilterUC(Action resetFilter, Action<Func<object, bool>> applyFilter, params IMemberFilter[] filters) {
            InitializeComponent();
            ResetFilter = resetFilter;
            ApplyFilter = applyFilter;
            Filters = new(filters);
            foreach (IMemberFilter filter in Filters)
                FiltersStackPanel.Children.Add(new MemberFilterUC(filter, this));
        }
        public void Apply() {
            ResetFilter();
            ApplyFilter((obj) => {
                bool filterStatus = true;
                foreach (IMemberFilter filter in Filters.Where(x => x.IsEnable).ToList()) {
                    filterStatus = filter.ApplyFilter(obj);
                }
                return filterStatus;
            });
        }
    }
}
