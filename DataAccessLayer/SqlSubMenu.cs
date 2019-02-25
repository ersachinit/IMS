using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SpiritWorx.Utility;
using SpiritWorx.BO;

namespace SpiritWorx.DAL
{
    public class SqlSubMenu
    {
        SqlHelper sqlHelper = new SqlHelper();
        private readonly string _connectionString;

        public SqlSubMenu()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[DbConstant.ConnectionString];
            if (connectionString == null)
                throw new Exception(DbConstant.ErrorConnection);
            _connectionString = connectionString.ConnectionString;
        }

        #region Add Update a SubMenu
        /// <summary>
        /// Add Update a  SubMenu into the database.
        /// </summary>
        /// <param name="entity">object of SubMenu class to be added/updated.</param>
        /// <returns>
        /// Returns true if add is successful, else false.
        /// </returns>
        public bool AddUpdateSubMenu(SubMenu entity)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                bool isAddUpdated = false;
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.SubMenu.StoreProcedure.usp_AddUpdateSubMenu, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.SubMenu.DbParameter.Id, entity.Id);
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramSubMenu = new SqlParameter(DbConstant.SubMenu.DbParameter.SubMenuName, entity.SubMenuName);
                    cmd.Parameters.Add(paramSubMenu);

                    SqlParameter paramMenuLinku = new SqlParameter(DbConstant.SubMenu.DbParameter.MenuLink, entity.MenuLink);
                    cmd.Parameters.Add(paramMenuLinku);

                    SqlParameter paramMenuId = new SqlParameter(DbConstant.SubMenu.DbParameter.MenuId, entity.MenuId);
                    cmd.Parameters.Add(paramMenuId);

                    SqlParameter paramDisplayOrder = new SqlParameter(DbConstant.SubMenu.DbParameter.DisplayOrder, entity.DisplayOrder);
                    cmd.Parameters.Add(paramDisplayOrder);

                    SqlParameter paramListPageHeading = new SqlParameter(DbConstant.SubMenu.DbParameter.ListPageHeading, entity.ListPageHeading);
                    cmd.Parameters.Add(paramListPageHeading);

                    SqlParameter paramListPageDescription = new SqlParameter(DbConstant.SubMenu.DbParameter.ListPageDescription, entity.ListPageDescription);
                    cmd.Parameters.Add(paramListPageDescription);

                    SqlParameter paramListAddPageHeading = new SqlParameter(DbConstant.SubMenu.DbParameter.AddPageHeading, entity.AddPageHeading);
                    cmd.Parameters.Add(paramListAddPageHeading);

                    SqlParameter paramAddPageDescription = new SqlParameter(DbConstant.SubMenu.DbParameter.AddPageDescription, entity.AddPageDescription);
                    cmd.Parameters.Add(paramAddPageDescription);

                    SqlParameter paramIsAddPage = new SqlParameter(DbConstant.SubMenu.DbParameter.IsAddPage, entity.IsAddPage);
                    cmd.Parameters.Add(paramIsAddPage);

                    SqlParameter paramIsActive = new SqlParameter(DbConstant.SubMenu.DbParameter.IsActive, entity.IsActive);
                    cmd.Parameters.Add(paramIsActive);

                    cn.Open();
                    var id = cmd.ExecuteScalar();
                    entity.Id = TypeConversionUtility.ToInteger(id);
                    isAddUpdated = entity.Id > 0;
                }
                return isAddUpdated;
            }
        }
        #endregion

        #region Get the SubMenu
        /// <summary>
        /// Get the SubMenu.
        /// </summary>
        /// <returns>Collection of SubMenu.</returns>
        public IList<SubMenu> GetSubMenus()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.SubMenu.StoreProcedure.usp_SelectSubMenu, cn, true))
                {
                    IList<SubMenu> SubMenus = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        SubMenus = new List<SubMenu>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                SubMenu SubMenu = new SubMenu();
                                SubMenu.Id = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.Id]);
                                SubMenu.MenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.MenuName]);
                                SubMenu.SubMenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.SubMenuName]);
                                SubMenu.MenuId = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.MenuId]);
                                SubMenu.DisplayOrder = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.DisplayOrder]);
                                SubMenu.IsActive = TypeConversionUtility.ToBoolean(reader[DbConstant.SubMenu.DbColumn.IsActive]);
                                SubMenu.CreatedDate = TypeConversionUtility.ToDateTime(reader[DbConstant.SubMenu.DbColumn.CreatedDate]);
                                SubMenus.Add(SubMenu);
                            }
                        }
                        cn.Close();
                    }
                    return SubMenus;
                }
            }
        }
        #endregion

        #region Get the SubMenu
        /// <summary>
        /// Get the SubMenu.
        /// </summary>
        /// <returns>Details of SubMenu.</returns>
        public SubMenu GetSubMenu(int id,bool ? isAddPage)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.SubMenu.StoreProcedure.usp_SelectSubMenu, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.SubMenu.DbParameter.Id, id);
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramIsAddPage = new SqlParameter(DbConstant.SubMenu.DbParameter.IsAddPage, isAddPage);
                    cmd.Parameters.Add(paramIsAddPage);

                    SubMenu subMenus = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        subMenus = new SubMenu();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                subMenus.Id = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.Id]);
                                subMenus.MenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.MenuName]);
                                subMenus.MenuLink = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.MenuLink]);
                                subMenus.SubMenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.SubMenuName]);
                                subMenus.ListPageHeading = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.ListPageHeading]);
                                subMenus.ListPageDescription = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.ListPageDescription]);
                                subMenus.AddPageHeading = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.AddPageHeading]);
                                subMenus.AddPageDescription = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.AddPageDescription]);
                                subMenus.IsAddPage = TypeConversionUtility.ToBoolean(reader[DbConstant.SubMenu.DbColumn.IsAddPage]);
                                subMenus.MenuId = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.MenuId]);
                                subMenus.DisplayOrder = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.DisplayOrder]);
                                subMenus.IsActive = TypeConversionUtility.ToBoolean(reader[DbConstant.SubMenu.DbColumn.IsActive]);
                                subMenus.CreatedDate = TypeConversionUtility.ToDateTime(reader[DbConstant.SubMenu.DbColumn.CreatedDate]);
                            }
                        }
                        cn.Close();
                    }
                    return subMenus;
                }
            }
        }
        #endregion
        #region Get the Sub Menus by Role
        /// <summary>
        /// Get the Sub Menus by Role.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleId"></param>
        /// <returns>Collection of Sub Menus.</returns>
        public IList<SubMenu> GetSubMenusByRole(int? id = null, int ? roleId = null)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.SubMenu.StoreProcedure.usp_SelectSubMenuByRole, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.Role.DbParameter.Id, id);
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramRoleId = new SqlParameter(DbConstant.Menu.DbParameter.RoleId, roleId);
                    cmd.Parameters.Add(paramRoleId);

                    IList<SubMenu> listSubMenu = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listSubMenu = new List<SubMenu>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                SubMenu subMenu = new SubMenu();
                                subMenu.Id = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.Id]);
                                subMenu.MenuId = TypeConversionUtility.ToInteger(reader[DbConstant.SubMenu.DbColumn.MenuId]);
                                subMenu.MenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.MenuName]);
                                subMenu.SubMenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.SubMenuName]);
                                subMenu.MenuLink = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.MenuLink]);
                                listSubMenu.Add(subMenu);
                            }
                        }
                        cn.Close();
                    }
                    return listSubMenu;
                }
            }
        }
        #endregion

        #region Delete SubMenu
        /// <summary>
        /// Deletes an SubMenu from the database based on SubMenu Id.
        /// </summary>
        /// <param name="dtSubMenuId"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public bool DeleteSubMenu(DataTable dtSubMenuId)
        {
            int effectedRows = 0;
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.SubMenu.StoreProcedure.usp_DeleteSubMenu, cn, true))
                {
                    SqlParameter paramdtSubMenu = new SqlParameter(DbConstant.DbTypeParameter.EntityIdIntTableType, SqlDbType.Structured);
                    paramdtSubMenu.Value = dtSubMenuId;
                    paramdtSubMenu.TypeName = DbConstant.DbTypeName.EntityIdIntTableType;
                    cmd.Parameters.Add(paramdtSubMenu);
                    cn.Open();
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            return effectedRows > 0;

        }//end Delete
        #endregion


    }//end class
}//end region