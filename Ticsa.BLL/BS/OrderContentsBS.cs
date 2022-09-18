using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class OrderContentsBS : StdBS<OrderContents, OrderContentsDP> {
        private readonly LotsDP _lotsDP;
        public OrderContentsBS() {
            _lotsDP = new();
        }
        public async Task<IEnumerable<OrderContents?>> GetByIdOrder(int idOrder) =>
            await _dp.GetByIdOrder(idOrder);

        public override async Task<OrderContents?> Add(OrderContents entity) {
            Lots lot = await _lotsDP.GetById(entity.IdLot);
            int newQuantity = lot.Quantity - entity.Quantity;
            if (newQuantity < 0) throw new Exception("Ce lot n'a plus assez de stock !");
            else {
                lot.Quantity = newQuantity;
                await _lotsDP.Update(lot);
            }
            return await base.Add(entity);
        }
    }
}
