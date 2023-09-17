using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.DTOs {
    public class PartnerTypesDTO : IDTO<PartnerTypes>, IPartnerType {
        public PartnerTypes? BaseEntity { get; set; }
        public string Label => BaseEntity!.Label!;
        public Guid Id => BaseEntity!.Id;
    }
}
