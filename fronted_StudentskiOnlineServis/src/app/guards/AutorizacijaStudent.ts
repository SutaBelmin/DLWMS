import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";
@Injectable()
export class AutorizacijaStudent implements CanActivate {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    try {
      if (AutentifikacijaHelper.getLoginInfo().isPermisijaStudent)
        return true;
    }catch (e) {
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
    return false;
  }
}
