import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PackageService } from '../../travelAway-services/package-service/package.service';
import { IViewBookings } from '../travelAway-interfaces/ViewBookings';

@Component({
  selector: 'app-view-bookings',
  templateUrl: './view-bookings.component.html',
  styleUrls: ['./view-bookings.component.css']
})
export class ViewBookingsComponent implements OnInit {
  userRole: string;
  bookings: any[];
  userName: string;
   errorMsg: any;
   rawbookings: any[];
  constructor(private packageService: PackageService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRole = sessionStorage.getItem('userRole');
    this.userName = sessionStorage.getItem('userName');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    }
    this.getBookings();
  }

  getBookings() {
    this.packageService.getBookings(this.userName).subscribe(
      responseTotalStatus => {
        this.rawbookings = responseTotalStatus;

        for (let booking of this.rawbookings) {
          if (booking['hotelName'] == 'N/A') {
            booking['noOfRooms'] =0;
          }
          if (booking['totalAmount']<0) {
            booking['totalAmount'] = 0;
          
          }
          booking['dateOfTravel'] = booking['dateOfTravel'].substring(0, 10);
        }
        this.bookings = this.rawbookings;
      },
      responseTotalError => {
        this.errorMsg = responseTotalError;
      },
      () => console.log("ViewBookings method executed successfully")
    );

  }

  gocustcare(bookingid: string) {
    if (sessionStorage.getItem('bookingId')) {
      sessionStorage.removeItem('bookingId');
    } 
    sessionStorage.setItem('bookingId', bookingid);
    this.router.navigate(['/custcare']);
  }

  gohotelbook(bookingid: string) {
    if (sessionStorage.getItem('bookingId')) {
      sessionStorage.removeItem('bookingId');
    } 
    sessionStorage.setItem('bookingId', bookingid);
    this.router.navigate(['/accommodation']);
  }
  gopayment(bookingid: string) {
    if (sessionStorage.getItem('bookingId')) {
      sessionStorage.removeItem('bookingId');
    } 
      sessionStorage.setItem('bookingId', bookingid);

    this.router.navigate(['/payment']);
  }
}
