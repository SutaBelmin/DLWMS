import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../MyConfig";
import {AutentifikacijaToken} from "../helpers/LoginInformacije";
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";

declare function porukaError(sadrzaj: any): any;

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  korisnici: any;
  korisnikID: any;
  showMessages: boolean = false;
  korisnickoIme: any = '';
  korisnik2ID: any;
  poruke: any;
  message: any;
  auth:any;
  constructor(private httpKlijent: HttpClient) {
    let autentifikacijaToken: AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    this.korisnikID = autentifikacijaToken.korisnickiNalogId;
    this.auth=autentifikacijaToken;
  }

  ngOnInit(): void {
    this.httpKlijent.get(MojConfig.MyLocalHost + '/Korisnik/GetKorisnike?KorisnikID=' + this.korisnikID).subscribe(x => {
      this.korisnici = x;
    }, error => porukaError("Greska pri preuzimanju korisnika -> " + error.error))
    this.ucitajPoruke();
  }
  ucitajPoruke(){
    if (this.showMessages) {
      this.httpKlijent.get(MojConfig.MyLocalHost + '/Chat/GetPoruke?korisnikID1=' + this.korisnikID + '&korisnikID2=' + this.korisnik2ID).subscribe(x => {
        this.poruke = x
      }, error => porukaError("Greska prilikom preuzimanja poruka -> " + error.error));
    }
  }
  otvoriChat(k: any) {
    this.korisnickoIme = k.korisnickoIme;
    this.korisnik2ID = k.id;
    this.showMessages = true;
    this.ngOnInit();

  }

  sendMessage() {
    let saljemo={
      "sadrzaj": this.message,
      "korisnik1ID": this.korisnikID,
      "korisnik2ID": this.korisnik2ID,
      "date": new Date()
    }
    this.httpKlijent.post(MojConfig.MyLocalHost+'/Chat/SendMessage', saljemo).subscribe(x=>{
      this.ucitajPoruke();
    }, error => porukaError("Poruka nije poslata -> " + error.error));
    this.message='';
  }
}
