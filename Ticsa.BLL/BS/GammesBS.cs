using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class GammesBS : StdBS<Gammes, GammesDP, GammesDTO> {
        private PartnersDP _partnersDP;

        public GammesBS() {
            _partnersDP = new PartnersDP();
        }
        protected override GammesDTO ToDTO(Gammes entity) {
            GammesDTO dto = base.ToDTO(entity);
            dto.Init(_partnersDP);
            return dto;
        }
    }
}
