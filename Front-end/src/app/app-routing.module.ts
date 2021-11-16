import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserLoginComponent } from './user-auth/user-login/user-login.component';
import { UserRegistrationComponent } from './user-auth/user-registration/user-registration.component';

const routes: Routes = [
  {path: '', component: UserLoginComponent},
  {path: 'user-registration', component: UserRegistrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
