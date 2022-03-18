import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";
import {ngModuleJitUrl} from "@angular/compiler";
declare function porukaSuccess(sadrzaj: string): any;
declare function porukaError(sadrzaj: string): any;
@Component({
  selector: 'app-rezultati',
  templateUrl: './rezultati.component.html',
  styleUrls: ['./rezultati.component.css']
})
export class RezultatiComponent implements OnInit {
  studenti: any;
  sub:any;
  private rokID:number;
  private studentID:any;
  prikaziStudente: boolean=true;
  prikaziRezultateStudenta:boolean=false;
  NizSadrzaja: any;
  Odgovori: any;
  Pitanja: any;
  display: any;
  IZNOS: any;
  ocjena: any;
  prikaziFormuZaUpis:boolean= false;

  constructor(private httpKlijent:HttpClient, private activatedRoute:ActivatedRoute, private route:Router) { }


  ngOnInit(): void {
  this.sub=this.activatedRoute.params.subscribe(x=>{
    this.rokID=+x['rokID'];
    this.httpKlijent.get(MojConfig.MyLocalHost+"/Rok_Student/GetStudenteByRokID?RokID="+this.rokID, MojConfig.http_opcije()).subscribe(y=>{
      this.studenti=y;
    }, error => porukaError("Greska prilikom preuzimanja studenata!"));
  })
  }
  GetPitanja(id: any) {
    this.display = "block";
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Rok_Student/GetPitanjaByStudentID?StudentID="+ id + "&RokID=" + this.rokID).subscribe(x => {
      this.Pitanja = x;
      this.studentID=id;
      if (this.Pitanja.length > 0) {
        this.NizSadrzaja=this.Pitanja;
      }
    });
  }

  GetOdgovore(id:any) {
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Rok_Student/GetOdgovoreByStudentID?StudentID=" + id).subscribe(x => {
      this.Odgovori = x;
    });
  }
  getRezultate(id:any){
    this.prikaziStudente=false;
    this.prikaziRezultateStudenta=true;
    this.GetPitanja(id);
    this.GetOdgovore(id);
    this.httpKlijent.get(MojConfig.MyLocalHost+"/Rok_Student/GetTacnostOdgovora?StudentID="+id+"&RokID="+this.rokID, {responseType:"text"}).subscribe(x=>{
      this.IZNOS=x;
    }, error => porukaError("Greska pri priuzimanju podatka -> IZNOS"));
  }

  back() {
    this.prikaziRezultateStudenta=false;
    this.prikaziStudente=true;
  }

  upisOcjene() {
    this.prikaziStudente=false;
    this.prikaziRezultateStudenta=false;
    this.prikaziFormuZaUpis=true;
  }

  upisi() {
    let saljemo= {"studentID": this.studentID,
      "rokID": this.rokID,
      "ocjena": parseInt(this.ocjena)}
      this.httpKlijent.post(MojConfig.MyLocalHost+'/Rok_Student/UpisiOcjenu', saljemo, MojConfig.http_opcije()).subscribe(x=>{
        porukaSuccess("Ocjena upisana -> " + this.ocjena);
        this.prikaziFormuZaUpis=false;
        this.prikaziStudente=true;
      }, error => porukaError("Greska pri upisu ->" + error.error));
    this.ocjena='';
  }
}
