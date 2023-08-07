using Ticsa.DAL.DP;

namespace Ticsa.DAL.Models.Interfaces {
    public interface IOrdersDependency {
        public Guid IdOrder { get; }
        public Orders? Order { get; set; }
    }
    public static partial class Extention {
        public static void Init(this IOrdersDependency order, OrdersDP orders) {
            if (order.Order == null)
                order.Order = orders.Get(order.IdOrder)!;
        }
    }
}
