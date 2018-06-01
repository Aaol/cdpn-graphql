import { Injectable } from '@angular/core';
import { GraphQlService } from './graph-ql.service';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Author } from '../Classes/author';
import { Observable } from 'rxjs/Observable';
import { InputBook } from '../Classes/inputbook';

@Injectable()
export class AuthorService {

  private author$: ReplaySubject<Author> = new ReplaySubject<Author>(null);
  public author: Observable<Author>;
  private idAuthor: number;
  constructor(private graphqlService: GraphQlService) {
    this.author = new Observable(observer => {
      this.author$.subscribe(observer);
    });
    this.author$.next(null);
  }
  public setNewAuthor(id: number) {
    this.idAuthor = id;
    return this.loadAuthor();
  }
  public addBook(book: InputBook) {
    return this.graphqlService.addBook(book, this.idAuthor).subscribe(res => {
      this.loadAuthor().subscribe((author) => console.log(author));
    });
  }
  private loadAuthor() {
    return this.graphqlService.getAuthor(this.idAuthor).do(res => {
      this.author$.next(res);
    });
  }
}
