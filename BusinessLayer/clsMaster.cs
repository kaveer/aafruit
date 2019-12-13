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
    }
}
