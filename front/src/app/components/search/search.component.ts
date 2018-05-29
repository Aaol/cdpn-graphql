import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { PokemonService } from '../../Services/pokemon.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  public search: string;
  formGroup: FormGroup;
  constructor(private pokemonService: PokemonService,
  formBuilder: FormBuilder) {
    this.formGroup = formBuilder.group({
      search: []
    });
  }

  ngOnInit() {
    this.formGroup.get('search').valueChanges
    .subscribe(value => {
      this.pokemonService.searchByName(value);
    });
  }

}
