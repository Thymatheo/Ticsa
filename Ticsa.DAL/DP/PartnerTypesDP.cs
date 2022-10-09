using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnerTypesDP : StdDP<PartnerTypes> {
        public PartnerTypesDP() {
        }

        protected override object BuildAddParam(PartnerTypes entity) => new {
            entity.Label
        };
    }
}
