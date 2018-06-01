import { Component, OnInit } from '@angular/core';
import { GraphQlService } from '../../Services/graph-ql.service';
import { Author } from '../../Classes/author';
import { AuthorService } from '../../Services/author.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {
  authors: Author[];
  constructor(
    private graphqlService: GraphQlService,
    private authorService: AuthorService,
    private router: Router
  ) {}

  ngOnInit() {
    this.graphqlService
      .getAuthors()
      .do(res => console.log(res))
      .subscribe(authors => (this.authors = authors));
  }
  redirectToAuthor(author: Author) {
    this.authorService.setNewAuthor(author.id).subscribe(res => {
      this.router.navigate(['author', author.id]);
    });
  }
}
