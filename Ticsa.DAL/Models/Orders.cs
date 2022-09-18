namespace Ticsa.DAL.Models {
    public class Orders : StdEntity {
        public DateTime OrderDate { get; set; }
        public string OrderTag { get; set; }
        public int IdPartner { get; set; }
    }
}
