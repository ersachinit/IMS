using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using SpiritWorx.BO;
using SpiritWorx.DAL;

namespace SpiritWorx.BL
{
    public class SubMenuRepository
    {
        #region Add/Update SubMenu
        /// <summary>
        /// Add/Update SubMenu
        /// </summary>
        /// <returns></returns>
        public static bool AddUpdateSubMenu(SubMenu entity)
        {
            var sqlSubMenu = new SqlSubMenu();
            bool isAddUpdated = sqlSubMenu.AddUpdateSubMenu(entity);
            return isAddUpdated;
        }
        #endregion

        #region Get the SubMenu
        /// <summary>
        /// Get the SubMenu.
        /// </summary>
        /// <returns>Collection of SubMenu.</returns>
        public static IList<SubMenu> GetSubMenus()
        {
            var sqlSubMenu = new SqlSubMenu();
            return sqlSubMenu.GetSubMenus();
        }

        #endregion

        #region Get the SubMenu
        /// <summary>
        /// Get the SubMenu.
        /// </summary>
        /// <returns>Collection of SubMenu.</returns>
        public static SubMenu GetSubMenu(int id,bool ? isAddPage = null)
        {
            var sqlSubMenu = new SqlSubMenu();
            return sqlSubMenu.GetSubMenu(id, isAddPage);
        }

        #endregion


        #region Delete SubMenu
        /// <summary>
        /// Deletes an SubMenu from the database based on SubMenu Id.
        /// </summary>
        /// <param name="dtSubMenuId"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public static bool DeleteSubMenu(DataTable dtSubMenuId)
        {
            if (dtSubMenuId.Rows.Count > 0)
            {
                SqlSubMenu sqlSubMenu = new SqlSubMenu();
                return sqlSubMenu.DeleteSubMenu(dtSubMenuId);
            }
            return false;

        }
        #endregion


        #region Get the Sub Menus by Role 
        /// <summary>
        /// Get the Sub Menus by Role .
        /// </summary>
        /// <returns>Collection of SubMenu.</returns>
        public static IList<SubMenu> GetSubMenusByRole(int id,int roleId)
        {
            var sqlSubMenu = new SqlSubMenu();
            return sqlSubMenu.GetSubMenusByRole(id,roleId);
        }

        #endregion

            
        public static void PopulateSubMenuInRepater(Repeater subMenuRpt, int id,int ? roleId = null)
        {
            var menus = GetSubMenusByRole(id,1);
            if (menus != null)
            {
                subMenuRpt.DataSource = menus;
                subMenuRpt.DataBind();
            }
        }
    }
}