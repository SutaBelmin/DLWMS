import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-predmeti-serach',
  templateUrl: './predmeti-serach.component.html',
  styleUrls: ['./predmeti-serach.component.css']
})
export class PredmetiSerachComponent implements OnInit {

  predmeti:any;

  constructor(private httpKlijent:HttpClient, private router:Router)
  {

  }

  ngOnInit(): void
  {
    this.getPredmeti();
  }

  getPredmeti()
  {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Predmet/GetAll`).subscribe(x=>{
      this.predmeti=x;
    });
  }

  delete(id:any)
  {
   this.httpKlijent.delete(`${MojConfig.MyLocalHost}/Predmet/Delete/${id}`).subscribe(x=>{
     this.getPredmeti();
     porukaSuccess("Predmet uspješno obrisan");
   });
  }

  edit(id:any)
  {
    this.router.navigateByUrl(`/referent/predmeti/edit/${id}`);
  }
}
