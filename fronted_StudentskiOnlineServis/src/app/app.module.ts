import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from "@angular/forms";
import {AppComponent} from './app.component';
import {HttpClientModule} from "@angular/common/http";
import {RouterModule} from "@angular/router";
import { LoginComponent } from './login/login.component';
import { ZaboravioSifruComponent } from './login/zaboravio-sifru/zaboravio-sifru.component';
import { NovaSifraComponent } from './login/nova-sifra/nova-sifra.component';
import { ProfesorComponent } from './profesor/profesor.component';
import { NavMenuComponent } from './StudentModule/_components/nav-menu/nav-menu.component';
import { StudentsSearchComponent } from './StudentModule/Referent/students-search/students-search.component';
import { StudentAddComponent } from './StudentModule/Referent/student-add/student-add.component';
import { StudentEditComponent } from './StudentModule/Referent/student-edit/student-edit.component';
import {AutorizacijaLoginProvjera} from "./guards/AutorizacijaLoginProvjera";
import {AutorizacijaProfesor} from "./guards/AutorizacijaProfesor";
import { ReferentPotvrdeComponent } from './StudentModule/Referent/referent-potvrde/referent-potvrde.component';
import { StudentPotvrdeComponent } from './StudentModule/Student/student-potvrde/student-potvrde.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ZaboravioSifruComponent,
    NovaSifraComponent,
    ProfesorComponent,
    NavMenuComponent,
    StudentsSearchComponent,
    StudentAddComponent,
    StudentEditComponent,
    ReferentPotvrdeComponent,
    StudentPotvrdeComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: LoginComponent},
      {path: 'login', component: LoginComponent},
      {path: 'zaboravio_sifru', component: ZaboravioSifruComponent},
      {path: 'nova_sifra', component: NovaSifraComponent},
      {path: 'profesor', component: ProfesorComponent},
      {path: 'student', component: StudentsSearchComponent},
      {path: 'student/add', component: StudentAddComponent},
      {path: 'student/:id', component: StudentEditComponent},

      {path: 'ref-potvrde', component: ReferentPotvrdeComponent},
      {path: 'stu-potvrde', component: StudentPotvrdeComponent}

    ]),
  ],
  providers: [
    AutorizacijaProfesor,
    AutorizacijaLoginProvjera
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
