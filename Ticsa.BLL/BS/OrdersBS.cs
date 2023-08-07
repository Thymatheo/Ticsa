using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class OrdersBS : StdBS<Orders, OrdersDP, OrdersDTO> {
        private PartnersDP _partnersDP;

        public OrdersBS() {
            _partnersDP = new PartnersDP();
        }
        protected override OrdersDTO ToDTO(Orders entity) {
            OrdersDTO dto = base.ToDTO(entity);
            dto.Init(_partnersDP);
            return dto;
        }
    }
}
