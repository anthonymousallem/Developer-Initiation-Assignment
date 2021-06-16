import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { CommonService } from './common.service';
@Injectable()
export class Proxy {
APIBaseUrl ='';
url ='';
constructor(public api: HttpClient,private common: CommonService) {
this.APIBaseUrl = common.APIUrl; 
}
Edit_Blood_type(i_Blood_type: Blood_type) : Observable<Blood_type> {
this.url = this.APIBaseUrl + '/Edit_Blood_type?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Edit_Blood_type>(this.url, JSON.stringify(i_Blood_type), options)
.map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Blood_type;});
}
Delete_Blood_type(i_Params_Delete_Blood_type: Params_Delete_Blood_type) : Observable<string> {
this.url = this.APIBaseUrl + '/Delete_Blood_type?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<any>(this.url, JSON.stringify(i_Params_Delete_Blood_type), options)
.map(response => { this.common.Handle_Exception(response.ExceptionMsg);return response.ExceptionMsg;});
}
Get_Blood_type_By_OWNER_ID(i_Params_Get_Blood_type_By_OWNER_ID: Params_Get_Blood_type_By_OWNER_ID) : Observable<Blood_type[]> {
this.url = this.APIBaseUrl + '/Get_Blood_type_By_OWNER_ID?Ticket=' + this.common.ticket;
const headers = new HttpHeaders({ 'Content-Type': 'application/json','ticket': this.common.ticket });
const options = { headers: headers };
return this.api.post<Result_Get_Blood_type_By_OWNER_ID>(this.url, JSON.stringify(i_Params_Get_Blood_type_By_OWNER_ID), options)
.map(response => { this.common.Handle_Exception(response.ExceptionMsg); return response.My_Result;});
}
}
export class Blood_type
{
BLOOD_TYPE_ID?: number;
NAME: string;
ENTRY_USER_ID?: number;
ENTRY_DATE: string;
OWNER_ID?: number;
}
export class Params_Delete_Blood_type
{
BLOOD_TYPE_ID?: number;
}
export class Params_Get_Blood_type_By_OWNER_ID
{
OWNER_ID?: number;
}
export class Action_Result{
ExceptionMsg: string;
}
export class Result_Edit_Blood_type extends Action_Result {
My_Blood_type : Blood_type;
}
export class Result_Delete_Blood_type extends Action_Result {
My_Params_Delete_Blood_type : Params_Delete_Blood_type;
}
export class Result_Get_Blood_type_By_OWNER_ID extends Action_Result {
My_Result : Blood_type[];
My_Params_Get_Blood_type_By_OWNER_ID : Params_Get_Blood_type_By_OWNER_ID;
}
