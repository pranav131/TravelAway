import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { UserService } from "../../travelAway-services/user-service/user.service";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  status: number;
  errorMsg: string;
  msg: string;
  showDiv: boolean = false;
  name: string;
  loginRole: number;
  rolename: string;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {
    this.loginRole = parseInt(this.route.snapshot.params['loginRole']);
    if (this.loginRole == 1) this.rolename = "Customer";
    else if (this.loginRole == 2) this.rolename = "Employee";
  }

  ngOnInit(): void {
  
  }
  submitLoginForm(form: NgForm) {
    console.log(form.value.email, form.value.password);
    this.userService.validateCredentials(form.value.email, form.value.password, this.loginRole).subscribe(
    
      responseLoginStatus => {
        this.status = responseLoginStatus;
        this.showDiv = true;
        if (this.status==1) {
          this.msg = "Login Successful";
          sessionStorage.setItem('userName', form.value.email);
          sessionStorage.setItem('userRole', "Customer");
          this.router.navigate(['/home']);
        }
        else if (this.status == 2) {
          this.msg = "Login Successful";
          sessionStorage.setItem('userName', form.value.email);
          sessionStorage.setItem('userRole', "Employee");
          this.router.navigate(['/home']);
        }
        else {
          this.msg = "Try again with valid credentials.";
        }
      },
      responseLoginError => {
        this.errorMsg = responseLoginError;
      },
      () => console.log("SubmitLoginForm method executed successfully")
    );
  }
}
