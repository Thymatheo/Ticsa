using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class LotsDP : StdDP<Lots> {
        private static readonly Lazy<LotsDP> _instance = new(() => new());
        public static LotsDP Instance => _instance.Value;
        public IEnumerable<Lots?> GetbyIdGamme(Guid idGamme) => GetsBy(x => x.IdGamme == idGamme);
    }
}
