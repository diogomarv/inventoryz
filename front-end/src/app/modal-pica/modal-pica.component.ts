import {Component, Inject, OnInit} from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DialogData } from '../app.component';
@Component({
  selector: 'app-modal-pica',
  templateUrl: './modal-pica.component.html',
  styleUrls: ['./modal-pica.component.css']
})
export class ModalPicaComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit(): void {
  }

}
