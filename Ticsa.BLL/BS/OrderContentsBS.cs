using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class OrderContentsBS : StdBS<OrderContents, OrderContentsDP, OrderContentsDTO> {
        private static readonly Lazy<OrderContentsBS> _instance = new(() => new());
        public static OrderContentsBS Instance => _instance.Value;
        private readonly LotsDP _lotsDP;
        private readonly OrdersDP _ordersDP;
        public OrderContentsBS() {
            _lotsDP = LotsDP.Instance;
            _ordersDP = OrdersDP.Instance;
            _dp = OrderContentsDP.Instance;
        }
        protected override OrderContentsDTO ToDTO(OrderContents entity) {
            OrderContentsDTO dto = base.ToDTO(entity);
            dto.Init(_ordersDP, _lotsDP);
            return dto;
        }
        public IEnumerable<OrderContentsDTO?> GetByIdOrder(Guid idOrder) =>
            _dp!.GetByIdOrder(idOrder).Select(ToDTO);

        public override OrderContentsDTO? Add(OrderContents entity) {
            Lots? lot = _lotsDP.Get(entity.IdLot);
            if (lot != null) {
                int newQuantity = lot.Quantity - entity.Quantity;
                if (newQuantity < 0) throw new Exception("Ce lot n'a plus assez de stock !");
                else {
                    lot.Quantity = newQuantity;
                    _lotsDP.Update(lot);
                }
                return base.Add(entity);
            }
            else return null;
        }
        public override bool Delete(Guid id) {
            Lots lot = _lotsDP.Get(id)!;
            lot.Quantity += Get(id)!.Quantity;
            _lotsDP.Update(lot);
            return base.Delete(id);
        }
    }
}
