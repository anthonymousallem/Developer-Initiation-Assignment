using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BLC;
[Route("api/[controller]")]
[ApiController]
public partial class DataController : ControllerBase
{
#region Members
#endregion
#region Extract_Ticket
private string Extract_Ticket()
{
#region Declaration And Initialization Section.
string str_Ticket = string.Empty;
#endregion
if(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null)
{
str_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
#region Return Section.
return str_Ticket;
#endregion
}
#endregion
#region IsValidWebTicket
private bool IsValidWebTicket(string i_Input)
{
#region Declaration And Initialization Section.
bool Is_Valid = false;
BLCInitializer oBLCInitializer = new BLCInitializer();
#endregion
#region Body Section.
BLC.BLC oBLC_Default = new BLC.BLC();
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
Is_Valid = oBLC.IsValidTicket(i_Input);
}
#endregion
#region Return Section.
return Is_Valid;
#endregion
}
#endregion
#region Authenticate
[HttpPost]
[Route("Authenticate")]
public Result_Authenticate Authenticate(Params_Authenticate i_Params_Authenticate)
{
#region Declaration And Initialization Section.
UserInfo oReturnValue = new UserInfo();
string i_Ticket = string.Empty;
Result_Authenticate oResult_Authenticate = new Result_Authenticate();
#endregion
#region Body Section.
try
{


BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Authenticate(i_Params_Authenticate);
oResult_Authenticate.My_Result = oReturnValue;
oResult_Authenticate.My_Params_Authenticate = i_Params_Authenticate;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Authenticate.ExceptionMsg = string.Format("Authenticate : {0}", ex.Message);
}
else
{
oResult_Authenticate.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Authenticate;
#endregion
}
#endregion
#region Delete_Admin
[HttpPost]
[Route("Delete_Admin")]
public Result_Delete_Admin Delete_Admin(Params_Delete_Admin i_Params_Delete_Admin)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Admin oResult_Delete_Admin = new Result_Delete_Admin();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket,BLC.BLC.Enum_API_Method.Delete_Admin);
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Admin(i_Params_Delete_Admin);
oResult_Delete_Admin.My_Params_Delete_Admin = i_Params_Delete_Admin;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Admin.ExceptionMsg = string.Format("Delete_Admin : {0}", ex.Message);
}
else
{
oResult_Delete_Admin.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Admin;
#endregion
}
#endregion
#region Delete_Contact
[HttpPost]
[Route("Delete_Contact")]
public Result_Delete_Contact Delete_Contact(Params_Delete_Contact i_Params_Delete_Contact)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_Contact oResult_Delete_Contact = new Result_Delete_Contact();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_Contact(i_Params_Delete_Contact);
oResult_Delete_Contact.My_Params_Delete_Contact = i_Params_Delete_Contact;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_Contact.ExceptionMsg = string.Format("Delete_Contact : {0}", ex.Message);
}
else
{
oResult_Delete_Contact.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_Contact;
#endregion
}
#endregion
#region Delete_User
[HttpPost]
[Route("Delete_User")]
public Result_Delete_User Delete_User(Params_Delete_User i_Params_Delete_User)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Delete_User oResult_Delete_User = new Result_Delete_User();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Delete_User(i_Params_Delete_User);
oResult_Delete_User.My_Params_Delete_User = i_Params_Delete_User;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Delete_User.ExceptionMsg = string.Format("Delete_User : {0}", ex.Message);
}
else
{
oResult_Delete_User.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Delete_User;
#endregion
}
#endregion
#region Edit_Admin
[HttpPost]
[Route("Edit_Admin")]
public Result_Edit_Admin Edit_Admin(Admin i_Admin)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Admin oResult_Edit_Admin = new Result_Edit_Admin();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket,BLC.BLC.Enum_API_Method.Edit_Admin);
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Admin(i_Admin);
oResult_Edit_Admin.My_Admin = i_Admin;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Admin.ExceptionMsg = string.Format("Edit_Admin : {0}", ex.Message);
}
else
{
oResult_Edit_Admin.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Admin;
#endregion
}
#endregion
#region Edit_Contact
[HttpPost]
[Route("Edit_Contact")]
public Result_Edit_Contact Edit_Contact(Contact i_Contact)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_Contact oResult_Edit_Contact = new Result_Edit_Contact();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_Contact(i_Contact);
oResult_Edit_Contact.My_Contact = i_Contact;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_Contact.ExceptionMsg = string.Format("Edit_Contact : {0}", ex.Message);
}
else
{
oResult_Edit_Contact.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_Contact;
#endregion
}
#endregion
#region Edit_User
[HttpPost]
[Route("Edit_User")]
public Result_Edit_User Edit_User(User i_User)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_Edit_User oResult_Edit_User = new Result_Edit_User();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.Edit_User(i_User);
oResult_Edit_User.My_User = i_User;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Edit_User.ExceptionMsg = string.Format("Edit_User : {0}", ex.Message);
}
else
{
oResult_Edit_User.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Edit_User;
#endregion
}
#endregion
#region Get_Admin_By_OWNER_ID
[HttpPost]
[Route("Get_Admin_By_OWNER_ID")]
public Result_Get_Admin_By_OWNER_ID Get_Admin_By_OWNER_ID(Params_Get_Admin_By_OWNER_ID i_Params_Get_Admin_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Admin>  oReturnValue = new List<Admin> ();
string i_Ticket = string.Empty;
Result_Get_Admin_By_OWNER_ID oResult_Get_Admin_By_OWNER_ID = new Result_Get_Admin_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = oBLC_Default.Prepare_BLCInitializer(i_Ticket,BLC.BLC.Enum_API_Method.Get_Admin_By_OWNER_ID);
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Admin_By_OWNER_ID(i_Params_Get_Admin_By_OWNER_ID);
oResult_Get_Admin_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Admin_By_OWNER_ID.My_Params_Get_Admin_By_OWNER_ID = i_Params_Get_Admin_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Admin_By_OWNER_ID.ExceptionMsg = string.Format("Get_Admin_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Admin_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Admin_By_OWNER_ID;
#endregion
}
#endregion
#region Get_Contact_By_OWNER_ID
[HttpPost]
[Route("Get_Contact_By_OWNER_ID")]
public Result_Get_Contact_By_OWNER_ID Get_Contact_By_OWNER_ID(Params_Get_Contact_By_OWNER_ID i_Params_Get_Contact_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<Contact>  oReturnValue = new List<Contact> ();
string i_Ticket = string.Empty;
Result_Get_Contact_By_OWNER_ID oResult_Get_Contact_By_OWNER_ID = new Result_Get_Contact_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_Contact_By_OWNER_ID(i_Params_Get_Contact_By_OWNER_ID);
oResult_Get_Contact_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_Contact_By_OWNER_ID.My_Params_Get_Contact_By_OWNER_ID = i_Params_Get_Contact_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_Contact_By_OWNER_ID.ExceptionMsg = string.Format("Get_Contact_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_Contact_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_Contact_By_OWNER_ID;
#endregion
}
#endregion
#region Get_User_By_OWNER_ID
[HttpPost]
[Route("Get_User_By_OWNER_ID")]
public Result_Get_User_By_OWNER_ID Get_User_By_OWNER_ID(Params_Get_User_By_OWNER_ID i_Params_Get_User_By_OWNER_ID)
{
#region Declaration And Initialization Section.
List<User>  oReturnValue = new List<User> ();
string i_Ticket = string.Empty;
Result_Get_User_By_OWNER_ID oResult_Get_User_By_OWNER_ID = new Result_Get_User_By_OWNER_ID();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oReturnValue = oBLC.Get_User_By_OWNER_ID(i_Params_Get_User_By_OWNER_ID);
oResult_Get_User_By_OWNER_ID.My_Result = oReturnValue;
oResult_Get_User_By_OWNER_ID.My_Params_Get_User_By_OWNER_ID = i_Params_Get_User_By_OWNER_ID;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_Get_User_By_OWNER_ID.ExceptionMsg = string.Format("Get_User_By_OWNER_ID : {0}", ex.Message);
}
else
{
oResult_Get_User_By_OWNER_ID.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_Get_User_By_OWNER_ID;
#endregion
}
#endregion
#region SendEmailForSubscriptions
[HttpPost]
[Route("SendEmailForSubscriptions")]
public Result_SendEmailForSubscriptions SendEmailForSubscriptions(Params_SendEmailForSubscriptions i_Params_SendEmailForSubscriptions)
{
#region Declaration And Initialization Section.
string i_Ticket = string.Empty;
Result_SendEmailForSubscriptions oResult_SendEmailForSubscriptions = new Result_SendEmailForSubscriptions();
#endregion
#region Body Section.
try
{

// Ticket Checking
//-------------------
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] != null)
{
if (ConfigurationManager.AppSettings["ENABLE_TICKET"] == "1")
{
if
(
(HttpContext.Request.Query["Ticket"].FirstOrDefault() != null) &&
(HttpContext.Request.Query["Ticket"].ToString() != "")
)
{
i_Ticket = HttpContext.Request.Query["Ticket"].ToString();
}
else
{
throw new Exception("Invalid Ticket");
}
}
}
//-------------------

BLC.BLC oBLC_Default = new BLC.BLC();
BLCInitializer oBLCInitializer = new BLCInitializer();
oBLCInitializer.UserID           = Convert.ToInt64(oBLC_Default.ResolveTicket(i_Ticket)["USER_ID"]);
oBLCInitializer.OwnerID          = Convert.ToInt32(oBLC_Default.ResolveTicket(i_Ticket)["OWNER_ID"]);
oBLCInitializer.ConnectionString = ConfigurationManager.AppSettings["CONN_STR"];
oBLCInitializer.Messages_FilePath = ConfigurationManager.AppSettings["BLC_MESSAGES"];
using (BLC.BLC oBLC = new BLC.BLC(oBLCInitializer))
{
oBLC.SendEmailForSubscriptions(i_Params_SendEmailForSubscriptions);
oResult_SendEmailForSubscriptions.My_Params_SendEmailForSubscriptions = i_Params_SendEmailForSubscriptions;
}
}
catch(Exception ex)
{
if (ex.GetType().FullName != "BLC.BLCException")
{
oResult_SendEmailForSubscriptions.ExceptionMsg = string.Format("SendEmailForSubscriptions : {0}", ex.Message);
}
else
{
oResult_SendEmailForSubscriptions.ExceptionMsg = ex.Message;
}
}
#endregion
#region Return Section
return oResult_SendEmailForSubscriptions;
#endregion
}
#endregion
}

