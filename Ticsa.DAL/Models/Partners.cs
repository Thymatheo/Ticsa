namespace Ticsa.DAL.Models {
    public class Partners : StdEntity {
        public int IdPartnerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string PostalAddress { get; set; }
        public int PostalCode { get; set; }

    }
}
