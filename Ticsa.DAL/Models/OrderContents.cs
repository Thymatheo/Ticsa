namespace Ticsa.DAL.Models {
    public class OrderContents : StdEntity {
        public int IdOrder { get; set; }
        public int IdLot { get; set; }
        public int Quantity { get; set; }
    }
}
