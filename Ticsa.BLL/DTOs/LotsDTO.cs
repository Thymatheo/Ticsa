using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.DTOs {
    public class LotsDTO : IGammesDependency, IDTO<Lots>, ILot {
        public Gammes? Gamme { get; set; }
        public Lots? BaseEntity { get; set; }
        public Guid IdGamme => BaseEntity!.IdGamme;
        public string Label => BaseEntity!.Label!;
        public int Quantity => BaseEntity!.Quantity;
        public DateTime EntryDate => BaseEntity!.EntryDate;
        public DateTime ExpirationDate => BaseEntity!.ExpirationDate;
        public Guid Id => BaseEntity!.Id;

        public LotsDTO Init(GammesDP gammesDP) {
            (this as IGammesDependency).Init(gammesDP);
            return this;
        }
    }
}
