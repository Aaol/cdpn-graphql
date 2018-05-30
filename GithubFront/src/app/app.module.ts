import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatMenuModule, MatToolbarModule, MatInputModule, MatCardModule, MatGridListModule } from '@angular/material';
import { SearchComponent } from './Components/search/search.component';
import { ResultComponent } from './Components/result/result.component';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { FormsModule } from '@angular/forms';
import { RepositoryService } from './Services/Repository/repository.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderInterceptorService } from './Services/Interceptors/header-interceptor.service';
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    SearchComponent,
    ResultComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule,
    MatInputModule,
    MatCardModule,
    MatGridListModule,
    MatToolbarModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [RepositoryService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HeaderInterceptorService,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }

platformBrowserDynamic().bootstrapModule(AppModule);
