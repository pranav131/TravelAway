import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { IPackage } from 'src/app/travelAway-interfaces/Package';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IEmployee } from '../../app/travelAway-interfaces/Employee';
import { ICustomer } from '../../app/travelAway-interfaces/Customer';
import { IHotel } from '../../app/travelAway-interfaces/Hotel';
import { IVehicle } from '../../app/travelAway-interfaces/Vehicle';
import { IcustCare } from '../../app/travelAway-interfaces/CustomerCare';
import { IAccommodation } from '../../app/travelAway-interfaces/Accommodation';
import { IPayment } from '../../app/travelAway-interfaces/Payment';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) {
  
  }
  //for login
  validateCredentials(email: string, password: string,loginRole: number): Observable<number> {
    let temp;
    if (loginRole == 1) {
      var custObj: ICustomer;
     // custObj = { EmailId: email, UserPassword: password, FirstName:null,LastName:null,RoleId: null,Gender:null,DateOfBirth: null, Address: null,ContactNumber:null};
      temp = this.http.post<number>('https://localhost:44393/api/TravelAway/ValidateLoginCustomer', { EmailId: email, UserPassword: password}).pipe(catchError(this.errorHandler))
    } else if (loginRole == 2) {
      var EmpObj: IEmployee;
      EmpObj = { EmailId: email, Password: password, FirstName: null, LastName: null, RoleId:null};
      temp = this.http.post<number>('https://localhost:44393/api/TravelAway/ValidateLoginEmployee',EmpObj).pipe(catchError(this.errorHandler))

    }
    return temp;
  }
  //for register
  addUserDetails(firstName: string, lastName: string, emailId: string,
    password: string, contactNumber: number, address: string, gender: string, dateOfBirth: Date, roleId: number): Observable<number> {
    var custObj: ICustomer;
    custObj = { EmailId: emailId, UserPassword: password, FirstName: firstName, LastName: lastName, RoleId: roleId, Gender: gender, DateOfBirth: dateOfBirth, Address: address, ContactNumber: contactNumber };
    let temp = this.http.post<number>('https://localhost:44393/api/TravelAway/AddCustomer', custObj).pipe(catchError(this.errorHandler));
    return temp;
  }

  updateUserDetails(firstName: string, lastName: string, emailId: string,
    password: string, contactNumber: number, address: string, gender: string, dateOfBirth: Date, roleId: number): Observable<boolean> {
    var custObj: ICustomer;
    custObj = { EmailId: emailId, UserPassword: password, FirstName: firstName, LastName: lastName, RoleId: roleId, Gender: gender, DateOfBirth: dateOfBirth, Address: address, ContactNumber: contactNumber };
    let temp = this.http.put<boolean>('https://localhost:44393/api/TravelAway/UpdateProfile', custObj).pipe(catchError(this.errorHandler));
    return temp;
  }

  getCustomerById(emailId: string): Observable<ICustomer> {
    let CustId = { emailId: emailId };
    let temp = this.http.get<ICustomer>('https://localhost:44393/api/TravelAway/GetCustomerDetails', { params: CustId }).pipe(catchError(this.errorHandler));
    return temp;
  }

  addHotel(hotel: IHotel): Observable<boolean> {
    let temp = this.http.post<boolean>('https://localhost:44393/api/TravelAway/AddHotel', hotel).pipe(catchError(this.errorHandler));
    return temp;
  }

  addVehicle(vehicle: IVehicle): Observable<boolean> {
    let temp = this.http.post<boolean>('https://localhost:44393/api/TravelAway/AddVehicle', vehicle).pipe(catchError(this.errorHandler));
    return temp;
  }

  custCare(query: IcustCare): Observable<boolean> {
    let temp = this.http.post<boolean>('https://localhost:44393/api/TravelAway/AddCustomerCare', query).pipe(catchError(this.errorHandler));
    return temp;
  }

  getassignee(): Observable<number> {
    let temp = this.http.get<number>('https://localhost:44393/api/TravelAway/GetAssignee').pipe(catchError(this.errorHandler));
    return temp;
  }
  getTotal(bookingId: string): Observable<number> {
    let BookId = { bookingId: bookingId };
    let temp = this.http.get<number>('https://localhost:44393/api/TravelAway/GetTotal', { params: BookId }).pipe(catchError(this.errorHandler));
    return temp;
  }

  getCitiesByBookId(bookingId: string): Observable<string> {
    let BookId = { bookingId: bookingId };
    let temp = this.http.get<string>('https://localhost:44393/api/TravelAway/GetCityByPackageDetailsId', { params: BookId }).pipe(catchError(this.errorHandler));
    return temp;
  }

  getHotelRatingByCity(city: string): Observable<number[]> {
    let City = { city: city };
    let temp = this.http.get<number[]>('https://localhost:44393/api/TravelAway/GetHotelRatingsByCity', { params: City }).pipe(catchError(this.errorHandler));
    return temp;
  }

  getHotelsByCityAndRating(city: string, rating: string): Observable<string[]> {
  // let CityandRating = { city: city,rating: rating};
    //let params = new HttpParams().set('city', city).set('rating', rating);
    //console.log("mayank",params);
    let address: string = 'https://localhost:44393/api/TravelAway/GetHotelsByCityAndRating?city=' + city + '&rating=' + rating;
    let temp = this.http.get<string[]>(address).pipe(catchError(this.errorHandler));
    return temp;
  }

  getCost(hotelName: string, roomtype: string): Observable<number> {
 
    let address: string = 'https://localhost:44393/api/TravelAway/GetHotelCost?hotelName=' + hotelName + '&roomtype=' + roomtype;
    let temp = this.http.get<number>(address).pipe(catchError(this.errorHandler));
    return temp;
  }

  bookAccommodation(accommodation: IAccommodation): Observable<boolean> {
    let temp = this.http.post<boolean>('https://localhost:44393/api/TravelAway/AddAccomodationDetails', accommodation).pipe(catchError(this.errorHandler));
    return temp;
  }


  makePayment(pay:IPayment): Observable<boolean> {
    let temp = this.http.post<boolean>('https://localhost:44393/api/TravelAway/Payment', pay).pipe(catchError(this.errorHandler));
    return temp;
  }

    errorHandler(error: HttpErrorResponse) {
      console.error(error);
      return throwError(error.message || "Server Error");
    }
  }
