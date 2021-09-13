import {Injectable} from '@angular/core';
import {IEvent} from '../event/event.model';
import {Observable} from 'rxjs/Observable';
import {IVoter} from './voter.model';
import {Http, RequestOptions, Headers, Response} from '@angular/http';

@Injectable()
export class VoterService {
  private baseUrl = 'http://localhost:5000';

  constructor(private http: Http) {

  }

  deleteVoter(eventId: number, userId: number): Observable<IVoter> {
    return this.http.delete(`${this.baseUrl}/api/voter/${eventId}/${userId}`).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  addVoter(eventId: number, userId: number): Observable<IVoter> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});
    const voter: IVoter = {
      eventId: eventId,
      userId: userId
    };

    return this.http.post(`${this.baseUrl}/api/voter`, JSON.stringify(voter), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  userHasVoted(event: IEvent, userId: number) {
    return event.voters.some(voter => voter.userId === userId);
  }

  private handleError(error: Response) {
    return Observable.throw(error.statusText);
  }
}
