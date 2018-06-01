import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular/api';
import { HttpLink } from 'apollo-angular-link-http';
import { Observable } from 'rxjs/Observable';
import { Author } from '../Classes/author';
import { getAuthors, getAuthor } from './Queries/authors';
import { EntityResponse } from '../Classes/entity-response';
@Injectable()
export class GraphQlService {

  constructor(public apollo: Apollo, httpLink: HttpLink) {

  }

  public getAuthors(): Observable<Author[]> {
    return this.apollo.query({
      query: getAuthors
    }).map(result => (<EntityResponse<Author[]>>result.data['authors']).entity);
  }
  public getAuthor(id: number): Observable<Author> {
    return this.apollo.query({
      query: getAuthor,
      variables: {identifier: id}
    }).map(result => (<EntityResponse<Author>>result.data['author']).entity);
  }
}
