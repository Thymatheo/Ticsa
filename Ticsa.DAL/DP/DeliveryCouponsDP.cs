using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticsa.DAL.Models;

namespace Ticsa.DAL.DP {
    public class DeliveryCouponsDP : StdDP<DeliveryCoupons> {
        protected override object BuildAddParam(DeliveryCoupons entity) => new {
            entity.IdOrder,
            entity.IdPartner,
            entity.Label,
            entity.RecieveDate,
            entity.FilePath
        };
    }
}
