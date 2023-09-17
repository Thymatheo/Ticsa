using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;
using Ticsa.DAL.Models.Interfaces;

namespace Ticsa.BLL.DTOs {
    public class GammesDTO : IPartnersDependency, IDTO<Gammes>, IGamme {
        public Partners? Partner { get; set; }
        public Guid IdPartner => BaseEntity!.IdPartner;
        public Gammes? BaseEntity { get; set; }
        public string Label => BaseEntity!.Label!;
        public string Summary => BaseEntity!.Summary!;
        public Guid Id => BaseEntity!.Id;

        public GammesDTO Init(PartnersDP partnersDP) {
            (this as IPartnersDependency).Init(partnersDP);
            return this;
        }
    }
}
