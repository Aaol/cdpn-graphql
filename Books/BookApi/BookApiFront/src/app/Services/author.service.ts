import { Injectable } from '@angular/core';
import { GraphQlService } from './graph-ql.service';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Author } from '../Classes/author';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthorService {

  private author$: ReplaySubject<Author> = new ReplaySubject<Author>(null);
  public author: Observable<Author>;
  constructor(private graphqlService: GraphQlService) {
    this.author = new Observable(observer => {
      this.author$.subscribe(observer);
    });
    this.author$.next(null);
  }
  public setNewAuthor(id: number) {
    return this.graphqlService.getAuthor(id).do(res => this.author$.next(res));
  }
}
