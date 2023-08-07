namespace Ticsa.DAL.Models {
    public class OrderContents : StdEntity, IOrderContent {
        public Guid IdOrder { get; set; }
        public Guid IdLot { get; set; }
        public int Quantity { get; set; }
    }
    public interface IOrderContent : IStdEntity {
        public Guid IdOrder { get; }
        public Guid IdLot { get; }
        public int Quantity { get; }
    }
}
