import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { HttpLink } from 'apollo-angular-link-http';
import {InMemoryCache} from 'apollo-cache-inmemory';
@Injectable()
export class ApolloService {

  constructor(public apollo: Apollo, httpLink: HttpLink) {
    apollo.create({
      link: httpLink.create({uri: 'https://graphql-pokemon.now.sh'}),
      cache: new InMemoryCache(),
    });
  }

}
