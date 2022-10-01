using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infosys.TravelAway.BL;
using Infosys.TravelAway.DAL.Models;

namespace Infosys.TravelAway.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelAwayController : Controller
    {
        AdminBL adminBL;
        public TravelAwayController()
        {
            adminBL = new AdminBL();
        }
        #region - READ
        // API to validate a user
        // Returns user role
        //         1 represents Customer
        //         2 represents Employee
        //         0 represents Invalid
        //        -99 represents Exception
        [HttpPost]
        public int ValidateLoginCustomer(Customer cust)
        {
            int role;
            string emailId = cust.EmailId;
            string password = cust.UserPassword;
            try
            {
                role = adminBL.ValidateLoginCustomer(emailId, password);
            }
            catch (Exception)
            {
                role = -99;
            }
            return role;
        }

        [HttpPost]
        public JsonResult ValidateLoginEmployee(Employee emp)
        {
            int role;
          
            try
            {
                role = adminBL.ValidateLoginEmployee(emp.EmailId, emp.Password);
            }
            catch (Exception)
            {
                role = -99;
            }
            return Json(role);
        }

        // API to get a list of all packages
        [HttpGet]
        public JsonResult GetPackages()
        {
            List<Package> packageList;
            try
            {
                packageList = adminBL.GetPackages();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                packageList = null;
            }
            return Json(packageList);
        }

        [HttpGet]
        public JsonResult GetCustomerDetails(string emailId)
        {
            Customer customer;
            try
            {
                customer = adminBL.GetCustomerDetails(emailId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                customer = null;
            }
            return Json(customer);
        }

        // API to get a list of all package categories
        [HttpGet]
        public JsonResult GetPackageCategories()
        {
            List<PackageCategory> packageCategoriesList;
            try
            {
                packageCategoriesList = adminBL.GetPackageCategories();
            }
            catch (Exception)
            {
                packageCategoriesList = null;
            }
            return Json(packageCategoriesList);
        }

        // API to get a list of package filtered by categoryId
        [HttpGet]
        public JsonResult GetPackagesByCategoryId(int categoryId)
        {
            List<Package> packageList;
            try
            {
                packageList = adminBL.GetPackagesByCategoryId(categoryId);
            }
            catch (Exception)
            {
                packageList = null;
            }
            return Json(packageList);
        }

        // API to get package details for given packageId
        [HttpGet]
        public JsonResult GetPackageDetailsByPackageId(string packageId)
        {
            List<PackageDetails> packageDetails;
            try
            {
                int Id = Convert.ToInt32(packageId);
                packageDetails = adminBL.GetPackageDetailsByPackageId(Id);
            }
            catch (Exception)
            {
                packageDetails = null;
            }
            return Json(packageDetails);
        }

        // API to get details of user given emailId
        [HttpGet]
        public JsonResult GetCustomerByEmail(string emailId)
        {
            Customer cust;
            try
            {
                cust = adminBL.GetCustomerByEmail(emailId);
            }
            catch (Exception)
            {
                cust = null;
            }
            return Json(cust);
        }

        // API to get accommodation details given bookingId
        [HttpGet]
        public JsonResult GetAccomodationByBookingId(string bookingId)
        {
            Accomodation accObj;
            try
            {
                int Id = Convert.ToInt32(bookingId);
                accObj = adminBL.GetAccomodationByBookingId(Id);
            }
            catch (Exception)
            {
                accObj = null;
            }
            return Json(accObj);
        }

        // API to get a random employeeId
        [HttpGet]
        public int GetAssignee()
        {
            int empId;
            try
            {
                empId = adminBL.GetAssigne();
            }
            catch (Exception)
            {
                empId = -99;
            }
            return empId;
        }

        // API to get an arithmetic set of all hotel ratings for a city 
        [HttpGet]
        public JsonResult GetHotelRatingsByCity(string city)
        {
            List<int> ratings;
            try
            {
                ratings = adminBL.GetHotelRatingsByCity(city);
            }
            catch (Exception)
            {
                ratings = null;
            }
            return Json(ratings);
        }

        // API to get a list of hotels given city and rating
        [HttpGet]
        public JsonResult GetHotelsByCityAndRating(string city, string rating)
        {
            List<string> hotels;
            try
            {
                int val = Convert.ToInt32(rating);
                hotels = adminBL.GetHotelsByCityAndRating(city, val);
            }
            catch (Exception)
            {
                hotels = null;
            }
            return Json(hotels);
            
        }

        [HttpGet]
        public int GetHotelCost(string hotelName,string roomtype)
        {
            int cost;
            try
            {
                
                cost = adminBL.GetHotelCost(hotelName, roomtype);
            }
            catch (Exception)
            {
                cost = 0;
            }
            return cost;

        }


        [HttpGet]
        public int GetTotal(string bookingId)
        {
            int total;
            try
            {
                int bkid = Convert.ToInt32(bookingId);
                total = adminBL.GetTotal(bkid);
            }
            catch (Exception)
            {
                total = 0;
            }
            return total;

        }

        [HttpGet]
        public JsonResult ViewBookedPackages(string email)
        {
            List<ViewBookings> bookings;
            try
            {
                
                bookings = adminBL.ViewBookedPackages(email);
            }
            catch (Exception)
            {
                bookings = null;
            }
            return Json(bookings);

        }


        [HttpGet]
        public JsonResult GetHotels()
        {
            List<Hotel> hotels;
            try
            {

                hotels = adminBL.GetHotels();
            }
            catch (Exception)
            {
                hotels = null;
            }
            return Json(hotels);

        }

        [HttpGet]
        public JsonResult GetVehicles()
        {
            List<Vehicle> vehicles;
            try
            {

                vehicles = adminBL.GetVehicles();
            }
            catch (Exception)
            {
                vehicles = null;
            }
            return Json(vehicles);

        }

        // API to get city given packageDetailsId
        [HttpGet]
        public JsonResult GetCityByPackageDetailsId(string bookingId)
        {
            string city;
            try
            {
                int pkgDetId = Convert.ToInt32(bookingId);
                city = adminBL.GetCityByPackageDetailsId(pkgDetId);
            }
            catch (Exception)
            {
                city = null;
            }
            return Json(city);
        }
        #endregion

        #region - CREATE
        // API to register a user
        // Return 1 indicates success
        //       -98 indicates invalid details
        //       -99 indicates an exception
        [HttpPost]
        public int AddCustomer(Customer custObj)
        {
            int role;
            try
            {
                role = adminBL.AddCustomer(custObj);
            }
            catch(Exception)
            {
                role = -99;
            }
            return role;
        }

        // API to add accomodation details for customer
        [HttpPost]
        public bool AddAccomodationDetails(Accomodation accObj)
        {
            bool status;
            try
            {
                status = adminBL.AddAccomodation(accObj);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // API to add bookPackage details for customer
        [HttpPost]
        public int AddBookPackage(BookPackage bkPkg)
        {
            int bookingId;
            try
            {
                bookingId = adminBL.AddBookPackage(bkPkg);
            }
            catch (Exception)
            {
                bookingId = 0;
            }
            return bookingId;
        }

        // API to add a hotel by Admin
        [HttpPost]
        public bool AddHotel(Hotel hotel)
        {
            bool status;
            try
            {
                status = adminBL.AddHotel(hotel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }

        // API to add a vehivle by Admin
        [HttpPost]
        public bool AddVehicle(Vehicle vehicle)
        {
            bool status;
            try
            {
                status = adminBL.AddVehicle(vehicle);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // API to add a customer care entry
        [HttpPost]
        public bool AddCustomerCare(CustomerCare custCare)
        {
            bool status;
            try
            {
                status = adminBL.AddCustomerCare(custCare);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }



        [HttpPost]
        public bool Payment(Payment pay)
        {
            bool status;
            try
            {
                status = adminBL.Payment(pay);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        #endregion

        #region - UPDATE
        // API to update user details
        [HttpPut]
        public bool UpdateProfile(Customer custObj)
        {
            bool status;
            try
            {
                status = adminBL.UpdateProfile(custObj);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region - DELETE
        #endregion
    }
}
