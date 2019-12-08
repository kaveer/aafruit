using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class clsFruitModel
    {
        public int iFruitId { get; set; }
        public string sFruitName { get; set; }
        public string sDescription { get; set; }
        public decimal deQuantity { get; set; }
        public MeasurementType eMeasurement { get; set; }
        public bool bStatus { get; set; }
        public decimal deUnitPrice { get; set; }
    }
}
