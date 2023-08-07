using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class DeliveryCouponsBS : StdBS<DeliveryCoupons, DeliveryCouponsDP, DeliveryCouponsDTO> {
        private OrdersDP _ordersDP;
        private PartnersDP _partnersDP;

        public DeliveryCouponsBS() {
            _ordersDP = new OrdersDP();
            _partnersDP = new PartnersDP();
        }
        protected override DeliveryCouponsDTO ToDTO(DeliveryCoupons entity) {
            DeliveryCouponsDTO dto = base.ToDTO(entity);
            dto.Init(_ordersDP, _partnersDP);
            return dto;
        }
    }
}
