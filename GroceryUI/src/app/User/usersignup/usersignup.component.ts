import { Component, OnInit } from '@angular/core';

import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserserviceService } from 'src/app/shared/userservice.service';
@Component({
  selector: 'app-usersignup',
  templateUrl: './usersignup.component.html',
  styleUrls: ['./usersignup.component.css']
})
export class UsersignupComponent implements OnInit {

  constructor(public userService:UserserviceService, public toast:ToastrService,private router : Router) { }

  ngOnInit(): void {
  }
  submit(form:NgForm)
  {
      this.insertEmployee(form);
  }
  insertEmployee(myform:NgForm)
  {  this.userService.saveUser().subscribe(d=> {
     this.toast.success('Sucess','Record Saved');
    });
  }
  LoginUser()
  {
      this.router.navigate(['/loginUser']);
  }
  Admins(){
    this.router.navigate(['/adminSignup']);
  }

}
