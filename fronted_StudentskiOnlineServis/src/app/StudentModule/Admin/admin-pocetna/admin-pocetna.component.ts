import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {Router} from "@angular/router";
import {TranslateService} from "@ngx-translate/core";

@Component({
  selector: 'app-admin-pocetna',
  templateUrl: './admin-pocetna.component.html',
  styleUrls: ['./admin-pocetna.component.css']
})
export class AdminPocetnaComponent implements OnInit {

  greske:any;
  language: any = "en";

  constructor(private httpKlijent:HttpClient, private router:Router, private languageService: TranslateService) {

  }

  ngOnInit(): void
  {
    this.getGreske();
    this.language = this.languageService.currentLang ?? "en";
  }

  getGreske()
  {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Greska/GetAll`).subscribe(x=>{
      this.greske=x;
    });
  }

  LogOut()
  {
    this.httpKlijent.delete(MojConfig.AutentifikacijaLogOut, MojConfig.http_opcije()).subscribe(x=> {
      localStorage.removeItem('_Token');
      this.router.navigateByUrl('/login')
    });
  }

  changeLanguage(e: Event)
  {
    let lang = (e.target as HTMLInputElement).value;
    this.languageService.use(lang);
  }
}
