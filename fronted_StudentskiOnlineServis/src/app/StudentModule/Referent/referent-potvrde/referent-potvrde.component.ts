import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";

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
    this.httpKlijent.get(`http://localhost:59854/Potvrda/GetAll`).subscribe(x=>{
      this.potvrde=x;
    });
  }

  izdaj(id:any)
  {
    this.httpKlijent.post(`http://localhost:59854/Potvrda/IzdajPotvrdu/${id}`,{}).subscribe(x=>{
      this.getPotvrde();
    });
  }
}
