import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Admin } from './models/admin.model';
import { User } from './models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserserviceService {

  constructor(private myhttp:HttpClient) { }
  userUrl : string = 'https://localhost:44324/api/UserModel/';
  listUser:User[]=[]; //For Getting Data userlist
  userData:User = new User(); //for post data / Insert data
  adminUrl : string = 'https://localhost:44324/api/AdminUser/';
  listAdmin:Admin[]=[]; //For Getting Data userlist
  adminData:Admin = new Admin(); //for post data / Insert data
  //https://localhost:44324/api/AdminUser/register
  //https://localhost:44324/api/Stock
  saveUser(){
    return this.myhttp.post(this.userUrl+'register',this.userData);
  }
  // logincheck() : Observable<User[]>{
  //  return this.myhttp.post<User[]>(this.userUrl+'/api/UserModel/login',this.userData);
  // }
  loginUser(loginInfo:Array<any>){
    return this.myhttp.post(this.userUrl+'LoginUser',
    {
      UserMail:loginInfo[0],
      Password :loginInfo[1],
    },
   {
     responseType:'text',
   }
    );
  }
  signAdmin(){
    return this.myhttp.post(this.adminUrl+'register',this.adminData);
  }
  loginAdmin(loginInfo:Array<any>){
    return this.myhttp.post(this.adminUrl+'LoginUser',
    {
      AdminMail:loginInfo[0],
      Password :loginInfo[1],
    },
   {
     responseType:'text',
   }
    );
  }

}
