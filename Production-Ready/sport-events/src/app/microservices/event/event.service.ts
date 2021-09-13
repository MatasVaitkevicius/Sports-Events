import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs/Rx';
import {IEvent, INewEvent, IUpdateEvent} from './event.model';
import {Http, Response, Headers, RequestOptions} from '@angular/http';

@Injectable()
export class EventService {
  private searchNotification = new Subject<string>();
  searchNotificationObservable$ = this.searchNotification.asObservable();

  private filterNotification = new Subject<number>();
  filterNotificationObservable$ = this.filterNotification.asObservable();

  private resetEventsNotification = new Subject<any>();
  resetEventsObservable$ = this.resetEventsNotification.asObservable();

  private baseUrl = 'http://localhost:5000';

  constructor(private http: Http) {

  }

  getEvents(): Observable<IEvent[]> {
    return this.http.get(this.baseUrl + '/api/events')
      .map((response: Response) => {
        return <IEvent[]>response.json();
      }).catch(this.handleError);
  }

  getEventsBySearchTerm(searchTerm: string): Observable<IEvent[]> {
    return this.http.get(`${this.baseUrl}/api/events/search/${searchTerm}`)
      .map((response: Response) => {
        return <IEvent[]>response.json();
      }).catch(this.handleError);
  }

  getEventsBySportTypeId(sportTypeId: number): Observable<IEvent[]> {
    return this.http.get(`${this.baseUrl}/api/events/sportType/${sportTypeId}`)
      .map((response: Response) => {
        return <IEvent[]>response.json();
      }).catch(this.handleError);
  }

  getEvent(id: number): Observable<IEvent> {
    return this.http.get(this.baseUrl + '/api/events/' + id)
      .map((response: Response) => {
        return <IEvent>response.json();
      }).catch(this.handleError);
  }

  saveEvent(newEvent): Observable<INewEvent> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});

    return this.http.post(`${this.baseUrl}/api/events`, JSON.stringify(newEvent), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  updateEvent(updateEvent, eventId: number): Observable<IUpdateEvent> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});

    return this.http.put(`${this.baseUrl}/api/myEvents/${eventId}`, JSON.stringify(updateEvent), options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  changeEventState(eventId: number): Observable<IEvent> {
    const headers = new Headers({'Content-Type': 'application/json'});
    const options = new RequestOptions({headers: headers});
    return this.http.put(`${this.baseUrl}/api/events/${eventId}/state`, options).map((response: Response) => {
      return response.json();
    }).catch(this.handleError);
  }

  public activateSearch(searchTerm: string) {
    this.searchNotification.next(searchTerm);
  }

  filterEvents(sportTypeId: number) {
    this.filterNotification.next(sportTypeId);
  }

  resetEvents() {
    this.resetEventsNotification.next();
  }

  getEventsByUserId(userId: number): Observable<IEvent[]> {
    return this.http.get(this.baseUrl + '/api/myEvents/' + userId)
      .map((response: Response) => {
        return <IEvent>response.json();
      }).catch(this.handleError);
  }

  private handleError(error: Response) {
    return Observable.throw(error.statusText);
  }
}
