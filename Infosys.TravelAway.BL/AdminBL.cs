using System;
using System.Collections.Generic;
using System.Text;
using Infosys.TravelAway.DAL;
using Infosys.TravelAway.DAL.Models;

namespace Infosys.TravelAway.BL
{
    public class AdminBL
    {
        TravelAwayRepository repository;

        public AdminBL()
        {
            repository = new TravelAwayRepository();
        }

        #region - CREATE
        // Method to register a new Customer of type DAL.Models.Customer
        // Return 1 indicates success
        //       -98 indicates invalid details
        //       -99 indicates an exception
        public int AddCustomer(Customer custObj)
        {
            int status;
            try
            {
                status = repository.RegisterNewCustomer(custObj);
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }

        public List<ViewBookings> ViewBookedPackages(string email)
        {
            List<ViewBookings> bookings;
            try
            {

                bookings = repository.ViewBookedPackages(email);
            }
            catch (Exception)
            {
                bookings = null;
            }
            return bookings;
        }

        public int GetTotal(int bookingId)
        {
            int total;
            try
            {
               
                total = repository.TotalAmount(bookingId);
            }
            catch (Exception)
            {
                total = 0;
            }
            return total;

        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles;
            try
            {

                vehicles = repository.GetVehicles();
            }
            catch (Exception)
            {
                vehicles = null;
            }
            return vehicles;

        }

        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels;
            try
            {

                hotels = repository.GetHotels();
            }
            catch (Exception)
            {
                hotels = null;
            }
            return hotels;

        }

        // Add accomodation details for customer
        public bool AddAccomodation(Accomodation accObj)
        {
            bool status;
            try
            {
                status = repository.AddAccomodation(accObj);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // Add bookPackage details for customer
        public int AddBookPackage(BookPackage bkPkg)
        {
            int bookingId;
            try
            {
                bookingId= repository.BookPackageBySP(bkPkg);
            }
            catch (Exception)
            {
                bookingId = 0;
            }
            return bookingId;
        }

        // Add new hotel - Admin
        public bool AddHotel(Hotel hotel)
        {
            bool status;
            try
            {
                status = repository.AddNewHotel(hotel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }

        // Add new vehicle - Admin
        public bool AddVehicle(Vehicle veh)
        {
            bool status;
            try
            {
                status = repository.AddNewVehicle(veh);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // Add a customer care object
        public bool AddCustomerCare(CustomerCare custCare)
        {
            bool status;
            try
            {
                status = repository.AddCustomerCare(custCare);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        public bool Payment(Payment pay)
        {
            bool status;
            try
            {
                status = repository.PaymentMethod(pay);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region - READ
        // User login validation
        public int ValidateLoginCustomer(string emailId, string password)
        {
            int role;
            int result;
            try
            {
                result = repository.ValidateLoginCustomer(emailId, password);
                if (result > 0)
                {
                    role = result;
                }
                else
                {
                    role = 0;
                }
            }
            catch (Exception)
            {
                role = -99;
            }
            return role;
        }

        public Customer GetCustomerDetails(string email)
        {
            Customer cust;
            try
            {
                cust = repository.GetCustomerById(email);
            }
            catch
            {
                cust = null;
            }
            return cust;
        }



        public int ValidateLoginEmployee(string emailId, string password)
        {
            int role;
            int result;
            try
            {
                result = repository.EmployeeLogin(emailId, password);
                if (result > 0)
                {
                    role = result;
                }
                else
                {
                    role = 0;
                }
            }
            catch (Exception)
            {
                role = -99;
            }
            return role;
        }

        // Retrieve all packages from Package table
        public List<Package> GetPackages()
        {
            List<Package> packageList;
            try
            {
                packageList = repository.GetPackages();
            }
            catch
            {
                packageList = null;
            }
            return packageList;
        }

        // Retrieve all package categories from PackageCategory table
        public List<PackageCategory> GetPackageCategories()
        {
            List<PackageCategory> packageCategoriesList;
            try
            {
                packageCategoriesList = repository.GetPackageCategories();
            }
            catch (Exception)
            {
                packageCategoriesList = null;
            }
            return packageCategoriesList;
        }

        // Retrieve all packages corresponding to given categoryId
        public List<Package> GetPackagesByCategoryId(int categoryId)
        {
            List<Package> packageList;
            try
            {
                packageList = repository.GetPackageByCategoryId(categoryId);
            }
            catch
            {
                packageList = null;
            }
            return packageList;
        }

        // Retrieve package details given packageId
        public List<PackageDetails> GetPackageDetailsByPackageId(int packageId)
        {
            List<PackageDetails> packageDetails;
            try
            {
                packageDetails = repository.GetPackageDetailsByPackageId(packageId);
            }
            catch (Exception)
            {
                packageDetails = null;
            }
            return packageDetails;
        }

        // Retrieve customer details given emailId
        public Customer GetCustomerByEmail(string email)
        {
            Customer cust;
            try
            {
                cust = repository.GetCustomerById(email);
            }
            catch (Exception)
            {
                cust = null;
            }
            return cust;
        }

        // Retrieve accomodation given bookingId
        public Accomodation GetAccomodationByBookingId(int bookingId)
        {
            Accomodation accObj;
            try
            {
                accObj = repository.GetAccomodationByBookingId(bookingId);
            }
            catch (Exception)
            {
                accObj = null;
            }
            return accObj;
        }

        // Retrieve a random employee
        public int GetAssigne()
        {
            int empId;
            try
            {
                empId = repository.GetAssigne();
            }
            catch (Exception)
            {
                empId = -99;
            }
            return empId;
        }

        // Get an arithmetic set of all hotel ratings for a city
        public List<int> GetHotelRatingsByCity(string city)
        {
            List<int> ratings;
            try
            {
                ratings = repository.GetHotelRatingByCity(city);
            }
            catch (Exception)
            {
                ratings = null;
            }
            return ratings;
        }

        // Get a list of hotels given city and rating
        public List<string> GetHotelsByCityAndRating(string city, int rating)
        {
            List<string> hotels;
            try
            {
                hotels = repository.GetHotelsByCityAndRating(city, rating);
            }
            catch (Exception)
            {
                hotels = null;
            }
            return hotels;
        }

        // Get city given the packageDetailsId
        public string GetCityByPackageDetailsId(int pId)
        {
            string city;
            try
            {
                city = repository.GetCitiesByPackageDetailsId(pId);
            }
            catch (Exception)
            {
                city = null;
            }
            return city;
        }

        // Retrieve total cost for given bookingId
        //public int GetCostByBookingId(int bookingId){}

        // Get cost of room for given hotel and room type
        public int GetHotelCost(string hotelName, string roomType)
        {
            int cost;
            try
            {
                cost = repository.GetHotelCost(hotelName, roomType);
            }
            catch (Exception)
            {
                cost = 0;
            }
            return cost;
        }

        // Get booked packages for a given userId
        public List<ViewBookings> GetBookedPackages(string emailId)
        {
            List<ViewBookings> bookings;
            try
            {
                bookings = repository.ViewBookedPackages(emailId);
            }
            catch (Exception)
            {
                bookings = null;
            }
            return bookings;
        }
        #endregion

        #region - UPDATE
        // Update Customer details
        public Boolean UpdateProfile(Customer custObj)
        {
            bool status;
            try
            {
                status = repository.EditProfile(custObj);
            }
            catch(Exception)
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
