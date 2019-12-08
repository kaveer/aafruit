using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class StockSummary
    {

        public clsFruitModel objFruit { get; set; }
        public List<clsStockModel> lstStock { get; set; }
    }
    class clsStockModel
    {
        public clsUserDetailsModel objUserDetails { get; set; }
        public int iStockId { get; set; }
        public bool bStatus { get; set; }
        public DateTime dDeliveryDate { get; set; }
        public string sNote { get; set; }
        public decimal deQuantityAdded { get; set; }
    }
}
