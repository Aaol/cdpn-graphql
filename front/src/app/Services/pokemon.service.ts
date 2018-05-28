import { Injectable } from '@angular/core';
import { ApolloService } from './apollo.service';
import gql from 'graphql-tag';
import { PokemonListResponse } from '../responses/pokemon-list-response';
@Injectable()
export class PokemonService {

  constructor(private apolloService: ApolloService) {

  }
  public searchByName(value: string) {
    return this.apolloService.apollo.query({
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
    }).map(res => <PokemonListResponse>res.data);
  }
}
