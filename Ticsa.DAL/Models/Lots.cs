namespace Ticsa.DAL.Models {
    public class Lots : StdEntity, ILot {
        public string? Label { get; set; }
        public int Quantity { get; set; }
        public Guid IdGamme { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
    public interface ILot : IStdEntity {
        public string? Label { get; }
        public int Quantity { get; }
        public Guid IdGamme { get; }
        public DateTime EntryDate { get; }
        public DateTime ExpirationDate { get; }
    }
}
