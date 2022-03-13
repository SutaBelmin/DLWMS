import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-predmet-add',
  templateUrl: './predmet-add.component.html',
  styleUrls: ['./predmet-add.component.css']
})
export class PredmetAddComponent implements OnInit {

  predmet:any={};

  constructor(private httpKlijent:HttpClient, private router:Router)
  {

  }

  ngOnInit(): void
  {

  }

  save()
  {
    this.httpKlijent.post(`${MojConfig.MyLocalHost}/Predmet/AddPredmet`,{
      Naziv:this.predmet.naziv,
      Oznaka:this.predmet.oznaka,
      Godina:this.predmet.godina
    }).subscribe(x=>{
      porukaSuccess("Predmet uspješno dodat");
      this.router.navigateByUrl(`/referent/predmeti`);
    });
  }
}
