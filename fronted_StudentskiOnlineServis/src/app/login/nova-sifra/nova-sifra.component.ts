import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../MyConfig";

@Component({
  selector: 'app-nova-sifra',
  templateUrl: './nova-sifra.component.html',
  styleUrls: ['./nova-sifra.component.css']
})
export class NovaSifraComponent implements OnInit {
  prvi_pass: any;
  drugi_pass: any;
  EnableAlert: boolean = false;

  constructor(private httpKlijent: HttpClient, private route: Router) {
  }

  ngOnInit(): void {
  }

  OnClick() {
    if (this.prvi_pass != undefined || this.drugi_pass != undefined) {
      if (this.prvi_pass == this.drugi_pass) {
        this.EnableAlert=false;
        let Saljemo = {
          brojDosijea: localStorage.getItem('BrojDosijea'),
          lozinka: this.prvi_pass,
          ponovnaLozinka : this.drugi_pass
        };
        this.httpKlijent.post(MojConfig.PromjeniPassword, Saljemo, {responseType: "text"}).subscribe(x => {
          if (x == 'Lozinka uspjesno promjenjena!') {
            this.route.navigateByUrl("/login");
            localStorage.removeItem('BrojDosijea');
          }
        });
      }
      else {
        this.EnableAlert=true;
      }
    }
  }
}
