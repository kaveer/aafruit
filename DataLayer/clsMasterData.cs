using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ViewModel;

namespace DataLayer
{
    public class clsMasterData
    {
        private readonly string connectionString;
        private SqlConnection connection = new SqlConnection();

        public clsMasterData()
        {
            connectionString = ConfigurationManager.AppSettings["appctxt"];
        }

        public DataSet RetrieveCountry()
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadCountryMasterDataFail));

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblCountryRetrieve", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            data.Load(command.ExecuteReader());
            if (data?.Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadCountryMasterDataFail));

            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        public DataSet RetrieveDiscount()
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblDiscountRetrieve", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            data.Load(command.ExecuteReader());
            if (data?.Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        public DataSet RetrieveFruits()
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblFruitRetrieve", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            data.Load(command.ExecuteReader());
            if (data?.Rows.Count == 0)
                throw new Exception(Convert.ToString((int)ErrorStatus.LoadDiscountMasterDataFail));

            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }
    }
}
