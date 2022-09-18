using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class PartnersBS : StdBS<Partners, PartnersDP> {
        public async Task<IEnumerable<Partners?>> GetByIdType(int idType) =>
            await _dp.GetByIdType(idType);
    }
}
