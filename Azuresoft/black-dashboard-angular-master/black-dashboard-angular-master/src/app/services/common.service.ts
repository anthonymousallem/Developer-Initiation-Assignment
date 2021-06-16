import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
//import { MatSnackBar } from '@angular/material';

@Injectable()
export class CommonService {
  public APIUrl = 'http://localhost:5000/api/Data';
  public ticket = '';
  Is_Logged_In = new BehaviorSubject<boolean>(false);
  UI_Direction = new BehaviorSubject<string>('ltr');
  constructor(private _toast: ToastrService) { }

  ShowMessage(message: any) {
    this._toast.success(message);
  }

  Handle_Exception(msg: any) {
    if ((msg != null) && (msg !== '')) {
      this._toast.error(msg);
    }
  }
}