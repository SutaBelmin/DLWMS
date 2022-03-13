import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, Router} from "@angular/router";
import {StudentUpdateVM} from "../../_models/StudentUpdateVM";
import {HttpClient} from "@angular/common/http";
import {Student} from "../../_models/Student";
import {MojConfig} from "../../../MyConfig";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit {

  public id: number;
  public student: StudentUpdateVM={} as StudentUpdateVM;
  Fakulteti:any;
  constructor(
    private activatedRoute: ActivatedRoute,
    private httpClient: HttpClient,
    private router: Router
  ) {
    this.id = this.activatedRoute.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.httpClient.get<Student>(`${MojConfig.MyLocalHost}/Student/GetById/${this.id}`).subscribe(s =>{
      this.student.ime = s.ime;
      this.student.prezime = s.prezime;
      this.student.datum_rodjenja=s.datum_rodjenja;
      this.student.slika_studenta = s.slika_studenta;
      this.student.FakultetID=s.fakultetID;
    });
    this.getFakulteti();
  }

  onFileChanged(event: any) {
    let selectedFile = event.target.files[0];
    let formData = new FormData();
    formData.append('file', selectedFile, selectedFile.name);
    this.httpClient.post<any>(MojConfig.UploadImage, formData).subscribe(x => {
      this.student.slika_studenta = x.imageUrl;
    });
  }

  getFakulteti()
  {
    this.httpClient.get(MojConfig.GetFakulteti).subscribe(x => {
      this.Fakulteti = x;
    });
  }

  Save() {
    this.httpClient.post(`${MojConfig.EditujStudenta}/${this.id}`, this.student).subscribe(x=>{
      this.router.navigateByUrl("/referent/student");
      porukaSuccess("Student uspješno editovan");
    })
  }
}
