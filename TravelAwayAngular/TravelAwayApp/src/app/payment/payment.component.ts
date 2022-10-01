import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../../travelAway-services/user-service/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IPayment } from '../travelAway-interfaces/Payment';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  cost: string;
  userRole: string;
  bookingId: string;
    status: boolean;
    showDiv: boolean;
    msg: string;
  errorMsg: any;
  total: number;
  constructor(private userService: UserService,private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.bookingId = sessionStorage.getItem('bookingId');
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    }
    this.getTotal(this.bookingId);
  }

  //filldefaultfields(id: number, cost: string) {
  //  this.bookingId = id;
  //  this.cost = cost;
  //}

  getTotal(bookingid:string) {
    this.userService.getTotal(bookingid).subscribe(
      responseTotalStatus => {
        this.total = responseTotalStatus;
       
      },
      responseTotalError => {
        this.errorMsg = responseTotalError;
      },
      () => console.log("GetTotal method executed successfully")
    );
  }
  submitpayForm(form: NgForm) {

    var pay: IPayment = {
      bookingId: parseInt(form.value.bookid),
      paymentStatus: "Confirmed",
      totalAmount: parseInt(form.value.amount),
    
    }
    this.userService.makePayment(pay).subscribe(
      responseHotelStatus => {
        this.status = responseHotelStatus;
        this.showDiv = true;
        if (this.status) {
          alert("Payment Done successfully");
          sessionStorage.removeItem('bookingId');
          this.router.navigate(['/']);
        } else {
          this.msg = "Payment not done.Try Again";
        }
      },
      responseHotelError => {
        this.errorMsg = responseHotelError;
      },
      () => console.log("AddVehicle method executed successfully")
    );


  }
}
