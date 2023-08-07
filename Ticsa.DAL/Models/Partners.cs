namespace Ticsa.DAL.Models {
    public class Partners : StdEntity, IPartner {
        public Guid IdPartnerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string PostalAddress { get; set; }
        public int PostalCode { get; set; }

    }
    public interface IPartner : IStdEntity {
        public Guid IdPartnerType { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string CompanyName { get; }
        public string Email { get; }
        public int PhoneNumber { get; }
        public string PostalAddress { get; }
        public int PostalCode { get; }

    }
}
