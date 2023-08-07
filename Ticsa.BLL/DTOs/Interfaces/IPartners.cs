using Ticsa.DAL.DP;

namespace Ticsa.DAL.Models.Interfaces {
    public interface IPartnersDependency {
        public Guid IdPartner { get; }
        public Partners? Partner { get; set; }
    }
    public static partial class Extention {
        public static void Init(this IPartnersDependency partner, PartnersDP partners) {
            if (partner.Partner == null)
                partner.Partner = partners.Get(partner.IdPartner)!;
        }
    }
}
