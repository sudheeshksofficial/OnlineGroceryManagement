import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserserviceService } from 'src/app/shared/userservice.service';
import { FormGroup,FormControl,Validators} from '@angular/forms';
@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {

  constructor(public toast:ToastrService,private router : Router,private userservice : UserserviceService) { }

  ngOnInit(): void {
  }
  loginForm = new FormGroup({
    adminmail: new FormControl('',[Validators.required,Validators.email]),
    password:new FormControl('',[
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(15),
    ]),
   });
   
   isUserValid : boolean = false;
   loginSubmitted(){
    this.userservice.loginUser([this.loginForm.value.adminmail,this.loginForm.value.password]).subscribe(res =>{
      if(res =='Failure'){
        this.isUserValid = false;
        alert('Login Unsuccessful');
        this.router.navigate(['']);
        this.toast.info('Please sign up to login');
      }else{
        this.isUserValid = true;
        alert(this.loginForm.value.adminmail+'  Login Successfull');
        this.router.navigate(['adminDashboard']);
        this.toast.success('Logged in successfully');
      }
    });
   //  console.log(this.loginForm);
  }
  
   get adminmail() : FormControl{
     return this.loginForm.get('adminmail') as FormControl;
   }
   get password() : FormControl{
     return this.loginForm.get('password') as FormControl;
   }
}
