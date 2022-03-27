import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-pocetna',
  templateUrl: './admin-pocetna.component.html',
  styleUrls: ['./admin-pocetna.component.css']
})
export class AdminPocetnaComponent implements OnInit {

  greske:any;

  token:any=localStorage.getItem('_Token');

  constructor(private httpKlijent:HttpClient, private router:Router)
  {

  }

  ngOnInit(): void
  {
    this.getGreske();
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
}
