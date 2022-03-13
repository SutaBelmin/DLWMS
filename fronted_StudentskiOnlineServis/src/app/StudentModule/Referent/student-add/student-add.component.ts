import { Component, OnInit } from '@angular/core';
import {Student} from "../../_models/Student";
import {StudentAddVM} from "../../_models/StudentAddVM";
import {MojConfig} from "../../../MyConfig";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent implements OnInit {

  Students:StudentAddVM={} as StudentAddVM;
  Fakulteti:any;

  constructor(private httpClient: HttpClient, private router:Router) { }

  ngOnInit(): void {
    this.getFakulteti();
  }

  getFakulteti()
  {
    this.httpClient.get(MojConfig.GetFakulteti).subscribe(x => {
      this.Fakulteti = x;
    });
  }

  onFileChanged(event: any) {
    let selectedFile = event.target.files[0];
    let formData = new FormData();
    formData.append('file', selectedFile, selectedFile.name);
    this.httpClient.post<any>(MojConfig.UploadImage, formData).subscribe(x => {
      this.Students.slika_studenta = x.imageUrl;
    });
  }

  Save()
  {
    this.httpClient.post(MojConfig.DodajStudenta, this.Students).subscribe(x=>{
      this.router.navigateByUrl("/referent/student");
      porukaSuccess("Student uspješno dodat");
    })
  }

}
