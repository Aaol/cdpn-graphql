import { Injectable } from '@angular/core';
import { SearchRepository } from './search-repository';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Observable } from 'rxjs/Observable';
import { Repository } from './repository';
import { HttpClient } from '@angular/common/http';
import { RepositoryReponse } from './repository-response';

@Injectable()
export class RepositoryService {
  private $search: ReplaySubject<SearchRepository> = new ReplaySubject<SearchRepository>(null);
  private currentSearch: SearchRepository;
  public search: Observable<SearchRepository>;

  private $repositories: ReplaySubject<Repository[]> = new ReplaySubject<Repository[]>(null);
  public repositories: Observable<Repository[]>;

  private $selectedRepository: ReplaySubject<Repository> = new ReplaySubject<Repository>(null);
  public selectedRepository: Observable<Repository>;

  private apiUrl = 'http://localhost:58058/api/repository/';
  constructor(private http: HttpClient) {
    this.search = new Observable(observer => {
      this.$search.subscribe(observer);
    });
    this.repositories = new Observable(observer => {
      this.$repositories.subscribe(observer);
    });
    this.selectedRepository = new Observable(observer => {
      this.$selectedRepository.subscribe(observer);
    });
  }
  public newSearch(search: SearchRepository) {
    this.$search.next(search);
    this.currentSearch = search;
    this.searchRepositories();
  }
  private searchRepositories() {
    this.http.post<RepositoryReponse>
    (this.apiUrl + 'repositories', JSON.stringify(this.currentSearch))
    .subscribe(response =>
      this.$repositories.next(response.user.repositories.nodes)
    );
  }
}
