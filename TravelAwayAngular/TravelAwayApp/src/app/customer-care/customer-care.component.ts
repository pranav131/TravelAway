import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../travelAway-services/user-service/user.service';
import { IcustCare } from '../travelAway-interfaces/CustomerCare';
@Component({
  selector: 'app-customer-care',
  templateUrl: './customer-care.component.html',
  styleUrls: ['./customer-care.component.css']
})
export class CustomerCareComponent implements OnInit {
  userRole: string;
  showDiv: boolean = false;
  msg: string;
  status: boolean;
  bookingId: number;
  assignee: number;
  errorMsg: string;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    }
    this.bookingId = parseInt(sessionStorage.getItem('bookingId'));
    this.getAssignee();
  }
  submitCompForm(form: NgForm) {

    var query: IcustCare = {
      bookingId: this.bookingId,
      query: form.value.query,
      queryStatus: "Assigned",
      assignee: this.assignee
    }
    console.log(query);
    this.userService.custCare(query).subscribe(
      responsecustCareStatus => {
        this.status = responsecustCareStatus;
        if (this.status) {
          this.showDiv = true;
          this.msg = "We will answer you soon";
        } else {
          this.msg = "Some error occured. Query not sent";
        }
      },
      responseHotelError => {
        this.errorMsg = responseHotelError;
      },
      () => console.log("CustomerCare method executed successfully")
    );
  }

  getAssignee() {
    this.userService.getassignee().subscribe(
      responseassignee => {
        this.assignee = responseassignee;
       // console.log(this.assignee, typeof (this.assignee));
      },
      responseassigneeError => {
        this.assignee = null;
      },
      () => console.log("GetAssignee method executed successfully")
    );
  }
}
