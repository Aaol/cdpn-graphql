import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular/api';
import { HttpLink } from 'apollo-angular-link-http';
import { Observable } from 'rxjs/Observable';
import { Author } from '../Classes/author';
import { getAuthors, getAuthor } from './Queries/authors';
import { EntityResponse } from '../Classes/entity-response';
import { InputBook } from '../Classes/inputbook';
import { addBook } from './Queries/books';
import { Book } from '../Classes/book';
import { variable } from '@angular/compiler/src/output/output_ast';
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
      variables: {identifier: id},
      fetchPolicy: 'network-only'
    }).map(result => (<EntityResponse<Author>>result.data['author']).entity);
  }
  public addBook(book: InputBook, id: number): Observable<Book> {
    return this.apollo.mutate({
      mutation: addBook,
      variables: {
        identifier: id,
        book: book
      }
    }).do(res => console.log(res)).map(result => (<EntityResponse<Book>>result.data['newBook']).entity);
  }
}
