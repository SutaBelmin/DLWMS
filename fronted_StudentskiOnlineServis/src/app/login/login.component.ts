import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../MyConfig";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  title = 'Login';
  BrojDosijea: any
  Password: any;
  NizFakulteta: any;
  OdabraniFakultet: any = 1;
  EnableAlert: boolean = false;
  warn: string = 'Pogrešan broj dosijea ili šifra';

  constructor(private httpKlijent: HttpClient, private route: Router) {
    this.GetFakulteti();
  }

  GetFakulteti() {
    this.httpKlijent.get(MojConfig.GetFakulteti).subscribe(x => {
      this.NizFakulteta = x;
    })
  }

  Login() {
    let saljemo = {username: this.BrojDosijea, password: this.Password, fakultet_s: parseInt(this.OdabraniFakultet)};
    this.httpKlijent.post(MojConfig.AutentifikacijaLogin, saljemo, {responseType: "text"})
      .subscribe((x: any) => {
        if (x != 'GRESKA') {
          localStorage.setItem("_Token", x.substr(0, 5));
          let korisnik = x.substr(6, x.length - 6);
          if (korisnik == "profesor")
            this.route.navigateByUrl("/profesor")
        } else {
          if (this.BrojDosijea == '' || this.Password == '' || this.BrojDosijea == undefined || this.Password == undefined) {
            this.warn = 'Niste unijeli podatke!';
          } else {
            this.warn = 'Pogrešan broj dosijea ili šifra';
          }
          this.EnableAlert = true;
        }
      });
  }

  ngOnInit(): void {
  }

  ForgotPassword() {
    this.route.navigateByUrl("zaboravio_sifru")
  }
}
