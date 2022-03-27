import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../MyConfig";

@Component({
  selector: 'app-uspjeh',
  templateUrl: './uspjeh.component.html',
  styleUrls: ['./uspjeh.component.css']
})
export class UspjehComponent implements OnInit {

  uspjeh:any;

  constructor(private httpKlijent:HttpClient)
  {

  }

  ngOnInit(): void
  {
    this.getUspjeh();
  }

  getUspjeh()
  {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Uspjeh/GetListUspjeh`,MojConfig.http_opcije()).subscribe(x=>{
      this.uspjeh=x;
      console.log(x);
    });
  }

}
