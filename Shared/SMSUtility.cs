using BusinessDataModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WhatsAppApi;

namespace SMS
{
    public class SMSUtility
    {
        #region Variable Section
        readonly private static string ApiKey = WebConfigurationManager.AppSettings["ApiKey"];
        readonly private static string Sender = WebConfigurationManager.AppSettings["Sender"];
        readonly private static string SMSService = WebConfigurationManager.AppSettings["SMSService"];
        readonly private static string WhatsappFrom = WebConfigurationManager.AppSettings["WhatsappFrom"];
        readonly private static string WhatsappPassword = WebConfigurationManager.AppSettings["WhatsappPassword"];
        readonly private static string WhatsappNickName = WebConfigurationManager.AppSettings["WhatsappNickName"];
        readonly private static string TwilioSID = WebConfigurationManager.AppSettings["TwilioSID"];
        readonly private static string TwilioToken = WebConfigurationManager.AppSettings["TwilioToken"];
        #endregion
        Result result = null;


        #region Send By Text Local API
        public string SendbyTextLocal(string Number, string Message)
        {
            String message = HttpUtility.UrlEncode(Message);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , ApiKey},
                {"numbers" , Number},
                {"message" , message},
                {"sender" , Sender}
                });
                string result = Encoding.UTF8.GetString(response);
                return result;
            }
        }
        #endregion

        public Result SendByWhatsApp(string To, string Message)
        {
            result = new Result();
            if (SMSService == "True")
            {
                WhatsApp wa = new WhatsApp(WhatsappFrom, WhatsappPassword, WhatsappNickName, true, true);
                wa.OnConnectSuccess += () =>
                {
                    wa.OnLoginSuccess += (phoneNumber, data) =>
                    {
                        wa.SendMessage(To, Message);
                        result.Message = "Message sent successfully!";
                    };
                    wa.OnLoginFailed += (data) =>
                    {
                        result.Message = "Login Failed : {0}," + data + "";
                    };
                    wa.Login();
                };
                wa.OnConnectFailed += (ex) =>
                {
                    result.Message = "Connection Failed!";
                };
                wa.Connect();
            }
            return result;
        }
        public Result SendByTwilioWhatsApp(string To, string Message)
        {
            result = new Result();
            if (SMSService == "True")
            {
                // Find your Account Sid and Token at twilio.com/console
                string accountSid = TwilioSID;
                string authToken = TwilioToken;

                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                    body: Message,
                    from: new Twilio.Types.PhoneNumber("whatsapp:" + WhatsappFrom + ""),//"whatsapp:+14155238886"
                    to: new Twilio.Types.PhoneNumber("whatsapp:" + To + "")//"whatsapp:+15005550006"
                );
                result.Message = message.Sid;
            }
            return result;
        }
    }
}
