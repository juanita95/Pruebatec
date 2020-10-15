import { formatCurrency } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Users } from '../models/users';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.sass']
})
export class FacturasComponent implements OnInit {

  constructor(public service: UsersService, private toastr: ToastrService ) {
  }

  ngOnInit(): void {
    this.service.getUserName();
  }
  send(id){
    this.service.send(id);

  }

}



