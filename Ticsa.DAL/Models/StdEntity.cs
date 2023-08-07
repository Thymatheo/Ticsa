namespace Ticsa.DAL.Models {
    public abstract class StdEntity {
        public Guid Id { get; set; }
    }
    public interface IStdEntity {
        public Guid Id { get; }
    }
}
