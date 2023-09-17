namespace Ticsa.DAL.Models {
    public class PartnerTypes : StdEntity, IPartnerType {
        public string? Label { get; set; }
    }
    public interface IPartnerType : IStdEntity {
        public string? Label { get; }
    }
}
