using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.Models;

namespace Ticsa {
    internal static class Utils {

        public static void Refresh<T, U>(this ObservableCollection<U?> col, Func<IEnumerable<U?>> func) where T : StdEntity, new() where U : IDTO<T>, new() {
            col.Clear();
            foreach (U? lot in func.Invoke())
                col.Add(lot);
        }
        public static void ApplyFilter<T>(this ObservableCollection<T?> col, IEnumerable<T?> lots){
            col.Clear();
            foreach (T? lot in lots)
                col.Add(lot);
        }
    }
}
