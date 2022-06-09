import { Component, OnInit } from '@angular/core';
import {TranslateService} from "@ngx-translate/core";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";

@Component({
  selector: 'app-stu-nav',
  templateUrl: './stu-nav.component.html',
  styleUrls: ['./stu-nav.component.css']
})
export class StuNavComponent implements OnInit {

  language: any = "en";

  constructor(private httpClient: HttpClient, private router: Router,
    private languageService: TranslateService
  ) { }

  ngOnInit(): void
  {
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
