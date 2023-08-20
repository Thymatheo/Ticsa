using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnerTypesDP : StdDP<PartnerTypes> {
        private static readonly Lazy<PartnerTypesDP> _instance = new(() => new());
        public static PartnerTypesDP Instance => _instance.Value;
        public const string CLIENT_TYPE = "Client";
        public const string PRODUCER_TYPE = "Producer";
        public PartnerTypesDP() {
            if (Entities.Count == 0) {
                Add(new PartnerTypes() { Label = CLIENT_TYPE });
                Add(new PartnerTypes() { Label = PRODUCER_TYPE });
            }
        }
        public PartnerTypes GetClient() => GetBy(x => x?.Label == CLIENT_TYPE)!;
        public PartnerTypes GetProducer() => GetBy(x => x?.Label == PRODUCER_TYPE)!;
    }
}
