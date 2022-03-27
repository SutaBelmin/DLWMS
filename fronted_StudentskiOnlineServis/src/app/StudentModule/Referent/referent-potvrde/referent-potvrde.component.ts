import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";

@Component({
  selector: 'app-referent-potvrde',
  templateUrl: './referent-potvrde.component.html',
  styleUrls: ['./referent-potvrde.component.css']
})
export class ReferentPotvrdeComponent implements OnInit {

  potvrde:any;

  constructor(private httpKlijent:HttpClient)
  {

  }

  ngOnInit(): void
  {
    this.getPotvrde();
  }

  getPotvrde()
  {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Potvrda/GetAll`).subscribe(x=>{
      this.potvrde=x;
    });
  }

  izdaj(id:any)
  {
    this.httpKlijent.post(`${MojConfig.MyLocalHost}/Potvrda/IzdajPotvrdu/${id}`,{}, MojConfig.http_opcije()).subscribe(x=>{
      this.getPotvrde();
    });
  }
}
