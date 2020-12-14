import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import '@angular/compiler';
import { GooglePlaceModule } from "ngx-google-places-autocomplete";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatGoogleMapsAutocompleteModule } from '@angular-material-extensions/google-maps-autocomplete';
import { AgmCoreModule } from '@agm/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { GooglePlaceComponent } from './google-place-api/google-place-api.component';

import {
  MatInputModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatSortModule,
  MatTableModule,
  MatFormFieldModule
} from '@angular/material';

const appRoutes: Routes = [
  { path: '', redirectTo: '/google-place', pathMatch: 'full' },
  {
    path: 'google-place',
    component: GooglePlaceComponent
  }
];
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    GooglePlaceComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot([
      { path: 'google-place', component: GooglePlaceComponent },
    ]),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyB_4x15ATP7Br_fRJpb215UGhsL519cwPA',
      libraries: ['places']
    }),
    HttpClientModule,
    FormsModule,
    GooglePlaceModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MatGoogleMapsAutocompleteModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
