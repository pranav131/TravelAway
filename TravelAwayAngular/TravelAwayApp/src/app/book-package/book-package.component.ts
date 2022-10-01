import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PackageService } from '../../travelAway-services/package-service/package.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IBookPackage } from '../travelAway-interfaces/BookPackage';

@Component({
  selector: 'app-book-package',
  templateUrl: './book-package.component.html',
  styleUrls: ['./book-package.component.css']
})
export class BookPackageComponent implements OnInit {
  bookingId: number;
  packageId: number;
  errorMsg: string;
  userRole: string;
  constructor(private packageService: PackageService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.packageId = parseInt(this.route.snapshot.params['packageId']);
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    }
  }

  submitBookForm(form: NgForm) {
    var email = sessionStorage.getItem("userName");

    var bookpkg: IBookPackage = {
      contactNumber: parseInt(form.value.contactNumber), emailId: email, address: form.value.address, dateOfTravel: new Date(form.value.dateOfTravel), numberOfAdults: parseInt(form.value.adults),
      numberOfChildren: parseInt(form.value.children), status: "Booked", packageId: this.packageId
    }
    console.log(bookpkg);
    this.packageService.bookPackage(bookpkg).subscribe(
        responseRegisterStatus => {
        this.bookingId = responseRegisterStatus;
        if (this.bookingId > 0) {
          sessionStorage.setItem('bookingId', this.bookingId.toString());
          if (confirm("Booking Done successfully.Do you want to continue to book accommodation?")) {
            this.router.navigate(['/accommodation']);
          } else {
            this.router.navigate(['/viewbookings']);
          }
        } else {
          console.log("Not added");
        }  
        },
        responseRegisterError => {
          this.errorMsg = responseRegisterError;
        },
        () => console.log("BookingPackage method executed successfully")
    );

  }
}
