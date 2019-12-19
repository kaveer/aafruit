using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer.Helper
{
    public static class clsCommon
    {
        public static MeasurementType GetMeasurementType(int measurementId)
        {
            MeasurementType result = new MeasurementType();

            switch (measurementId)
            {
                case (int)MeasurementType.Gram:
                    result = MeasurementType.Gram;
                    break;
                case (int)MeasurementType.Dekagram:
                    result = MeasurementType.Dekagram;
                    break;
                case (int)MeasurementType.Hectogram:
                    result = MeasurementType.Hectogram;
                    break;
                case (int)MeasurementType.Kilogram:
                    result = MeasurementType.Kilogram;
                    break;
                case (int)MeasurementType.Ton:
                    result = MeasurementType.Ton;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
