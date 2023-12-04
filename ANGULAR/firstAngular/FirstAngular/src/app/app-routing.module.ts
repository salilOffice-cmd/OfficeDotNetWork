import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponentComponent } from './home-component/home-component.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CardComponent } from './home-component/card/card.component';

const routes: Routes = [
  // default route
  // {
  //   component : HomeComponentComponent,
  //   path:""
  // },

  // wildcard route
  // {
  //   component : PageNotFoundComponent,
  //   path:"**"
  // },
  {
    component : HomeComponentComponent,
    path:"home",
    children: [{
      component : CardComponent,
      path:"card"
    }]
  },
  {
    component : AboutComponent,
    path:"about"
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}
