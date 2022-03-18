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
import { StudentsSearchComponent } from './StudentModule/Referent/students-search/students-search.component';
import { StudentAddComponent } from './StudentModule/Referent/student-add/student-add.component';
import { StudentEditComponent } from './StudentModule/Referent/student-edit/student-edit.component';
import {AutorizacijaLoginProvjera} from "./guards/AutorizacijaLoginProvjera";
import {AutorizacijaProfesor} from "./guards/AutorizacijaProfesor";
import { CasComponent } from './profesor/cas/cas.component';
import { RokTestComponent } from './profesor/rok-test/rok-test.component';
import { PrisustvoComponent } from './profesor/cas/prisustvo/prisustvo.component';
import { PrisustvaPoCasuComponent } from './profesor/cas/prisustvo/prisustva-po-casu/prisustva-po-casu.component';
import { PitanjaComponent } from './profesor/rok-test/pitanja/pitanja.component';
import { ReferentPotvrdeComponent } from './StudentModule/Referent/referent-potvrde/referent-potvrde.component';
import { StudentPotvrdeComponent } from './StudentModule/Student/student-potvrde/student-potvrde.component';
import { RefNavComponent } from './StudentModule/Referent/ref-nav/ref-nav.component';
import { ReferentComponent } from './StudentModule/Referent/referent.component';
import { PredmetiSerachComponent } from './StudentModule/Referent/predmeti-serach/predmeti-serach.component';
import { PredmetAddComponent } from './StudentModule/Referent/predmet-add/predmet-add.component';
import { PredmetiEditComponent } from './StudentModule/Referent/predmeti-edit/predmeti-edit.component';
import { StudentMainComponent } from './StudentModule/Student/student-main.component';
import { StuNavComponent } from './StudentModule/Student/stu-nav/stu-nav.component';
import { StudentPocetnaComponent } from './StudentModule/Student/student-pocetna/student-pocetna.component';
import { PotvrdePregledComponent } from './StudentModule/Student/potvrde-pregled/potvrde-pregled.component';
import { TestComponent } from './StudentModule/Student/test/test.component';
import { RezultatiComponent } from './profesor/rok-test/rezultati/rezultati.component';
import { ChatComponent } from './chat/chat.component';
import {AutorizacijaStudent} from "./guards/AutorizacijaStudent";
import {AutorizacijaReferent} from "./guards/AutorizacijaReferent";
import { TwoWayComponent } from './login/two-way/two-way.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ZaboravioSifruComponent,
    NovaSifraComponent,
    ProfesorComponent,
    StudentsSearchComponent,
    StudentAddComponent,
    StudentEditComponent,
    CasComponent,
    RokTestComponent,
    PrisustvoComponent,
    PrisustvaPoCasuComponent,
    PitanjaComponent,
    ReferentPotvrdeComponent,
    StudentPotvrdeComponent,
    RefNavComponent,
    ReferentComponent,
    PredmetiSerachComponent,
    PredmetAddComponent,
    PredmetiEditComponent,
    StudentMainComponent,
    StuNavComponent,
    StudentPocetnaComponent,
    PotvrdePregledComponent,
    TestComponent,
    RezultatiComponent,
    ChatComponent,
    TwoWayComponent,
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
      {path:'profesor/rok_test/rezultati/:rokID', component: RezultatiComponent, canActivate: [AutorizacijaProfesor]},
      {path:'chat', component: ChatComponent, canActivate: [AutorizacijaLoginProvjera]},
      {
        path: 'referent',
        component: ReferentComponent, canActivate:[AutorizacijaReferent],
        children:[
          {
            path: '',
            redirectTo: 'student',
            pathMatch: 'full'
          },
          {
            path: 'potvrde',
            component: ReferentPotvrdeComponent},
          {
            path: 'student',
            component: StudentsSearchComponent
          },
          {
            path: 'student/add',
            component: StudentAddComponent
          },
          {
            path: 'student/:id',
            component: StudentEditComponent
          },
          {
            path: 'predmeti',
            component: PredmetiSerachComponent
          },
          {
            path: 'predmeti/add',
            component: PredmetAddComponent
          },
          {
            path: 'predmeti/edit/:id',
            component: PredmetiEditComponent
          }
        ]
      },
      {
        path: 'studentmain',
        component: StudentMainComponent,canActivate:[AutorizacijaStudent],
        children:[
          {path: 'test', component: TestComponent},
          {
            path: '',
            redirectTo: 'studentpocetna',
            pathMatch: 'full'
          },
          {
            path: 'studentpocetna',
            component: StudentPocetnaComponent
          },
          {
            path: 'potvrdepregled',
            component: PotvrdePregledComponent
          },
          {
            path: 'studentpotvrde',
            component: StudentPotvrdeComponent
          },

        ]
      }

    ]),
  ],
  providers: [
    AutorizacijaProfesor,
    AutorizacijaLoginProvjera,
    AutorizacijaReferent,
    AutorizacijaStudent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
