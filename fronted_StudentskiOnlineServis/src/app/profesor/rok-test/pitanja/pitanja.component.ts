import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";

declare function porukaSuccess(sadrzaj: string): any;

declare function porukaError(sadrzaj: string): any;

@Component({
  selector: 'app-pitanja',
  templateUrl: './pitanja.component.html',
  styleUrls: ['./pitanja.component.css']
})
export class PitanjaComponent implements OnInit {

  Pitanja: any;
  Odgovori: any;

  Pitanje: any;
  NizOdgovora: Array<any> = [];
  NizTacnosti: Array<any> = [];
  NizSadrzaja: Array<any> = [];
  display: any;

  rok: any;
  sub: any;
  private rokID: number;
  prikazi: boolean = false;

  constructor(private httpKlijent: HttpClient, private route: Router, private router: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.sub = this.router.params.subscribe(x => {
      this.rokID = +x['rokID'];
      this.GetPitanja(this.rokID);
      this.GetOdgovore();
      this.GetRokInfo();
    })
  }

  GetRokInfo() {
    this.httpKlijent.get(MojConfig.MyLocalHost + "/Rok/GetRokDateByID/" + this.rokID, {responseType:"text"}).subscribe(x => {
      this.rok=x;
      console.log(this.rok);
      if(this.rok=="false")
        this.prikazi=false;
      else
        this.prikazi=true;
    }, error => porukaError("Greska prilikom preuzimanja roka(jednog)"));
  }

  GetPitanja(id: any) {
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

  DodajOdgovor(id: any, indeks: any) {
    let v;
    if (this.NizTacnosti[indeks - 1].startsWith("false"))
      v = false;
    else if (this.NizTacnosti[indeks - 1].startsWith('true'))
      v = true;
    let saljemo = {'sadrzajOdgovora': this.NizOdgovora[indeks - 1], 'tacan': v, 'iD_Pitanja': id};
    this.httpKlijent.post(MojConfig.MyLocalHost + "/Test/AddOdgovor", saljemo).subscribe(X => {
      this.GetOdgovore();
      this.NizOdgovora[indeks - 1] = '';
      this.NizTacnosti[indeks - 1] = '';
    });
  }

  ObrisiOdgovor(id: any) {
    this.httpKlijent.delete(MojConfig.MyLocalHost + "/Test/IzbrisiOdgovor/" + id).subscribe(x => {
      this.GetOdgovore();
    });
  }

  DodajPitanje() {
    let saljemo = {'sadrzaj': this.Pitanje, 'iD_rok': this.rokID}
    this.httpKlijent.post(MojConfig.MyLocalHost + "/Test/AddPitanje", saljemo).subscribe(x => {
      this.GetPitanja(this.rokID);
      this.Pitanje = '';
    });
  }

  Edituj(id: any, indeks: any) {
    let saljemo = {'iD_pitanja': id, 'sadrzaj': this.NizSadrzaja[indeks - 1]};
    this.httpKlijent.post(MojConfig.MyLocalHost + "/Test/EditujPitanje", saljemo).subscribe(x => {
      this.GetPitanja(this.rokID);
    });
  }

  ObrisiPitanje(id: any) {
    this.httpKlijent.delete(MojConfig.MyLocalHost + "/Test/IzbrisiPitanje/" + id).subscribe(x => {
      this.GetPitanja(this.rokID);
    })
  }
}
