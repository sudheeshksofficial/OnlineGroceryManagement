import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminLoginComponent } from './Admin/admin-login/admin-login.component';
import { AdminNavbarComponent } from './Admin/admin-navbar/admin-navbar.component';
import { AdminSignupComponent } from './Admin/admin-signup/admin-signup.component';
import { StockEditComponent } from './Admin/stock-view/stock-edit/stock-edit.component';
import { StockViewComponent } from './Admin/stock-view/stock-view.component';
import { LoginComponent } from './User/login/login.component';
import { ProductsComponent } from './User/products/products.component';
import { PurchseComponent } from './User/purchse/purchse.component';
import { UserDashboardComponent } from './User/user-dashboard/user-dashboard.component';
import { UserNavbarComponent } from './User/user-navbar/user-navbar.component';
import { UserStocktobuyComponent } from './User/user-stocktobuy/user-stocktobuy.component';

import { UsersignupComponent } from './User/usersignup/usersignup.component';

const routes: Routes = [{
  path:'' , component:UsersignupComponent
},
{
  path:'loginUser', component:LoginComponent
},
{
  path:'userdashboard', component:UserDashboardComponent
},
{
  path:'usernavbar' , component:UserNavbarComponent
},

{
  path:'adminLogin', component:AdminLoginComponent
},
{
  path:'adminSignup', component:AdminSignupComponent
},
{
  path:'adminDashboard',component:AdminDashboardComponent
},
{
  path:'adminNavbar',component:AdminNavbarComponent
},
{
  path:'stocksview',component:StockViewComponent
},
{
  path:'stockedit',component:StockEditComponent
},
{
 path:'availableStocks' , component: UserStocktobuyComponent
},
{
  path:'purchases', component:PurchseComponent
},
{
  path:'products' , component:ProductsComponent
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
