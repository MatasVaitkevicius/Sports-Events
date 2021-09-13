import {CreateEventComponent} from "./events/create-event/create-event.component";
import {Routes} from "@angular/router";
import {EventListComponent} from "./events/event-list/event-list.component";
import {EventListResolver} from "./microservices/event/event-list-resolver.service";
import {EventDetailsComponent} from "./events/event-details/event-details.component";
import {EventResolver} from "./microservices/event/event-resolver.service";
import {Error404Component} from "./errors/error404/error404.component";
import {ProfileComponent} from "./user/profile/profile.component";
import {LoginComponent} from "./user/login/login.component";
import {MyEventsComponent} from './events/my-events/my-events.component';
import {EditEventComponent} from './events/edit-event/edit-event.component';
import {RegisterComponent} from './user/register/register.component';

export const appRoutes: Routes = [
  { path: 'events/new', component: CreateEventComponent, canDeactivate: ['canDeactivateCreateEvent'] },
  { path: 'events', component: EventListComponent, resolve: { events: EventListResolver }},
  { path: 'events/category/:categoryId', component: EventListComponent, resolve: { events: EventListResolver }},
  { path: 'events/:eventId', component: EventDetailsComponent, resolve: { event: EventResolver }},
  { path: 'myEvents', component: MyEventsComponent, resolve: { events: EventListResolver}},
  { path: 'myEvents/:eventId', component: EditEventComponent, resolve: { event: EventResolver }},

  { path: '404', component: Error404Component },
  { path: '', redirectTo: '/events', pathMatch: 'full' },



  {path: 'user/profile', component: ProfileComponent},
  {path: 'user/login', component: LoginComponent},
  {path: 'user/register', component: RegisterComponent}
];
