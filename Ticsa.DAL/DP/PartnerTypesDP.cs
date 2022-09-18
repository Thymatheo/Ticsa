using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnerTypesDP : StdDP<PartnerTypes> {
        public PartnerTypesDP() : base("PartnerTypes") {
        }

        protected override object BuildAddParam(PartnerTypes entity) => new {
            InputLabelPartnerTypes = entity.Label
        };

        protected override object BuildDeleteParam(int id) => new {
            InputIdPartnerTypes = id
        };

        protected override object BuildGetByIdParam(int id) => new {
            InputIdPartnerTypes = id
        };

        protected override object BuildUpdateParam(PartnerTypes entity) => new {

            InputToPutLabelPartnerTypes = entity.Label,
            InputIdPartnerTypes = entity.Id
        };
    }
}
