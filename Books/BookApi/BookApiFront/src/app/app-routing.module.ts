import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorsComponent } from './Components/authors/authors.component';
import { AuthorComponent } from './Components/author/author.component';

const routes: Routes = [
  {path: 'authors', component: AuthorsComponent},
  {path: 'author/:id', component: AuthorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
