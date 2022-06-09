import { Component, OnInit } from '@angular/core';
import {TranslateService} from "@ngx-translate/core";
import {MojConfig} from "../../../MyConfig";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-ref-nav',
  templateUrl: './ref-nav.component.html',
  styleUrls: ['./ref-nav.component.css']
})
export class RefNavComponent implements OnInit {

  language: any = "en";

  constructor(private httpClient: HttpClient, private router: Router,private languageService: TranslateService) { }

  ngOnInit(): void {
    this.language = this.languageService.currentLang ?? "en";
  }

  changeLanguage(e: Event)
  {
    let lang = (e.target as HTMLInputElement).value;
    this.languageService.use(lang);
  }

  LogOut()
  {
    this.httpClient.post(MojConfig.AutentifikacijaLogOut, MojConfig.http_opcije(),{}).subscribe(x=> {
      localStorage.removeItem('_Token');
      this.router.navigateByUrl('/login')
    });
  }
}
