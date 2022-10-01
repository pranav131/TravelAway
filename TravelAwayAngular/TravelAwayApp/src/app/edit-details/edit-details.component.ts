import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../travelAway-services/user-service/user.service';
import { NgForm } from '@angular/forms';
import { ICustomer } from '../travelAway-interfaces/Customer';
@Component({
  selector: 'app-edit-details',
  templateUrl: './edit-details.component.html',
  styleUrls: ['./edit-details.component.css']
})
export class EditDetailsComponent implements OnInit {
  msg: string;
  emailId: string;
  errorMsg: any;
  status: boolean;
  firstName: string;
  lastName: string;
  contact: number;
  dob: Date;
  Address: string;
  userRole: string;
  gender: string;
  customer: ICustomer;
  showDiv: boolean = true;
  customerLayout: boolean = false;
  commonLayout: boolean = false;
  constructor(private router: Router, private userService: UserService, private ac: ActivatedRoute) {
    this.emailId = sessionStorage.getItem("userName");
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    } else if (this.userRole == "Customer") {
      this.customerLayout = true;
    }
  }

  ngOnInit(): void {
  
    this.getCustomerDetails(this.emailId);

  }

  getCustomerDetails(emailId: string) {
    this.userService.getCustomerById(emailId).subscribe(
        responseRegisterStatus => {
        this.customer = responseRegisterStatus;
        this.firstName = this.customer['firstName'];
        this.lastName = this.customer['lastName'];
        this.gender = this.customer['gender'];
        this.Address = this.customer['address'];
        this.contact = this.customer['contactNumber'];
        this.dob = this.customer['dateOfBirth'].substring(0,10);
        console.log(this.firstName,this.lastName);
        },
        responseRegisterError => {
          this.errorMsg = responseRegisterError;
        },
        () => console.log("cutomer details method executed successfully")
      );
  }

  SubmitForm(form: NgForm) {
    this.userService.updateUserDetails(form.value.firstName, form.value.lastName, this.emailId,
      null, parseInt(form.value.contactNumber), form.value.address, form.value.gender, new Date(form.value.dateOfBirth), 1).subscribe(
        responseUpdateStatus => {
          this.status = responseUpdateStatus;
          this.showDiv = true;
          if (this.status == true) {
            this.msg = "Updation Successfully";
            

          } else {
            this.msg = "Not able to update";
          }
        },
        responseUpdateError => {
          this.errorMsg = responseUpdateError;
        },
        () => console.log("Updated method executed successfully")
      );
  }

}

