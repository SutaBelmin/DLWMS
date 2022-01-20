export class LoginInformacije {
  autentifikacijaToken:        AutentifikacijaToken=null;
  isLogiran:                   boolean=false;
  isPermisijaProfesor:         boolean=false;
  isPermsijaAdmin:             boolean=false;
}

export interface AutentifikacijaToken {
  id:                   number;
  vrijednost:           string;
  korisnickiNalogId:    number;
  korisnickiNalog:      KorisnickiNalog;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
}

export interface KorisnickiNalog {
  id:                 number;
  korisnickoIme:      string;
  lozinka:            string;
  fakultet:           Fakultet;
  fakultetID:         number;
  privatniEmail:      string;
  fakultetEmail:      string;
  isProfesor:         boolean;
  isAdmin:            boolean;
}
export interface Fakultet{
  id:                 number;
  naziv:              string;
  grad:               string;
}
