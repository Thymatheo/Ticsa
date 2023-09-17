using System.Data.SqlClient;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public abstract class StdDP<T> where T : StdEntity, new() {
        protected Entities<T> Entities;
        public StdDP() {
            this.Entities = new();
        }

        public IEnumerable<T> Gets() => Entities;
        public T? Get(Guid id) => Entities.FirstOrDefault(x => x!.Id == id, null);
        public T Add(T entity) {
            entity.Id = Guid.NewGuid();
            return Entities.Add(entity);
        }
        public T Update(T entity) =>
            Entities.Update(entity);

        public bool Delete(Guid id) =>
            Entities.Delete(id);
        public bool Deletes(Predicate<T> match) =>
            Entities.DeleteAll(match);

        public IEnumerable<T> GetsBy(Func<T, bool> predicate) => Entities.Where(predicate);
        public T? GetBy(Func<T?, bool> predicate) => Entities.FirstOrDefault(predicate);

    }
}
