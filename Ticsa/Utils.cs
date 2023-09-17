using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Ticsa.BLL.DTOs;
using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.Models;
using Ticsa.Filters;
using Ticsa.Filters.UserControls;
using Ticsa.Filters.ViewModels;

namespace Ticsa {
    internal static class Utils {

        public static void Refresh<U>(this FiltrableCollection<U?> col, Func<IEnumerable<U?>> func) {
            col.Values.Clear();
            foreach (U? lot in func.Invoke())
                col.Values.Add(lot);
        }
        public static void Refresh<T, U>(this ObservableCollection<U?> col, Func<IEnumerable<U?>> func) where T : StdEntity, new() where U : IDTO<T>, new() {
            col.Clear();
            foreach (U? lot in func())
                col.Add(lot);
        }
        public static void Refresh<U>(this ObservableCollection<U?> col, IEnumerable<U?> lots) {
            col.Clear();
            foreach (U? lot in lots)
                col.Add(lot);
        }
        public static void ApplyFilter<T>(this ObservableCollection<T?> col, IEnumerable<T?> lots) {
            col.Clear();
            foreach (T? lot in lots)
                col.Add(lot);

        }

        public static void UpdateFilter<T>(this ListView view, FilterUC? filterUC, Func<T, string> predicate) {
            if (filterUC != null)
                if (view.SelectedItem is T dto) {
                    IMemberFilter memberFilter = filterUC!.FiltrableCollection.Filters[0];
                    if (memberFilter.IsEnable && memberFilter.Value == predicate(dto)) {
                        memberFilter.UdpateFilterValue(false, "");
                    }
                    else {
                        memberFilter.UdpateFilterValue(true, predicate(dto));
                    }
                    filterUC?.Apply();
                    view.SelectedItem = null;
                }
        }
    }
}
