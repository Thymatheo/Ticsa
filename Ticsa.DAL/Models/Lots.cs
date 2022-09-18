namespace Ticsa.DAL.Models {
    public class Lots : StdEntity {
        public string Label { get; set; }
        public int Quantity { get; set; }
        public int IdGamme { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
