using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class OrdersBS : StdBS<Orders, OrdersDP, OrdersDTO> {
        private static readonly Lazy<OrdersBS> _instance = new(() => new());
        public static OrdersBS Instance => _instance.Value;
        private PartnersDP _partnersDP;

        public OrdersBS() {
            _partnersDP = PartnersDP.Instance;
            _dp = OrdersDP.Instance;
        }
        protected override OrdersDTO ToDTO(Orders entity) {
            OrdersDTO dto = base.ToDTO(entity);
            dto.Init(_partnersDP);
            return dto;
        }
    }
}
