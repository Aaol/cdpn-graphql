import { Component, OnInit } from '@angular/core';
import { SearchRepository } from '../../Services/Repository/search-repository';
import { Repository } from '../../Services/Repository/repository';
import { RepositoryService } from '../../Services/Repository/repository.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchModel: SearchRepository;
  repos: Repository[] = [];
  constructor(private repositoryService: RepositoryService) {
    this.searchModel = new SearchRepository();
  }

  ngOnInit() {
    this.repositoryService.repositories.subscribe(repos => {
      console.log(repos);
      this.repos = repos;
    });
    this.repositoryService.search.subscribe(res => {
      if (res != null) {
        this.searchModel = res;
      }
    });
  }

  search() {
    this.repositoryService.newSearch(this.searchModel);
  }
}
