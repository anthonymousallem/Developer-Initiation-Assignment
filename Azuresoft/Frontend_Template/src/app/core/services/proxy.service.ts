import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent} from '@angular/common/http';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { CommonService } from './common.service';
@Injectable()
export class Proxy {
APIBaseUrl = '';
url = '';
constructor(public api: HttpClient, private common: CommonService) {
this.APIBaseUrl = common.APIUrl; 
}
Edit_Admin(i_Admin: Admin) : Observable<Admin> {
this.url = this.APIBaseUrl + '/Edit_Admin?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Edit_Admin>(this.url, JSON.stringify(i_Admin), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Admin;}));
}
Delete_Admin(i_Params_Delete_Admin: Params_Delete_Admin) : Observable<string> {
this.url = this.APIBaseUrl + '/Delete_Admin?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<any>(this.url, JSON.stringify(i_Params_Delete_Admin), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg);return response.ExceptionMsg;}));
}
Get_Admin_By_OWNER_ID(i_Params_Get_Admin_By_OWNER_ID: Params_Get_Admin_By_OWNER_ID) : Observable<Admin[]> {
this.url = this.APIBaseUrl + '/Get_Admin_By_OWNER_ID?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Get_Admin_By_OWNER_ID>(this.url, JSON.stringify(i_Params_Get_Admin_By_OWNER_ID), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Result;}));
}
Authenticate(i_Params_Authenticate: Params_Authenticate) : Observable<UserInfo> {
this.url = this.APIBaseUrl + '/Authenticate?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Authenticate>(this.url, JSON.stringify(i_Params_Authenticate), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Result;}));
}
Edit_Contact(i_Contact: Contact) : Observable<Contact> {
this.url = this.APIBaseUrl + '/Edit_Contact?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Edit_Contact>(this.url, JSON.stringify(i_Contact), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Contact;}));
}
Delete_Contact(i_Params_Delete_Contact: Params_Delete_Contact) : Observable<string> {
this.url = this.APIBaseUrl + '/Delete_Contact?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<any>(this.url, JSON.stringify(i_Params_Delete_Contact), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg);return response.ExceptionMsg;}));
}
Get_Contact_By_OWNER_ID(i_Params_Get_Contact_By_OWNER_ID: Params_Get_Contact_By_OWNER_ID) : Observable<Contact[]> {
this.url = this.APIBaseUrl + '/Get_Contact_By_OWNER_ID?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Get_Contact_By_OWNER_ID>(this.url, JSON.stringify(i_Params_Get_Contact_By_OWNER_ID), options)
.pipe(map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Result;}));
}
}
export class Admin
{
ADMIN_ID?: number;
EMAIL!: string;
USERNAME!: string;
PASSWORD!: string;
ENTRY_USER_ID?: number;
ENTRY_DATE!: string;
OWNER_ID?: number;
}
export class Params_Delete_Admin
{
ADMIN_ID?: number;
}
export class Params_Get_Admin_By_OWNER_ID
{
OWNER_ID?: number;
}
export class Params_Authenticate
{
USER_NAME!: string;
PASSWORD!: string;
}
export class UserInfo
{
UserID?: number;
UserName!: string;
Email!: string;
Password!: string;
IsAuthenticated!: boolean;
Language!: number;
OwnerID?: number;
Ticket!: string;
USER_TYPE_CODE!: string;
}
export class Contact
{
CONTACT_ID?: number;
NAME!: string;
EMAIL!: string;
CATEGORY!: string;
BUDGET!: string;
MESSAGE!: string;
ENTRY_USER_ID?: number;
ENTRY_DATE!: string;
OWNER_ID?: number;
}
export class Params_Delete_Contact
{
CONTACT_ID?: number;
}
export class Params_Get_Contact_By_OWNER_ID
{
OWNER_ID?: number;
}
export class Action_Result{
ExceptionMsg!: string;
}
export class Result_Edit_Admin extends Action_Result {
My_Admin!: Admin;
}
export class Result_Delete_Admin extends Action_Result {
My_Params_Delete_Admin!: Params_Delete_Admin;
}
export class Result_Get_Admin_By_OWNER_ID extends Action_Result {
My_Result!: Admin[];
My_Params_Get_Admin_By_OWNER_ID!: Params_Get_Admin_By_OWNER_ID;
}
export class Result_Authenticate extends Action_Result {
My_Result!: UserInfo;
My_Params_Authenticate!: Params_Authenticate;
}
export class Result_Edit_Contact extends Action_Result {
My_Contact!: Contact;
}
export class Result_Delete_Contact extends Action_Result {
My_Params_Delete_Contact!: Params_Delete_Contact;
}
export class Result_Get_Contact_By_OWNER_ID extends Action_Result {
My_Result!: Contact[];
My_Params_Get_Contact_By_OWNER_ID!: Params_Get_Contact_By_OWNER_ID;
}
