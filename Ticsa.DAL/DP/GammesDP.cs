using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class GammesDP : StdDP<Gammes> {
        public GammesDP() : base("Gammes") {
        }

        protected override object BuildAddParam(Gammes entity) => new {
            entity.IdPartner,
            entity.Label,
            entity.Summary,
        };

        protected override object BuildUpdateParam(Gammes entity) => new {
            entity.IdPartner,
            entity.Label,
            entity.Summary,
            entity.Id
        };
    }
}
