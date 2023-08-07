using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.DTOs.Interfaces {
    public interface IPartnersTypeDpendency {
        public Guid IdPartnerType { get; }
        public PartnerTypes? PartnerType { get; set; }
    }
    public static partial class Extention {
        public static void Init(this IPartnersTypeDpendency partnerType, PartnerTypesDP partnerTypes) {
            if (partnerType.PartnerType == null)
                partnerType.PartnerType = partnerTypes.Get(partnerType.IdPartnerType)!;
        }
    }
}
