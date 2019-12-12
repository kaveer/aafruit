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

        public DataSet GetUserByUserDetailId(int userDetails)
        {
            return null;
        }

        public void Setting(clsUserDetailsModel item)
        {

        }

        public DataSet SignUp(clsUserDetailsModel item)
        {
            return null;
        }

        public DataSet ViewOrder(bool isStaff, int customerId, OrderType orderType)
        {
            return null;
        }
    }
}
