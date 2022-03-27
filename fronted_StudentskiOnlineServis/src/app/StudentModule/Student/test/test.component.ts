import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {AutentifikacijaToken} from "../../../helpers/LoginInformacije";
import {AutentifikacijaHelper} from "../../../helpers/autentifikacija-helper";
declare function porukaSuccess(sadrzaj: string): any;

declare function porukaError(sadrzaj: string): any;
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  //PART - 1
  rokID: any;
  rokovi: any;
  showFirstTable: boolean = true;
  showSecondTable: boolean = false;

  //PART - 2
  Pitanja: any;
  Odgovori: any;
  Pitanje: any;
  NizOdgovora: boolean[] = [false];
  NizTacnosti: Array<any> = [];
  NizSadrzaja: Array<any> = [];
  display: any;
  studentID: any;
  nizIndeksa: Array<any> = new Array<any>();

  constructor(private httpKlijent: HttpClient, private route: Router) {
    let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    this.studentID = autentifikacijaToken.korisnickiNalogId;
  }

  ngOnInit(): void {
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Rok/GetActiveRokovi?StudentID="+this.studentID, MojConfig.http_opcije()).subscribe(x => {
      this.rokovi = x;
    })
  }

  RunTest(id: any) {
    this.showFirstTable = false;
    this.showSecondTable = true;
    this.rokID = id;
    this.GetPitanja();
  }

  GetPitanja() {
    this.display = "block";
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Test/GetPitanjaByID_Rok/" + this.rokID).subscribe(x => {
      this.Pitanja = x;
      this.GetOdgovore();
      if (this.Pitanja.length > 0) {
        for (let i = 0; i < this.Pitanja.length; i++) {
          this.NizSadrzaja[i] = this.Pitanja[i].sadrzaj;
        }
      }
    });
  }

  GetOdgovore() {
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Test/GetOdgovore").subscribe(x => {
      this.Odgovori = x;
    });
  }

  FinishTest() {
    let k = 0;
    for (let i = 0; i < this.Pitanja.length; i++) {
      for (let j = 0; j < this.Odgovori.length; j++) {
        if (this.Odgovori[j].pitanje.id == this.Pitanja[i].id) {
          this.nizIndeksa[k] = this.Odgovori[j];
          k++;
        }
      }
    }
    for (let i = 0; i < k; i++) {
      let saljemo = {
        "rokID": this.rokID,
        "studentID": this.studentID,
        "odgovorID": this.nizIndeksa[i].id,
        "studentZaokruzio": this.NizOdgovora[this.nizIndeksa[i].id]
      }
      this.httpKlijent.post(MojConfig.MyLocalHost+'/Rok_Student/OdgovorNaPitanje', saljemo).subscribe(x=>{
      }, error => porukaError("Greska"));
    }
  }

}
