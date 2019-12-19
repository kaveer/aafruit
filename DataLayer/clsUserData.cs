using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataLayer
{
    public class clsUserData
    {
        private readonly string connectionString;
        private SqlConnection connection = new SqlConnection();

        public clsUserData()
        {
            connectionString = ConfigurationManager.AppSettings["appctxt"];
        }

        public DataSet Login(string email, string password, UserType userType)
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserGetUserIdByEmailAndPassword", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@password", password));
            command.Parameters.Add(new SqlParameter("@usertype", (int)userType));

            data.Load(command.ExecuteReader());
            if (data?.Rows.Count == 0)
                throw new FormatException("Invalid username and password");

            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        public DataSet GetUserByUserDetailId(int userDetailsId)
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserDetailsRetrieve", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userDetailsId", userDetailsId));

            data.Load(command.ExecuteReader());
            if (data?.Rows.Count == 0)
                throw new Exception();
            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        public DataSet GetFruitByFruitId(int fruitId)
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblFruitGetByFruitId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@fruitId", fruitId));

            data.Load(command.ExecuteReader());
            if (data?.Rows.Count == 0)
                throw new Exception();
            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        public void Setting(clsUserDetailsModel item)
        {
            UpdateUser(item);
            UpdateUserDetails(item);
        }

        public DataSet SignUp(clsUserDetailsModel item)
        {
            DataSet result = new DataSet();
            DataTable userData = new DataTable();
            DataTable userDetailsData = new DataTable();

            userData = SaveUserData(item);
            if (userData.Rows.Count == 0)
                throw new Exception();

            item.iUserId = Convert.ToInt32(userData.Rows[0][0]);
            userDetailsData = SaveUserDetails(item);

            result.Tables.Add(userData);
            result.Tables.Add(userDetailsData);

            return result;
        }

        public DataSet ViewOrder(bool isStaff, int customerId, OrderType orderType)
        {
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblOrderRetrieve", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@isStaff", isStaff));
            command.Parameters.Add(new SqlParameter("@userDetailsId", customerId));
            command.Parameters.Add(new SqlParameter("@orderType", (int)orderType));

            data.Load(command.ExecuteReader());
           
            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        private DataTable SaveUserData(clsUserDetailsModel item)
        {
            DataTable result = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserSave", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@email", item.sUsername));
            command.Parameters.Add(new SqlParameter("@password", item.sPassword));

            result.Load(command.ExecuteReader());
            if (result?.Rows.Count == 0)
                throw new Exception();

            if (connection != null)
                connection.Close();

            return result;
        }

        private DataTable SaveUserDetails(clsUserDetailsModel item)
        {
            DataTable result = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserDetailsSave", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userId", item.iUserId));
            command.Parameters.Add(new SqlParameter("@userTypeId", (int)item.eUserType));
            command.Parameters.Add(new SqlParameter("@status", item.bStatus));

            command.Parameters.Add(new SqlParameter("@name", item.sName));
            command.Parameters.Add(new SqlParameter("@surnmae", item.sSurname));
            command.Parameters.Add(new SqlParameter("@address", item.sAddress));
            command.Parameters.Add(new SqlParameter("@countryId", item.iCountryId));

            command.Parameters.Add(new SqlParameter("@email", item.sEmail));
            command.Parameters.Add(new SqlParameter("@fix", item.sFixLine));
            command.Parameters.Add(new SqlParameter("@mobile", item.sMobile));
            command.Parameters.Add(new SqlParameter("@web", item.sWebsite));
            command.Parameters.Add(new SqlParameter("@fax", item.sFax));

            command.Parameters.Add(new SqlParameter("@company", item.sCompany));
            command.Parameters.Add(new SqlParameter("@brn", item.sBRN));
            command.Parameters.Add(new SqlParameter("@note", item.sNote));

            result.Load(command.ExecuteReader());
            if (result?.Rows.Count == 0)
                throw new Exception();

            if (connection != null)
                connection.Close();

            return result;
        }

        private void UpdateUser(clsUserDetailsModel item)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserupdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userId", item.iUserId));
            command.Parameters.Add(new SqlParameter("@email", item.sUsername));
            command.Parameters.Add(new SqlParameter("@password", item.sPassword));

            command.ExecuteNonQuery();
        }

        private void UpdateUserDetails(clsUserDetailsModel item)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserDetailsUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userDetailsId", item.iUserDetailsId));
            command.Parameters.Add(new SqlParameter("@userId", item.iUserId));
            command.Parameters.Add(new SqlParameter("@userTypeId", (int)item.eUserType));
            command.Parameters.Add(new SqlParameter("@status", item.bStatus));

            command.Parameters.Add(new SqlParameter("@name", item.sName));
            command.Parameters.Add(new SqlParameter("@surnmae", item.sSurname));
            command.Parameters.Add(new SqlParameter("@address", item.sAddress));
            command.Parameters.Add(new SqlParameter("@countryId", item.iCountryId));

            command.Parameters.Add(new SqlParameter("@email", item.sEmail));
            command.Parameters.Add(new SqlParameter("@fix", item.sFixLine));
            command.Parameters.Add(new SqlParameter("@mobile", item.sMobile));

            command.Parameters.Add(new SqlParameter("@company", item.sCompany));
            command.Parameters.Add(new SqlParameter("@brn", item.sBRN));
            command.Parameters.Add(new SqlParameter("@note", item.sNote));

            command.Parameters.Add(new SqlParameter("@web", item.sWebsite));
            command.Parameters.Add(new SqlParameter("@fax", item.sFax));

            command.ExecuteNonQuery();

            if (connection != null)
                connection.Close();
        }
    }
}
