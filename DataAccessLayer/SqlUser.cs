using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SpiritWorx.BO;
using SpiritWorx.Utility;

namespace SpiritWorx.DAL
{
    /// <summary>
    /// Class SqlUser.
    /// </summary>
    public class SqlUser
    {
        /// <summary>
        /// The _connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlUser" /> class.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public SqlUser()
        {
            var connectionString = SqlHelper.GetConnectionString();
            if (connectionString == null)
                throw new Exception(DbConstant.ErrorConnection);
            _connectionString = connectionString;
        }

        #region Add Update a User
        /// <summary>
        /// Add Update a User into the database.
        /// </summary>
        /// <param name="entity">object of User class to be added/updated.</param>
        /// <returns>Returns true if add is successful, else false.</returns>
        public bool AddUpdateUser(User entity)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                bool isAddUpdated = false;
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_AddUpdateUser, cn, true))
                {
                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.Id, entity.Id);
                    cmd.Parameters.Add(paramUserId);

                    SqlParameter paramFirstName = new SqlParameter(DbConstant.Parameter.FirstName, entity.FirstName);
                    cmd.Parameters.Add(paramFirstName);

                    SqlParameter paramLastName = new SqlParameter(DbConstant.Parameter.LastName, entity.LastName);
                    cmd.Parameters.Add(paramLastName);

                    SqlParameter paramEmailAddress = new SqlParameter(DbConstant.Parameter.Email, entity.Email);
                    cmd.Parameters.Add(paramEmailAddress);

                    SqlParameter paramStatus = new SqlParameter(DbConstant.Parameter.Status, (byte)entity.Status);
                    cmd.Parameters.Add(paramStatus);

                    SqlParameter paramUserType = new SqlParameter(DbConstant.Parameter.UserType, (byte)entity.UserType);
                    cmd.Parameters.Add(paramUserType);

                    SqlParameter paramPassword = new SqlParameter(DbConstant.Parameter.Password, entity.Password);
                    cmd.Parameters.Add(paramPassword);

                    SqlParameter paramProfileImage = new SqlParameter(DbConstant.Parameter.ProfileImage, entity.ProfileImage);
                    cmd.Parameters.Add(paramProfileImage);

                    SqlParameter paramPhoneNumber = new SqlParameter(DbConstant.Parameter.PhoneNumber, entity.PhoneNumber);
                    cmd.Parameters.Add(paramPhoneNumber);

                    SqlParameter paramSchoolName = new SqlParameter(DbConstant.Parameter.SchoolName, entity.SchoolName);
                    cmd.Parameters.Add(paramSchoolName);

                    SqlParameter paramAccountType = new SqlParameter(DbConstant.Parameter.AccountType, entity.AccountType.Id);
                    cmd.Parameters.Add(paramAccountType);

                    SqlParameter paramPhoneNumberType = new SqlParameter(DbConstant.Parameter.PhoneNumberType, entity.PhoneNumberType);
                    cmd.Parameters.Add(paramPhoneNumberType);

                    SqlParameter paramAddress1 = new SqlParameter(DbConstant.Parameter.Address1, entity.Address1);
                    cmd.Parameters.Add(paramAddress1);

                    SqlParameter paramAddress2 = new SqlParameter(DbConstant.Parameter.Address2, entity.Address2);
                    cmd.Parameters.Add(paramAddress2);

                    SqlParameter paramCity = new SqlParameter(DbConstant.Parameter.City, entity.City);
                    cmd.Parameters.Add(paramCity);



                    SqlParameter paramZipCode = new SqlParameter(DbConstant.Parameter.ZipCode, entity.ZipCode);
                    cmd.Parameters.Add(paramZipCode);

                    SqlParameter paramSchoolDistric = new SqlParameter(DbConstant.Parameter.SchoolDistrict, entity.SchoolDistrict);
                    cmd.Parameters.Add(paramSchoolDistric);

                    SqlParameter paramApprovedVendor = new SqlParameter(DbConstant.Parameter.ApprovedVendor, entity.ApprovedVendor);
                    cmd.Parameters.Add(paramApprovedVendor);

                    SqlParameter paramIsTaxExempt = new SqlParameter(DbConstant.Parameter.IsTaxExempt, entity.IsTaxExempt);
                    cmd.Parameters.Add(paramIsTaxExempt);



                    SqlParameter paramTaxExempt = new SqlParameter(DbConstant.Parameter.TaxExempt, entity.TaxExempt);
                    cmd.Parameters.Add(paramTaxExempt);

                    SqlParameter paramTaxExemptPath = new SqlParameter(DbConstant.Parameter.TaxExemptFile, entity.TaxExemptFile);
                    cmd.Parameters.Add(paramTaxExemptPath);


                    SqlParameter paramAccountCategory = new SqlParameter(DbConstant.Parameter.AccountCategory, entity.AccountCategory.Id);
                    cmd.Parameters.Add(paramAccountCategory);
                    if (entity.AccountCategory.IsOther)
                    {
                        SqlParameter paramCategoryName = new SqlParameter(DbConstant.Parameter.CategoryName, entity.AccountCategory.CategoryName);
                        cmd.Parameters.Add(paramCategoryName);
                    }

                    SqlParameter paramSchoolCampusId = new SqlParameter(DbConstant.Parameter.SchoolCampusId, entity.SchoolCampus.Id);
                    cmd.Parameters.Add(paramSchoolCampusId);
                    if (entity.SchoolCampus.IsOther)
                    {
                        SqlParameter paramCampusName = new SqlParameter(DbConstant.Parameter.CampusName, entity.SchoolCampus.CampusName);
                        cmd.Parameters.Add(paramCampusName);
                    }

                    SqlParameter paramStateId = new SqlParameter(DbConstant.Parameter.StateId, entity.State.Id);
                    cmd.Parameters.Add(paramStateId);
                    if (entity.State.IsOther)
                    {
                        SqlParameter paramStateName = new SqlParameter(DbConstant.Parameter.StateName, entity.State.StateName);
                        cmd.Parameters.Add(paramStateName);
                    }

                    SqlParameter paramSchoolTypeId = new SqlParameter(DbConstant.Parameter.SchoolTypeId, entity.SchoolType.Id);
                    cmd.Parameters.Add(paramSchoolTypeId);
                    if (entity.SchoolType.IsOther)
                    {
                        SqlParameter paramSchoolTypeName = new SqlParameter(DbConstant.Parameter.SchoolTypeName, entity.SchoolType.SchoolTypeName);
                        cmd.Parameters.Add(paramSchoolTypeName);
                    }
                    SqlParameter paramIsSchoolDistrictExempt = new SqlParameter(DbConstant.Parameter.IsSchoolDistrictExempt, entity.IsSchoolDistrictExempt);
                    cmd.Parameters.Add(paramIsSchoolDistrictExempt);

                    SqlParameter paramIsNotifications = new SqlParameter(DbConstant.Parameter.IsNotifications, entity.IsNotifications);
                    cmd.Parameters.Add(paramIsNotifications);

                    SqlParameter paramCellPhone = new SqlParameter(DbConstant.Parameter.CellPhone, entity.CellPhone);
                    cmd.Parameters.Add(paramCellPhone);

                    cn.Open();
                    var id = cmd.ExecuteScalar();
                    entity.Id = TypeConversionUtility.ToInteger(id);
                    isAddUpdated = entity.Id > 0;
                }
                return isAddUpdated;
            }
        }
        #endregion

        #region Get the User
        /// <summary>
        /// Gets the user based on User ID.
        /// </summary>
        /// <param name="userId">The User ID to be loaded.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <param name="status">The status.</param>
        /// <returns>Object of <see cref="User" />.</returns>
        public User GetUser(int? userId, string emailAddress, string password, Enums.Status status)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_GetUser, cn, true))
                {
                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.Id, userId);
                    cmd.Parameters.Add(paramUserId);

                    SqlParameter paramEmailAddress = new SqlParameter(DbConstant.Parameter.Email, emailAddress);
                    cmd.Parameters.Add(paramEmailAddress);

                    SqlParameter paramPassword = new SqlParameter(DbConstant.Parameter.Password, password);
                    cmd.Parameters.Add(paramPassword);

                    if (status != Enums.Status.NotDefined)
                    {
                        SqlParameter paramStatus = new SqlParameter(DbConstant.Parameter.Status, status);
                        cmd.Parameters.Add(paramStatus);
                    }

                    User user = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                user = new User();
                                user.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.Id]);
                                user.FirstName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.FirstName]);
                                user.LastName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.LastName]);
                                user.Status = (Enums.Status)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.Status]);
                                user.UserType = (Enums.UserType)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.UserType]);
                                user.Email = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Email]);
                                user.Password = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Password]);
                                user.ProfileImage = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.ProfileImage]);
                                user.PhoneNumber = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.PhoneNumber]);
                                user.SchoolName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.SchoolName]);
                                user.DateCreated = TypeConversionUtility.ToDateTime(reader[DbConstant.DbColumn.DateCreated]);
                                user.PromoCode = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.PromoCode]);
                                user.SYId = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.SYId]);
                                user.IsGiftFree = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsGiftFree]);
                                user.IsTaxExempt = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsTaxExempt]);
                                user.RoleId = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.RoleId]);

                            }
                        }
                    }
                    return user;
                }
            }
        }
        #endregion

        #region Get the User
        /// <summary>
        /// Gets the user based on User ID.
        /// </summary>
        /// <param name="userId">The User ID to be loaded.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <param name="status">The status.</param>
        /// <returns>Object of <see cref="User" />.</returns>
        public User GetUserProfile(int? userId, string emailAddress, string password, Enums.Status status)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_GetUserProfile, cn, true))
                {
                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.Id, userId);
                    cmd.Parameters.Add(paramUserId);


                    User user = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                user = new User();
                                user.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.Id]);
                                user.FirstName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.FirstName]);
                                user.LastName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.LastName]);
                                user.Status = (Enums.Status)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.Status]);
                                user.UserType = (Enums.UserType)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.UserType]);
                                user.Email = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Email]);
                                user.Password = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Password]);
                                user.ProfileImage = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.ProfileImage]);
                                user.PhoneNumber = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.PhoneNumber]);
                                user.SchoolName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.SchoolName]);
                                user.DateCreated = TypeConversionUtility.ToDateTime(reader[DbConstant.DbColumn.DateCreated]);
                                user.PromoCode = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.PromoCode]);
                                user.SYId = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.SYId]);
                                user.AccountType.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.AccountType]);
                                user.PromoType = (Enums.PromoType)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.PromoType]);
                                user.IsGiftFree = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsGiftFree]);
                                user.PhoneNumberType = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.PhoneNumberType]);
                                user.Address1 = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Address1]);
                                user.Address2 = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Address2]);
                                user.City = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.City]);
                                user.ZipCode = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.ZipCode]);
                                user.SchoolDistrict = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.SchoolDistrict]);
                                user.ApprovedVendor = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.ApprovedVendor]);
                                user.IsTaxExempt = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsTaxExempt]);
                                user.TaxExempt = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.TaxExempt]);
                                user.TaxExemptFile = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.TaxExemptFile]);

                                user.AccountCategory.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.AccountCategory]);
                                user.AccountCategory.CategoryName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.CategoryName]);
                                user.AccountCategory.IsOther = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsOtherCategoryName]);

                                user.SchoolCampus.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.SchoolCampusId]);
                                user.SchoolCampus.CampusName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.CampusName]);
                                user.SchoolCampus.IsOther = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsOtherCampus]);

                                user.SchoolType.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.SchoolTypeId]);
                                user.SchoolType.IsOther = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsOtherSchoolType]);
                                user.SchoolType.SchoolTypeName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.SchoolTypeName]);

                                user.State.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.StateId]);
                                user.State.StateName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.StateName]);
                                user.State.StateCode = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.StateCode]);
                                user.State.IsOther = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsOtherState]);
                                user.IsSchoolDistrictExempt = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsSchoolDistrictExempt]);
                                user.IsActiveCategory = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsActiveCategory]);
                                user.IsProfile = true;
                                user.IsNotifications = TypeConversionUtility.ToBoolean(reader[DbConstant.DbColumn.IsNotifications]);
                                user.CellPhone = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.CellPhone]);
                            }
                        }
                    }
                    return user;
                }
            }
        }
        #endregion


        #region Get the Users Paged

        /// <summary>
        /// Get the Users Paged.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startPage">Page number at which to start reading.</param>
        /// <param name="pageLength">Number of records to be displayed per page.</param>
        /// <param name="noOfPages">Out parameter which returns the number of pages.</param>
        /// <param name="totalRecords">Out parameter which returns the total records.</param>
        /// <param name="email"></param>
        /// <returns>Collection of User.</returns>
        public IList<User> GetUsers(string email, string name, int startPage, int pageLength, out int noOfPages, out int totalRecords)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_GetUsersPaged, cn, true))
                {

                    SqlParameter paramName = new SqlParameter(DbConstant.Parameter.Name, name);
                    cmd.Parameters.Add(paramName);

                    SqlParameter paramEmailAddress = new SqlParameter(DbConstant.Parameter.Email, email);
                    cmd.Parameters.Add(paramEmailAddress);

                    SqlParameter parStart = new SqlParameter(DbConstant.Parameter.StartPage, startPage);
                    cmd.Parameters.Add(parStart);

                    SqlParameter parPageLength = new SqlParameter(DbConstant.Parameter.PageLength, pageLength);
                    cmd.Parameters.Add(parPageLength);

                    SqlParameter parNoOfPage = new SqlParameter(DbConstant.Parameter.NoOfPages, noOfPages = 0);
                    parNoOfPage.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parNoOfPage);

                    SqlParameter partotalRecords = new SqlParameter(DbConstant.Parameter.TotalRecords, totalRecords = 0);
                    partotalRecords.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(partotalRecords);

                    IList<User> users = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        users = new List<User>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var user = new User();
                                user.Id = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.Id]);
                                user.FirstName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.FirstName]);
                                user.LastName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.LastName]);
                                user.Password = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Password]);
                                user.Status = (Enums.Status)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.Status]);
                                user.UserType = (Enums.UserType)TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.UserType]);
                                user.Email = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Email]);
                                user.ProfileImage = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.ProfileImage]);
                                user.PhoneNumber = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.PhoneNumber]);
                                user.SchoolName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.SchoolName]);
                                user.DateCreated = TypeConversionUtility.ToDateTime(reader[DbConstant.DbColumn.DateCreated]);
                                user.AccountType.Id = TypeConversionUtility.ToByte(reader[DbConstant.DbColumn.AccountType]);
                                user.AccountCategory.CategoryName = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.CategoryName]);
                                user.SYId = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.SYId]);
                                users.Add(user);
                            }
                        }
                        cn.Close();
                        if (reader.IsClosed)
                        {
                            noOfPages = TypeConversionUtility.ToInteger(parNoOfPage.Value);
                            totalRecords = TypeConversionUtility.ToInteger(partotalRecords.Value);
                        }
                    }

                    return users;
                }
            }
        }
        #endregion

        #region Delete User
        /// <summary>
        /// Deletes an User from the database based on UserId.
        /// </summary>
        /// <param name="dtUserId">The dt user identifier.</param>
        /// <returns>Returns true if delete is successful, else false.</returns>
        /// <remarks>Deletes based on primary key(s).</remarks>
        public bool DeleteUser(DataTable dtUserId)
        {
            int effectedRows = 0;
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_DeleteUser, cn, true))
                {
                    SqlParameter paramdtUser = new SqlParameter(DbConstant.Parameter.EntityIdIntTableType, SqlDbType.Structured);
                    paramdtUser.Value = dtUserId;
                    paramdtUser.TypeName = DbConstant.EntityIdIntTableType;
                    cmd.Parameters.Add(paramdtUser);

                    cn.Open();
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            return effectedRows > 0;

        }//end Delete
        #endregion

        #region Change Password
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Returns true if add is successful, else false.</returns>
        public bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                bool isAddUpdated = false;
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_ChangePassword, cn, true))
                {
                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.Id, SqlDbType.Int);
                    paramUserId.Value = userId;
                    cmd.Parameters.Add(paramUserId);

                    SqlParameter paramcurrentPassword = new SqlParameter(DbConstant.Parameter.CurrentPassword, currentPassword);
                    cmd.Parameters.Add(paramcurrentPassword);

                    SqlParameter paramNewPassword = new SqlParameter(DbConstant.Parameter.NewPassword, newPassword);
                    cmd.Parameters.Add(paramNewPassword);

                    cn.Open();
                    int id = cmd.ExecuteNonQuery();

                    isAddUpdated = id > 0;
                }
                return isAddUpdated;
            }
        }
        #endregion

        #region Check Availability Of User Email
        /// <summary>
        /// Checks if the User Email is available for registration.
        /// </summary>
        /// <param name="email">User Email to be checked</param>
        /// <returns>
        /// Returns true if User Email is available, else false.
        /// </returns>
        public bool CheckUserEmailAvailability(string email, int userId)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_CheckUserEmailAvailability, cn, true))
                {
                    SqlParameter paramEmail = new SqlParameter(DbConstant.Parameter.Email, email);
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.UserId, userId);
                    cmd.Parameters.Add(paramUserId);

                    cn.Open();
                    int results = TypeConversionUtility.ToInteger(cmd.ExecuteScalar());
                    return results <= 0;
                }
            }
        }
        #endregion


        #region Add Update a User
        /// <summary>
        /// Delete User Profile Image.
        /// </summary>
        /// <param name="userId">delete user profile image by userId.</param>
        /// <returns>Returns true if add is successful, else false.</returns>
        public bool DeleteProfileImage(int userId)
        {
            int effectedRows = 0;
            using (var cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_DeleteUserImage, cn, true))
                {
                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.UserId, userId);
                    cmd.Parameters.Add(paramUserId);

                    cn.Open();
                    effectedRows = cmd.ExecuteNonQuery();
                }
                return effectedRows > 0;
            }
        }
        #endregion


        public List<UserOrderDiscount> GetOrderDiscounts(int userId)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = SqlHelper.GetSqlCommand(DbConstant.StoreProcedure.usp_GetOrderDiscount, cn, true))
                {
                    SqlParameter paramUserId = new SqlParameter(DbConstant.Parameter.UserId, userId);
                    cmd.Parameters.Add(paramUserId);

                    List<UserOrderDiscount> userPromoDiscounts = null;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        userPromoDiscounts = new List<UserOrderDiscount>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var data = new UserOrderDiscount
                                {
                                    Discount = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Discount]),
                                    OrderNumber = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.OrderNumber]),
                                    TemplateId = TypeConversionUtility.ToInteger(reader[DbConstant.DbColumn.TemplateId]),
                                    Savings = TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.Savings]),
                                    GlobalPromoCode= TypeConversionUtility.ToStringWithNull(reader[DbConstant.DbColumn.GlobalPromoCode])
                                };
                                userPromoDiscounts.Add(data);
                            }
                        }
                    }
                    return userPromoDiscounts;
                }
            }
        }

    }//end class
}//end namespace