#region Action_Result
public partial class Action_Result
{
#region Properties.
public string ExceptionMsg { get; set; }
#endregion
#region Constructor
public Action_Result()
{
#region Declaration And Initialization Section.
#endregion
#region Body Section.
this.ExceptionMsg = string.Empty;
#endregion
}
#endregion
}
#endregion
#region Result_Authenticate
public partial class Result_Authenticate : Action_Result
{
#region Properties.
public UserInfo My_Result { get; set; }
public Params_Authenticate My_Params_Authenticate { get; set; }
#endregion
}
#endregion
#region Result_Delete_Admin
public partial class Result_Delete_Admin : Action_Result
{
#region Properties.
public Params_Delete_Admin My_Params_Delete_Admin { get; set; }
#endregion
}
#endregion
#region Result_Delete_Contact
public partial class Result_Delete_Contact : Action_Result
{
#region Properties.
public Params_Delete_Contact My_Params_Delete_Contact { get; set; }
#endregion
}
#endregion
#region Result_Delete_User
public partial class Result_Delete_User : Action_Result
{
#region Properties.
public Params_Delete_User My_Params_Delete_User { get; set; }
#endregion
}
#endregion
#region Result_Edit_Admin
public partial class Result_Edit_Admin : Action_Result
{
#region Properties.
public Admin My_Admin { get; set; }
#endregion
}
#endregion
#region Result_Edit_Contact
public partial class Result_Edit_Contact : Action_Result
{
#region Properties.
public Contact My_Contact { get; set; }
#endregion
}
#endregion
#region Result_Edit_User
public partial class Result_Edit_User : Action_Result
{
#region Properties.
public User My_User { get; set; }
#endregion
}
#endregion
#region Result_Get_Admin_By_OWNER_ID
public partial class Result_Get_Admin_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Admin>  My_Result { get; set; }
public Params_Get_Admin_By_OWNER_ID My_Params_Get_Admin_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_Contact_By_OWNER_ID
public partial class Result_Get_Contact_By_OWNER_ID : Action_Result
{
#region Properties.
public List<Contact>  My_Result { get; set; }
public Params_Get_Contact_By_OWNER_ID My_Params_Get_Contact_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_Get_User_By_OWNER_ID
public partial class Result_Get_User_By_OWNER_ID : Action_Result
{
#region Properties.
public List<User>  My_Result { get; set; }
public Params_Get_User_By_OWNER_ID My_Params_Get_User_By_OWNER_ID { get; set; }
#endregion
}
#endregion
#region Result_SendEmailForSubscriptions
public partial class Result_SendEmailForSubscriptions : Action_Result
{
#region Properties.
public Params_SendEmailForSubscriptions My_Params_SendEmailForSubscriptions { get; set; }
#endregion
}
#endregion
