import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserserviceService } from 'src/app/shared/userservice.service';
@Component({
  selector: 'app-admin-signup',
  templateUrl: './admin-signup.component.html',
  styleUrls: ['./admin-signup.component.css']
})
export class AdminSignupComponent implements OnInit {

  constructor(public userService:UserserviceService, public toast:ToastrService,private router : Router) { }

  ngOnInit(): void {
  }
  submit(form:NgForm)
  {
      this.insertAdmin(form);
  }
  insertAdmin(myform:NgForm)
  {  this.userService.signAdmin().subscribe(d=> {
     this.toast.success('Sucess','Record Saved');
    });
  }
  LoginAdmin()
  {
      this.router.navigate(['/adminLogin']);
  }
  Users(){
    this.router.navigate(['']);
  }
}
