using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class GammesBS : StdBS<Gammes, GammesDP, GammesDTO> {
        private static readonly Lazy<GammesBS> _instance = new(() => new());
        public static GammesBS Instance => _instance.Value;
        private PartnersDP _partnersDP;

        public GammesBS() {
            _partnersDP = PartnersDP.Instance;
            _dp = GammesDP.Instance;
        }
        protected override GammesDTO ToDTO(Gammes entity) {
            GammesDTO dto = base.ToDTO(entity);
            dto.Init(_partnersDP);
            return dto;
        }
    }
}
