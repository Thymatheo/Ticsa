using Ticsa.BLL.DTOs.Interfaces;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class StdBS<T, U, V> where T : StdEntity, new() where U : StdDP<T>, new() where V : IDTO<T>, new() {
        protected readonly U _dp;
        public StdBS() {
            _dp = new();
        }

        public virtual IEnumerable<V?> Gets() =>
             _dp.Gets().Select(ToDTO);
        public virtual V? Get(Guid id) =>
            ToDTO(_dp.Get(id)!);
        public virtual V? GetBy(Func<T?, bool> predicate) =>
            ToDTO(_dp.GetBy(predicate)!);
        public virtual IEnumerable<V?> GetsBy(Func<T, bool> predicate) =>
            _dp.GetsBy(predicate).Select(ToDTO);
        public virtual bool Delete(Guid id) =>
            _dp.Delete(id);
        public virtual V? Add(T entity) =>
            ToDTO(_dp.Add(entity));
        public virtual V? Update(T entity) =>
            ToDTO(_dp.Update(entity));
        protected virtual V ToDTO(T entity) => (V)new V().Set(entity);
    }
}
