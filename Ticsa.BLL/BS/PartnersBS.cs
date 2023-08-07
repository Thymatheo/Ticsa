using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class PartnersBS : StdBS<Partners, PartnersDP, PartnersDTO> {
        private PartnerTypesDP _partnerTypesDP;

        public PartnersBS() {
            _partnerTypesDP = new();
        }
        protected override PartnersDTO ToDTO(Partners entity) {
            PartnersDTO dto = base.ToDTO(entity);
            dto.Init(_partnerTypesDP);
            return dto;
        }

        public IEnumerable<PartnersDTO?> GetByIdType(Guid idType) =>
             _dp.GetsBy(x => x.IdPartnerType == idType).Select(ToDTO);
    }
}
