using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class PartnersBS : StdBS<Partners, PartnersDP, PartnersDTO> {
        private static readonly Lazy<PartnersBS> _instance = new(() => new());
        public static PartnersBS Instance => _instance.Value;
        private PartnerTypesDP _partnerTypesDP;
        private readonly GammesDP _gammesDP;
        private readonly OrdersDP _ordersDP;
        private readonly DeliveryCouponsDP _deliveryCouponsDP;

        public PartnersBS() {
            _partnerTypesDP = PartnerTypesDP.Instance;
            _gammesDP = GammesDP.Instance;
            _dp = PartnersDP.Instance;
            _ordersDP = OrdersDP.Instance;
            _deliveryCouponsDP = DeliveryCouponsDP.Instance;
        }
        protected override PartnersDTO ToDTO(Partners entity) {
            PartnersDTO dto = base.ToDTO(entity);
            dto.Init(_partnerTypesDP);
            return dto;
        }

        public IEnumerable<PartnersDTO?> GetByIdType(Guid idType) =>
             _dp!.GetsBy(x => x.IdPartnerType == idType).Select(ToDTO);
        public override bool Delete(Guid id) {
            _gammesDP.Deletes(x => x.IdPartner == id);
            _ordersDP.Deletes(x => x.IdPartner == id);
            _deliveryCouponsDP.Deletes(x => x.IdPartner == id);
            return base.Delete(id);
        }
    }
}
