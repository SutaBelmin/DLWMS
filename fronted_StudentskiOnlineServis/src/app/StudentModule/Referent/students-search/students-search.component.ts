import { Component, OnInit } from '@angular/core';
import {Student} from "../../_models/Student";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../../MyConfig";

declare function porukaSuccess(s:string):any;

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

  ngOnInit(): void
  {
    this.getStudents();
  }

  getStudents(){
    this.httpClient.get<Student[]>(`${MojConfig.MyLocalHost}/Student/GetAll`).subscribe(x => {
      this.students = x;
      this.allStudent=x;
      console.log(x);
    });
  }

  delete(id: number){
    this.httpClient.delete(`${MojConfig.MyLocalHost}/Student/Delete/${id}`).subscribe(x => {
      this.getStudents();
      porukaSuccess("Student uspješno obrisan");
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
    this.router.navigateByUrl(`/referent/student/${id}`);
  }

  skolarina(id:any)
  {
    let cijena=this.students.find(x=>x.id==id).cijenaSkolarine;
   this.httpClient.post(`${MojConfig.MyLocalHost}/Student/EvidentirajSkolarinu/${id}?cijena=${cijena}`,{}).subscribe(x=>{
     this.getStudents();
   });
  }

  LogOut()
  {
    this.httpClient.delete(MojConfig.AutentifikacijaLogOut, MojConfig.http_opcije()).subscribe(x=> {
      localStorage.removeItem('_Token');
      this.router.navigateByUrl('/login')
    });
  }
}
