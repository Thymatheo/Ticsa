using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class GammesDP : StdDP<Gammes> {
        public GammesDP() : base("Gammes") {
        }

        protected override object BuildAddParam(Gammes entity) => new {
            InputLabelGammes = entity.Label,
            InputSummaryGammes = entity.Summary,
            InputIdPartnerGammes = entity.IdPartner
        };

        protected override object BuildDeleteParam(int id) => new {
            InputIdGammes = id
        };

        protected override object BuildGetByIdParam(int id) => new {
            InputIdGammes = id
        };

        protected override object BuildUpdateParam(Gammes entity) => new {
            InputToPutLabelGammes = entity.Label,
            InputToPutSummaryGammes = entity.Summary,
            InputToPutIdPartnerGammes = entity.IdPartner,
            InputIdGammes = entity.Id
        };
    }
}
