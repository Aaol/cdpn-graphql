import { Component, OnInit } from '@angular/core';
import { Author } from '../../Classes/author';
import { AuthorService } from '../../Services/author.service';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material';
import { AddBookComponent } from '../add-book/add-book.component';
import { InputBook } from '../../Classes/inputbook';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  author: Author;
  constructor(private authorService: AuthorService,
  private route: ActivatedRoute,
private dialog: MatDialog) { }

  ngOnInit() {
    this.authorService.author.subscribe(res => {
      if (res != null) {
        this.author = res;
      } else {
        console.log(this.route);
        this.route.params.subscribe(params => this.authorService.setNewAuthor(+params['id']).subscribe(() => res));
      }
    });
  }
  addBook() {
    const dialogRef = this.dialog.open(AddBookComponent);
    dialogRef.afterClosed()
    .subscribe((res: InputBook) => {
      if (res != null) {
        this.authorService.addBook(res);
      }
    });
  }
}
