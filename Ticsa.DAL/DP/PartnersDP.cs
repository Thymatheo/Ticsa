using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnersDP : StdDP<Partners> {
        public PartnersDP() {
        }
        public IEnumerable<Partners> GetByIdType(Guid idType) => GetsBy(x => x.IdPartnerType == idType);
    }
}
