using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class DeliveryCouponsDP : StdDP<DeliveryCoupons> {
        private static readonly Lazy<DeliveryCouponsDP> _instance = new(() => new());
        public static DeliveryCouponsDP Instance => _instance.Value;
    }
}
