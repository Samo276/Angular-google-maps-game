import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import{ GOOGLE_MAPS_API_CONFIG, NgMapsGoogleModule } from '@ng-maps/google'
import {NgMapsCoreModule, } from '@ng-maps/core';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgMapsCoreModule,
    NgMapsGoogleModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: GOOGLE_MAPS_API_CONFIG,
      useValue: {
        apiKey: 'AIzaSyD9cCSvZT_uY3WS4IWuBw-mgPc_Ne3SIyk'
      }
    }
  ],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
