using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class DeliveryCouponsBS : StdBS<DeliveryCoupons, DeliveryCouponsDP, DeliveryCouponsDTO> {
        private static readonly Lazy<DeliveryCouponsBS> _instance = new(() => new());
        public static DeliveryCouponsBS Instance => _instance.Value;
        private OrdersDP _ordersDP;
        private PartnersDP _partnersDP;

        public DeliveryCouponsBS() {
            _ordersDP = OrdersDP.Instance;
            _partnersDP = PartnersDP.Instance;
            _dp = DeliveryCouponsDP.Instance;
        }
        protected override DeliveryCouponsDTO ToDTO(DeliveryCoupons entity) {
            DeliveryCouponsDTO dto = base.ToDTO(entity);
            dto.Init(_ordersDP, _partnersDP);
            return dto;
        }
    }
}
