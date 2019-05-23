using DataAccessLayer;
using System.Collections.Generic;
using BusinessDataModel;
namespace BusinessAccessLayer
{
    public class CommonBAL
    {
        public List<BDMMenus> GetMenuByRole(string roleId)
        {
            return CommonDataAccess.GetMenuByRole(roleId);
        }
        public static string ConnectionString()
        {
            return ConnectionDB.ConnectionString;
        }
    }
}
