using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class clsReportModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<StockSummaryModel> Purchase { get; set; }
        public List<clsOrderModel> Sales { get; set; }
    }
}
