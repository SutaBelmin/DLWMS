import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";
import {AutentifikacijaHelper} from "../../../helpers/autentifikacija-helper";

@Component({
  selector: 'app-student-pocetna',
  templateUrl: './student-pocetna.component.html',
  styleUrls: ['./student-pocetna.component.css']
})
export class StudentPocetnaComponent implements OnInit {

  student:any;

  constructor(private httpKlijent:HttpClient, private router:Router)
  {

  }

  ngOnInit(): void
  {
    this.getStudent();
  }

  getStudent()
  {
    this.httpKlijent.get(`${MojConfig.MyLocalHost}/Student/GetStudent`, MojConfig.http_opcije()).subscribe(x=>{
      this.student=x;
    });
  }

}
