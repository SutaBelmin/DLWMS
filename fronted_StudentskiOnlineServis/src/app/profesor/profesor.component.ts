import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../MyConfig";
import {AutentifikacijaToken} from "../helpers/LoginInformacije";
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";

@Component({
  selector: 'app-profesor',
  templateUrl: './profesor.component.html',
  styleUrls: ['./profesor.component.css']
})
export class ProfesorComponent implements OnInit {
  token:any=localStorage.getItem('autentifikacija-token');
  Pitanje: boolean=false;
  Profesor:any;
  constructor(private httpKlijent: HttpClient, private route: Router) {
    let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    this.Profesor=autentifikacijaToken.korisnickiNalog;
  }
  LogOut():any{
    let headers = {'autentifikacija-token': this.token};
    this.httpKlijent.delete(MojConfig.AutentifikacijaLogOut, {headers}).subscribe(x=> {
      localStorage.removeItem('autentifikacija-token');
      this.route.navigateByUrl('/login')
    });
  }
  ngOnInit(): void {
  }

  LogOutR() {
    this.Pitanje=true;
  }

  CloseDialog() {
    this.Pitanje=false;
  }

  Change() {
    this.httpKlijent.post(MojConfig.MyLocalHost+"/Profesor/UpdateProfesorTwoStep?id="+this.Profesor.id +"&TWA="+this.Profesor.isTwoWayAuth, MojConfig.http_opcije()).subscribe();
  }
}
