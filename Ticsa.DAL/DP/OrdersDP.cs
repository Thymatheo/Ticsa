using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrdersDP : StdDP<Orders> {
        public OrdersDP() : base("Orders") {
        }

        protected override object BuildAddParam(Orders entity) => new {
            entity.OrderTag,
            entity.OrderDate,
            entity.IdPartner,
        };
    }
}
