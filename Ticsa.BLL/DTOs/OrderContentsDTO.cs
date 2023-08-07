using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;
using Ticsa.DAL.Models.Interfaces;

namespace Ticsa.BLL.DTOs {
    public class OrderContentsDTO : IOrdersDependency, ILots, IDTO<OrderContents>, IOrderContent {
        public Orders? Order { get; set; }
        public Guid IdOrder => BaseEntity!.IdOrder;
        public Lots? Lot { get; set; }
        public Guid IdLot => BaseEntity!.IdLot;
        public OrderContents? BaseEntity { get; set; }
        public int Quantity => BaseEntity!.Quantity;
        public Guid Id => BaseEntity!.Id;

        public OrderContentsDTO Init(OrdersDP ordersDP, LotsDP lotsDP) {
            this.Init(lotsDP);
            this.Init(ordersDP);
            return this;
        }
    }
}
