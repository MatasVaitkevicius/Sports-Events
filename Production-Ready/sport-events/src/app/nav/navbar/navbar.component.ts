import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../user/shared/auth.service';
import {EventService} from '../../microservices/event/event.service';
import {ISportType} from '../../microservices/sport-type/sport-type.model';
import {SportTypeService} from '../../microservices/sport-type/sport-type.service';

@Component({
  selector: 'nav-bar',
  templateUrl: 'navbar.component.html',
  styleUrls: ['navbar.component.css']
})
export class NavbarComponent implements OnInit {
  searchTerm = '';
  sportTypes: ISportType[];

  constructor(public authService: AuthService,
              private eventService: EventService,
              private sportTypeService: SportTypeService) {
  }

  ngOnInit() {
    this.sportTypeService.getSportTypes().subscribe(sportType => {
      this.sportTypes = sportType;
    });
  }

  searchEvents(searchTerm: string) {
    this.eventService.activateSearch(searchTerm);
  }

  filterEvents(sportTypeId: number) {
    this.searchTerm = null;
    this.eventService.filterEvents(sportTypeId);
  }

  resetEvents() {
    this.searchTerm = null;
    this.eventService.resetEvents();
  }

  logout() {
    this.authService.logout();
  }
}
