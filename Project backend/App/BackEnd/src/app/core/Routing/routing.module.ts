import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../../components/login/login.component';
import { LogoutComponent } from '../../components/logout/logout.component';
import { CanActivateThisRoute } from '../Guard/RouterGuard';
import { MenuComponent } from '../../components/menu/menu.component';


export const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'logout', component: LogoutComponent},
    {path: 'menu', component: MenuComponent, canActivate: [CanActivateThisRoute]},
    {path: '**', component: LoginComponent}
  ];


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [ RouterModule]
})
export class RoutingModule {}
