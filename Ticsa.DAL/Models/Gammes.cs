namespace Ticsa.DAL.Models {
    public class Gammes : StdEntity, IGamme {
        public Guid IdPartner { get; set; }
        public string Label { get; set; }
        public string Summary { get; set; }
    }
    public interface IGamme : IStdEntity{
        public Guid IdPartner { get; }
        public string Label { get; }
        public string Summary { get; }
    }
}
