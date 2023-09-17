using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;
using Ticsa.DAL.Models.Interfaces;

namespace Ticsa.BLL.DTOs {
    public class PartnersDTO : IPartnersTypeDpendency, IDTO<Partners>, IPartner {
        public PartnerTypes? PartnerType { get; set; }
        public Partners? BaseEntity { get; set; }
        public Guid IdPartnerType => BaseEntity!.IdPartnerType;
        public string FirstName => BaseEntity!.FirstName!;
        public string LastName => BaseEntity!.LastName!;
        public string CompanyName => BaseEntity!.CompanyName!;
        public string Email => BaseEntity!.Email!;
        public int PhoneNumber => BaseEntity!.PhoneNumber;
        public string PostalAddress => BaseEntity!.PostalAddress!;
        public int PostalCode => BaseEntity!.PostalCode;
        public Guid Id => BaseEntity!.Id;

        public PartnersDTO Init(PartnerTypesDP partnersDP) {
            (this as IPartnersTypeDpendency).Init(partnersDP);
            return this;
        }
    }
}
