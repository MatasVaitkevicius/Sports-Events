import {Component, OnInit} from '@angular/core';
import {ISportType} from '../../microservices/sport-type/sport-type.model';
import {SportTypeService} from '../../microservices/sport-type/sport-type.service';
import {IUser} from '../../user/shared/user.model';
import {UserService} from '../../user/shared/user.service';
import {IEvent} from '../../microservices/event/event.model';
import {Subscription} from 'rxjs/Subscription';
import {ActivatedRoute, Router} from '@angular/router';
import {EventService} from '../../microservices/event/event.service';

@Component({
  selector: 'event-list',
  templateUrl: 'event-list.component.html',
  styleUrls: ['event-list.component.css']
})
export class EventListComponent implements OnInit {

  events: IEvent[];
  sportTypes: ISportType[];
  users: IUser[];
  showCanceled = false;
  searchTerm = '';
  filterTerm = '';
  private searchSubscription: Subscription;
  private filterSubscription: Subscription;
  private resetSubscription: Subscription;

  constructor(private route: ActivatedRoute,
              private eventService: EventService,
              private sportTypeService: SportTypeService,
              private userService: UserService) {
  }

  ngOnInit() {
    this.events = this.route.snapshot.data['events'].filter(e => e.canceled === false);

    this.sportTypeService.getSportTypes().subscribe(sportType => {
      this.sportTypes = sportType;
      this.events = this.mapSportTypes(this.events);
    });

    this.userService.getUsers().subscribe(users => {
      this.users = users;
      this.events = this.mapUsers(this.events);
    });

    this.resetSubscription = this.eventService.resetEventsObservable$.subscribe(() => {
      this.filterTerm = '';
      this.searchTerm = '';
      this.showCanceled = false;
      this.eventService.getEvents().subscribe(e => {
        this.events = e.filter(ev => ev.canceled === false);
        this.events = this.mapUsers(this.events);
        this.events = this.mapSportTypes(this.events);
      });
    });

    this.searchSubscription = this.eventService.searchNotificationObservable$.subscribe((searchTerm) => {
      this.filterTerm = '';
      this.searchTerm = searchTerm;
      this.showCanceled = false;
      this.eventService.getEventsBySearchTerm(searchTerm).subscribe(e => {
        this.events = e.filter(ev => ev.canceled === false);
        this.events = this.mapUsers(this.events);
        this.events = this.mapSportTypes(this.events);
      });
    });

    this.filterSubscription = this.eventService.filterNotificationObservable$.subscribe((sportTypeId) => {
      this.filterTerm = this.determineSportType(sportTypeId);
      this.searchTerm = '';
      this.showCanceled = false;
      this.eventService.getEventsBySportTypeId(sportTypeId).subscribe(e => {
        this.events = e.filter(ev => ev.canceled === false);
        this.events = this.mapUsers(this.events);
        this.events = this.mapSportTypes(this.events);
      });
    });
  }

  private mapSportTypes(events: IEvent[]): IEvent[] {
    return events.map(e => {
      e.sportTypeName = this.determineSportType(e.sportTypeId);
      return e;
    });
  }

  private mapUsers(events: IEvent[]): IEvent[] {
    return events.map(e => {
      e.authorName = this.determineAuthor(e.userId);
      return e;
    });
  }

  private determineSportType(sportTypeId: number): string {
    if (this.sportTypes !== undefined) {
      return this.sportTypes.find(x => x.sportTypeId === sportTypeId).name;
    }
  }

  private determineAuthor(authorId: number): string {
    if (this.users !== undefined) {
      const foundUser = this.users.find(x => x.userId === authorId);
      return `${foundUser.firstName} ${foundUser.lastName}`;
    }
  }

  public toggleCanceledEvents() {
    this.searchTerm = '';
    this.filterTerm = '';
    this.showCanceled = !this.showCanceled;
    if (this.showCanceled === false) {
      this.events = this.route.snapshot.data['events'].filter(e => e.canceled === this.showCanceled);
    } else if (this.showCanceled === true) {
      this.events = this.route.snapshot.data['events'];
      this.events = this.mapUsers(this.events);
      this.events = this.mapSportTypes(this.events);
    }
  }
}
