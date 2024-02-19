import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './User/login/login.component';
import { UsersignupComponent } from './User/usersignup/usersignup.component';
import { UserDashboardComponent } from './User/user-dashboard/user-dashboard.component';
import { UserNavbarComponent } from './User/user-navbar/user-navbar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserserviceService } from './shared/userservice.service';
import { AdminLoginComponent } from './Admin/admin-login/admin-login.component';
import {MatIconModule} from '@angular/material/icon';
import { AdminSignupComponent } from './Admin/admin-signup/admin-signup.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminNavbarComponent } from './Admin/admin-navbar/admin-navbar.component';
import { StockViewComponent } from './Admin/stock-view/stock-view.component';
import { StockEditComponent } from './Admin/stock-view/stock-edit/stock-edit.component';
import { UserStocktobuyComponent } from './User/user-stocktobuy/user-stocktobuy.component';
import { PurchseComponent } from './User/purchse/purchse.component';
import { PurchaseEditComponent } from './User/purchse/purchase-edit/purchase-edit.component';
import { ProductsComponent } from './User/products/products.component';







@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsersignupComponent,
    UserDashboardComponent,
    UserNavbarComponent,
    AdminLoginComponent,
    AdminSignupComponent,
    AdminDashboardComponent,
    AdminNavbarComponent,
    StockViewComponent,
    StockEditComponent,
    UserStocktobuyComponent,
    PurchseComponent,
    PurchaseEditComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,FormsModule,MatIconModule,ReactiveFormsModule,ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
