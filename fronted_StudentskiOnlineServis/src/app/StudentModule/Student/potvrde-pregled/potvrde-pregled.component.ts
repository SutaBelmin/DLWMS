import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {AutentifikacijaHelper} from "../../../helpers/autentifikacija-helper";

@Component({
  selector: 'app-potvrde-pregled',
  templateUrl: './potvrde-pregled.component.html',
  styleUrls: ['./potvrde-pregled.component.css']
})
export class PotvrdePregledComponent implements OnInit {

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
    var studentId=AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Potvrda/GetAll?studentId=${studentId}`).subscribe(x=>{
      this.potvrde=x;
    });
  }

}
