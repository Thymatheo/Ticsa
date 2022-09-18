using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ticsa.DAL.Models;

namespace Ticsa {
    internal static class Utils {

        public static async Task Refresh<T>(this ObservableCollection<T?> col, Func<Task<IEnumerable<T?>>> func) where T : StdEntity, new() {
            col.Clear();
            foreach (T? lot in await func.Invoke())
                col.Add(lot);
        }
    }
}
