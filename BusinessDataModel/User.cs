using System;
using System.Collections.Generic;
using System.Linq;
using SpiritWorx.BL;
using SpiritWorx.Utility;

namespace SpiritWorx.BO
{
    /// <summary>
    /// Class User.
    /// </summary>
    public class User
    {
        public int RoleId { get; set; }

        public User()
        {
            AccountCategory = new AccountCategory();
            AccountType = new UserAccountType();
            State = new State();
            SchoolCampus = new SchoolCampus();
            SchoolType = new SchoolType();
            ResponseOutput = new ResponseOutput();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string MemberType
        {
            get
            {
                if (Enum.IsDefined(typeof(Enums.UserType), UserType))
                {
                    return Enum.IsDefined(typeof(Enums.UserType), UserType) ? EnumHelper.DescriptionAttr(UserType) : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string UserStatus
        {
            get
            {
                if (Enum.IsDefined(typeof(Enums.Status), Status))
                {
                    return Enum.IsDefined(typeof(Enums.Status), Status) ? EnumHelper.DescriptionAttr(Status) : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public Enums.Status Status { get; set; }


        /// <summary>
        /// Gets or sets the User Type.
        /// </summary>
        /// <value>The User Type.</value>
        public Enums.UserType UserType { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        public string ProfileImage { get; set; }

        public string SchoolName { get; set; }
        public byte[] ProfileImageByte { get; set; }
        public string ProfileImageVirtulaUrl => $"{Utilities.GetWebSiteUrl()}{Utilities.UserProfilePathVirtualUrl}{(!string.IsNullOrWhiteSpace(ProfileImage) ? ProfileImage : "avatardefault.jpg")}";

        public string FullName => $"{FirstName} {LastName}";

        public string PromoCode { get; set; }
        // ReSharper disable once InconsistentNaming
        public int SYId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is anonymous.
        /// </summary>
        /// <value><c>true</c> if this instance is anonymous; otherwise, <c>false</c>.</value>
        public bool IsAnonymous { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }

        public Enums.UserLoginStatus UserLoginStatus { get; set; }

        public UserAccountType AccountType { get; set; }
        public State State { get; set; }
        public AccountCategory AccountCategory { get; set; }
        public bool IsGiftFree { get; set; }
        public int PhoneNumberType { get; set; }

        public SchoolCampus SchoolCampus { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string SchoolDistrict { get; set; }
        public string ApprovedVendor { get; set; }
        public bool IsTaxExempt { get; set; }
        public string TaxExempt { get; set; }
        public string TaxExemptFile { get; set; }
        public string TaxExemptFileVirtulaUrl => $"{Utilities.GetWebSiteUrl()}{Utilities.UserProfilePathVirtualUrl}{(!string.IsNullOrWhiteSpace(TaxExemptFile) ? ProfileImage : "")}";
        public SchoolType SchoolType { get; set; }
        public bool IsProfile { get; set; }
        public Enums.PromoType PromoType { get; set; }
        public  bool IsSchoolDistrictExempt { get; set; }
        public bool IsActiveCategory { get; set; }
        public string CellPhone { get; set; }
        public bool IsNotifications { get; set; }

        public string PromoTypeName
        {
            get
            {
                if (Enum.IsDefined(typeof(Enums.PromoType), PromoType))
                {
                    return Enum.IsDefined(typeof(Enums.PromoType), PromoType) ? EnumHelper.DescriptionAttr(PromoType) : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public List<UserAccountType> AccountTypes => IsProfile ? AccountCategoryRepository.GetAccountTypes().ToList() : null;
        public List<AccountCategory> AccountCategories => IsProfile ? AccountCategoryRepository.FindAccountCategories()?.ToList() : null;
        public List<SchoolCampus> SchoolCampuses => IsProfile ? SchoolCampusRepository.FindSchoolCampuses()?.ToList() : null;
        public List<SchoolType> SchoolTypes => IsProfile ? SchoolTypeRepository.FindSchoolTypes()?.ToList() : null;
        public List<State> States => IsProfile ? StateRepository.FindStates()?.ToList() : null;
        private List<SwDistrict> _schoolDistricts = null;

        public List<SwDistrict> SchoolDistricts
        {
            get
            {
                if (IsProfile && _schoolDistricts == null)
                {
                    _schoolDistricts = SwDistrictRepository.SearchDestricts("")?.ToList();
                }
                return _schoolDistricts;
            }
            set { _schoolDistricts = value; }
        }
        public List<UserOrderDiscount> UserOrderoDiscounts => Id > 0 ? (IsProfile ? UserRepository.GetOrderDiscounts(Id)?.ToList() : null) : null;


        public ResponseOutput ResponseOutput { get; set; }
    }//end class
}//end namespace