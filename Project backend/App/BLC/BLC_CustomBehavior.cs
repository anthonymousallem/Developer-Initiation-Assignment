using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLC
{
    #region Enumerations
    public enum Enum_EntityNameFormat
    {
        FML,
        FLM,
        MFL,
        MLF,
        LFM,
        LMF
    }
    #endregion
    public partial class BLC
    {
        #region Members
        const string _JWT_SECRET = "cBoDstcKww4457ry8uTHjPOuXOYg5MbeJ1XT0uFiwDVkzIr";
        #endregion
        #region Setup
        #region EditSetup
        #region EditSetup
        public void EditSetup(SetupEntry i_SetupEntry)
        {
            #region Declaration And Initialization Section.
            Tools.Tools oTools = new Tools.Tools();
            #endregion
            #region Environment Related Code Handling
            Params_GetEnvCode oParams_GetEnvCode = new Params_GetEnvCode();
            oParams_GetEnvCode.My_Environment = this.Environment;
            oParams_GetEnvCode.My_MethodName = "EditSetup";
            oParams_GetEnvCode.My_Type = typeof(BLC);
            MethodInfo oMethodInfo = EnvCode.GetEnvCode(oParams_GetEnvCode);
            if (oMethodInfo != null)
            {
                oMethodInfo.Invoke(this, new object[] { i_SetupEntry });
                return;
            }
            #endregion
            #region PreEvent_General
            if (OnPreEvent_General != null)
            {
                OnPreEvent_General("EditSetup");
            }
            #endregion
            #region Body Section.
            i_SetupEntry.ENTRY_USER_ID = this.UserID;
            i_SetupEntry.OWNER_ID = this.OwnerID;
            i_SetupEntry.ENTRY_DATE = oTools.GetDateString(DateTime.Today);
            oTools.InvokeMethod(_AppContext, "UP_EDIT_SETUP", i_SetupEntry);
            #endregion
            #region PostEvent_General
            if (OnPostEvent_General != null)
            {
                OnPostEvent_General("EditSetup");
            }
            #endregion
        }
        #endregion
        #endregion
        #endregion        
        #region JWT
        #region ResolveTicket_JWT
        public Dictionary<string, string> ResolveTicket_JWT(string i_Input)
        {
            #region Declaration And Initialization Section.
            Dictionary<string, string> oList = new Dictionary<string, string>();
            Crypto.MiniCryptoHelper oMiniCryptoHelper = new Crypto.MiniCryptoHelper();
            #endregion
            #region PreEvent_General
            if (OnPreEvent_General != null)
            {
                OnPreEvent_General("ResolveTicket_JWT");
            }
            #endregion
            #region Body Section.
            if (!string.IsNullOrEmpty(i_Input))
            {

                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                try
                {
                    // var json = decoder.Decode(i_Input, _JWT_SECRET, verify: true);
                    var payload = JwtBuilder.Create()
                             .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                             .WithSecret(_JWT_SECRET)
                             .MustVerifySignature()
                             .Decode<IDictionary<string, object>>(i_Input);
                    oList.Add("USER_ID", oMiniCryptoHelper.Decrypt(payload["CLAIM-01"].ToString()));
                    oList.Add("OWNER_ID", oMiniCryptoHelper.Decrypt(payload["CLAIM-02"].ToString()));
                }
                catch (Exception ex)
                {
                    throw new BLCException("Your session has timed out.Please click here to relogin.");
                }
            }
            else
            {
                oList.Add("USER_ID", "2");
                oList.Add("OWNER_ID", "1");
            }
            #endregion
            #region PostEvent_General
            if (OnPostEvent_General != null)
            {
                OnPostEvent_General("ResolveTicket_JWT");
            }
            #endregion
            #region Return Section.
            return oList;
            #endregion
        }
        #endregion
        #region Prepare_Ticket_JWT
        public string Prepare_Ticket_JWT(UserInfo i_UserInfo)
        {
            #region Declaration And Initialization Section.
            string str_Return_Value = string.Empty;
            Crypto.MiniCryptoHelper oMiniCryptoHelper = new Crypto.MiniCryptoHelper();
            #endregion
            #region Body Section.

            str_Return_Value = JwtBuilder.Create()
                                  .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                                  .WithSecret(_JWT_SECRET)
                                  .AddClaim("exp", DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeSeconds())
                                  .AddClaim("CLAIM-01", oMiniCryptoHelper.Encrypt(i_UserInfo.UserID.ToString()))
                                  .AddClaim("CLAIM-02", oMiniCryptoHelper.Encrypt(i_UserInfo.OwnerID.ToString()))
                                  .Encode();

            #endregion
            #region Return Section.
            return str_Return_Value;
            #endregion
        }
        #endregion
        #region IsValidTicket_JWT
        public bool IsValidTicket_JWT(string i_Input)
        {
            #region Declaration And Initialization Section.
            bool Is_ValidTicket = false;
            #endregion
            #region Environment Related Code Handling
            return true;
            #endregion           
            #region Return Section.
            return Is_ValidTicket;
            #endregion
        }
        #endregion
        #endregion
        #region Authentication        
        #region Authenticate
        public UserInfo Authenticate(Params_Authenticate i_Params_Authenticate)
        {
            #region Declaration And Initialization Section.
            UserInfo oUserInfo = null;
            Crypto.MiniCryptoHelper oMiniCryptoHelper = new Crypto.MiniCryptoHelper();

            Tools.Tools oTools = new Tools.Tools();
            #endregion            
            #region Body Section.

            var oQuery =
                        (
                        from oItem in _AppContext.UP_GET_USER_BY_CREDENTIALS
                                    (
                                        1,
                                        i_Params_Authenticate.USER_NAME,
                                        oMiniCryptoHelper.Encrypt(i_Params_Authenticate.PASSWORD)
                                    )
                        select oItem
                        ).ToList();

            if (oQuery.Count() == 1)
            {

                var oResult = oQuery.First();
                //#region Check if this User is Active [Even if provided valid credentials]
                //if (oResult.IS_ACTIVE == false)
                //{
                //    throw new BLCException("Not Active User");
                //}
                //#endregion
                #region Prepare Returned Object

                oUserInfo = new UserInfo();
                oUserInfo.IsAuthenticated = true;
                oUserInfo.UserID = oResult.USER_ID;
                oUserInfo.OwnerID = oResult.OWNER_ID;
                oUserInfo.UserName = oResult.USERNAME;
                // Preparing ticket
                // ------------------------------               
                oUserInfo.Ticket = Prepare_Ticket(oUserInfo);
                // ------------------------------
            }
            else
            {
                throw new BLCException("Invalid UserName and/or Password!!");
            }
            #endregion            
            #region Return Section.
            return oUserInfo;
            #endregion
        }
        #endregion
        #region ResolveTicket
        public Dictionary<string, string> ResolveTicket(string i_Input)
        {
            return ResolveTicket_JWT(i_Input);
            #region Declaration And Initialization Section.
            Dictionary<string, string> oList = new Dictionary<string, string>();
            string str_Ticket_PlainText = string.Empty;
            Crypto.Crypto oCrypto = new Crypto.Crypto();
            string[] oMainTempList = null;
            string[] oSubTempList = null;
            #endregion
            #region PreEvent_General
            if (OnPreEvent_General != null)
            {
                OnPreEvent_General("ResolveTicket");
            }
            #endregion
            #region Body Section.
            if (!string.IsNullOrEmpty(i_Input))
            {
                //str_Ticket_PlainText = oCrypto.Decrypt(i_Input, _KeySet);
                str_Ticket_PlainText = i_Input;

                if (!string.IsNullOrEmpty(str_Ticket_PlainText))
                {
                    oMainTempList = str_Ticket_PlainText.Split(new string[] { "[~!@]" }, StringSplitOptions.RemoveEmptyEntries);

                    var oQuery = from oItem in oMainTempList
                                 select oItem;

                    foreach (var oRow in oQuery)
                    {
                        oSubTempList = oRow.Split(new string[] { ":" }, StringSplitOptions.None);
                        oList.Add(oSubTempList[0], oSubTempList[1]);
                    }
                }
            }
            else
            {
                oList.Add("USER_ID", "2");
                oList.Add("OWNER_ID", "1");
            }
            #endregion
            #region PostEvent_General
            if (OnPostEvent_General != null)
            {
                OnPostEvent_General("ResolveTicket");
            }
            #endregion
            #region Return Section.
            return oList;
            #endregion
        }
        #endregion        
        #region IsValidTicket
        public bool IsValidTicket(string i_Input)
        {
            return IsValidTicket(i_Input);
            #region Declaration And Initialization Section.
            bool Is_ValidTicket = false;
            long? i_MinutesElapsedSinceMidnight = 0;
            string str_CurrentDate = string.Empty;
            Tools.Tools oTools = new Tools.Tools();
            Dictionary<string, string> oTicketParts = new Dictionary<string, string>();
            #endregion
            #region Environment Related Code Handling
            Params_GetEnvCode oParams_GetEnvCode = new Params_GetEnvCode();
            oParams_GetEnvCode.My_Environment = this.Environment;
            oParams_GetEnvCode.My_MethodName = "IsValidTicket";
            oParams_GetEnvCode.My_Type = typeof(BLC);
            MethodInfo oMethodInfo = EnvCode.GetEnvCode(oParams_GetEnvCode);
            if (oMethodInfo != null)
            {
                return Convert.ToBoolean(oMethodInfo.Invoke(this, new object[] { i_Input }));
                // Intentially Left Empty.
            }
            #endregion
            #region PreEvent_General
            if (OnPreEvent_General != null)
            {
                OnPreEvent_General("IsValidTicket");
            }
            #endregion
            #region Body Section.
            try
            {
                oTicketParts = ResolveTicket(i_Input);
                str_CurrentDate = oTools.GetDateString(DateTime.Today);

                if (oTicketParts["START_DATE"] == str_CurrentDate) // Session Started In Different Day.
                {
                    i_MinutesElapsedSinceMidnight = (long?)(DateTime.Now - DateTime.Today).TotalMinutes;

                    if (i_MinutesElapsedSinceMidnight <= Convert.ToInt32(oTicketParts["START_MINUTE"]) + Convert.ToInt32(oTicketParts["SESSION_PERIOD"]))
                    {
                        Is_ValidTicket = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Is_ValidTicket = false;
            }
            #endregion
            #region PostEvent_General
            if (OnPostEvent_General != null)
            {
                OnPostEvent_General("IsValidTicket");
            }
            #endregion
            #region Return Section.
            return Is_ValidTicket;
            #endregion
        }
        #endregion
        #region Prepare_Ticket
        public string Prepare_Ticket(UserInfo i_UserInfo)
        {
            return Prepare_Ticket_JWT(i_UserInfo);
            #region Declaration And Initialization Section.
            string str_Return_Value = string.Empty;

            Int64? i_MinutesElapsedSinceMidnight = 0;
            Int32? i_ExpiryPeriod = 240; // In Minutes
            Tools.Tools oTools = new Tools.Tools();
            #endregion
            #region Body Section.

            // ------------------------------
            if (ConfigurationManager.AppSettings["SESSION_PERIOD"] != null)
            {
                i_ExpiryPeriod = Convert.ToInt32(ConfigurationManager.AppSettings["SESSION_PERIOD"].ToString());
            }
            // ------------------------------

            // Prepare ticket
            // ------------------------------
            i_MinutesElapsedSinceMidnight = (long?)(DateTime.Now - DateTime.Today).TotalMinutes;
            str_Return_Value = string.Format
                        (
                            "USER_ID:{0}[~!@]OWNER_ID:{1}[~!@]START_DATE:{2}[~!@]START_MINUTE:{3}[~!@]SESSION_PERIOD:{4}",
                            i_UserInfo.UserID.ToString(),
                            i_UserInfo.OwnerID.ToString(),
                            oTools.GetDateString(DateTime.Today),
                            i_MinutesElapsedSinceMidnight.ToString(),
                            i_ExpiryPeriod.ToString()
                        );
            //str_Return_Value = oCrypto.Encrypt(str_Return_Value, _KeyPublic);         
            // ------------------------------

            #endregion
            #region Return Section.
            return str_Return_Value;
            #endregion
        }
        #endregion
        #endregion
        #endregion

        #region SubscriptionEmail
        public void SendEmailForSubscriptions(Params_SendEmailForSubscriptions i_Params_SendEmailForSubscriptions)
        {
            List<Contact> listOfContacts = new List<Contact>();
            Params_Get_Contact_By_OWNER_ID paramsGetContacts = new Params_Get_Contact_By_OWNER_ID();
            paramsGetContacts.OWNER_ID = 1;
            listOfContacts = Get_Contact_By_OWNER_ID(paramsGetContacts);

           if (listOfContacts.Count > 0)
            {
                listOfContacts.ForEach(contact =>
                {
                    var msg = new MimeMessage();
                    msg.From.Add(new MailboxAddress(i_Params_SendEmailForSubscriptions.Title , "azuresoftsolutionstrial@gmail.com"));

                    msg.To.Add(new MailboxAddress("User", contact.EMAIL));
                    msg.Subject = i_Params_SendEmailForSubscriptions.Header;
                    var builder = new BodyBuilder();
                    using (StreamReader reader = new StreamReader(@"D:\DOCUMENTS\ANTHONY\PROJECTS\Project backend\App\BLC\SubscriptionsEmail.html", Encoding.UTF8))
                    {
                        var Title = i_Params_SendEmailForSubscriptions.Body;
                        builder.HtmlBody = reader.ReadToEnd().Replace("TITLE", Title);
                       
                    }

                    msg.Body = builder.ToMessageBody();

                    using (var client = new SmtpClient())
                    {
                        client.CheckCertificateRevocation = false;
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("azuresoftsolutionstrial@gmail.com", "Azuresoftsolutions@Gmail");
                        client.Send(msg);
                        client.Disconnect(true);
                    }

                });
            }
        }
        #endregion
    }

    public class Params_SendEmailForSubscriptions
    {
        public string Body { get; set; }

        public string Header { get; set; }

        public string Title { get; set; }
    }
    #region Business Entities
    #region Setup
    #region SetupEntry
    public class SetupEntry
    {
        #region Properties
        public Int32? OWNER_ID { get; set; }
        public string TBL_NAME { get; set; }
        public string CODE_NAME { get; set; }
        public bool? ISSYSTEM { get; set; }
        public bool? ISDELETEABLE { get; set; }
        public bool? ISUPDATEABLE { get; set; }
        public bool? ISVISIBLE { get; set; }
        public bool? ISDELETED { get; set; }
        public Int32? DISPLAY_ORDER { get; set; }
        public string CODE_VALUE_EN { get; set; }
        public string CODE_VALUE_FR { get; set; }
        public string CODE_VALUE_AR { get; set; }
        public string ENTRY_DATE { get; set; }
        public long? ENTRY_USER_ID { get; set; }
        public string NOTES { get; set; }

        public string INVARIANT_VALUE { get; set; }
        #endregion
    }
    #endregion    
    #endregion
    #region Uploaded_file
    public partial class Uploaded_file
    {
        public string My_URL { get; set; }
    }
    #endregion
    #region UserInfo
    public class UserInfo
    {
        #region Properties
        public long? UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public BLC.Enum_Language Language { get; set; }
        public Int32? OwnerID { get; set; }
        public string Ticket { get; set; }
        public string USER_TYPE_CODE { get; set; }
        #endregion
    }
    public partial class Params_Auto_Prepare_Ticket
    {
        #region Properties.
        public string input { get; set; }
        #endregion
    }
    #endregion
    #region Authentication
    public partial class Params_Authenticate
    {
        #region Properties.
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        #endregion
    }
    #endregion
    #endregion
}


