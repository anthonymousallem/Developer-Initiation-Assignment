import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { CommonService } from "src/app/services/common.service";
import { Admin, Params_Delete_Admin, Params_Get_Admin_By_OWNER_ID , Proxy } from "src/app/services/proxy.service";

@Component({
  selector: "app-user",
  templateUrl: "user.component.html"
})
export class UserComponent implements OnInit, OnDestroy  {
  Get_Admin_By_OWNER_ID_Subscription = new Subscription();
  searchModel: Params_Get_Admin_By_OWNER_ID = new Params_Get_Admin_By_OWNER_ID();
  data: Admin[] = [];
  
  
  
  constructor(private proxy: Proxy, private CmSvc: CommonService) {}
  
  ngOnInit(): void {
  
  
  this.fetchData();
  }
  ngOnDestroy(): void {
  this.Get_Admin_By_OWNER_ID_Subscription.unsubscribe();
  
  }
  fetchData() {
  this.searchModel.OWNER_ID = 1;
  this.Get_Admin_By_OWNER_ID_Subscription = this.proxy.Get_Admin_By_OWNER_ID(this.searchModel).subscribe(result => {
   if (result != null) {
  result.forEach((element: any) => {
  this.data.push(element);
  });
  }
  });
  }
  AddEntry() {
  if (this.data !== undefined) {
  if (this.data.filter(e => e.ADMIN_ID === -1).length > 0) {
  return;
  }
  }
  const record = new Admin();
  record.ADMIN_ID = -1;
  this.data.unshift(record);
  }
  Edit(current) {
  this.proxy.Edit_Admin(current).subscribe((result) => {
  if (result != null) {
  this.CmSvc.ShowMessage('Done');
  if (current.ADMIN_ID === -1) {
  this.data.splice(this.data.indexOf(current), 1);
  const newEntry: any = result;
  newEntry.MyUploadedImages = [];
  newEntry.MyURL = this.CmSvc.APIUrl + '/Upload_Image?REL_ENTITY=[TBL_ADMIN]&REL_FIELD=ADMIN_IMAGE&REL_KEY=' + newEntry.ADMIN_ID;
  this.data.unshift(newEntry);
  }
  }
  });
  }
  Delete(entry) {
  const _params_Delete_Admin = new Params_Delete_Admin();
  _params_Delete_Admin.ADMIN_ID = entry.ADMIN_ID;
  this.proxy.Delete_Admin(_params_Delete_Admin).subscribe(data => {
  if (data === '') {
  this.data.splice(this.data.indexOf(entry), 1);
  }
  });
  }
}
