import { Injectable } from '@angular/core';
import { ApolloService } from './apollo.service';
import gql from 'graphql-tag';
import { PokemonListResponse } from '../responses/pokemon-list-response';
import { Pokemon } from '../classes/pokemon';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class PokemonService {

  private $pokemons = new ReplaySubject<Pokemon[]>();
  public pokemons: Observable<Pokemon[]>;
  constructor(private apolloService: ApolloService) {
    this.pokemons = new Observable( observer => {
      this.$pokemons.subscribe(observer);
    });
  }
  public searchAll() {
    this.apolloService.apollo.query({
      query: gql`
      {
      pokemons(first: 10) {
        id
        number
        name
        attacks {
          special {
            name
            type
            damage
          }
        }
        evolutions {
          id
          number
          name
          weight {
            minimum
            maximum
          }
          attacks {
            fast {
              name
              type
              damage
            }
          }
        }
      }
      }`
    }).map(res => (<PokemonListResponse>res.data).pokemons)
    .subscribe(res => this.$pokemons.next(res)
  );
  }
  public searchByName(value: string) {
    this.apolloService.apollo.query({
      query: gql`
      {
      pokemon(name: {value}) {
        id
        number
        name
        attacks {
          special {
            name
            type
            damage
          }
        }
        evolutions {
          id
          number
          name
          weight {
            minimum
            maximum
          }
          attacks {
            fast {
              name
              type
              damage
            }
          }
        }
      }
      }`
    }).map(res => <PokemonListResponse>res.data)
    .subscribe( res => {
      console.log(res);
    });
  }
}
