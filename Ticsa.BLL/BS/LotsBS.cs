using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class LotsBS : StdBS<Lots, LotsDP, LotsDTO> {
        private GammesDP _gammesDP;

        public LotsBS() {
            _gammesDP = new();
        }
        protected override LotsDTO ToDTO(Lots entity) {
            LotsDTO dto = base.ToDTO(entity);
            dto.Init(_gammesDP);
            return dto;
        }
        public IEnumerable<LotsDTO?> GetByIdGamme(Guid idGamme) =>
             _dp.GetbyIdGamme(idGamme).Select(ToDTO);
    }
}
