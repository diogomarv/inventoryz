import { Component } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ModalPicaComponent } from './modal-pica/modal-pica.component';
export interface DialogData {
  animal: 'panda' | 'unicorn' | 'lion';
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'front-end';
  constructor(public dialog: MatDialog) {}
  openDialog() {
    this.dialog.open(ModalPicaComponent, {
      data: {
        animal: 'panda',
      },
    });
  }
}
