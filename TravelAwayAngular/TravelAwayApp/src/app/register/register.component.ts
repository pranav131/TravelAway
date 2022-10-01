import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from "../../travelAway-services/user-service/user.service";
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  msg: string;
  showDiv: boolean;
  errorMsg: string;
  status:number;
  constructor(private userService: UserService,private formBuilder: FormBuilder, private router: Router) {
    //this.registerForm = this.formBuilder.group({
    //  firstName: ['', [Validators.required, Validators.pattern("[a-zA-z]{1,}")]],
    //  lastName: ['', [Validators.required, Validators.pattern("[a-zA-z]{1,}")]],
    //  emailId: ['', [Validators.required, Validators.pattern("^[a-zA-z0-9+_.-]+@[a-zA-z0-9+_.-]+$")]],
    //  gender: ['', Validators.required],
    //  password: ['', [Validators.required,Validators.maxLength(16)]],
    //  confirmpassword: ['', Validators.required, Validators.minLength(8), Validators.maxLength(16)],
    //  dateOfbirth: ['', [Validators.required, checkDate]],
    //  address: ['', Validators.required],
    //  contactNumber: ['', [Validators.required, Validators.maxLength(10), Validators.pattern("[1-9]{1}[0-9]{9}")]]
    //});

  }

  ngOnInit(): void {
  }
  SubmitForm(form: NgForm) {
    var email = form.value.emailId;
    this.userService.addUserDetails(form.value.firstName, form.value.lastName, form.value.emailId,
      form.value.password, parseInt(form.value.contactNumber), form.value.address, form.value.gender, new Date("1999-08-23"),1).subscribe(
      responseRegisterStatus => {
        this.status = responseRegisterStatus;
        this.showDiv = true;
        if (this.status==1) {
          this.msg = "Registered Successfully";
          sessionStorage.setItem('userName', email);
          sessionStorage.setItem('userRole', "Customer");
          this.router.navigate(['/home']);
        } else {
          this.msg = "Not able to register";
        }
      },
      responseRegisterError => {
        this.errorMsg = responseRegisterError;
      },
      () => console.log("SubmitLoginForm method executed successfully")
    );
  }
}
function checkDate(control: FormControl) {
  var currentDate = new Date();
  var givenDate = new Date(control.value)
  console.log(currentDate);
  console.log(givenDate);
  if (givenDate <= currentDate || givenDate == null) {
    return null
  }
  else {
    return {
      dateError: {
        message: "Enter a date less than today's date"
      }
    };
  }
}
