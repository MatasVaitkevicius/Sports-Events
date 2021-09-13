import {Component, OnInit} from '@angular/core';
import {EventService} from '../../microservices/event/event.service';
import {Router} from '@angular/router';
import {ISportType} from '../../microservices/sport-type/sport-type.model';
import {SportTypeService} from '../../microservices/sport-type/sport-type.service';
import {INewEvent} from '../../microservices/event/event.model';
import {AuthService} from '../../user/shared/auth.service';
import {ToastrService} from 'toastr-ng2';

@Component({
  selector: 'create-event',
  templateUrl: 'create-event.component.html',
  styleUrls: ['create-event.component.css']
})
export class CreateEventComponent implements OnInit {
  isDirty: boolean = true;
  sportTypes: ISportType[];
  event: any = {location: {}};
profile: any;
  // Form variables

 public eventId: number;
 public userId: number;
 public name: string;
 public sportTypeId: number;
 public eventDate: Date;
 public timeFrom: string;
 public timeTill: string;
 public price: number;
 public phoneNumber: string;
 public address: string;
 public city: string;
 public country: string;
 public description: string;
 public facebookEventUrl: string;
 public imageUrl: string;
 public canceled: boolean;

  public mouserOverLogin = false;

  constructor(private eventService: EventService,
              private router: Router,
              private sportTypeService: SportTypeService,
              private auth: AuthService,
              private toastrService: ToastrService) {
  }

  ngOnInit(): void {
    this.sportTypeService.getSportTypes().subscribe(sportType => {
      this.sportTypes = sportType;
    });

    this.auth.getProfile((err, profile) => {
      this.profile = profile;
    });
  }

  saveEvent(formValues) {
    const newEvent: INewEvent = {
      userId: this.profile.sub,
      name: formValues.name,
      sportTypeId: formValues.sportTypeId,
      eventDate: new Date(formValues.eventDate),
      timeFrom: formValues.timeFrom,
      timeTill: formValues.timeTill,
      phoneNumber: formValues.phoneNumber,
      price: formValues.price,
      location: {
        address: formValues.location.address,
        city: formValues.location.city,
        country: formValues.location.country,
      },
      facebookEventUrl: formValues.facebookEventUrl,
      description: formValues.description,
      imageUrl: formValues.imageUrl
    };

    this.eventService.saveEvent(newEvent).subscribe();

    this.router.navigate(['/myEvents']);
    this.isDirty = false;
    this.toastrService.success('Event Created Successfully!');
  }

  cancel() {
    this.router.navigate(['/events']);
  }
}
