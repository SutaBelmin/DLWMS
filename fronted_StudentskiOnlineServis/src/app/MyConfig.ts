import {HttpHeaders} from "@angular/common/http";
import {AutentifikacijaToken} from "./helpers/LoginInformacije";
import {AutentifikacijaHelper} from "./helpers/autentifikacija-helper";

export class MojConfig {
  static http_opcije= function () {

    let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    let mojtoken = "";

    if (autentifikacijaToken != null)
      mojtoken = autentifikacijaToken.vrijednost;
    return {
      headers: {
        'autentifikacija-token': mojtoken,
      }
    };
  }
  static MyLocalHost = 'https://dlwms-api.p2103.app.fit.ba';
  static GetKorisnici = this.MyLocalHost + '/Korisnik/GetKorisnike';
  static AutentifikacijaLogin = this.MyLocalHost + '/AutentifikacijaLogin/Login';
  static GetFakulteti = this.MyLocalHost + '/Fakultet/GetFakulteti';
  static AutentifikacijaLogOut = this.MyLocalHost + '/AutentifikacijaLogin/Logout';
  static GetProvjeruEmaila = this.MyLocalHost + '/Email/Get?Email=';
  static PosaljiMail = this.MyLocalHost + '/Email/SendMail';
  static GetVerifikacijskiKod = this.MyLocalHost + '/Email/GenerisiToken';
  static GetBrojDosijea = this.MyLocalHost + '/Password/GetDosije?email=';
  static PromjeniPassword = this.MyLocalHost + '/Password/PromjeniPassword';
  static IzbrisiVerifikaciju = this.MyLocalHost +'/Password/IzbrisiVerifikaciju/';
  static DodajStudenta = this.MyLocalHost +'/Student/Add';
  static EditujStudenta = this.MyLocalHost +'/Student/Update';
  static UploadImage = this.MyLocalHost + '/Student/UploadImage';
  static _BrisanjeZapisa=this.MyLocalHost+'/Email/BrisanjeZapisa/';

}
