namespace Ticsa.DAL.Models {
    public class DeliveryCoupons : StdEntity, IDeliveryCoupon {
        public Guid IdOrder { get; set; }
        public Guid IdPartner { get; set; }
        public string? Label { get; set; }
        public DateTime RecieveDate { get; set; }
        public string? FilePath { get; set; }
    }
    public interface IDeliveryCoupon : IStdEntity {
        public Guid IdOrder { get; }
        public Guid IdPartner { get; }
        public string? Label { get; }
        public DateTime RecieveDate { get; }
        public string? FilePath { get; }
    }
}
