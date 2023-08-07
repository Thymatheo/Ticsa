using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class LotsDP : StdDP<Lots> {
        public LotsDP() {
        }
        public IEnumerable<Lots?> GetbyIdGamme(Guid idGamme) => GetsBy(x => x.IdGamme == idGamme);
    }
}
