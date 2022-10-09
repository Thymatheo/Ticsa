using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class GammesDP : StdDP<Gammes> {
        public GammesDP() {
        }

        protected override object BuildAddParam(Gammes entity) => new {
            entity.IdPartner,
            entity.Label,
            entity.Summary,
        };
    }
}
