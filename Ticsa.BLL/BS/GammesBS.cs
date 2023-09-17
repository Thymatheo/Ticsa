using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class GammesBS : StdBS<Gammes, GammesDP, GammesDTO> {
        private static readonly Lazy<GammesBS> _instance = new(() => new());
        public static GammesBS Instance => _instance.Value;
        private PartnersDP _partnersDP;
        private readonly LotsDP _lotsDP;

        public GammesBS() {
            _partnersDP = PartnersDP.Instance;
            _lotsDP = LotsDP.Instance;
            _dp = GammesDP.Instance;
        }
        protected override GammesDTO ToDTO(Gammes entity) {
            GammesDTO dto = base.ToDTO(entity);
            dto.Init(_partnersDP);
            return dto;
        }
        public override bool Delete(Guid id) {
            _lotsDP.Deletes(x => x.IdGamme == id);
            return base.Delete(id);
        }
    }
}
