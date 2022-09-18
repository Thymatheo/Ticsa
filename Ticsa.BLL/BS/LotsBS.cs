using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.BS {
    public class LotsBS : StdBS<Lots, LotsDP> {
        public async Task<IEnumerable<Lots?>> GetByIdGamme(int idGamme) =>
            await _dp.GetbyIdGamme(idGamme);
    }
}
