using Dapper;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrderContentsDP : StdDP<OrderContents> {
        public OrderContentsDP() : base("OrderContents") {
        }


        public async Task<IEnumerable<OrderContents>> GetByIdOrder(int idOrder) => await GetConnection().QueryAsync<OrderContents>($"{_SpGetAllLabel}ByIdOrder", new {
            InputIdOrderOrderContents = idOrder
        }, commandType: System.Data.CommandType.StoredProcedure);

        protected override object BuildAddParam(OrderContents entity) => new {
            InputIdOrderOrderContents = entity.IdOrder,
            InputIdLotOrderContents = entity.IdLot,
            InputQuantityOrderContents = entity.Quantity
        };

        protected override object BuildDeleteParam(int id) => new {
            InputIdOrderContents = id
        };

        protected override object BuildGetByIdParam(int id) => new {
            InputIdOrderContents = id
        };

        protected override object BuildUpdateParam(OrderContents entity) => new {
            InputToPutIdOrderOrderContents = entity.IdOrder,
            InputToPutIdLotOrderContents = entity.IdLot,
            InputToPutQuantityOrderContents = entity.Quantity,
            InputIdOrderContents = entity.Id
        };
    }
}
