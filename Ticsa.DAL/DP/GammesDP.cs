using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class GammesDP : StdDP<Gammes> {
        private static readonly Lazy<GammesDP> _instance = new(() => new());
        public static GammesDP Instance => _instance.Value;
    }
}
