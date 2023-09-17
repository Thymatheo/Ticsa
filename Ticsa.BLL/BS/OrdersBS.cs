using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class OrdersBS : StdBS<Orders, OrdersDP, OrdersDTO> {
        private static readonly Lazy<OrdersBS> _instance = new(() => new());
        public static OrdersBS Instance => _instance.Value;
        private readonly PartnersDP _partnersDP;
        private readonly DeliveryCouponsDP _deliveryCouponsDP;
        private readonly OrderContentsDP _orderContentsDP;

        public OrdersBS() {
            _partnersDP = PartnersDP.Instance;
            _deliveryCouponsDP = DeliveryCouponsDP.Instance;
            _dp = OrdersDP.Instance;
            _orderContentsDP = OrderContentsDP.Instance;
        }
        protected override OrdersDTO ToDTO(Orders entity) {
            OrdersDTO dto = base.ToDTO(entity);
            dto.Init(_partnersDP);
            return dto;
        }
        public override bool Delete(Guid id) {
            _deliveryCouponsDP.Deletes(x => x.IdOrder == id);
            _orderContentsDP.Deletes(x => x.IdOrder == id);
            return base.Delete(id);
        }
    }
}
