import { Component, OnInit } from '@angular/core';
import { Params_SendEmailForSubscriptions , Proxy } from 'src/app/services/proxy.service';

@Component({
  selector: 'app-send-email',
  templateUrl: './send-email.component.html',
  styleUrls: ['./send-email.component.scss']
})
export class SendEmailComponent implements OnInit {
  paramsSendEmail : Params_SendEmailForSubscriptions  = new  Params_SendEmailForSubscriptions();
  constructor(private proxy: Proxy) { }

  ngOnInit(): void {
  }

public SendEmail(){
this.proxy.SendEmailForSubscriptions(this.paramsSendEmail).subscribe();
}

}
