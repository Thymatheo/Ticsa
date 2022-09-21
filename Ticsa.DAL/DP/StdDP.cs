using Dapper;
using System.Data.SqlClient;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public abstract class StdDP<T> where T : StdEntity, new() {
        protected string _SpGetAllLabel;
        protected string _SpGetByIdLabel;
        protected string _SpAddLabel;
        protected string _SpUpdateLabel;
        protected string _SpDeleteLabel;
        public SqlConnection GetConnection() =>
            new(DatabaseConfig.DBConnectionString);

        public StdDP(string labelDP) {
            _SpAddLabel = $"Post{labelDP}";
            _SpUpdateLabel = $"Put{labelDP}";
            _SpDeleteLabel = $"Delete{labelDP}";
            _SpGetAllLabel = $"GetAll{labelDP}";
            _SpGetByIdLabel = $"Get{labelDP}";
        }

        public async Task<IEnumerable<T>> GetAll() =>
            await GetConnection().QueryAsync<T>($"{_SpGetAllLabel}", commandType: System.Data.CommandType.StoredProcedure);
        public async Task<T> GetById(int id) =>
            (await GetConnection().QueryAsync<T>($"{_SpGetByIdLabel}", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
        public async Task<T> Add(T entity) =>
            (await GetConnection().QueryAsync<T>($"{_SpAddLabel}", BuildAddParam(entity), commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault() ?? throw new Exception($"Fail to add entity typeof({typeof(T).Name})");
        public async Task<T> Update(T entity) =>
            (await GetConnection().ExecuteAsync($"{_SpUpdateLabel}", entity, commandType: System.Data.CommandType.StoredProcedure)) != 0 ? entity : throw new Exception($"Fail to update entity typeof({typeof(T).Name})");
        public async Task<bool> Delete(int id) =>
            (await GetConnection().ExecuteAsync($"{_SpDeleteLabel}", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure)) != 0 ? true : throw new Exception($"Fail to delete entity typeof({typeof(T).Name})");

        protected abstract object BuildAddParam(T entity);
    }
}
