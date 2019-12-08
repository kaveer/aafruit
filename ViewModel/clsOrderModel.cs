using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class clsOrderModel
    {
        public int iOrderId { get; set; }
        public OrderType eOrderType { get; set; }
        public clsUserDetailsModel objUserDetails { get; set; }
        public clsFruitModel objFruit { get; set; }
        public DateTime dRequestedDate { get; set; }
        public DateTime dDeadline { get; set; }
        public decimal deTotalPrice { get; set; }
        public bool bHasDiscount { get; set; }
        public string sDiscount { get; set; }
        public decimal deTotalPriceAfterDiscount { get; set; }
        public bool bStatus { get; set; }

    }
}
