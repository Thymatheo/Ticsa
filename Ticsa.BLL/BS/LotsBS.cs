using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class LotsBS : StdBS<Lots, LotsDP, LotsDTO> {
        private static readonly Lazy<LotsBS> _instance = new(() => new());
        public static LotsBS Instance => _instance.Value;
        private GammesDP _gammesDP;

        public LotsBS() {
            _gammesDP = GammesDP.Instance;
            _dp = LotsDP.Instance;
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
