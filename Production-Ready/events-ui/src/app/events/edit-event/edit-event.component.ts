import {Component, OnInit} from '@angular/core';
import {IEvent, IUpdateEvent} from '../../microservices/event/event.model';
import {ActivatedRoute, Router} from '@angular/router';
import {EventService} from '../../microservices/event/event.service';
import {FormControl, FormGroup} from '@angular/forms';
import {ISportType} from '../../microservices/sport-type/sport-type.model';
import {ToastrService} from 'toastr-ng2';
import {SportTypeService} from '../../microservices/sport-type/sport-type.service';

@Component({
  selector: 'edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent implements OnInit {
  event: IEvent;
  eventForm: FormGroup;
  sportTypes: ISportType[];

  constructor(private eventService: EventService,
              private sportTypeService: SportTypeService,
              private route: ActivatedRoute,
              private router: Router,
              private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.event = this.route.snapshot.data['event'];

    this.sportTypeService.getSportTypes().subscribe(sportType => {
      this.sportTypes = sportType;
    });

    this.eventForm = new FormGroup({
      name: new FormControl(this.event.name),
      eventDate: new FormControl(this.event.eventDate),
      timeFrom: new FormControl(this.event.timeFrom),
      timeTill: new FormControl(this.event.timeTill),
      price: new FormControl(this.event.price),
      phoneNumber: new FormControl(this.event.phoneNumber),
      address: new FormControl(this.event.location.address),
      city: new FormControl(this.event.location.city),
      country: new FormControl(this.event.location.country),
      description: new FormControl(this.event.description),
      facebookEventUrl: new FormControl(this.event.facebookEventUrl),
      imageUrl: new FormControl(this.event.imageUrl),
      sportTypeId: new FormControl(this.event.sportTypeId)
    });
  }

  cancel() {
    this.router.navigate(['/myEvents']);
  }

  saveEvent(formValues) {

    const updateEvent: IUpdateEvent = {
      name: formValues.name,
      sportTypeId: formValues.sportTypeId,
      eventDate: new Date(formValues.eventDate),
      timeFrom: formValues.timeFrom,
      timeTill: formValues.timeTill,
      phoneNumber: formValues.phoneNumber,
      price: formValues.price,
      location: {
        address: formValues.address,
        city: formValues.city,
        country: formValues.country,
      },
      facebookEventUrl: formValues.facebookEventUrl,
      description: formValues.description,
      imageUrl: formValues.imageUrl
    };

    this.eventService.updateEvent(updateEvent, this.event.eventId).subscribe();

    this.router.navigate(['/myEvents']);

    this.toastrService.success('Event Updated');
  }
}
