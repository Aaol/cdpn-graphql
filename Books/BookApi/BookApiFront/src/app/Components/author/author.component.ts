import { Component, OnInit } from '@angular/core';
import { Author } from '../../Classes/author';
import { AuthorService } from '../../Services/author.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  author: Author;
  constructor(private authorService: AuthorService,
  private route: ActivatedRoute) { }

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

}
