import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IVehicle } from '../travelAway-interfaces/Vehicle';
import { UserService } from '../../travelAway-services/user-service/user.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {
  msg: string;
  status: boolean;
  showDiv: boolean;
  errorMsg: any;
  userRole: string;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRole = sessionStorage.getItem('userRole');
    if (this.userRole != "Employee") {
      this.router.navigate(['/login/2']);
    }
  }
  submitvehicleForm(form: NgForm) {
    var vehicle: IVehicle = {
      vehicleName: form.value.vehicleName,
      vehicleType: form.value.vehicleType,
      ratePerHour: parseInt(form.value.rateperhr),
      ratePerKm: parseInt(form.value.rateperkm),
      basePrice: parseInt(form.value.basePrice)
    }
    this.userService.addVehicle(vehicle).subscribe(
      responseHotelStatus => {
        this.status = responseHotelStatus;
        this.showDiv = true;
        if (this.status) {
          this.msg = "Vehicle added successfully";
        } else {
          this.msg = "Vehicle not added";
        }
      },
      responseHotelError => {
        this.errorMsg = responseHotelError;
      },
      () => console.log("AddVehicle method executed successfully")
    );
  }
}
