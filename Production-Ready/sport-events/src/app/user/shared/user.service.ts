import {IUser} from './user.model';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {IRegisterUser, IUpdateUser} from './login.model';
import {RequestOptions, Response, Headers, Http} from '@angular/http';

@Injectable()
export class UserService {

  baseUrl = 'http://localhost:5000';

  constructor(private http: Http) {
  }

  getUsers(): Observable<IUser[]> {
    return this.http.get(this.baseUrl + '/api/user/all')
      .map((response: Response) => {
        return <IUser[]>response.json();
      }).catch(this.handleError);
  }

  getUserById(id: number): Observable<IUser> {
    return this.http.get(this.baseUrl + '/api/user/id')
      .map((response: Response) => {
        return <IUser>response.json();
      }).catch(this.handleError);
  }

  registerUser(newUser): Observable<IRegisterUser> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});

    return this.http.post(`${this.baseUrl}/api/user`, JSON.stringify(newUser), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  checkUser(checkUser): Observable<boolean> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});

    return this.http.post(`${this.baseUrl}/api/user/exists`, JSON.stringify(checkUser), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  loginUser(loginInfo): Observable<IUser> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});

    return this.http.post(`${this.baseUrl}/api/user/login`, JSON.stringify(loginInfo), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  updateUser(userId: number, updateUser): Observable<IUpdateUser> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});

    return this.http.put(`${this.baseUrl}/api/user/${userId}`, JSON.stringify(updateUser), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  private handleError(error: Response) {
    return Observable.throw(error.statusText);
  }
}
