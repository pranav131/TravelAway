import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ViewPackagesComponent } from './view-packages/view-packages.component';
import { ViewPackageDetailsComponent } from './view-package-details/view-package-details.component';
import { HomeComponent } from './home/home.component';
import { UserService } from '../travelAway-services/user-service/user.service';
import { PackageService } from '../travelAway-services/package-service/package.service';
import { HttpClientModule } from '@angular/common/http';
import { routing } from './app.routing';
import { CommonLayoutComponent } from './layouts/common-layout/common-layout.component';
import { UserLayoutComponent } from './layouts/user-layout/user-layout.component';
import { EmployeeLayoutComponent } from './layouts/employee-layout/employee-layout.component';
import { EditDetailsComponent } from './edit-details/edit-details.component';
import { CustomerCareComponent } from './customer-care/customer-care.component';
import { BookPackageComponent } from './book-package/book-package.component';
import { AccommodationComponent } from './accommodation/accommodation.component';
import { PaymentComponent } from './payment/payment.component';
import { AddVehicleComponent } from './add-vehicle/add-vehicle.component';
import { AddHotelComponent } from './add-hotel/add-hotel.component';
import { ViewBookingsComponent } from './view-bookings/view-bookings.component';
import { ViewHotelsComponent } from './view-hotels/view-hotels.component';
import { ViewVehiclesComponent } from './view-vehicles/view-vehicles.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ViewPackagesComponent,
    ViewPackageDetailsComponent,
    HomeComponent,
    CommonLayoutComponent,
    UserLayoutComponent,
    EmployeeLayoutComponent,
    EditDetailsComponent,
    CustomerCareComponent,
    BookPackageComponent,
    AccommodationComponent,
    PaymentComponent,
    AddVehicleComponent,
    AddHotelComponent,
    ViewBookingsComponent,
    ViewHotelsComponent,
    ViewVehiclesComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule, ReactiveFormsModule,routing
  ],
  providers: [PackageService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
