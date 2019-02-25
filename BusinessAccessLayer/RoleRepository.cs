using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using SpiritWorx.DAL;
using SpiritWorx.BO;

namespace SpiritWorx.BL
{
    public class RoleRepository
    {
        #region Add/Update Role

        /// <summary>
        /// Add/Update Role
        /// </summary>
        /// <returns></returns>
        public static bool AddUpdateRole(Role entity)
        {
            var sqlRole = new SqlRole();
            bool isAddUpdated = sqlRole.AddUpdateRole(entity);
            return isAddUpdated;
        }

        #endregion

        #region Get the Role

        /// <summary>
        /// Get the Role.
        /// </summary>
        /// <returns>Collection of Role.</returns>
        public static IList<Role> GetRoles()
        {
            var sqlRole = new SqlRole();
            return sqlRole.GetRoles();
        }

        #endregion

        #region Get the Menus

        /// <summary>
        /// Get the Menus.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of Menus.</returns>
        public static IList<Role> GetMenus(int? id = null)
        {
            var sqlRole = new SqlRole();
            return sqlRole.GetMenus(id);
        }

        #endregion

        #region

        /// <summary>
        /// Add Menu Permission from the database.
        /// </summary>
        /// <param name="dtMenu"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        public static bool AddUpdateMenu(DataTable dtMenu)
        {
            if (dtMenu.Rows.Count > 0)
            {
                var sqlRole = new SqlRole();
                return sqlRole.AddUpdateMenu(dtMenu);
            }
            return false;
        }

        #endregion


        public static void PopulateSubMenuInCheckBoxList(CheckBoxList chkSubMenu, int? id = null)
        {
            var menus = GetMenus(id);
            if (menus != null)
            {
                chkSubMenu.DataSource = menus;
                chkSubMenu.DataTextField = "SubMenuName";
                chkSubMenu.DataValueField = "SubMenuId";
                chkSubMenu.DataBind();
            }
        }




        #region Get the Menus

        /// <summary>
        /// Get the Menus.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of Menus.</returns>
        public static IList<Role> GetMenusByRoleId(int? id = null)
        {
            var sqlRole = new SqlRole();
            return sqlRole.GetMenusByRoleId(id);
        }

        #endregion

        #region Delete Role

        /// <summary>
        /// Deletes an Role from the database based on Id.
        /// </summary>
        /// <param name="dtRole"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public static bool DeleteRole(DataTable dtRole)
        {
            var sqlRole = new SqlRole();
            return sqlRole.DeleteRole(dtRole);
        }

        #endregion
    }//end class
}//end namespace