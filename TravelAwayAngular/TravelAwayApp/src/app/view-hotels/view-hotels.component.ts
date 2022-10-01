import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PackageService } from '../../travelAway-services/package-service/package.service';

@Component({
  selector: 'app-view-hotels',
  templateUrl: './view-hotels.component.html',
  styleUrls: ['./view-hotels.component.css']
})
export class ViewHotelsComponent implements OnInit {
  userRole: string;
    errorMsg: any;
  hotels: any[];
  constructor(private packageService: PackageService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Employee") {
      this.router.navigate(['/login/2']);
    }
    this.getHotels();
  }
  getHotels() {
    this.packageService.getHotels().subscribe(
      responseHotelStatus => {
        this.hotels = responseHotelStatus;
      },
      responseHotelError => {
        this.errorMsg = responseHotelError;
      },
      () => console.log("ViewHotels method executed successfully")
    );
  }

}
