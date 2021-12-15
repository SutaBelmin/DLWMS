import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../MyConfig";

@Component({
  selector: 'app-profesor',
  templateUrl: './profesor.component.html',
  styleUrls: ['./profesor.component.css']
})
export class ProfesorComponent implements OnInit {
  token:any=localStorage.getItem('_Token');
  Pitanje: boolean=false;
  constructor(private httpKlijent: HttpClient, private route: Router) {
  }
  LogOut():any{
    let headers = {'Token': this.token};
    this.httpKlijent.delete(MojConfig.AutentifikacijaLogOut, {headers}).subscribe(x=> {
      localStorage.removeItem('_Token');
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
}
