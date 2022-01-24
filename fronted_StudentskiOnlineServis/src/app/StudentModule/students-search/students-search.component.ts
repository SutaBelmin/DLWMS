import { Component, OnInit } from '@angular/core';
import {Student} from "../_models/Student";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-students-search',
  templateUrl: './students-search.component.html',
  styleUrls: ['./students-search.component.css']
})
export class StudentsSearchComponent implements OnInit {

  students: Student[] = [];
  allStudent : Student[] = [];
  searchTerm:string="";
  constructor(private httpClient: HttpClient, private router: Router)
  {

  }

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents(){
    this.httpClient.get<Student[]>("https://dlwms-api.p2103.app.fit.ba/Student/GetAll").subscribe(x => {
      this.students = x;
      this.allStudent=x;
    });
  }

  delete(id: number){
    this.httpClient.delete(`https://dlwms-api.p2103.app.fit.ba/Student/Delete/${id}`).subscribe(x => {
      this.getStudents();
    });
  }

  search()
  {
    this.students=this.allStudent.filter(x=>
      x.ime.toLowerCase().includes(this.searchTerm) ||
      x.prezime.toLowerCase().includes(this.searchTerm));
  }

  edit(id: number)
  {
    this.router.navigateByUrl(`/student/${id}`);
  }

}
