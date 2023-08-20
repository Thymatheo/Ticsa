using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class PartnerTypesBS : StdBS<PartnerTypes, PartnerTypesDP, PartnerTypesDTO> {
        private static readonly Lazy<PartnerTypesBS> _instance = new(() => new());
        public static PartnerTypesBS Instance => _instance.Value;
        public PartnerTypesBS() {
            _dp = PartnerTypesDP.Instance;
        }
    }
}
