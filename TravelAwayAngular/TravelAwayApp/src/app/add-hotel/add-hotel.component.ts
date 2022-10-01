import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IHotel } from '../travelAway-interfaces/Hotel';
import { PackageService } from '../../travelAway-services/package-service/package.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../../travelAway-services/user-service/user.service';

@Component({
  selector: 'app-add-hotel',
  templateUrl: './add-hotel.component.html',
  styleUrls: ['./add-hotel.component.css']
})
export class AddHotelComponent implements OnInit {
  status: boolean;
  showDiv: boolean;
  errorMsg: string;
  msg: string;
  userRole: string;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Employee") {
      this.router.navigate(['/login/2']);
    }
  }
  submithotelForm(form: NgForm) {

    var hotel: IHotel = {
      hotelName: form.value.hotelname,
      hotelRating: parseInt(form.value.hotelType),
      singleRoomPrice: parseInt(form.value.singleprice),
      doubleRoomPrice: parseInt(form.value.doubleprice),
      deluxeeRoomPrice: parseInt(form.value.deluxeprice),
      suiteRoomPrice: parseInt(form.value.suiteprice),
      city: form.value.city
    }
    console.log(hotel);
    this.userService.addHotel(hotel).subscribe(
      responseHotelStatus => {
        this.status = responseHotelStatus;
        this.showDiv = true;
        if (this.status) {
          this.msg = "Hotel added successfully";
        } else {
          this.msg = "Hotel not added";
        }
      },
      responseHotelError => {
        this.errorMsg = responseHotelError;
      },
      () => console.log("AddHotel method executed successfully")
    );

  }
}
