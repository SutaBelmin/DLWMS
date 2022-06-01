import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {AutentifikacijaHelper} from "../../../helpers/autentifikacija-helper";
import {PageEvent} from "@angular/material/paginator";

@Component({
  selector: 'app-potvrde-pregled',
  templateUrl: './potvrde-pregled.component.html',
  styleUrls: ['./potvrde-pregled.component.css']
})
export class PotvrdePregledComponent implements OnInit {

  potvrde:any;
  numberOfRecords: number= 0;

  constructor(private httpKlijent:HttpClient)
  {

  }

  ngOnInit(): void
  {
    this.getPotvrde();
  }


  getPotvrde(pageSize: number = 10,  page: number = 0)
  {
    var studentId=AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
    const potvrdeRequest  ={
      studentId: studentId,
      pageSize: pageSize,
      pageNumber: page
    };
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Potvrda/GetAll`, {
      params: potvrdeRequest
    }).subscribe(x=>{
      // @ts-ignore
      this.potvrde=x.potvrde;
      // @ts-ignore
      this.numberOfRecords = x.numberOfRecords;
    });
  }

  onPageChanged(e: PageEvent){
    this.getPotvrde(e.pageSize, e.pageIndex);
  }

}
