import {IUser} from './user.model';
import {Injectable} from '@angular/core';
import {CookieService} from 'ngx-cookie';
import * as auth0 from 'auth0-js';

@Injectable()
export class AuthService {
  currentUser: IUser;

  auth0 = new auth0.WebAuth({
    clientID: 'uVHyR3Z3Ze2Gk2Bg6Im5odt5ZJm8cpjk',
    domain: 'eventsdb.eu.auth0.com',
    responseType: 'token id_token',
    audience: 'https://eventsdb.eu.auth0.com/userinfo',
    redirectUri: 'http://localhost:4200/callback',
    scope: 'openid'
  });

  constructor(private cookieService: CookieService) {
  }

  login() {
    this.currentUser = <IUser>this.cookieService.getObject('user');
  }

  isAuthenticated() {
    this.currentUser = <IUser>this.cookieService.getObject('user');
    return !!this.currentUser;
  }

  updateUser(firstName: string, lastName: string) {
    this.currentUser.firstName = firstName;
    this.currentUser.lastName = lastName;
    this.cookieService.putObject('user', this.currentUser);
  };

  logout() {
    this.currentUser = null;
    this.cookieService.removeAll();
  }
}
