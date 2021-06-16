import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from 'src/app/services/common.service';
import { Params_Authenticate, User , Proxy } from 'src/app/services/proxy.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
paramsAuthenticate:Params_Authenticate = new Params_Authenticate();
  constructor(private proxy:Proxy , private route : Router , private CmSvc:CommonService) { }

  ngOnInit(): void {
  }
public Login(){
  this.proxy.Authenticate(this.paramsAuthenticate).subscribe(result => {
    if(result){
      this.CmSvc.ShowMessage("Welcome "+result.UserName);
this.route.navigate(["/dashboard"])
    }
  })
}
}
