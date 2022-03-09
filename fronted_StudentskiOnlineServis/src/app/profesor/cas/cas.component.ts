import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";
import {AutentifikacijaToken} from "../../helpers/LoginInformacije";
import {MojConfig} from "../../MyConfig";

declare function porukaSuccess(sadrzaj: string): any;
declare function porukaError(sadrzaj: string): any;

@Component({
  selector: 'app-cas',
  templateUrl: './cas.component.html',
  styleUrls: ['./cas.component.css']
})
export class CasComponent implements OnInit {
  NoviCas: any = null;
  predmets: any;
  profesorID: any;
  predmetID: any = 1;
  CasoviPoProfesoru: any;
  predmetFilter: any = "SVI";
  datumFilter: any;

  constructor(private httpKlijent: HttpClient, private route: Router) {
    let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    this.profesorID = autentifikacijaToken.korisnickiNalogId;
  }

  ngOnInit(): void {
    this.NoviCas = {
      "datum": new Date(),
      "lekcija": "",
      "predmetID": 0,
      "profesorID": this.profesorID
    }
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Profesor_Predmet_/GetProfesorPredmet?ProfesorID=" + this.profesorID, MojConfig.http_opcije()).subscribe(x => {
      this.predmets = x;
    }, error => porukaError("Greska prilikom preuzimanja predmeta"));
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Cas/GetCasove?ID=" + this.profesorID, MojConfig.http_opcije()).subscribe(x => {
      this.CasoviPoProfesoru = x;
    }, error => porukaError("Greska -> " + error.error));
  }

  AddCas() {
    this.NoviCas.predmetID = parseInt(this.predmetID);
    this.httpKlijent.post(MojConfig.MyLocalHost + "/Cas/AddCas", this.NoviCas, MojConfig.http_opcije()).subscribe(x => {
      porukaSuccess("Cas dodan");
      this.ngOnInit();
    }, error => porukaError("Greska -> " + error.error));
  }

  filterCasova(): any {
    if (this.CasoviPoProfesoru == null)
      return [];
    return this.CasoviPoProfesoru.filter((x: any) =>
      this.predmetFilter == "SVI" ||
      this.predmetFilter == undefined ||
      x.predmet.naziv == this.predmetFilter
    );
  }

  Prisustvo(c: any) {
    this.route.navigate(['/profesor/cas/prisustvo/', c.predmet.naziv, c.predmetID, c.id]);
  }

  obrisiCas(id: any) {
    this.httpKlijent.delete(MojConfig.MyLocalHost + "/Cas/ObrisiCas?ID=" + id, MojConfig.http_opcije())
      .subscribe(x => {
        porukaSuccess("Obrisan cas!")
        this.ngOnInit()
      }, error => porukaError("Greska prilikom brisanja casa!"));
  }
}
