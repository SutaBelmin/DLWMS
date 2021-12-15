import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../MyConfig";

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
  brojac:number=0;
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
          this.EnableAlert = true;
          this._opacity='5%';
          return;
        }
        this._opacity='40%';
        this.EnableAlert = false;
        this._n0 = false;
        //Postavljanje koda
        let S = {'mail': this.email};
        this.brojac++;
        if(this.brojac>=2){
          this.httpKlijent.delete(MojConfig.IzbrisiVerifikaciju+this.testniKod).subscribe();
        }
        this.httpKlijent.post(MojConfig.GetVerifikacijskiKod, S, {responseType: "text"}).subscribe(y => {
          this.testniKod = y;
          //Slanje maila
          let Slanje = {to: this.email, subject: 'Verifikacijski kod', sadrzaj: y};
          this.httpKlijent.post(MojConfig.PosaljiMail, Slanje).subscribe();
        });
      });

    }

  }

  OnClick_2() {
    if (this.kod == this.testniKod) {
      this._2opacity='40%';

      this.httpKlijent.get(MojConfig.GetBrojDosijea + this.email, {responseType: "text"}).subscribe(a => {
        localStorage.setItem("BrojDosijea", a);
      });
      this.httpKlijent.delete(MojConfig.IzbrisiVerifikaciju+this.testniKod).subscribe();
      this.route.navigateByUrl("nova_sifra");
      this.EnableAlert=false;
    }
    else {
      this._2opacity='5%';
      this.EnableAlert=true;
    }

  }
}
