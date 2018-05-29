import { Component, OnInit, Input } from '@angular/core';
import { Repository } from '../../Services/Repository/repository';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  @Input() repository: Repository;
  constructor() { }

  ngOnInit() {
  }

}
