using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.DTOs.Interfaces {
    public interface ILots {
        public Guid IdLot { get; }
        public Lots? Lot { get; set; }
    }
    public static partial class Extention {
        public static void Init(this ILots lot, LotsDP lots) {
            if (lot.Lot == null)
                lot.Lot = lots.Get(lot.IdLot)!;
        }
    }
}
