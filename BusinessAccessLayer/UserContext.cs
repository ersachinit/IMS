using System;
using System.Web;
using SpiritWorx.BO;

namespace SpiritWorx.BL
{
    /// <summary>
    /// This class can be used without HttpContext too (non-web requests), and it encapuslates global as well
    /// as user related objects (like current logged in user) for easy-access throughout the app. 
    /// properties 
    /// </summary>
    public sealed class UserContext
    {
        /// <summary>
        /// This static variable is used for DyveContext calls when there is no HttpContext.Current
        /// available (non-Http requests), like API calls.
        /// </summary>
        [ThreadStatic]
        private static UserContext _staticContext = null;

        /// <summary>
        /// TLD domain name of the site (minus any www or any other sub-domain)
        /// </summary>
        public string Domain
        {
            get
            {
                return Context.Request.Url.Host.Replace("www.", String.Empty);
            }
        }


        public bool IsRoutedUrl
        { get; set; }



        /// <summary>
        /// Returns the current instance of the HttpContext class
        /// </summary>
        public HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        /// <summary>
        /// Constructor: Private so that this class cannot be initialized from outside.
        /// </summary>
        private UserContext()
        {

        }

        public static UserContext Current
        {
            get
            {
                UserContext userContext = null;
                HttpContext context = HttpContext.Current;
                if (context != null)
                {
                    //check if the current HttpContext.ITems (temp data store) has the current
                    //DyveContext instance or not. If not, then create a new instance and save
                    //it in the Items collection (a per request store)
                    if (context.Items.Contains(BLConstant.CONTEXT_KEY))
                        userContext = context.Items[BLConstant.CONTEXT_KEY] as UserContext;
                    else
                    {
                        userContext = new UserContext();
                        userContext.Context.Items[BLConstant.CONTEXT_KEY] = userContext;
                    }
                }
                else if (_staticContext != null)
                {
                    userContext = _staticContext;
                }
                else
                {
                    //create a new instance of static context as there is no web request
                    _staticContext = new UserContext();
                    userContext = _staticContext;
                }
                return userContext;
            }
        }

        public User User
        {
            get
            {
                User user = null;
                if (Current.Context.Session[BLConstant.LoggedInUser] != null)
                    user = (User)Current.Context.Session[BLConstant.LoggedInUser];
                else
                {
                    //no user in session, so check for the permanent cookie
                    user = UserRepository.FindUser(emailAddress: HttpContext.Current.User.Identity.Name) ?? new User { IsAnonymous = true, Id = 0 };
                    //cache in session
                    Current.Context.Session[BLConstant.LoggedInUser] = user;
                }
                return user;
            }
            set
            {
                Current.Context.Session[BLConstant.LoggedInUser] = value;
            }
        }
        public int RoleId { get; set; }

    }//end class
}//end namespace