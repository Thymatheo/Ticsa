using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrderContentsDP : StdDP<OrderContents> {
        private static readonly Lazy<OrderContentsDP> _instance = new(() => new());
        public static OrderContentsDP Instance => _instance.Value;
        public IEnumerable<OrderContents> GetByIdOrder(Guid idOrder) => GetsBy(x => x.IdOrder == idOrder);
        public IEnumerable<OrderContents> GetByIdLots(Guid idLot) => GetsBy(x => x.IdLot == idLot);

    }
}
