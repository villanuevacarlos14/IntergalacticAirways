import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StarshipSearchComponent } from './components/starship-search/starship-search.component';

const routes: Routes = [{
  path: '', component: StarshipSearchComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
