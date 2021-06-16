import { Component, OnInit, Output } from '@angular/core';
import { CommonService } from 'src/app/core/services/common.service';
import { Contact, Proxy } from 'src/app/core/services/proxy.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  scripts = [
    "assets/scripts/vlt-plugins.min.js",
    "assets/scripts/vlt-helpers.js",
    "assets/scripts/vlt-controllers.min.js"
  ]
public entry:Contact = new Contact();
  constructor(private proxy: Proxy, private CmSvc: CommonService) { }

  ngOnInit(): void {
    this.scripts.forEach(script => {
      this.loadScript(script);
    });
    
  }
  loadScript(url: string) {
    const body = <HTMLDivElement>document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }
  Edit(current:any) {
    current.CONTACT_ID = -1;
    current.OWNER_ID = 1;
    this.proxy.Edit_Contact(current).subscribe((result) => {
    if (result != null) {
    this.CmSvc.ShowMessage('Your operation is successful !');
    if (current.CONTACT_ID === -1) {
    const newEntry: any = result;
    newEntry.MyUploadedImages = [];
    newEntry.MyURL = this.CmSvc.APIUrl + '/Upload_Image?REL_ENTITY=[TBL_CONTACT]&REL_FIELD=CONTACT_IMAGE&REL_KEY=' + newEntry.CONTACT_ID;
    }
    }
    });
    }
    public moveToContactForm(category : string)
    {
      this.entry.CATEGORY = category ;
    }
  }





  

