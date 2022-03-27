import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../MyConfig";
import {Forum} from "../_models/Forum";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {

  forum:Forum[];
  pitanje:any;
  public logiraniKorisnik:any=AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId;

  constructor(private httpKlijent:HttpClient)
  {

  }

  ngOnInit(): void
  {
    console.log(this.logiraniKorisnik);
    this.getForum();
  }

  getForum()
  {
    this.httpKlijent.get<Forum[]>(`${MojConfig.MyLocalHost}/Forum/GetAll`,MojConfig.http_opcije()).subscribe(x=>{
      this.forum=x;
    });
  }

  addPitanje()
  {
   this.httpKlijent.post(`${MojConfig.MyLocalHost}/Forum/AddPitanje`,{
     Pitanje:this.pitanje
   },MojConfig.http_opcije()).subscribe(x=>{
     this.getForum();
     this.pitanje='';
   });
  }

  addOdgovor(id:any)
  {
    let odgovor=this.forum.find(x=>x.id==id).odgovor;
    this.httpKlijent.post(`${MojConfig.MyLocalHost}/Forum/AddOdgovor/${id}`,{
      Odgovor:odgovor
    },MojConfig.http_opcije()).subscribe(x=>{
      this.getForum();
    });
  }
}
