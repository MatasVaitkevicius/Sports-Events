import {Component, Input, OnInit} from '@angular/core';
import {IEvent} from '../../microservices/event/event.model';

@Component({
  selector: 'sorting',
  templateUrl: './sorting.component.html',
  styleUrls: ['./sorting.component.css']
})
export class SortingComponent implements OnInit {
  sortBy: string;
  @Input() events: IEvent[];

  constructor() {
  }

  ngOnInit() {
  }

  sortByName() {
    this.sortBy = 'name';
    this.events.sort(sortByNameAsc);
  }

  sortByVotes() {
    this.sortBy = 'votes';
    this.events.sort(sortByVotesDesc);
  }

  sortByDate() {
    this.sortBy = 'date';
    this.events.sort(sortByDateAsc);
  }
}

function sortByNameAsc(s1: IEvent, s2: IEvent) {
  if (s1.name > s2.name) {
    return 1;
  } else if (s1.name === s2.name) {
    return 0;
  } else {
    return -1;
  }
}

function sortByDateAsc(s1: IEvent, s2: IEvent) {
  if (s1.eventDate > s2.eventDate) {
    return 1;
  } else if (s1.eventDate === s2.eventDate) {
    return 0;
  } else {
    return -1;
  }
}

function sortByVotesDesc(s1: IEvent, s2: IEvent) {
  return s2.voters.length - s1.voters.length;
}
