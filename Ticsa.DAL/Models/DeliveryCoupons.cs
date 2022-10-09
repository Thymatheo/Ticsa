using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticsa.DAL.Models {
    public class DeliveryCoupons : StdEntity {
        public int IdOrder { get; set; }
        public int IdPartner { get; set; }
        public string Label { get; set; }
        public DateTime RecieveDate { get; set; }
        public string? FilePath { get; set; }
    }
}
