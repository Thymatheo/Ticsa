using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnersDP : StdDP<Partners> {
        private static readonly Lazy<PartnersDP> _instance = new(() => new());
        public static PartnersDP Instance => _instance.Value;
        public IEnumerable<Partners> GetByIdType(Guid idType) => GetsBy(x => x.IdPartnerType == idType);
    }
}
