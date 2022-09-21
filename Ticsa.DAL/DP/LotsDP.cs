using Dapper;
using System.Data.SqlTypes;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class LotsDP : StdDP<Lots> {
        public LotsDP() : base("Lots") {
        }

        public async Task<IEnumerable<Lots?>> GetbyIdGamme(int idGamme) => await GetConnection().QueryAsync<Lots?>($"{_SpGetAllLabel}ByIdGamme", new { IdGamme = idGamme }, commandType: System.Data.CommandType.StoredProcedure);

        protected override object BuildAddParam(Lots entity) => new {
            entity.Label,
            entity.IdGamme,
            entity.EntryDate,
            entity.ExpirationDate,
            entity.Quantity

        };

        protected override object BuildUpdateParam(Lots entity) => new {
            entity.Label,
            entity.IdGamme,
            entity.EntryDate,
            entity.ExpirationDate,
            entity.Quantity,
            entity.Id
        };
    }
}
