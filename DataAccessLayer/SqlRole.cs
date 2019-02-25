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
    public class SqlRole
    {
        SqlHelper sqlHelper = new SqlHelper();
        private readonly string _connectionString;

        public SqlRole()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[DbConstant.ConnectionString];
            if (connectionString == null)
                throw new Exception(DbConstant.ErrorConnection);
            _connectionString = connectionString.ConnectionString;
        }

        #region Add Update a Role
        /// <summary>
        /// Add Update a  Role into the database.
        /// </summary>
        /// <param name="entity">object of Role class to be added/updated.</param>
        /// <returns>
        /// Returns true if add is successful, else false.
        /// </returns>
        public bool AddUpdateRole(Role entity)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                bool isAddUpdated = false;
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Role.StoreProcedure.usp_AddUpdateUserRole, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.Role.DbParameter.Id, entity.Id);
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramRole = new SqlParameter(DbConstant.Role.DbParameter.RoleName, entity.RoleName);
                    cmd.Parameters.Add(paramRole);

                    SqlParameter paramIsActive = new SqlParameter(DbConstant.Role.DbParameter.IsActive, entity.IsActive);
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

        #region Get the Role
        /// <summary>
        /// Get the Role.
        /// </summary>
        /// <returns>Collection of Role.</returns>
        public IList<Role> GetRoles()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Role.StoreProcedure.usp_SelectUserRole, cn, true))
                {
                    IList<Role> listRole = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listRole = new List<Role>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Role Role = new Role();
                                Role.Id = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.Id]);
                                Role.RoleName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.Role.DbColumn.RoleName]);
                                Role.IsActive = TypeConversionUtility.ToBoolean(reader[DbConstant.Role.DbColumn.IsActive]);
                                Role.CreatedDate = TypeConversionUtility.ToDateTime(reader[DbConstant.Role.DbColumn.CreatedDate]);
                                listRole.Add(Role);
                            }
                        }
                        cn.Close();
                    }
                    return listRole;
                }
            }
        }
        #endregion


        #region Get the Menus
        /// <summary>
        /// Get the Menus.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of Menus.</returns>
        public IList<Role> GetMenus(int ? id= null)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Role.StoreProcedure.usp_SelectMenuOrSubMenu, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.Role.DbParameter.Id, id);
                    cmd.Parameters.Add(paramId);

                    IList<Role> listRole = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listRole = new List<Role>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Role Role = new Role();
                                Role.MenuId = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.MenuId]);
                                Role.MenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.Role.DbColumn.MenuName]);
                                Role.SubMenuId = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.SubMenuId]);
                                Role.SubMenuName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.Role.DbColumn.SubMenuName]);
                                Role.MenuLink = TypeConversionUtility.ToStringWithNull(reader[DbConstant.SubMenu.DbColumn.MenuLink]);
                                listRole.Add(Role);
                            }
                        }
                        cn.Close();
                    }
                    return listRole;
                }
            }
        }
        #endregion

        #region Add Menu Permission
        /// <summary>
        /// Add Menu Permission from the database.
        /// </summary>
        /// <param name="dtMenu"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        public bool AddUpdateMenu(DataTable dtMenu)
        {
            int effectedRows = 0;
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Role.StoreProcedure.usp_AddUpdatePermission, cn, true))
                {
                    SqlParameter paramdtProductType = new SqlParameter(DbConstant.DbTypeParameter.MenuPermissionTableType, SqlDbType.Structured);
                    paramdtProductType.Value = dtMenu;
                    paramdtProductType.TypeName = DbConstant.DbTypeName.MenuPermissionTableType;
                    cmd.Parameters.Add(paramdtProductType);

                    cn.Open();
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            return effectedRows > 0;
        }
        #endregion

        #region Get the Menus
        /// <summary>
        /// Get the Menus.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection of Menus.</returns>
        public IList<Role> GetMenusByRoleId(int? id = null)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Role.StoreProcedure.usp_SelectPermission, cn, true))
                {
                    SqlParameter paramId = new SqlParameter(DbConstant.Role.DbParameter.Id, id);
                    cmd.Parameters.Add(paramId);

                    IList<Role> listRole = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        listRole = new List<Role>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Role role = new Role();
                                role.Id = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.RoleId]);
                                role.MenuId = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.MenuId]);
                                role.SubMenuId = TypeConversionUtility.ToInteger(reader[DbConstant.Role.DbColumn.SubMenuId]);
                                listRole.Add(role);
                            }
                        }
                        cn.Close();
                    }
                    return listRole;
                }
            }
        }
        #endregion


        #region Delete Role
        /// <summary>
        /// Deletes an Role from the database based on Id.
        /// </summary>
        /// <param name="dtRole"></param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public bool DeleteRole(DataTable dtRole)
        {
            int effectedRows = 0;
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.Role.StoreProcedure.usp_DeleteRole, cn, true))
                {
                    SqlParameter paramdtResinPricing = new SqlParameter(DbConstant.DbTypeParameter.EntityIdIntTableType, SqlDbType.Structured);
                    paramdtResinPricing.Value = dtRole;
                    paramdtResinPricing.TypeName = DbConstant.DbTypeName.EntityIdIntTableType;
                    cmd.Parameters.Add(paramdtResinPricing);

                    SqlParameter paramdIsDeleted = new SqlParameter(DbConstant.DbParameters.IsDeleted, SqlDbType.Int);
                    paramdIsDeleted.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramdIsDeleted);

                    cn.Open();
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            return effectedRows > 0;
        }//end Delete
        #endregion

    }
}