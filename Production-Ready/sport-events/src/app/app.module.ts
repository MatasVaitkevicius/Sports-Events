import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {AppComponent} from './app.component';
import {EventDetailsComponent} from './events/event-details/event-details.component';

import {EventService} from "./microservices/event/event.service";
import {NavbarComponent} from './nav/navbar/navbar.component';
import {EventResolver} from "./microservices/event/event-resolver.service";
import {EventListComponent} from './events/event-list/event-list.component';
import {EventThumbnailComponent} from './events/event-thumbnail/event-thumbnail.component';
import {ProfileComponent} from './user/profile/profile.component';
import {LoginComponent} from './user/login/login.component';
import {Error404Component} from './errors/error404/error404.component';
import {AuthService} from "./user/shared/auth.service";
import {EventListResolver} from "./microservices/event/event-list-resolver.service";
import {RouterModule} from "@angular/router";
import {appRoutes} from "./app-routing.module";
import {CreateEventComponent} from "./events/create-event/create-event.component";
import {ToastrModule} from "toastr-ng2";
import {UpvoteComponent} from './events/upvote/upvote.component';
import {VoterService} from './microservices/voter/voter.service';
import {LocationValidator} from './events/create-event/location-validator.directive';
import {EditEventComponent} from './events/edit-event/edit-event.component';
import {MyEventsComponent} from './events/my-events/my-events.component';
import {UserService} from './user/shared/user.service';
import {CollapsibleWellComponent} from './common/collapsible-well/collapsible-well.component';
import {SortingComponent} from './events/sorting/sorting.component';
import {SportTypeService} from './microservices/sport-type/sport-type.service';
import {StringToDatePipe} from './events/shared/string-to-date.pipe';
import {RegisterComponent} from './user/register/register.component';
import {CookieModule} from 'ngx-cookie';

@NgModule({
  declarations: [
    AppComponent,
    EventDetailsComponent,
    NavbarComponent,
    CreateEventComponent,
    EventListComponent,
    EventThumbnailComponent,
    ProfileComponent,
    LoginComponent,
    Error404Component,
    StringToDatePipe,
    UpvoteComponent,
    LocationValidator,
    EditEventComponent,
    MyEventsComponent,
    CollapsibleWellComponent,
    SortingComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    ToastrModule.forRoot(),
    CookieModule.forRoot()
  ],
  providers: [
    EventService,
    UserService,
    VoterService,
    SportTypeService,
    EventResolver,
    EventListResolver,
    AuthService,
    {provide: 'canDeactivateCreateEvent', useValue: checkDirtyState}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

export function checkDirtyState(component: CreateEventComponent) {
  if (component.isDirty)
    return window.confirm('You have not saved this event, do you' +
      'really want to cancel?')
  return true;
}

