using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrdersDP : StdDP<Orders> {
        private static readonly Lazy<OrdersDP> _instance = new(() => new());
        public static OrdersDP Instance => _instance.Value;
    }
}
