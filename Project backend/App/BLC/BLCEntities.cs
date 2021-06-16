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
#region Params_Get_Admin_By_ADMIN_ID
public partial class Params_Get_Admin_By_ADMIN_ID
{
#region Properties
public Int32? ADMIN_ID {get;set;}

#endregion
}
#endregion
#region Params_Get_Contact_By_CONTACT_ID
public partial class Params_Get_Contact_By_CONTACT_ID
{
#region Properties
public Int32? CONTACT_ID {get;set;}

#endregion
}
#endregion
#region Params_Get_Owner_By_OWNER_ID
public partial class Params_Get_Owner_By_OWNER_ID
{
#region Properties
public Int32? OWNER_ID {get;set;}

#endregion
}
#endregion
#region Params_Get_User_By_USER_ID
public partial class Params_Get_User_By_USER_ID
{
#region Properties
public long? USER_ID {get;set;}

#endregion
}
#endregion
public partial class Params_Get_Admin_By_ADMIN_ID_List
{
public List<Int32?> ADMIN_ID_LIST {get;set;}
}
public partial class Params_Get_Admin_By_ADMIN_ID_List_SP
{
public string ADMIN_ID_LIST {get;set;}

}
public partial class Params_Get_Contact_By_CONTACT_ID_List
{
public List<Int32?> CONTACT_ID_LIST {get;set;}
}
public partial class Params_Get_Contact_By_CONTACT_ID_List_SP
{
public string CONTACT_ID_LIST {get;set;}

}
public partial class Params_Get_Owner_By_OWNER_ID_List
{
public List<Int32?> OWNER_ID_LIST {get;set;}
}
public partial class Params_Get_Owner_By_OWNER_ID_List_SP
{
public string OWNER_ID_LIST {get;set;}

}
public partial class Params_Get_User_By_USER_ID_List
{
public List<long?> USER_ID_LIST {get;set;}
}
public partial class Params_Get_User_By_USER_ID_List_SP
{
public string USER_ID_LIST {get;set;}

}
public partial class Params_Get_Admin_By_EMAIL
{
public string EMAIL {get;set;}

}
public partial class Params_Get_Admin_By_USERNAME
{
public string USERNAME {get;set;}

}
public partial class Params_Get_Admin_By_OWNER_ID
{
public Int32? OWNER_ID {get;set;}

}
public partial class Params_Get_Contact_By_OWNER_ID
{
public Int32? OWNER_ID {get;set;}

}
public partial class Params_Get_User_By_OWNER_ID
{
public Int32? OWNER_ID {get;set;}

}
public partial class Params_Get_User_By_USERNAME
{
public string USERNAME {get;set;}

}
public partial class Params_Get_Admin_By_Criteria
{

public Int32? OWNER_ID {get;set;}
public string EMAIL {get;set;}
public string USERNAME {get;set;}
public string PASSWORD {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Admin_By_Where
{

public Int32? OWNER_ID {get;set;}
public string EMAIL {get;set;}
public string USERNAME {get;set;}
public string PASSWORD {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Contact_By_Criteria
{

public Int32? OWNER_ID {get;set;}
public string NAME {get;set;}
public string EMAIL {get;set;}
public string CATEGORY {get;set;}
public string BUDGET {get;set;}
public string MESSAGE {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Contact_By_Where
{

public Int32? OWNER_ID {get;set;}
public string NAME {get;set;}
public string EMAIL {get;set;}
public string CATEGORY {get;set;}
public string BUDGET {get;set;}
public string MESSAGE {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Owner_By_Criteria
{

public Int32? OWNER_ID {get;set;}
public string CODE {get;set;}
public string DESCRIPTION {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Owner_By_Where
{

public Int32? OWNER_ID {get;set;}
public string CODE {get;set;}
public string DESCRIPTION {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Owner_By_Criteria_V2
{

public Int32? OWNER_ID {get;set;}
public string CODE {get;set;}
public string MAINTENANCE_DUE_DATE {get;set;}
public string DESCRIPTION {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_Owner_By_Where_V2
{

public Int32? OWNER_ID {get;set;}
public string CODE {get;set;}
public string MAINTENANCE_DUE_DATE {get;set;}
public string DESCRIPTION {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_User_By_Criteria
{

public Int32? OWNER_ID {get;set;}
public string USERNAME {get;set;}
public string PASSWORD {get;set;}
public string USER_TYPE_CODE {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
public partial class Params_Get_User_By_Where
{

public Int32? OWNER_ID {get;set;}
public string USERNAME {get;set;}
public string PASSWORD {get;set;}
public string USER_TYPE_CODE {get;set;}
public long? START_ROW {get;set;}
public long? END_ROW {get;set;}
public long? TOTAL_COUNT {get;set;}
}
#region Params_Delete_Admin
public partial class Params_Delete_Admin
{
#region Properties
public Int32? ADMIN_ID {get;set;}
#endregion
}
#endregion
#region Params_Delete_Contact
public partial class Params_Delete_Contact
{
#region Properties
public Int32? CONTACT_ID {get;set;}
#endregion
}
#endregion
#region Params_Delete_Owner
public partial class Params_Delete_Owner
{
#region Properties
public Int32? OWNER_ID {get;set;}
#endregion
}
#endregion
#region Params_Delete_User
public partial class Params_Delete_User
{
#region Properties
public long? USER_ID {get;set;}
#endregion
}
#endregion
public partial class Params_Delete_Admin_By_EMAIL
{
public string EMAIL {get;set;}
}
public partial class Params_Delete_Admin_By_USERNAME
{
public string USERNAME {get;set;}
}
public partial class Params_Delete_Admin_By_OWNER_ID
{
public Int32? OWNER_ID {get;set;}
}
public partial class Params_Delete_Contact_By_OWNER_ID
{
public Int32? OWNER_ID {get;set;}
}
public partial class Params_Delete_User_By_OWNER_ID
{
public Int32? OWNER_ID {get;set;}
}
public partial class Params_Delete_User_By_USERNAME
{
public string USERNAME {get;set;}
}
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
#region Params_Edit_Admin_List
public partial class Params_Edit_Admin_List
{
#region Properties
public List<Admin> My_List_To_Edit { get; set; }
public List<Admin> My_List_To_Delete { get; set; }
#endregion
}
#endregion
#region Params_Edit_Contact_List
public partial class Params_Edit_Contact_List
{
#region Properties
public List<Contact> My_List_To_Edit { get; set; }
public List<Contact> My_List_To_Delete { get; set; }
#endregion
}
#endregion
#region Params_Edit_Owner_List
public partial class Params_Edit_Owner_List
{
#region Properties
public List<Owner> My_List_To_Edit { get; set; }
public List<Owner> My_List_To_Delete { get; set; }
#endregion
}
#endregion
#region Params_Edit_User_List
public partial class Params_Edit_User_List
{
#region Properties
public List<User> My_List_To_Edit { get; set; }
public List<User> My_List_To_Delete { get; set; }
#endregion
}
#endregion
}
