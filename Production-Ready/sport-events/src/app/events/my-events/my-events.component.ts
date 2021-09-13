import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../user/shared/auth.service';
import {IEvent} from '../../microservices/event/event.model';
import {EventService} from '../../microservices/event/event.service';
import {ISportType} from '../../microservices/sport-type/sport-type.model';
import {SportTypeService} from '../../microservices/sport-type/sport-type.service';
import {ToastrService} from 'toastr-ng2';

@Component({
  selector: 'app-my-events',
  templateUrl: './my-events.component.html',
  styleUrls: ['./my-events.component.css']
})
export class MyEventsComponent implements OnInit {
  public myEvents: IEvent[];
  sportTypes: ISportType[];

  constructor(private auth: AuthService,
              private eventService: EventService,
              private sportTypeService: SportTypeService,
              private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.sportTypeService.getSportTypes().subscribe(sportType => {
      this.sportTypes = sportType;
    });

    this.eventService.getEventsByUserId(this.auth.currentUser.userId).subscribe(e => {
      this.myEvents = e;
      this.myEvents.sort((event1, event2) => {
        if (event1.eventDate > event2.eventDate) {
          return 1;
        } else if (event1.eventDate < event2.eventDate) {
          return -1;
        }
        return 0;
      });
    });
  }

  changeEventState(eventId: number) {
    this.eventService.changeEventState(eventId).subscribe();
    const event = this.myEvents.find(e => e.eventId === eventId);
    if (event.canceled === true) {
      event.canceled = false;
      this.toastrService.success('Event restarted!', 'Restarted', {timeOut: 1000});
    } else if (event.canceled === false) {
      event.canceled = true;
      this.toastrService.error('Event canceled!', 'Canceled', {timeOut: 1000});
    }
  }

  determineSportType(sportTypeId: number): string {
    if (this.sportTypes !== undefined) {
      return this.sportTypes.find(x => x.sportTypeId === sportTypeId).name;
    }
  }
}
