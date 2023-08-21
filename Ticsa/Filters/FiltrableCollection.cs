using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ticsa.Filters.ViewModels;

namespace Ticsa.Filters {
    public class FiltrableCollection<T> : IFiltrableCollection{
        public List<IMemberFilter> Filters { get; private set; }
        private Func<IEnumerable<T>> _source;
        public IEnumerable<T> Source => _source(); 
        public ObservableCollection<T> Values { get; set; }
        public FiltrableCollection(Func<IEnumerable<T>> source, params IMemberFilter[] filters) {
            _source = source;
            Filters = new(filters);
            Values = new(Source);
        }
        public void ApplyFilter() {
            Values!.ApplyFilter(Source.Where(obj => {
                bool filterStatus = true;
                foreach (IMemberFilter filter in Filters.Where(x => x.IsEnable).ToList()) {
                    filterStatus &= filter.ApplyFilter(obj!);
                }
                return filterStatus;
            }));
        }
        public void Refresh() {
            Values.Clear();
            foreach (T? lot in Source)
                Values.Add(lot);
        }
    }
    public interface IFiltrableCollection {
        public List<IMemberFilter> Filters { get; }
        public void ApplyFilter();
    }
}
