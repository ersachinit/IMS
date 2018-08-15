using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Enums
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
            [Description("Active")] True = 1,
            [Description("InActive")] False = 0
        }
    }
}
