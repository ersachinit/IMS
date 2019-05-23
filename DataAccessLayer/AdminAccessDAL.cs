using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdminAccessDAL
    {
        DataAccess obData = new DataAccess();
        private static string conStr = ConnectionDB.ConnectionString;
        SqlConnection con = new SqlConnection(conStr);
        DataTable dt = null;
        SqlDataAdapter da = null;

        public DataTable GetTypeList(int Id = 0)
        {
            SqlCommand cmd = new SqlCommand("sp_Masters", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            try
            {
                if (Id != 0)
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                }
                da.Fill(dt);
                return dt;
            }
            catch (SqlException)
            {
                return dt;
            }
            finally
            {
                da.Dispose();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }
    }
}
