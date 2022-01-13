import {HttpHeaders} from "@angular/common/http";

export class MojConfig {
  static MyLocalHost = 'http://localhost:59854';
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
  static http_opcije = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  };
}
