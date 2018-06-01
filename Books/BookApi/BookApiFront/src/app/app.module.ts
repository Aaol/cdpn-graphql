import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { ApolloModule, APOLLO_OPTIONS } from 'apollo-angular';
import { HttpLink, HttpLinkModule } from 'apollo-angular-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';
import {
  MatToolbarModule,
  MatButtonModule,
  MatCardModule,
  MatGridListModule,
  MatDialogModule,
  MatInputModule
} from '@angular/material';
import { AppComponent } from './app.component';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthorsComponent } from './Components/authors/authors.component';
import { GraphQlService } from './Services/graph-ql.service';
import { environment } from '../environments/environment.prod';
import { AuthorComponent } from './Components/author/author.component';
import { AuthorService } from './Services/author.service';
import { AddBookComponent } from './Components/add-book/add-book.component';
import { FormsModule } from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
export function createApollo(httpLink: HttpLink) {
  return {
    link: httpLink.create({ uri: environment.apiUrl }),
    cache: new InMemoryCache()
  };
}

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    AuthorsComponent,
    AuthorComponent,
    AddBookComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ApolloModule,
    MatToolbarModule,
    MatButtonModule,
    MatGridListModule,
    FormsModule,
    MatCardModule,
    MatDialogModule,
    MatInputModule,
    BrowserAnimationsModule,
    HttpLinkModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: APOLLO_OPTIONS,
      useFactory: createApollo,
      deps: [HttpLink]
    },
    GraphQlService,
    AuthorService
  ],
  entryComponents: [
    AddBookComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
