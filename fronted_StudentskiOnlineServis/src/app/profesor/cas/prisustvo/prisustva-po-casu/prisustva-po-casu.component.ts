import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../../../../MyConfig";
declare function porukaError(sadrzaj: string): any;
declare function porukaSuccess(sadrzaj: string): any;
@Component({
  selector: 'app-prisustva-po-casu',
  templateUrl: './prisustva-po-casu.component.html',
  styleUrls: ['./prisustva-po-casu.component.css']
})
export class PrisustvaPoCasuComponent implements OnInit {
  sub:any;
  private casID:number;
  prisustva:any;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute, private router:Router) {
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(x => {
      this.casID= +x['casID'];
      this.httpKlijent.get(MojConfig.MyLocalHost + "/Prisustvo/GetPrisustva/" + this.casID, MojConfig.http_opcije()).subscribe(x => {
        this.prisustva = x;
      }, error => porukaError("Greska -> " + error.error))
    })
  }

  obrisi(id:number) {
    this.httpKlijent.delete(MojConfig.MyLocalHost+"/Prisustvo/ObrisiPrisustvo/"+id,MojConfig.http_opcije()).subscribe(x=>{
      porukaSuccess("Uspjesno izbrisano");
      this.ngOnInit();
    }, error=> porukaError("Greska pri brisanju"));
  }
}
