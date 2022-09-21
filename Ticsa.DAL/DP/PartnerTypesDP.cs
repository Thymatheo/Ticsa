using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnerTypesDP : StdDP<PartnerTypes> {
        public PartnerTypesDP() : base("PartnerTypes") {
        }

        protected override object BuildAddParam(PartnerTypes entity) => new {
            entity.Label
        };

        protected override object BuildUpdateParam(PartnerTypes entity) => new {
            entity.Label,
            entity.Id
        };
    }
}
