import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ViewPackagesComponent } from './view-packages/view-packages.component';
import { ViewPackageDetailsComponent } from './view-package-details/view-package-details.component';
import { EditDetailsComponent } from './edit-details/edit-details.component';
import { CustomerCareComponent } from './customer-care/customer-care.component';
import { BookPackageComponent } from './book-package/book-package.component';
import { PaymentComponent } from './payment/payment.component';
import { AddVehicleComponent } from './add-vehicle/add-vehicle.component';
import { AddHotelComponent } from './add-hotel/add-hotel.component';
import { AccommodationComponent } from './accommodation/accommodation.component';
import { ViewBookingsComponent } from './view-bookings/view-bookings.component';
import { ViewHotelsComponent } from './view-hotels/view-hotels.component';
import { ViewVehiclesComponent } from './view-vehicles/view-vehicles.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'viewPackages', component: ViewPackagesComponent },
  { path: 'login/:loginRole', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'viewPackageDetails/:packageId/:packageName', component: ViewPackageDetailsComponent },
  { path: 'viewPackageDetails/:packageId/:packageName', component: ViewPackageDetailsComponent },
  { path: 'editDetails', component: EditDetailsComponent },
  { path: 'custcare', component: CustomerCareComponent },
  { path: 'bookpkg/:packageId', component: BookPackageComponent },
  { path: 'payment', component: PaymentComponent },
  { path: 'addvehicle', component: AddVehicleComponent },
  { path: 'addhotel', component: AddHotelComponent },
  { path: 'accommodation', component: AccommodationComponent },
  { path: 'viewbookings', component: ViewBookingsComponent },
  { path: 'viewhotels', component: ViewHotelsComponent },
  { path: 'viewvehicles', component: ViewVehiclesComponent },
  { path: '**', component: HomeComponent }
];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
