using Dapper;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class PartnersDP : StdDP<Partners> {
        public PartnersDP() : base("Partners") {
        }

        public async Task<IEnumerable<Partners>> GetByIdType(int idType) => await GetConnection().QueryAsync<Partners>($"{_SpGetAllLabel}ByIdPartnerType", new {
            InputIdPartnerTypePartners = idType
        }, commandType: System.Data.CommandType.StoredProcedure);

        protected override object BuildAddParam(Partners entity) => new {
            InputIdPartnerTypePartners = entity.IdPartnerType,
            InputFirstNamePartners = entity.FirstName,
            InputLastNamePartners = entity.LastName,
            InputCompanyNamePartners = entity.CompanyName,
            InputEmailPartners = entity.Email,
            InputPhoneNumberPartners = entity.PhoneNumber,
            InputPostalAddressPartners = entity.PostalAddress,
            InputPostalCodePartners = entity.PostalCode
        };

        protected override object BuildDeleteParam(int id) => new {
            InputIdPartners = id
        };

        protected override object BuildGetByIdParam(int id) => new {
            InputIdPartners = id
        };

        protected override object BuildUpdateParam(Partners entity) => new {
            InputIdPartnerTypePartners = entity.IdPartnerType,
            InputFirstNamePartners = entity.FirstName,
            InputLastNamePartners = entity.LastName,
            InputCompanyNamePartners = entity.CompanyName,
            InputEmailPartners = entity.Email,
            InputPhoneNumberPartners = entity.PhoneNumber,
            InputPostalAddressPartners = entity.PostalAddress,
            InputPostalCodePartners = entity.PostalCode,
            InputIdPartners = entity.Id
        };
    }
}
