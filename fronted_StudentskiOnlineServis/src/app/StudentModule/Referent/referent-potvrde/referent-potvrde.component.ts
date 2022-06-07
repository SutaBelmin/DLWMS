import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {AutentifikacijaHelper} from "../../../helpers/autentifikacija-helper";

@Component({
  selector: 'app-referent-potvrde',
  templateUrl: './referent-potvrde.component.html',
  styleUrls: ['./referent-potvrde.component.css']
})
export class ReferentPotvrdeComponent implements OnInit {

  potvrde:any;
  pageSize: number= 10;
  pageIndex: number= 0;
  numberOfRecords: number= 0;
  @ViewChild("matPaginator", {static: true}) private paginator: MatPaginator;


  constructor(private httpKlijent:HttpClient)
  {

  }

  ngOnInit(): void
  {
    this.getPotvrde();
  }

  getPotvrde(pageSize: number = 10,  page: number = 0)
  {
    const potvrdeRequest  ={
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

  izdaj(id:any)
  {
    this.httpKlijent.post(`${MojConfig.MyLocalHost}/Potvrda/IzdajPotvrdu/${id}`,{}, MojConfig.http_opcije()).subscribe(x=>{
      this.onPageChanged({pageSize:this.pageSize, pageIndex: this.pageIndex} as PageEvent);
    });
  }

  onPageChanged(e: PageEvent){
    this.pageSize = e.pageSize;
    this.pageIndex= e.pageIndex;
    this.getPotvrde(e.pageSize, e.pageIndex);
  }
}
