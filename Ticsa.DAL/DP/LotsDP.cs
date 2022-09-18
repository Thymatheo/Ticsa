using Dapper;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class LotsDP : StdDP<Lots> {
        public LotsDP() : base("Lots") {
        }

        public async Task<IEnumerable<Lots?>> GetbyIdGamme(int idGamme) => await GetConnection().QueryAsync<Lots?>($"{_SpGetAllLabel}ByIdGamme", new {
            InputIdGammeLots = idGamme
        }, commandType: System.Data.CommandType.StoredProcedure);

        protected override object BuildAddParam(Lots entity) => new {
            InputLabelLots = entity.Label,
            InputQuantityLots = entity.Quantity,
            InputIdGammeLots = entity.IdGamme,
            InputEntryDateLots = entity.EntryDate,
            InputExpirationDateLots = entity.ExpirationDate,
        };

        protected override object BuildDeleteParam(int id) => new {
            InputIdLots = id,
        };

        protected override object BuildGetByIdParam(int id) => new {
            InputIdLots = id,
        };

        protected override object BuildUpdateParam(Lots entity) => new {
            InputToPutLabelLots = entity.Label,
            InputToPutQuantityLots = entity.Quantity,
            InputToPutIdGammeLots = entity.IdGamme,
            InputToPutEntryDateLots = entity.EntryDate,
            InputToPutExpirationDateLots = entity.ExpirationDate,
            InputIdLots = entity.Id
        };
    }
}
