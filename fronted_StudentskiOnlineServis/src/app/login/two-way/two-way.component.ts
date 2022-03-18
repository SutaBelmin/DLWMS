import {Component, Input, OnInit} from '@angular/core';
import {MojConfig} from "../../MyConfig";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";
declare function porukaError(sadrzaj:string):any;
@Component({
  selector: 'app-two-way',
  templateUrl: './two-way.component.html',
  styleUrls: ['./two-way.component.css']
})
export class TwoWayComponent implements OnInit {
  showDialog: boolean=false;
  @Input()
  Verifikacija:any=null;
  @Input()
  loginInfo:any=null;
  kod:any;
  key: any;
  constructor( private route:Router, private httpKlijent:HttpClient) {
    }

  ngOnInit(): void {
    if(this.Verifikacija!=null) {
      let S = {'mail': this.Verifikacija.privatniEmail};
      this.httpKlijent.post(MojConfig.GetVerifikacijskiKod, S, {responseType: "text"}).subscribe(x => {
        this.kod = x;

        //Slanje maila
        let Slanje = {to: this.Verifikacija.privatniEmail, subject: 'Verifikacijski kod', sadrzaj: x};
        this.httpKlijent.post(MojConfig.PosaljiMail, Slanje).subscribe();
      });
    }
  }
  checkKey(){
    if(this.key==this.kod)
    {
      if (this.loginInfo.isPermisijaProfesor) {
        AutentifikacijaHelper.setLoginInfo(this.loginInfo)
        this.route.navigateByUrl("/profesor");
      }
      if (this.loginInfo.isPermisijaReferent) {
        AutentifikacijaHelper.setLoginInfo(this.loginInfo)
        this.route.navigateByUrl("/referent");
      }
      if (this.loginInfo.isPermisijaStudent) {
        AutentifikacijaHelper.setLoginInfo(this.loginInfo)
        this.route.navigateByUrl("/studentmain");
      }
    }
    else porukaError("Pogresan kod");
  }


}
