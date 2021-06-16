import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { CommonService } from "src/app/services/common.service";
import { Contact, Params_Get_Contact_By_OWNER_ID, Proxy } from "src/app/services/proxy.service";

@Component({
  selector: "app-tables",
  templateUrl: "tables.component.html"
})
export class TablesComponent implements OnInit, OnDestroy {

  Get_Contact_By_OWNER_ID_Subscription = new Subscription();
  searchModel: Params_Get_Contact_By_OWNER_ID = new Params_Get_Contact_By_OWNER_ID();
  data: Contact[] = [];



  constructor(private proxy: Proxy, private CmSvc: CommonService) { }

  ngOnInit(): void {


    this.fetchData();
  }
  ngOnDestroy(): void {
    this.Get_Contact_By_OWNER_ID_Subscription.unsubscribe();

  }
  fetchData() {
    this.searchModel.OWNER_ID = 1;
    this.Get_Contact_By_OWNER_ID_Subscription = this.proxy.Get_Contact_By_OWNER_ID(this.searchModel).subscribe(result => {
      if (result != null) {
        result.forEach((element: any) => {
          this.data.push(element);
        });
      }
    });
  }
}
