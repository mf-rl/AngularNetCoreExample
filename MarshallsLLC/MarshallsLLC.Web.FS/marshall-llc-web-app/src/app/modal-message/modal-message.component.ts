import { Component, Inject, Injectable } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

@Component({
  templateUrl: './modal-message.component.html',
})
export class ModalMessageComponent {

  constructor(private dialogRef: MatDialogRef<ModalMessageComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  public closeMe() {
    this.dialogRef.close();
  }

}
