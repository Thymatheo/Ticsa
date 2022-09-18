using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class StdBS<T, U> where T : StdEntity, new() where U : StdDP<T>, new() {
        protected readonly U _dp;
        public StdBS() {
            _dp = new();
        }

        public virtual async Task<IEnumerable<T?>> GetAll() =>
            await _dp.GetAll();
        public virtual async Task<T?> GetById(int id) =>
           await _dp.GetById(id);
        public virtual async Task<bool> Delete(int id) =>
            await _dp.Delete(id);
        public virtual async Task<T?> Add(T entity) =>
            await _dp.Add(entity);
        public virtual async Task<T?> Update(T entity) =>
            await _dp.Update(entity);
    }
}
