using BusinessDataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CommonDataAccess
    {
        public static string CompanyName
        {
            get { return "Diary"; }
        }
        public static List<BDMMenus> GetMenuByRole(string roleId)
        {
            List<BDMMenus> menuList = new List<BDMMenus>();
            using (SqlConnection con = new SqlConnection(ConnectionDB.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetMenuByRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.NVarChar).Value = roleId;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        menuList.Add(new BDMMenus()
                        {
                            MenuId = dr.GetInt32(dr.GetOrdinal("MenuId")),
                            MenuName = dr.GetString(dr.GetOrdinal("MenuName")),
                            MenuIcon = dr.GetString(dr.GetOrdinal("MenuIcon")),
                            MenuLink = dr.GetString(dr.GetOrdinal("MenuLink")),
                            ParentId = dr.GetInt32(dr.GetOrdinal("ParentId")),
                            DisplayOrder = dr.GetInt32(dr.GetOrdinal("DisplayOrder")),
                            Status = dr.GetBoolean(dr.GetOrdinal("Status")),
                        });
                    }
                }
            }
            return menuList;
        }
    }
}
