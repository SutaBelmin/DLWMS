import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-predmeti-edit',
  templateUrl: './predmeti-edit.component.html',
  styleUrls: ['./predmeti-edit.component.css']
})
export class PredmetiEditComponent implements OnInit {

  id: any;
  predmet: any;

  constructor(private httpKlijent: HttpClient, private activatedRoute: ActivatedRoute, private router: Router) {
    this.id = this.activatedRoute.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.getPredmet();
  }

  getPredmet() {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Predmet/GetById/${this.id}`).subscribe(x => {
      this.predmet=x;
    });
  }

  save()
  {
    this.httpKlijent.post(`${MojConfig.MyLocalHost}/Predmet/EditPredmet/${this.id}`,this.predmet).subscribe(x=>{
      porukaSuccess("Predmet uspješno editovan");
      this.router.navigateByUrl(`/referent/predmeti`);
    });
  }
}
