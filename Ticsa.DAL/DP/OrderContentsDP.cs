﻿using Dapper;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class OrderContentsDP : StdDP<OrderContents> {
        public OrderContentsDP() : base("OrderContents") {
        }


        public async Task<IEnumerable<OrderContents>> GetByIdOrder(int idOrder) => await GetConnection().QueryAsync<OrderContents>($"{_SpGetAllLabel}ByIdOrder", new { IdOrder = idOrder }, commandType: System.Data.CommandType.StoredProcedure);

        protected override object BuildAddParam(OrderContents entity) => new {
            entity.IdOrder,
            entity.IdLot,
            entity.Quantity,
        };

        protected override object BuildUpdateParam(OrderContents entity) => new {
            entity.IdOrder,
            entity.IdLot,
            entity.Quantity,
            entity.Id
        };
    }
}
