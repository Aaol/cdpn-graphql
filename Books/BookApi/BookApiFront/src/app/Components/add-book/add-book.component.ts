import { Component, OnInit } from '@angular/core';
import { InputBook } from '../../Classes/inputbook';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {
  book: InputBook;
  constructor() {
    this.book = new InputBook();
  }

  ngOnInit() {
  }

}
