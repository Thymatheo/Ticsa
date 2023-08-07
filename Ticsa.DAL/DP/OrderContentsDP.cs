using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrderContentsDP : StdDP<OrderContents> {
        public OrderContentsDP() {
        }
        public IEnumerable<OrderContents> GetByIdOrder(Guid idOrder) => GetsBy(x => x.IdOrder == idOrder);

    }
}
