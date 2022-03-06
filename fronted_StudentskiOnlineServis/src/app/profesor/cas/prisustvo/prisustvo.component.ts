import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";

declare function porukaError(sadrzaj: string): any;

declare function porukaSuccess(sadrzaj: string): any;

@Component({
  selector: 'app-prisustvo',
  templateUrl: './prisustvo.component.html',
  styleUrls: ['./prisustvo.component.css']
})
export class PrisustvoComponent implements OnInit {
  sub: any;
  studenti: any;
  private predmetID: number;
  private id: number;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute, private router:Router) {
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(x => {
      this.predmetID = +x['predmetID'];
      this.id = +x['id'];
      this.httpKlijent.get(MojConfig.MyLocalHost + "/Student_Predmet_/GetStudentPredmetPodaci/predmetID?predmetID=" + this.predmetID, MojConfig.http_opcije()).subscribe(x => {
        this.studenti = x;
      }, error => porukaError("Greska -> " + error.error))
    })
  }

  Dodaj(id: number, ime: string) {
    let saljemo = {"studentID": id, "casID": this.id}
    this.httpKlijent.post(MojConfig.MyLocalHost + "/Prisustvo/AddPrisustvo", saljemo, MojConfig.http_opcije()).subscribe(x => {
      porukaSuccess("Dodat student ->" + ime);
    }, error => porukaError("Greska -> " + ime +", "+error.error));
  }

  pregled() {
      this.router.navigate(["profesor/cas/prisustvo/pregled/", this.id]);
  }
}
