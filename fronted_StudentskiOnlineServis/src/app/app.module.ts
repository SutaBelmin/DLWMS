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
import { CasComponent } from './profesor/cas/cas.component';
import { RokTestComponent } from './profesor/rok-test/rok-test.component';
import { PrisustvoComponent } from './profesor/cas/prisustvo/prisustvo.component';
import { PrisustvaPoCasuComponent } from './profesor/cas/prisustvo/prisustva-po-casu/prisustva-po-casu.component';
import { PitanjaComponent } from './profesor/rok-test/pitanja/pitanja.component';
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
    CasComponent,
    RokTestComponent,
    PrisustvoComponent,
    PrisustvaPoCasuComponent,
    PitanjaComponent,
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
      {path: 'profesor', component: ProfesorComponent, canActivate: [AutorizacijaProfesor]},
      {path: 'profesor/cas', component: CasComponent, canActivate: [AutorizacijaProfesor]},
      {path: 'profesor/cas/prisustvo/:naziv/:predmetID/:id', component: PrisustvoComponent, canActivate: [AutorizacijaProfesor]},
      {path: 'profesor/rok_test', component: RokTestComponent, canActivate: [AutorizacijaProfesor]},
      {path: 'profesor/cas/prisustvo/pregled/:casID', component: PrisustvaPoCasuComponent, canActivate: [AutorizacijaProfesor]},
      {path: 'profesor/rok_test/pitanja/:rokID', component: PitanjaComponent, canActivate: [AutorizacijaProfesor]},
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
