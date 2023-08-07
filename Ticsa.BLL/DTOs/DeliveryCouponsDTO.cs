using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;
using Ticsa.DAL.Models.Interfaces;

namespace Ticsa.BLL.DTOs {
    public class DeliveryCouponsDTO : IPartnersDependency, IOrdersDependency, IDTO<DeliveryCoupons>, IDeliveryCoupon {
        public Orders? Order { get; set; }
        public Partners? Partner { get; set; }
        public Guid IdPartner => BaseEntity!.IdPartner;
        public Guid IdOrder => BaseEntity!.IdOrder;
        public DeliveryCoupons? BaseEntity { get; set; }
        public string Label => BaseEntity!.Label;
        public DateTime RecieveDate => BaseEntity!.RecieveDate;
        public string? FilePath => BaseEntity!.FilePath;
        public Guid Id => BaseEntity!.Id;

        public DeliveryCouponsDTO Init(OrdersDP ordersDP, PartnersDP partnersDP) {
            this.Init(partnersDP);
            this.Init(ordersDP);
            return this;
        }
    }
}
