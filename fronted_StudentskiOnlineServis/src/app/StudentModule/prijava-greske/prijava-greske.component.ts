import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../MyConfig";
import {Location} from "@angular/common";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-prijava-greske',
  templateUrl: './prijava-greske.component.html',
  styleUrls: ['./prijava-greske.component.css']
})
export class PrijavaGreskeComponent implements OnInit {

  opis:any;

  constructor(private httpKlijent:HttpClient, private location:Location)
  {

  }

  ngOnInit(): void
  {

  }

  save()
  {
   this.httpKlijent.post(`${MojConfig.MyLocalHost}/Greska/PrijavaGreske`, {
     Opis:this.opis
   }).subscribe(x=>{
     porukaSuccess("Greška uspješno prijavljena");
     this.opis='';
     this.location.back();
   });
  }
}
