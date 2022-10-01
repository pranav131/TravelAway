import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../travelAway-services/user-service/user.service';
import { IAccommodation } from '../travelAway-interfaces/Accommodation';

@Component({
  selector: 'app-accommodation',
  templateUrl: './accommodation.component.html',
  styleUrls: ['./accommodation.component.css']
})
export class AccommodationComponent implements OnInit {
  bookingId: string;
  userRole: string;
  errorMsg: any;
  status: boolean;
  showDiv: boolean = false;
  msg: string;
  cities: string[];
  ratings: number[];
  hotels: string[];
  rawcities: string;
  cost: number;
  rooms: number;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.bookingId = sessionStorage.getItem('bookingId');
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Customer") {
      this.router.navigate(['/login/1']);
    }
    this.getCitiesByBookingId(this.bookingId);
  }

  getCitiesByBookingId(bookingId:string) {
    this.userService.getCitiesByBookId(bookingId).subscribe(
      responseCitiesStatus => {
        this.rawcities = responseCitiesStatus;
        this.cities = this.rawcities.split(",");
      },
      responseCitiesError => {
        this.errorMsg = responseCitiesError;
      },
      () => console.log("GetCity method executed successfully")
    );
    
  }

  searchrating(city: string) {
    this.userService.getHotelRatingByCity(city).subscribe(
      responseCitiesStatus => {
        this.ratings = responseCitiesStatus;
        
      },
      responseCitiesError => {
        this.errorMsg = responseCitiesError;
      },
      () => console.log("HotelRating method executed successfully")
    );
  }

  searchhotel(rating: string, city: string) {

    this.userService.getHotelsByCityAndRating(city,rating).subscribe(
      responseCitiesStatus => {
       this.hotels = responseCitiesStatus;
        
      },
      responseCitiesError => {
        this.errorMsg = responseCitiesError;
      },
      () => console.log("SearchHotel method executed successfully")
    );
  }

  getCost(hotelName: string, roomtype: string) {

    this.userService.getCost(hotelName, roomtype).subscribe(
      responseCitiesStatus => {
        this.cost = responseCitiesStatus*this.rooms;
        //console.log("Cost:", this.cost * this.rooms);
      },
      responseCitiesError => {
        this.errorMsg = responseCitiesError;
      },
      () => console.log("Cost method executed successfully")
    );

  }
  submitaccodForm(form: NgForm) {
    var accommodation: IAccommodation = {
      bookingId: parseInt(form.value.bookingid),
      hotelName: form.value.hotelName,
      city: form.value.city,
      noOfRooms: parseInt(form.value.rooms),
      hotelRating: parseInt(form.value.rating),
      price: parseInt(form.value.estimatedcost),
      roomType: form.value.roomtype
    }

    this.userService.bookAccommodation(accommodation).subscribe(
      responseAccommodationStatus => {
        this.status = responseAccommodationStatus;
        if (this.status) {
          if (confirm("Accommodation details added successfully.Do you want to continue for payment?")) {
            this.router.navigate(['/payment']);
          } else {
            this.router.navigate(['/viewbookings']);
          }
        } else {
          this.showDiv = true;
          this.msg = "Accommodation details not added.Try Again";
        }
      },
      responseAccommodationError => {
        this.errorMsg = responseAccommodationError;
      },
      () => console.log("Book Accommodation method executed successfully")
    );
  }
}
