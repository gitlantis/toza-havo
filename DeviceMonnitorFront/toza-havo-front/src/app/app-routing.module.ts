import { NgModule } from '@angular/core';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { HomeScreenComponent } from './home-screen/home-screen.component';
import { LoginScreenComponent } from './login-screen/login-screen.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../services/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginScreenComponent },
  { path: 'main', component: MainScreenComponent, canActivate: [AuthGuard] },
  { path: '**', component: HomeScreenComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]

})
export class AppRoutingModule { }
