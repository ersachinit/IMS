using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SpiritWorx.DAL;
using SpiritWorx.BO;

namespace SpiritWorx.BL
{
    public class MenuRepository
    {

        #region Add/Update MenuNav
        /// <summary>
        /// Add/Update MenuNav
        /// </summary>
        /// <returns></returns>
        public static bool AddUpdateMenu(MenuNav entity)
        {
            var sqlMenuNav = new SqlMenu();
            bool isAddUpdated = sqlMenuNav.AddUpdateMenu(entity);
            return isAddUpdated;
        }
        #endregion

        #region Get the MenuNav

        /// <summary>
        /// Get the MenuNav.
        /// </summary>
        /// <returns>Collection of MenuNav.</returns>
        public static IList<MenuNav> GetMenus()
        {
            var sqlMenu = new SqlMenu();
            return sqlMenu.GetMenus();
        }

        #endregion

        #region Get the MenuNav By Role
        /// <summary>
        /// Get the MenuNav By Role.
        /// </summary>
        /// <returns>Collection of MenuNav.</returns>
        public static IList<MenuNav> GetMenusByRole(int roleId)
        {
            var sqlMenu = new SqlMenu();
            return sqlMenu.GetMenusByRole(roleId);
        }
        #endregion



        #region Delete MenuNav
        /// <summary>
        /// Deletes an MenuNav from the database based on MenuNav Id.
        /// </summary>
        /// <param name="dtMenuNavId"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public static bool DeleteMenu(DataTable dtMenuNavId)
        {
            if (dtMenuNavId.Rows.Count > 0)
            {
                SqlMenu sqlMenuNav = new SqlMenu();
                return sqlMenuNav.DeleteMenu(dtMenuNavId);
            }
            return false;

        }
        #endregion
    }
}