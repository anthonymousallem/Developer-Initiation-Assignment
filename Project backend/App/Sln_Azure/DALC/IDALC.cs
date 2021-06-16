using System;
using System.Collections.Generic;
namespace DALC
{
#region Repositories
public partial class Admin
{
public Int32? ADMIN_ID {get;set;}
public string EMAIL {get;set;}
public string USERNAME {get;set;}
public string PASSWORD {get;set;}
public long? ENTRY_USER_ID {get;set;}
public string ENTRY_DATE {get;set;}
public Int32? OWNER_ID {get;set;}
}
public partial class Contact
{
public Int32? CONTACT_ID {get;set;}
public string NAME {get;set;}
public string EMAIL {get;set;}
public string CATEGORY {get;set;}
public string BUDGET {get;set;}
public string MESSAGE {get;set;}
public long? ENTRY_USER_ID {get;set;}
public string ENTRY_DATE {get;set;}
public Int32? OWNER_ID {get;set;}
}
public partial class Owner
{
public Int32? OWNER_ID {get;set;}
public string CODE {get;set;}
public string MAINTENANCE_DUE_DATE {get;set;}
public string DESCRIPTION {get;set;}
public string ENTRY_DATE {get;set;}
}
public partial class User
{
public long? USER_ID {get;set;}
public Int32? OWNER_ID {get;set;}
public string USERNAME {get;set;}
public string PASSWORD {get;set;}
public string USER_TYPE_CODE {get;set;}
public bool? IS_ACTIVE {get;set;}
public string ENTRY_DATE {get;set;}
}
#endregion 
public partial interface IDALC
{
Admin Get_Admin_By_ADMIN_ID ( Int32? ADMIN_ID);
Contact Get_Contact_By_CONTACT_ID ( Int32? CONTACT_ID);
Owner Get_Owner_By_OWNER_ID ( Int32? OWNER_ID);
User Get_User_By_USER_ID ( long? USER_ID);
Admin Get_Admin_By_ADMIN_ID_Adv ( Int32? ADMIN_ID);
Contact Get_Contact_By_CONTACT_ID_Adv ( Int32? CONTACT_ID);
User Get_User_By_USER_ID_Adv ( long? USER_ID);
List<Admin> Get_Admin_By_ADMIN_ID_List ( List<Int32?> ADMIN_ID_LIST);
List<Contact> Get_Contact_By_CONTACT_ID_List ( List<Int32?> CONTACT_ID_LIST);
List<Owner> Get_Owner_By_OWNER_ID_List ( List<Int32?> OWNER_ID_LIST);
List<User> Get_User_By_USER_ID_List ( List<long?> USER_ID_LIST);
List<Admin> Get_Admin_By_ADMIN_ID_List_Adv ( List<Int32?> ADMIN_ID_LIST);
List<Contact> Get_Contact_By_CONTACT_ID_List_Adv ( List<Int32?> CONTACT_ID_LIST);
List<User> Get_User_By_USER_ID_List_Adv ( List<long?> USER_ID_LIST);
List<Admin> Get_Admin_By_EMAIL ( string EMAIL);
List<Admin> Get_Admin_By_USERNAME ( string USERNAME);
List<Admin> Get_Admin_By_OWNER_ID ( Int32? OWNER_ID);
List<Contact> Get_Contact_By_OWNER_ID ( Int32? OWNER_ID);
List<User> Get_User_By_OWNER_ID ( Int32? OWNER_ID);
List<User> Get_User_By_USERNAME ( string USERNAME);
List<Admin> Get_Admin_By_EMAIL_Adv ( string EMAIL);
List<Admin> Get_Admin_By_USERNAME_Adv ( string USERNAME);
List<Admin> Get_Admin_By_OWNER_ID_Adv ( Int32? OWNER_ID);
List<Contact> Get_Contact_By_OWNER_ID_Adv ( Int32? OWNER_ID);
List<User> Get_User_By_OWNER_ID_Adv ( Int32? OWNER_ID);
List<User> Get_User_By_USERNAME_Adv ( string USERNAME);
List<Admin> Get_Admin_By_Criteria ( string EMAIL, string USERNAME, string PASSWORD, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Admin> Get_Admin_By_Where ( string EMAIL, string USERNAME, string PASSWORD, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Contact> Get_Contact_By_Criteria ( string NAME, string EMAIL, string CATEGORY, string BUDGET, string MESSAGE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Contact> Get_Contact_By_Where ( string NAME, string EMAIL, string CATEGORY, string BUDGET, string MESSAGE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Owner> Get_Owner_By_Criteria ( string CODE, string DESCRIPTION, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Owner> Get_Owner_By_Where ( string CODE, string DESCRIPTION, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Owner> Get_Owner_By_Criteria_V2 ( string CODE, string MAINTENANCE_DUE_DATE, string DESCRIPTION, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Owner> Get_Owner_By_Where_V2 ( string CODE, string MAINTENANCE_DUE_DATE, string DESCRIPTION, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<User> Get_User_By_Criteria ( string USERNAME, string PASSWORD, string USER_TYPE_CODE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<User> Get_User_By_Where ( string USERNAME, string PASSWORD, string USER_TYPE_CODE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Admin> Get_Admin_By_Criteria_Adv ( string EMAIL, string USERNAME, string PASSWORD, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Admin> Get_Admin_By_Where_Adv ( string EMAIL, string USERNAME, string PASSWORD, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Contact> Get_Contact_By_Criteria_Adv ( string NAME, string EMAIL, string CATEGORY, string BUDGET, string MESSAGE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<Contact> Get_Contact_By_Where_Adv ( string NAME, string EMAIL, string CATEGORY, string BUDGET, string MESSAGE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<User> Get_User_By_Criteria_Adv ( string USERNAME, string PASSWORD, string USER_TYPE_CODE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
List<User> Get_User_By_Where_Adv ( string USERNAME, string PASSWORD, string USER_TYPE_CODE, Int32? OWNER_ID, Int64? START_ROW, Int64? END_ROW,ref  Int64? TOTAL_COUNT);
void Delete_Admin ( Int32? ADMIN_ID);
void Delete_Contact ( Int32? CONTACT_ID);
void Delete_Owner ( Int32? OWNER_ID);
void Delete_User ( long? USER_ID);
void Delete_Admin_By_EMAIL ( string EMAIL);
void Delete_Admin_By_USERNAME ( string USERNAME);
void Delete_Admin_By_OWNER_ID ( Int32? OWNER_ID);
void Delete_Contact_By_OWNER_ID ( Int32? OWNER_ID);
void Delete_User_By_OWNER_ID ( Int32? OWNER_ID);
void Delete_User_By_USERNAME ( string USERNAME);
Int32? Edit_Admin ( Int32? ADMIN_ID, string EMAIL, string USERNAME, string PASSWORD, long? ENTRY_USER_ID, string ENTRY_DATE, Int32? OWNER_ID);
Int32? Edit_Contact ( Int32? CONTACT_ID, string NAME, string EMAIL, string CATEGORY, string BUDGET, string MESSAGE, long? ENTRY_USER_ID, string ENTRY_DATE, Int32? OWNER_ID);
Int32? Edit_Owner ( Int32? OWNER_ID, string CODE, string MAINTENANCE_DUE_DATE, string DESCRIPTION, string ENTRY_DATE);
long? Edit_User ( long? USER_ID, Int32? OWNER_ID, string USERNAME, string PASSWORD, string USER_TYPE_CODE, bool? IS_ACTIVE, string ENTRY_DATE);
List<dynamic> GET_DISTINCT_SETUP_TBL ( Int32? OWNER_ID);
List<dynamic> GET_NEXT_VALUE ( string STARTER_CODE);
List<dynamic> GET_TBL_SETUP ();
List<dynamic> UP_BULK_UPSERT_ADMIN ( string JSON_CONTENT);
List<dynamic> UP_BULK_UPSERT_CONTACT ( string JSON_CONTENT);
List<dynamic> UP_BULK_UPSERT_OWNER ( string JSON_CONTENT);
List<dynamic> UP_BULK_UPSERT_USER ( string JSON_CONTENT);
List<dynamic> UP_CHECK_USER_EXISTENCE ( Int32? OWNER_ID, string USERNAME,ref  bool? EXISTS);
List<dynamic> UP_EDIT_SETUP ( Int32? OWNER_ID, string TBL_NAME, string CODE_NAME, bool? ISSYSTEM, bool? ISDELETEABLE, bool? ISUPDATEABLE, bool? ISVISIBLE, bool? ISDELETED, Int32? DISPLAY_ORDER, string CODE_VALUE_EN, string CODE_VALUE_FR, string CODE_VALUE_AR, string ENTRY_DATE, long? ENTRY_USER_ID, string NOTES);
List<dynamic> UP_EXTRACT_ROUTINE_PARAMETERS ( string ROUTINE_NAME);
List<dynamic> UP_EXTRACT_ROUTINE_RESULT_SCHEMA ( string ROUTINE_NAME);
List<dynamic> UP_GENERATE_INSERT_STATEMENTS ( string @tableName);
List<dynamic> UP_GET_NEXT_VALUE ( string STARTER_CODE,ref  long? VALUE);
List<dynamic> UP_GET_SETUP_ENTRIES ( Int32? OWNER_ID, string TBL_NAME, bool? ISDELETED, bool? ISVISIBLE);
List<dynamic> UP_GET_SETUP_ENTRY ( Int32? OWNER_ID, string TBL_NAME, string CODE_NAME);
List<dynamic> UP_GET_USER_BY_CREDENTIALS ( Int32? OWNER_ID, string USERNAME, string PASSWORD);
}
}
