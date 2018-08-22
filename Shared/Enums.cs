using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public class EnumSet
    {
        public enum ExceptionType
        {
            NoException,
            Warning,
            Error,
            Fault
        }

        /// <summary>
        /// This enum used for user login status. 
        /// </summary>
        public enum UserLoginStatus
        {
            InvalidCredentials = 0,
            Success = 1,
            AccountPending = 2,
            AccountBanned = 3,
            AccountDisapproved = 4,
            EmptyUserNameOrPassword = 5
        }

        public enum TicketStatus : byte
        {
            [Description("--All")] NotDefined = 0,
            [Description("New Ticket")] New = 1,
            [Description("Under Process ")] InProgress = 2,
            [Description("Closed")] Closed = 3
        }

        /// <summary>
        /// Enum used to specify the sort order while fetching rows of
        /// data for different entities
        /// </summary>
        public enum SortOrderType : byte
        {
            Ascending = 0,
            Descending = 1,
            Unspecified = 2
        } //end enum

        public enum UserType : byte
        {
            [Description("--select")] NotDefined = 0,
            [Description("Administrator")] Administrator = 1,
            [Description("Member")] Member = 2
        }
        public enum Status : byte
        {
            [Description("Active")] Active = 1,
            [Description("InActive")] InActive = 0
        }
        public static string GetDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }
    }
}
