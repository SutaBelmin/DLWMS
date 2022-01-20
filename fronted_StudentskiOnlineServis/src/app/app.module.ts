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
import { StudentsSearchComponent } from './StudentModule/students-search/students-search.component';
import { StudentAddComponent } from './StudentModule/student-add/student-add.component';
import { StudentEditComponent } from './StudentModule/student-edit/student-edit.component';
import {AutorizacijaLoginProvjera} from "./guards/AutorizacijaLoginProvjera";
import {AutorizacijaProfesor} from "./guards/AutorizacijaProfesor";
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
      {path: 'student/:id', component: StudentEditComponent}

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
