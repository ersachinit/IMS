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
    public class SqlMenu
    {
        SqlHelper sqlHelper = new SqlHelper();
        private readonly string _connectionString;

        public SqlMenu()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[DbConstant.ConnectionString];
            if (connectionString == null)
                throw new Exception(DbConstant.ErrorConnection);
            _connectionString = connectionString.ConnectionString;
        }

        #region Add Update a Menu
        /// <summary>
        /// Add Update a  Menu into the database.
        /// </summary>
        /// <param name="entity">object of Menu class to be added/updated.</param>
        /// <returns>
        /// Returns true if add is successful, else false.
        /// </returns>
        public bool AddUpdateMenu(MenuNav entity)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                bool isAddUpdated = false;
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Menu.StoreProcedure.usp_AddUpdateMenu, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.Menu.DbParameter.Id, entity.Id);
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramMenu = new SqlParameter(DbConstant.Menu.DbParameter.MenuName, entity.MenuName);
                    cmd.Parameters.Add(paramMenu);

                    SqlParameter paramDisplayOrder = new SqlParameter(DbConstant.Menu.DbParameter.DisplayOrder, entity.DisplayOrder);
                    cmd.Parameters.Add(paramDisplayOrder);

                    SqlParameter paramIsActive = new SqlParameter(DbConstant.Menu.DbParameter.IsActive, entity.IsActive);
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

        #region Get the Menu
        /// <summary>
        /// Get the Menu.
        /// </summary>
        /// <returns>Collection of Menu.</returns>
        public IList<MenuNav> GetMenus()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Menu.StoreProcedure.usp_SelectMenu, cn, true))
                {
                    IList<MenuNav> listMenuNav = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listMenuNav = new List<MenuNav>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                MenuNav menuNav = new MenuNav();
                                menuNav.Id = TypeConversionUtility.ToInteger(reader[DbConstant.Menu.DbColumn.Id]);
                                menuNav.MenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.Menu.DbColumn.MenuName]);
                                menuNav.DisplayOrder = TypeConversionUtility.ToInteger(reader[DbConstant.Menu.DbColumn.DisplayOrder]);
                                menuNav.IsActive = TypeConversionUtility.ToBoolean(reader[DbConstant.Menu.DbColumn.IsActive]);
                                menuNav.CreatedDate = TypeConversionUtility.ToDateTime(reader[DbConstant.Menu.DbColumn.CreatedDate]);
                                listMenuNav.Add(menuNav);
                            }
                        }
                        cn.Close();
                    }
                    return listMenuNav;
                }
            }
        }
        #endregion
        #region Delete Menu
        /// <summary>
        /// Deletes an Menu from the database based on Menu Id.
        /// </summary>
        /// <param name="dtMenuId"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public bool DeleteMenu(DataTable dtMenuId)
        {
            int effectedRows = 0;
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Menu.StoreProcedure.usp_DeleteMenu, cn, true))
                {
                    SqlParameter paramdtMenu = new SqlParameter(DbConstant.DbTypeParameter.EntityIdIntTableType, SqlDbType.Structured);
                    paramdtMenu.Value = dtMenuId;
                    paramdtMenu.TypeName = DbConstant.DbTypeName.EntityIdIntTableType;
                    cmd.Parameters.Add(paramdtMenu);

                    SqlParameter paramdIsDeleted = new SqlParameter(DbConstant.DbParameters.IsDeleted, SqlDbType.Int);
                    paramdIsDeleted.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramdIsDeleted);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    effectedRows = TypeConversionUtility.ToInteger(cmd.Parameters[DbConstant.DbParameters.IsDeleted].Value);
                }
            }
            return effectedRows > 0;

        }
        #endregion

        #region Get the Menus By Role
        /// <summary>
        /// Get the Menus By Role.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of Menus.</returns>
        public IList<MenuNav> GetMenusByRole(int? roleId = null)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Menu.StoreProcedure.usp_SelectRoleByMenu, cn, true))
                {
                    SqlParameter paramRoleId = new SqlParameter(DbConstant.Menu.DbParameter.RoleId, roleId);
                    cmd.Parameters.Add(paramRoleId);

                    IList<MenuNav> listMenuNav = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listMenuNav = new List<MenuNav>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                MenuNav menuNav = new MenuNav();
                                menuNav.Id = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.Id]);
                                menuNav.MenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.Role.DbColumn.MenuName]);
                                listMenuNav.Add(menuNav);
                            }
                        }
                        cn.Close();
                    }
                    return listMenuNav;
                }
            }
        }
        #endregion
    }//end Class
}//end namespace