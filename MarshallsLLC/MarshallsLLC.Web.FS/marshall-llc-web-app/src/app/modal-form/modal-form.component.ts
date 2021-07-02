import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog'
import { Router } from '@angular/router';
import { ModalMessageComponent } from '../modal-message/modal-message.component';

@Component({
  selector: 'app-modal-form',
  templateUrl: './modal-form.component.html',
  styleUrls: ['./modal-form.component.scss']
})
export class ModalFormComponent {
  public email: string = "";
  public password: string = "";

  constructor(private dialog: MatDialog, private router: Router) { }

  login() {
    if (this.email === "email@email.com" && this.password === "123456"){
      this.router.navigate(['success']);
    } else {
      this.dialog.open(ModalMessageComponent, { data: {
        message: "Error!!!"
      }})
    }
  }

}
