import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { MojConfig } from "../MyConfig";
import { LoginInformacije } from "../helpers/LoginInformacije";
import { AutentifikacijaHelper } from "../helpers/autentifikacija-helper";

declare function porukaSuccess(a: string): any;

declare function porukaError(a: string): any;

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
    TwoWay: any = null;
    loginInfo: any;
    constructor(private httpKlijent: HttpClient, private route: Router) {
        this.GetFakulteti();
    }

    GetFakulteti() {
        this.httpKlijent.get(MojConfig.GetFakulteti).subscribe(x => {
            this.NizFakulteta = x;
        })
    }

    Login() {
        let saljemo = { username: this.BrojDosijea, password: this.Password, fakultet_s: parseInt(this.OdabraniFakultet) };

        this.httpKlijent.post<LoginInformacije>(MojConfig.AutentifikacijaLogin, saljemo)
            .subscribe((x: LoginInformacije) => {
                this.loginInfo = x;
                if (x.autentifikacijaToken.korisnickiNalog.isTwoWayAuth == false) {
                    if (x.isLogiran) {
                        if (x.isPermisijaAdmin) {
                            AutentifikacijaHelper.setLoginInfo(x)
                            this.route.navigateByUrl("/admin");
                        }
                        else if (x.isPermisijaProfesor) {
                            AutentifikacijaHelper.setLoginInfo(x)
                            this.route.navigateByUrl("/profesor");
                        }
                        else if (x.isPermisijaReferent) {
                            AutentifikacijaHelper.setLoginInfo(x)
                            this.route.navigateByUrl("/referent");
                        }
                        else if (x.isPermisijaStudent) {
                            AutentifikacijaHelper.setLoginInfo(x)
                            this.route.navigateByUrl("/studentmain");
                        }
                    } else {
                        AutentifikacijaHelper.setLoginInfo(null)
                        porukaError("G R E Š K A !");
                    }
                }
                else {
                    this.TwoWay = x.autentifikacijaToken.korisnickiNalog;
                    this.TwoWay.show = true;
                }
            });
    }

    ngOnInit(): void {
    }

    ForgotPassword() {
        this.route.navigateByUrl("zaboravio_sifru")
    }
}
