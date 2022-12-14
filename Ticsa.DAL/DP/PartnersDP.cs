using Dapper;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnersDP : StdDP<Partners> {
        public PartnersDP(){
        }

        public async Task<IEnumerable<Partners>> GetByIdType(int idType) => await GetConnection().QueryAsync<Partners>($"{_SpGetByIdLabel}ByIdPartnerType", new { IdPartnerType = idType }, commandType: System.Data.CommandType.StoredProcedure);

        protected override object BuildAddParam(Partners entity) => new {
            entity.Email,
            entity.FirstName,
            entity.LastName,
            entity.PhoneNumber,
            entity.PostalCode,
            entity.CompanyName,
            entity.IdPartnerType,
            entity.PostalAddress
        };
    }
}
