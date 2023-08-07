namespace Ticsa.DAL.Models {
    public class Orders : StdEntity, IOrder {
        public DateTime OrderDate { get; set; }
        public string OrderTag { get; set; }
        public Guid IdPartner { get; set; }
    }
    public interface IOrder : IStdEntity {
        public DateTime OrderDate { get; }
        public string OrderTag { get; }
        public Guid IdPartner { get; }
    }
}
