using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
    public class clsMaster
    {
        clsMasterData masterData = new clsMasterData();

        public List<clsCountryModel> RetrieveCountry()
        {
            List<clsCountryModel> result = new List<clsCountryModel>();
            DataSet dataSet = new DataSet();

            dataSet = masterData.RetrieveCountry();
            if (dataSet?.Tables?.Count == 0 || dataSet?.Tables[0].Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadCountryMasterDataFail));

            if (dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsCountryModel country = new clsCountryModel()
                    {
                        iCountryId = Convert.ToInt32(item[0]),
                        sCountryName = item[1].ToString()
                    };
                    result.Add(country);
                }
            }

            return result;
        }

        public List<clsDiscountModel> RetrieveDiscount()
        {
            List<clsDiscountModel> result = new List<clsDiscountModel>();
            DataSet dataSet = new DataSet();

            dataSet = masterData.RetrieveDiscount();
            if (dataSet?.Tables?.Count == 0 || dataSet?.Tables[0].Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            if (dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsDiscountModel discount = new clsDiscountModel()
                    {
                        iDiscountId = Convert.ToInt32(item[0]),
                        iValue = Convert.ToInt32(item[1]),
                        dePriceRange = Convert.ToInt32(item[2]),
                        dePriceRangeMax = Convert.ToInt32(item[3])

                    };
                    result.Add(discount);
                }
            }

            return result;
        }

        public List<clsMeasurementUnitModel> RetrieveMeasurement()
        {
            List<clsMeasurementUnitModel> result = new List<clsMeasurementUnitModel>();
            DataSet dataSet = new DataSet();

            dataSet = masterData.RetrieveMeasurementUnit();
            if (dataSet?.Tables?.Count == 0 || dataSet?.Tables[0].Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            if (dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsMeasurementUnitModel measurement = new clsMeasurementUnitModel()
                    {
                        iMeasurementId = Convert.ToInt32(item[0]),
                        sMeasurement = item[1].ToString(),
                    };
                    result.Add(measurement);
                }
            }

            return result;
        }

        public List<clsUserTypeModel> RetrieveUserType()
        {
            List<clsUserTypeModel> result = new List<clsUserTypeModel>();
            DataSet dataSet = new DataSet();

            dataSet = masterData.RetrieveUserType();
            if (dataSet?.Tables?.Count == 0 || dataSet?.Tables[0].Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            if (dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsUserTypeModel user = new clsUserTypeModel()
                    {
                        iUserTypeId = Convert.ToInt32(item[0]),
                        sUserType = item[1].ToString(),
                    };
                    result.Add(user);
                }
            }

            return result;
        }

        public List<clsFruitModel> RetrieveFruits()
        {
            List<clsFruitModel> result = new List<clsFruitModel>();
            DataSet dataSet = new DataSet();

            dataSet = masterData.RetrieveFruits();
            if (dataSet?.Tables?.Count == 0 || dataSet?.Tables[0].Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            if (dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsFruitModel discount = new clsFruitModel()
                    {
                        iFruitId = Convert.ToInt32(item[0]),
                        sFruitName = item[1].ToString(),
                    };
                    result.Add(discount);
                }
            }

            return result;
        }
    }
}
