using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;
using Ticsa.DAL.Models.Interfaces;

namespace Ticsa.BLL.DTOs {
    public class OrdersDTO : IPartnersDependency, IDTO<Orders>, IOrder {
        public Partners? Partner { get; set; }
        public Guid IdPartner => BaseEntity!.IdPartner;
        public Orders? BaseEntity { get; set; }
        public DateTime OrderDate => BaseEntity!.OrderDate;
        public string OrderTag => BaseEntity!.OrderTag!;
        public Guid Id => BaseEntity!.Id;

        public OrdersDTO Init(PartnersDP partnersDP) {
            (this as IPartnersDependency).Init(partnersDP);
            return this;
        }
    }
}
