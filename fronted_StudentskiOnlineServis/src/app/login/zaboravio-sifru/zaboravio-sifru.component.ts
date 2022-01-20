import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../MyConfig";

declare function porukaSuccess(a: string): any;

declare function porukaError(a: string): any;

@Component({
  selector: 'app-zaboravio-sifru',
  templateUrl: './zaboravio-sifru.component.html',
  styleUrls: ['./zaboravio-sifru.component.css']
})

export class ZaboravioSifruComponent implements OnInit {
  email: any;
  kod: any;
  EnableAlert: boolean = false;
  _n0: boolean = true;
  testniKod: string = ' ';
  _opacity: any;
  _2opacity: any;
  brojac: number = 0;
  btn: any;
  Timer: number = 0;
  poruka: any;

  constructor(private httpKlijent: HttpClient, private route: Router) {
  }

  ngOnInit(): void {
  }

  OnClick_1() {
    this._n0 = true;
    let poruka;
    let p;
    if (this.email != undefined) {
      this.httpKlijent.get(MojConfig.GetProvjeruEmaila + this.email, {responseType: "text"}).subscribe(x => {
        poruka = x;
        p = true;
        if (poruka == 'F') {
          porukaError("G R E Š K A !");
          this._opacity = '5%';
          return;
        }
        this._opacity = '40%';
        porukaSuccess("T A Č N O !")
        this._n0 = false;
        //Postavljanje koda
        let S = {'mail': this.email};
        this.brojac++;
        this.httpKlijent.post(MojConfig.GetVerifikacijskiKod, S, {responseType: "text"}).subscribe(y => {
          this.testniKod = y;
          //Slanje maila
          let Slanje = {to: this.email, subject: 'Verifikacijski kod', sadrzaj: y};
          this.httpKlijent.post(MojConfig.PosaljiMail, Slanje).subscribe();
        });
        this.btn = true;
        this.poruka = "Novi pokušaj za 60 sekundi!";
        setTimeout(() => {
          this.poruka = "";
          this.btn = false;
        }, 60000)
      });

    }

  }

  OnClick_2() {
    if (this.kod == this.testniKod) {
      this._2opacity = '40%';

      this.httpKlijent.get(MojConfig.GetBrojDosijea + this.email, {responseType: "text"}).subscribe(a => {
        localStorage.setItem("BrojDosijea", a);
      });
      this.httpKlijent.delete(MojConfig._BrisanjeZapisa + this.email).subscribe();
      this.route.navigateByUrl("nova_sifra");
      porukaSuccess("T A Č N O !");
    } else {
      this._2opacity = '5%';
      porukaError("G R E Š K A !");
    }
  }
}
