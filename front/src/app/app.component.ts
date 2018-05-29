import { Component, OnInit } from '@angular/core';
import { PokemonService } from './Services/pokemon.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  pokemons: any[];
  constructor(private pokemonService: PokemonService) {

  }
  ngOnInit(): void {
    this.pokemonService.pokemons.subscribe(res => this.pokemons = res);
    this.pokemonService.searchAll();
  }
}
