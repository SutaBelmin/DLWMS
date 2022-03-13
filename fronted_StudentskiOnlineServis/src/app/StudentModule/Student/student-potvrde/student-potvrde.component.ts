import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {Router} from "@angular/router";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-student-potvrde',
  templateUrl: './student-potvrde.component.html',
  styleUrls: ['./student-potvrde.component.css']
})
export class StudentPotvrdeComponent implements OnInit {

  svrhe:any;

  odabranaSvrhaId:any;
  opis:any;

  constructor(private httpKlijent:HttpClient, private router:Router)
  {

  }

  ngOnInit(): void
  {
    this.getSvrhe();
  }

  getSvrhe()
  {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Potvrda/GetSvrhe`).subscribe(x=>{
      this.svrhe=x;
      // @ts-ignore
      this.odabranaSvrhaId=x[0].id;
    });
  }

  save()
  {
    this.httpKlijent.post(`${MojConfig.MyLocalHost}/Potvrda/AddPotvrdu`,{
      svrhaId:this.odabranaSvrhaId,
      Opis:this.opis
    }, MojConfig.http_opcije()).subscribe(x=>{
      porukaSuccess("Zahtijev uspješno poslat");
      this.router.navigateByUrl(`/studentmain/potvrdepregled`);
    });
  }

}
