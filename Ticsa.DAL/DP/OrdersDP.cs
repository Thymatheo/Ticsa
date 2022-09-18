using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrdersDP : StdDP<Orders> {
        public OrdersDP() : base("Orders") {
        }

        protected override object BuildAddParam(Orders entity) => new {
            InputOrderDateOrders = entity.OrderDate,
            InputIdPartnerOrders = entity.IdPartner,
            InputOrderTagOrders = entity.OrderTag
        };

        protected override object BuildDeleteParam(int id) => new {
            InputIdOrders = id
        };

        protected override object BuildGetByIdParam(int id) => new {
            InputIdOrders = id
        };

        protected override object BuildUpdateParam(Orders entity) => new {
            InputToPutOrderDateOrders = entity.OrderDate,
            InputToPutIdPartnerOrders = entity.IdPartner,
            InputToPutOrderTagOrders = entity.OrderTag,
            InputIdOrders = entity.Id,
        };
    }
}
