import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../MyConfig";
import {AutentifikacijaToken} from "../../helpers/LoginInformacije";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";
import {Router} from "@angular/router";

declare function porukaSuccess(sadrzaj: string): any;

declare function porukaError(sadrzaj: string): any;

@Component({
  selector: 'app-rok-test',
  templateUrl: './rok-test.component.html',
  styleUrls: ['./rok-test.component.css']
})
export class RokTestComponent implements OnInit {
  SadasnjiRokovi: any;
  profesorID: number;
  ProsliRokovi: any;


  constructor(private httpKlijent: HttpClient, private route: Router) {
    let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    this.profesorID = autentifikacijaToken.korisnickiNalogId;
  }

  ngOnInit(): void {
    this.GetSadasnjeRokove();
    this.GetProsliRokovi();
  }

  GetSadasnjeRokove() {
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Rok/GetSadasnjeRokoveByIDProfesora/" + this.profesorID, MojConfig.http_opcije()).subscribe(x => {
      this.SadasnjiRokovi = x;
    }, error => porukaError("Greska prilikom preuzimanja sadasnjih rokova!"));
  }

  pitanja(id: any) {
    this.route.navigate(["/profesor/rok_test/pitanja/", id]);
  }

  private GetProsliRokovi() {
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Rok/GetProsleRokoveByIDProfesora/" + this.profesorID, MojConfig.http_opcije()).subscribe(x => {
      this.ProsliRokovi = x;
    }, error => porukaError("Greska prilikom preuzimanja sadasnjih rokova!"));
  }
}
