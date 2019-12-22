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

        public static OrderType  GetOrderType(int orderId)
        {
            OrderType result = new OrderType();

            switch (orderId)
            {
                case (int)OrderType.Pending:
                    result = OrderType.Pending;
                    break;
                case (int)OrderType.Processing:
                    result = OrderType.Processing;
                    break;
                case (int)OrderType.AwaitPayment:
                    result = OrderType.AwaitPayment;
                    break;
                case (int)OrderType.ReadyForDelivery:
                    result = OrderType.ReadyForDelivery;
                    break;
                case (int)OrderType.Delivered:
                    result = OrderType.Delivered;
                    break;
                case (int)OrderType.Returned:
                    result = OrderType.Returned;
                    break;
                case (int)OrderType.Hold:
                    result = OrderType.Hold;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
