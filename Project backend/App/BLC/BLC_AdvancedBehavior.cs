using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Configuration;
using DALC;
//using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Reflection;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;







namespace BLC
{
public partial class BLC
{
public Admin Get_Admin_By_ADMIN_ID_Adv(Params_Get_Admin_By_ADMIN_ID i_Params_Get_Admin_By_ADMIN_ID)
{
Admin oAdmin = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_ADMIN_ID_Adv");}
#region Body Section.
DALC.Admin oDBEntry = _AppContext.Get_Admin_By_ADMIN_ID_Adv(i_Params_Get_Admin_By_ADMIN_ID.ADMIN_ID);
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_ADMIN_ID_Adv");}
return oAdmin;
}
public Contact Get_Contact_By_CONTACT_ID_Adv(Params_Get_Contact_By_CONTACT_ID i_Params_Get_Contact_By_CONTACT_ID)
{
Contact oContact = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_Contact_By_CONTACT_ID_Adv");}
#region Body Section.
DALC.Contact oDBEntry = _AppContext.Get_Contact_By_CONTACT_ID_Adv(i_Params_Get_Contact_By_CONTACT_ID.CONTACT_ID);
oContact = new Contact();
oTools.CopyPropValues(oDBEntry, oContact);
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Contact_By_CONTACT_ID_Adv");}
return oContact;
}
public User Get_User_By_USER_ID_Adv(Params_Get_User_By_USER_ID i_Params_Get_User_By_USER_ID)
{
User oUser = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_User_By_USER_ID_Adv");}
#region Body Section.
DALC.User oDBEntry = _AppContext.Get_User_By_USER_ID_Adv(i_Params_Get_User_By_USER_ID.USER_ID);
oUser = new User();
oTools.CopyPropValues(oDBEntry, oUser);
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_User_By_USER_ID_Adv");}
return oUser;
}
public List<Admin> Get_Admin_By_ADMIN_ID_List_Adv(Params_Get_Admin_By_ADMIN_ID_List i_Params_Get_Admin_By_ADMIN_ID_List)
{
Admin oAdmin = null;
List<Admin> oList = new List<Admin>();
Params_Get_Admin_By_ADMIN_ID_List_SP oParams_Get_Admin_By_ADMIN_ID_List_SP = new Params_Get_Admin_By_ADMIN_ID_List_SP();
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_ADMIN_ID_List_Adv");}
#region Body Section.
List<DALC.Admin> oList_DBEntries = _AppContext.Get_Admin_By_ADMIN_ID_List_Adv(i_Params_Get_Admin_By_ADMIN_ID_List.ADMIN_ID_LIST);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
oList.Add(oAdmin);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_ADMIN_ID_List_Adv");}
return oList;
}
public List<Contact> Get_Contact_By_CONTACT_ID_List_Adv(Params_Get_Contact_By_CONTACT_ID_List i_Params_Get_Contact_By_CONTACT_ID_List)
{
Contact oContact = null;
List<Contact> oList = new List<Contact>();
Params_Get_Contact_By_CONTACT_ID_List_SP oParams_Get_Contact_By_CONTACT_ID_List_SP = new Params_Get_Contact_By_CONTACT_ID_List_SP();
if (OnPreEvent_General != null){OnPreEvent_General("Get_Contact_By_CONTACT_ID_List_Adv");}
#region Body Section.
List<DALC.Contact> oList_DBEntries = _AppContext.Get_Contact_By_CONTACT_ID_List_Adv(i_Params_Get_Contact_By_CONTACT_ID_List.CONTACT_ID_LIST);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oContact = new Contact();
oTools.CopyPropValues(oDBEntry, oContact);
oList.Add(oContact);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Contact_By_CONTACT_ID_List_Adv");}
return oList;
}
public List<User> Get_User_By_USER_ID_List_Adv(Params_Get_User_By_USER_ID_List i_Params_Get_User_By_USER_ID_List)
{
User oUser = null;
List<User> oList = new List<User>();
Params_Get_User_By_USER_ID_List_SP oParams_Get_User_By_USER_ID_List_SP = new Params_Get_User_By_USER_ID_List_SP();
if (OnPreEvent_General != null){OnPreEvent_General("Get_User_By_USER_ID_List_Adv");}
#region Body Section.
List<DALC.User> oList_DBEntries = _AppContext.Get_User_By_USER_ID_List_Adv(i_Params_Get_User_By_USER_ID_List.USER_ID_LIST);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oUser = new User();
oTools.CopyPropValues(oDBEntry, oUser);
oList.Add(oUser);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_User_By_USER_ID_List_Adv");}
return oList;
}
public List<Admin> Get_Admin_By_EMAIL_Adv(Params_Get_Admin_By_EMAIL i_Params_Get_Admin_By_EMAIL)
{
List<Admin> oList = new List<Admin>();
Admin oAdmin = new Admin();
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_EMAIL_Adv");}
#region Body Section.
List<DALC.Admin> oList_DBEntries = _AppContext.Get_Admin_By_EMAIL_Adv(i_Params_Get_Admin_By_EMAIL.EMAIL);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
oList.Add(oAdmin);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_EMAIL_Adv");}
return oList;
}
public List<Admin> Get_Admin_By_USERNAME_Adv(Params_Get_Admin_By_USERNAME i_Params_Get_Admin_By_USERNAME)
{
List<Admin> oList = new List<Admin>();
Admin oAdmin = new Admin();
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_USERNAME_Adv");}
#region Body Section.
List<DALC.Admin> oList_DBEntries = _AppContext.Get_Admin_By_USERNAME_Adv(i_Params_Get_Admin_By_USERNAME.USERNAME);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
oList.Add(oAdmin);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_USERNAME_Adv");}
return oList;
}
public List<Admin> Get_Admin_By_OWNER_ID_Adv(Params_Get_Admin_By_OWNER_ID i_Params_Get_Admin_By_OWNER_ID)
{
List<Admin> oList = new List<Admin>();
Admin oAdmin = new Admin();
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_OWNER_ID_Adv");}
#region Body Section.
List<DALC.Admin> oList_DBEntries = _AppContext.Get_Admin_By_OWNER_ID_Adv(i_Params_Get_Admin_By_OWNER_ID.OWNER_ID);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
oList.Add(oAdmin);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_OWNER_ID_Adv");}
return oList;
}
public List<Contact> Get_Contact_By_OWNER_ID_Adv(Params_Get_Contact_By_OWNER_ID i_Params_Get_Contact_By_OWNER_ID)
{
List<Contact> oList = new List<Contact>();
Contact oContact = new Contact();
if (OnPreEvent_General != null){OnPreEvent_General("Get_Contact_By_OWNER_ID_Adv");}
#region Body Section.
List<DALC.Contact> oList_DBEntries = _AppContext.Get_Contact_By_OWNER_ID_Adv(i_Params_Get_Contact_By_OWNER_ID.OWNER_ID);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oContact = new Contact();
oTools.CopyPropValues(oDBEntry, oContact);
oList.Add(oContact);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Contact_By_OWNER_ID_Adv");}
return oList;
}
public List<User> Get_User_By_OWNER_ID_Adv(Params_Get_User_By_OWNER_ID i_Params_Get_User_By_OWNER_ID)
{
List<User> oList = new List<User>();
User oUser = new User();
if (OnPreEvent_General != null){OnPreEvent_General("Get_User_By_OWNER_ID_Adv");}
#region Body Section.
List<DALC.User> oList_DBEntries = _AppContext.Get_User_By_OWNER_ID_Adv(i_Params_Get_User_By_OWNER_ID.OWNER_ID);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oUser = new User();
oTools.CopyPropValues(oDBEntry, oUser);
oList.Add(oUser);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_User_By_OWNER_ID_Adv");}
return oList;
}
public List<User> Get_User_By_USERNAME_Adv(Params_Get_User_By_USERNAME i_Params_Get_User_By_USERNAME)
{
List<User> oList = new List<User>();
User oUser = new User();
if (OnPreEvent_General != null){OnPreEvent_General("Get_User_By_USERNAME_Adv");}
#region Body Section.
List<DALC.User> oList_DBEntries = _AppContext.Get_User_By_USERNAME_Adv(i_Params_Get_User_By_USERNAME.USERNAME);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oUser = new User();
oTools.CopyPropValues(oDBEntry, oUser);
oList.Add(oUser);
}
}
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_User_By_USERNAME_Adv");}
return oList;
}
public List<Admin> Get_Admin_By_Criteria_Adv(Params_Get_Admin_By_Criteria i_Params_Get_Admin_By_Criteria)
{
List<Admin> oList = new List<Admin>();
long? tmp_TOTAL_COUNT = 0;
Admin oAdmin = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_Criteria_Adv");}
#region Body Section.
if ((i_Params_Get_Admin_By_Criteria.OWNER_ID == null) || (i_Params_Get_Admin_By_Criteria.OWNER_ID == 0)) { i_Params_Get_Admin_By_Criteria.OWNER_ID = this.OwnerID; }
if (i_Params_Get_Admin_By_Criteria.START_ROW == null) { i_Params_Get_Admin_By_Criteria.START_ROW = 0; }
if ((i_Params_Get_Admin_By_Criteria.END_ROW == null) || (i_Params_Get_Admin_By_Criteria.END_ROW == 0)) { i_Params_Get_Admin_By_Criteria.END_ROW = 1000000; }
List<DALC.Admin> oList_DBEntries = _AppContext.Get_Admin_By_Criteria_Adv(i_Params_Get_Admin_By_Criteria.EMAIL,i_Params_Get_Admin_By_Criteria.USERNAME,i_Params_Get_Admin_By_Criteria.PASSWORD,i_Params_Get_Admin_By_Criteria.OWNER_ID,i_Params_Get_Admin_By_Criteria.START_ROW,i_Params_Get_Admin_By_Criteria.END_ROW,ref tmp_TOTAL_COUNT);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
oList.Add(oAdmin);
}
}
i_Params_Get_Admin_By_Criteria.TOTAL_COUNT = tmp_TOTAL_COUNT;
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_Criteria_Adv");}
return oList;
}
public List<Admin> Get_Admin_By_Where_Adv(Params_Get_Admin_By_Where i_Params_Get_Admin_By_Where)
{
List<Admin> oList = new List<Admin>();
long? tmp_TOTAL_COUNT = 0;
Admin oAdmin = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_Admin_By_Where_Adv");}
#region Body Section.
if ((i_Params_Get_Admin_By_Where.OWNER_ID == null) || (i_Params_Get_Admin_By_Where.OWNER_ID == 0)) { i_Params_Get_Admin_By_Where.OWNER_ID = this.OwnerID; }
if (i_Params_Get_Admin_By_Where.START_ROW == null) { i_Params_Get_Admin_By_Where.START_ROW = 0; }
if ((i_Params_Get_Admin_By_Where.END_ROW == null) || (i_Params_Get_Admin_By_Where.END_ROW == 0)) { i_Params_Get_Admin_By_Where.END_ROW = 1000000; }
List<DALC.Admin> oList_DBEntries = _AppContext.Get_Admin_By_Where_Adv(i_Params_Get_Admin_By_Where.EMAIL,i_Params_Get_Admin_By_Where.USERNAME,i_Params_Get_Admin_By_Where.PASSWORD,i_Params_Get_Admin_By_Where.OWNER_ID,i_Params_Get_Admin_By_Where.START_ROW,i_Params_Get_Admin_By_Where.END_ROW,ref tmp_TOTAL_COUNT);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oAdmin = new Admin();
oTools.CopyPropValues(oDBEntry, oAdmin);
oList.Add(oAdmin);
}
}
i_Params_Get_Admin_By_Where.TOTAL_COUNT = tmp_TOTAL_COUNT;
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Admin_By_Where_Adv");}
return oList;
}
public List<Contact> Get_Contact_By_Criteria_Adv(Params_Get_Contact_By_Criteria i_Params_Get_Contact_By_Criteria)
{
List<Contact> oList = new List<Contact>();
long? tmp_TOTAL_COUNT = 0;
Contact oContact = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_Contact_By_Criteria_Adv");}
#region Body Section.
if ((i_Params_Get_Contact_By_Criteria.OWNER_ID == null) || (i_Params_Get_Contact_By_Criteria.OWNER_ID == 0)) { i_Params_Get_Contact_By_Criteria.OWNER_ID = this.OwnerID; }
if (i_Params_Get_Contact_By_Criteria.START_ROW == null) { i_Params_Get_Contact_By_Criteria.START_ROW = 0; }
if ((i_Params_Get_Contact_By_Criteria.END_ROW == null) || (i_Params_Get_Contact_By_Criteria.END_ROW == 0)) { i_Params_Get_Contact_By_Criteria.END_ROW = 1000000; }
List<DALC.Contact> oList_DBEntries = _AppContext.Get_Contact_By_Criteria_Adv(i_Params_Get_Contact_By_Criteria.NAME,i_Params_Get_Contact_By_Criteria.EMAIL,i_Params_Get_Contact_By_Criteria.CATEGORY,i_Params_Get_Contact_By_Criteria.BUDGET,i_Params_Get_Contact_By_Criteria.MESSAGE,i_Params_Get_Contact_By_Criteria.OWNER_ID,i_Params_Get_Contact_By_Criteria.START_ROW,i_Params_Get_Contact_By_Criteria.END_ROW,ref tmp_TOTAL_COUNT);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oContact = new Contact();
oTools.CopyPropValues(oDBEntry, oContact);
oList.Add(oContact);
}
}
i_Params_Get_Contact_By_Criteria.TOTAL_COUNT = tmp_TOTAL_COUNT;
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Contact_By_Criteria_Adv");}
return oList;
}
public List<Contact> Get_Contact_By_Where_Adv(Params_Get_Contact_By_Where i_Params_Get_Contact_By_Where)
{
List<Contact> oList = new List<Contact>();
long? tmp_TOTAL_COUNT = 0;
Contact oContact = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_Contact_By_Where_Adv");}
#region Body Section.
if ((i_Params_Get_Contact_By_Where.OWNER_ID == null) || (i_Params_Get_Contact_By_Where.OWNER_ID == 0)) { i_Params_Get_Contact_By_Where.OWNER_ID = this.OwnerID; }
if (i_Params_Get_Contact_By_Where.START_ROW == null) { i_Params_Get_Contact_By_Where.START_ROW = 0; }
if ((i_Params_Get_Contact_By_Where.END_ROW == null) || (i_Params_Get_Contact_By_Where.END_ROW == 0)) { i_Params_Get_Contact_By_Where.END_ROW = 1000000; }
List<DALC.Contact> oList_DBEntries = _AppContext.Get_Contact_By_Where_Adv(i_Params_Get_Contact_By_Where.NAME,i_Params_Get_Contact_By_Where.EMAIL,i_Params_Get_Contact_By_Where.CATEGORY,i_Params_Get_Contact_By_Where.BUDGET,i_Params_Get_Contact_By_Where.MESSAGE,i_Params_Get_Contact_By_Where.OWNER_ID,i_Params_Get_Contact_By_Where.START_ROW,i_Params_Get_Contact_By_Where.END_ROW,ref tmp_TOTAL_COUNT);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oContact = new Contact();
oTools.CopyPropValues(oDBEntry, oContact);
oList.Add(oContact);
}
}
i_Params_Get_Contact_By_Where.TOTAL_COUNT = tmp_TOTAL_COUNT;
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_Contact_By_Where_Adv");}
return oList;
}
public List<User> Get_User_By_Criteria_Adv(Params_Get_User_By_Criteria i_Params_Get_User_By_Criteria)
{
List<User> oList = new List<User>();
long? tmp_TOTAL_COUNT = 0;
User oUser = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_User_By_Criteria_Adv");}
#region Body Section.
if ((i_Params_Get_User_By_Criteria.OWNER_ID == null) || (i_Params_Get_User_By_Criteria.OWNER_ID == 0)) { i_Params_Get_User_By_Criteria.OWNER_ID = this.OwnerID; }
if (i_Params_Get_User_By_Criteria.START_ROW == null) { i_Params_Get_User_By_Criteria.START_ROW = 0; }
if ((i_Params_Get_User_By_Criteria.END_ROW == null) || (i_Params_Get_User_By_Criteria.END_ROW == 0)) { i_Params_Get_User_By_Criteria.END_ROW = 1000000; }
List<DALC.User> oList_DBEntries = _AppContext.Get_User_By_Criteria_Adv(i_Params_Get_User_By_Criteria.USERNAME,i_Params_Get_User_By_Criteria.PASSWORD,i_Params_Get_User_By_Criteria.USER_TYPE_CODE,i_Params_Get_User_By_Criteria.OWNER_ID,i_Params_Get_User_By_Criteria.START_ROW,i_Params_Get_User_By_Criteria.END_ROW,ref tmp_TOTAL_COUNT);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oUser = new User();
oTools.CopyPropValues(oDBEntry, oUser);
oList.Add(oUser);
}
}
i_Params_Get_User_By_Criteria.TOTAL_COUNT = tmp_TOTAL_COUNT;
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_User_By_Criteria_Adv");}
return oList;
}
public List<User> Get_User_By_Where_Adv(Params_Get_User_By_Where i_Params_Get_User_By_Where)
{
List<User> oList = new List<User>();
long? tmp_TOTAL_COUNT = 0;
User oUser = null;
if (OnPreEvent_General != null){OnPreEvent_General("Get_User_By_Where_Adv");}
#region Body Section.
if ((i_Params_Get_User_By_Where.OWNER_ID == null) || (i_Params_Get_User_By_Where.OWNER_ID == 0)) { i_Params_Get_User_By_Where.OWNER_ID = this.OwnerID; }
if (i_Params_Get_User_By_Where.START_ROW == null) { i_Params_Get_User_By_Where.START_ROW = 0; }
if ((i_Params_Get_User_By_Where.END_ROW == null) || (i_Params_Get_User_By_Where.END_ROW == 0)) { i_Params_Get_User_By_Where.END_ROW = 1000000; }
List<DALC.User> oList_DBEntries = _AppContext.Get_User_By_Where_Adv(i_Params_Get_User_By_Where.USERNAME,i_Params_Get_User_By_Where.PASSWORD,i_Params_Get_User_By_Where.USER_TYPE_CODE,i_Params_Get_User_By_Where.OWNER_ID,i_Params_Get_User_By_Where.START_ROW,i_Params_Get_User_By_Where.END_ROW,ref tmp_TOTAL_COUNT);
if (oList_DBEntries != null)
{
foreach (var oDBEntry in oList_DBEntries)
{
oUser = new User();
oTools.CopyPropValues(oDBEntry, oUser);
oList.Add(oUser);
}
}
i_Params_Get_User_By_Where.TOTAL_COUNT = tmp_TOTAL_COUNT;
#endregion
if (OnPostEvent_General != null){OnPostEvent_General("Get_User_By_Where_Adv");}
return oList;
}
}
}
