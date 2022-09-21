using Dapper;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnersDP : StdDP<Partners> {
        public PartnersDP() : base("Partners") {
        }

        public async Task<IEnumerable<Partners>> GetByIdType(int idType) => await GetConnection().QueryAsync<Partners>($"{_SpGetAllLabel}ByIdPartnerType", new { IdPartnerType = idType }, commandType: System.Data.CommandType.StoredProcedure);

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

        protected override object BuildUpdateParam(Partners entity) => new {
            entity.Email,
            entity.FirstName,
            entity.LastName,
            entity.PhoneNumber,
            entity.PostalCode,
            entity.CompanyName,
            entity.IdPartnerType,
            entity.PostalAddress,
            entity.Id
        };
    }
}
