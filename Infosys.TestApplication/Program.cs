using Infosys.TravelAway.DAL;
using System;
using Infosys.TravelAway.DAL.Models;
using Infosys.TravelAway.BL;
using Infosys.TravelAway.Services.Controllers;
using System.Collections.Generic;

namespace Infosys.TestApplication
{
    class Program
    {
        static void Main()
        {
            TestDataAccessLayer testDAL = new TestDataAccessLayer();
            testDAL.TestFunction();
            //TestBusinessLayer testBL = new TestBusinessLayer();
            //testBL.TestList();
            //TestServiceLayer testServ = new TestServiceLayer();
            //testServ.TestList();
        }
    }

    #region - Tests for Data Access Layer
    public class TestDataAccessLayer
    {
        TravelAwayRepository repository;
        public TestDataAccessLayer() {
            repository = new TravelAwayRepository();
        }

        public void TestFunction() {
            //Customer obj = new Customer();
            //obj.EmailId = "Prabhjeet@gmail.com";
            //obj.FirstName = "Prabhjeet";
            //obj.LastName = "Bhabar";
            //obj.UserPassword = "jeet@2123";
            //obj.Gender = "M";
            //obj.ContactNumber = 1234567890;
            //obj.DateOfBirth = new DateTime(1999, 04, 04);
            //obj.Address = "Bhopal";
            //int result = repository.RegisterNewCustomer(obj);
            //if (result > 0)
            //{
            //    Console.WriteLine("Customer details added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!");
            //}
            //int result = repository.ValidateLogin("Brijesh@gmail.com", "efgh@1234");
            //Console.WriteLine(result);
            //if (result == 1)
            //{
            //    Console.WriteLine("Login succesfull");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!");
            //}

            //int result = repository.EmployeeLogin("peter@gmail.com", "asdfghjkl");
            //Console.WriteLine(result);
            //if (result == 1)
            //{
            //    Console.WriteLine("Login succesfull");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!");
            //}


            //------------EditDetails-----------------------------------------------------------------
            //Customer obj = new Customer();
            //obj.EmailId = "Prabhjeet@gmail.com";
            //obj.Address = "Punjab";
            //obj.FirstName = "Prabhjeet";
            //obj.LastName = "Bhabar";
            ////obj.UserPassword = "abcde@1234";
            //obj.Gender = "M";
            //obj.ContactNumber = 9876543210;
            ////obj.DateOfBirth = new DateTime(1997, 05, 07);

            //bool result = repository.EditProfile(obj);
            //if (result)
            //{
            //    Console.WriteLine("details added succesfully");
            //}
            //else
            //{
            //    Console.WriteLine("Some error occurred. Try again!");
            //}
            //        -------------------ViewAllPackages--------------------------------------------------------
            //var list = repository.GetPackages();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.PackageId);
            //    Console.WriteLine(item.PackageName);
            //    Console.WriteLine(item.PackageCategoryId);
            //    Console.WriteLine(item.TypeOfPackage);

            //}

            //--------------------------ViewPackageCategories----------------------------------------
            //var list = repository.GetPackageCategories();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.PackageCategoryId);
            //    Console.WriteLine(item.PackageCategoryName);
            //}
            //---------------detailsbyDetailsId-----------------------------------------------

            // PackageDetails item = null;

            //var list = repository.GetPackageDetailsByPackageId(2001);
            // foreach (var item in list)
            // {
            //     Console.WriteLine(item.PricePerAdult);
            //     Console.WriteLine(item.NoOfDays);
            //     Console.WriteLine(item.NoOfNights);
            // }
            // Console.WriteLine(item.PricePerAdult + " " + item.NoOfDays + " " + item.NoOfNights);

            //  -------------categoriesByCategoryId------------------------------------------------ -
            //PackageCategory obj = repository.GetPackageByCategoryId(104);
            //Console.WriteLine(obj.PackageCategoryId +" "+ obj.PackageCategoryName);

            //Accomodation a = new Accomodation();

            //a.BookingId = 4007;
            //a.HotelName = "Taj";
            //a.City = "Pune";
            //a.NoOfRooms = 4;
            //a.HotelRating = 4;
            //a.Price = 10000;
            //a.RoomType = "Deluxe";

            //string val = repository.AddAccomodation(a);
            //Console.WriteLine(val);

            //BookPackage a = new BookPackage();

            //a.EmailId = "poorvi@gmail.com";
            //a.ContactNumber = 1234567890;
            //a.Address = "Indore";
            //a.DateOfTravel = new DateTime(2021, 07, 07);
            //a.NumberOfAdults = 6;
            //a.NumberOfChildren = 1;
            //a.Status = "Booked";
            //a.PackageId = 2005;

            //string val = repository.BookPackage(a);
            //Console.WriteLine(val);

            //Hotel a = new Hotel();

            //a.HotelName = "Huuh";
            //a.HotelRating = 2;
            //a.DeluxeeRoomPrice = 4000;
            //a.DoubleRoomPrice = 2000;
            //a.SingleRoomPrice = 1000;
            //a.SuiteRoomPrice = 2500;
            //a.City = "Pune";
            // a.PackageId = 2002;

            //bool val = repository.AddNewHotel(a);
            //Console.WriteLine(val);

            //Vehicle a = new Vehicle();

            //a.VehicleName = "Honda";
            //a.VehicleType = "Four-Wheeler";
            //a.RatePerHour = 6;
            //a.RatePerKm = 8;
            //a.BasePrice = 200;
            //string val = repository.AddNewVehicle(a);
            //Console.WriteLine(val);


            //------------------------------------------------------------------------------------
            //CustomerCare a = new CustomerCare();

            //a.BookingId = 4008;
            //a.QueryStatus = "In Progress";
            //a.Query = "C101";
            //a.QueryAnswer = "Okie";
            //a.Assignee = "Poorvi";


            //string val = repository.AddCustomerCare(a);
            //Console.WriteLine(val);

            //Accomodation a = new Accomodation();
            // a = repository.GetAccomodationByBookingId(4005);
            //foreach (var item in a)
            //{
            //    Console.WriteLine(item.NoOfRooms);
            //    Console.WriteLine(item.HotelName);
            //    Console.WriteLine(item.City);
            //    Console.WriteLine(item.RoomType);
            //    Console.WriteLine(item.Price);
            //    Console.WriteLine(item.HotelRating);

            //}

            //int a = repository.GetAssigne();
            //Console.WriteLine(a);

            //int bookingId = 0;
            //int b = repository.BookPackageBySP("Sagar@gmail.com", 7673894320, "902-Delhi", new DateTime(2022,11,05),4,4,"Booked",900,out bookingId);
            //// Console.WriteLine(b);
            //if (b > 0)
            //{
            //    Console.WriteLine(b);
            //    Console.WriteLine("Booking details added successfully with BookingId = " + bookingId);
            //}
            //else
            //{
            //    Console.WriteLine(b);
            //    Console.WriteLine("Some error occurred. Try again!");
            //}

            //int bookingId = 0;
            //int noOfAdult = 0;
            //int noOfChildren = 0;
            //DateTime dateOfTravel = new DateTime(2021, 01, 01);
            //int totalAmount = 0;
            //string hotelName = " ";
            //int noOfRooms = 0;
            //string placesVisit = " ";
            //int noOfDays = 0;
            //int noOfNights = 0;
            //string packname = " ";
            ////List<ViewBookings> obj = new List<ViewBookings>();
            //var obj = repository.ViewBookingsSP("Sagar@gmail.com", out bookingId, out  noOfAdult,
            //out noOfChildren,
            //out  dateOfTravel,
            //out  totalAmount,
            //out  hotelName,
            //out  noOfRooms,
            //out  placesVisit,
            //out  noOfDays,
            //out  noOfNights,
            // out  packname);
            ////foreach (var item in obj)
            ////{
            ////    Console.WriteLine(item.NumberOfChildren);
            ////    Console.WriteLine(item.BookingId);
            ////    Console.WriteLine(item.DateOfTravel);
            ////    //Console.WriteLine(item.NumberOfChildren);
            ////}
            ////Console.WriteLine(obj);

            //if (obj > 0)
            //{
            //    //Console.WriteLine(b);
            //    Console.WriteLine( bookingId+" "+ noOfAdult+" "+ noOfChildren+
            //        " "+ dateOfTravel+" "+ totalAmount+" "+ hotelName+" "+ noOfRooms+" "+ placesVisit+" "+ noOfDays+" "+ noOfNights+" "+ packname);
            //}
            //else
            //{
            //   // Console.WriteLine(b);
            //    Console.WriteLine("Some error occurred. Try again!");
            //}

            //string emailId = "";
            // var c = repository.ViewBookedPackages("Prabhjeet@gmail.com");
            //Console.WriteLine(c);
            //if (c.Count == 0)
            // {
            //     Console.WriteLine("No products available under the given category!");
            // }
            // else
            // {
            //     foreach (var a in c)
            //     {
            //         Console.WriteLine("{0, -12}{1, -30}{2}", a.BookingId, a.DateOfTravel, a.NoOfDays);
            //     }
            // }

            Console.WriteLine("mayank"+ repository.TotalAmount(4029));

        }
    }
    #endregion

    #region - Tests for Business Layer
    public class TestBusinessLayer
    {
        readonly AdminBL _adminBL;
        static int _testCount = 0;
        readonly Customer custObj = new Customer
        {
            EmailId = "testuser@test.com",
            RoleId = 1,
            FirstName = "first",
            LastName = "last",
            UserPassword = "password",
            Gender = "F",
            ContactNumber = 1234567890,
            DateOfBirth = new DateTime(1999, 04, 04),
            Address = "address"
        };
        readonly Accomodation accObj = new Accomodation
        {
            BookingId = 1,
            HotelName = "hotel",
            City = "city",
            NoOfRooms = 1,
            HotelRating = 5,
            Price = 100,
            RoomType = "Single"
        };
        readonly BookPackage bkPkg = new BookPackage
        {
            EmailId = "test@test.com",
            BookingId = 1,
            ContactNumber = 1234567890,
            Address = "address",
            DateOfTravel = new DateTime(2022, 04, 04),
            NumberOfAdults = 4,
            NumberOfChildren = 2,
            Status = "Booked"
        };

        public TestBusinessLayer()
        {
            _adminBL = new AdminBL();
        }

        public void TestList()
        {
            TestAddCustomer();
            TestAddCustomerInvalidFirstName();
            TestAddAccomodation();
            TestAddBookPackage();
            TestValidateCustomer();
            TestInvalidCustomerEmail();
            TestInvalidCustomerPassword();
            TestUpdateSuccess();
            Console.WriteLine(_testCount + " tests passed");
        }

        public void SetUp()
        {
            using (var context = new TravelAwayDBContext())
            {
                context.Customer.Add(this.custObj);
                context.SaveChanges();
            }
        }
        public void TearDown()
        {
            using var context = new TravelAwayDBContext();
            context.Remove(this.custObj);
            context.SaveChanges();
        }

        public void TearDownAcc()
        {
            using var context = new TravelAwayDBContext();
            context.Remove(this.accObj);
            context.SaveChanges();
        }

        public void TearDownBkPkg()
        {
            using var context = new TravelAwayDBContext();
            context.Remove(this.bkPkg);
            context.SaveChanges();
        }

        // Tests for AddCustomer
        public void TestAddCustomer()
        {
            int status;
            status = _adminBL.AddCustomer(this.custObj);
            if (status == 1)
            {
                TearDown();
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed: TestAddCustomer");
            }
        }
        public void TestAddCustomerInvalidFirstName()
        {
            Customer tempCustObj = this.custObj;
            tempCustObj.FirstName = "";
            int status = _adminBL.AddCustomer(tempCustObj);
            if (status == -98)
            {
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed : TestAddCustomerFirstName");
            }
        }

        // Tests for AddAccomodation
        public void TestAddAccomodation()
        {
            bool status;
            status = _adminBL.AddAccomodation(this.accObj);
            if (status)
            {
                TearDownAcc();
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed: TestAddAccomodation");
            }
        }

        // Tests for AddBookPackage
        public void TestAddBookPackage()
        {
            int bookingId;
            bookingId = _adminBL.AddBookPackage(this.bkPkg);
            if (bookingId > 0)
            {
                TearDownBkPkg();
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed: TestAddBookPackage");
            }
        }

        // Tests for ValidateLogin
        public void TestValidateCustomer()
        {
            SetUp();
            int status = _adminBL.ValidateLoginCustomer(this.custObj.EmailId, this.custObj.UserPassword);
            if (status==1)
            {
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed: TestValidateCustomer");
            }
            TearDown();
        }

        public void TestInvalidCustomerEmail()
        {
            SetUp();
            int status = _adminBL.ValidateLoginCustomer("invalid", this.custObj.UserPassword);
            if (status == 0)
            {
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed: TestInvalidCustomerEmail");
            }
            TearDown();
        }

        public void TestInvalidCustomerPassword()
        {
            SetUp();
            int status = _adminBL.ValidateLoginCustomer(this.custObj.EmailId, "invalid");
            if (status == 0)
            {
                _testCount += 1;
            }
            else
            {
                Console.WriteLine("Test failed: TestInvalidCustomerPassword");
            }
            TearDown();
        }

        // Tests for UpdateProfile
        public void TestUpdateSuccess()
        {
            bool status;
            SetUp();
            Customer tempCust = this.custObj;
            tempCust.FirstName = "second";
            status = _adminBL.UpdateProfile(tempCust);
            using (var context = new TravelAwayDBContext())
            {
                Customer cust = context.Customer.Find(tempCust.EmailId);
                if (String.Equals(cust.FirstName, tempCust.FirstName))
                {
                    _testCount += 1;
                }
                else
                {
                    Console.WriteLine("Test failed: TestUpdateSuccess");
                }
            }
            TearDown();
        }

        // Tests for GetPackages
        // public void TestGetPackages() {}
    }
    #endregion

    #region - Tests for Service Layer
    public class TestServiceLayer
    {
        readonly TravelAwayController _controller;
        static int _testCount = 0;
        readonly Customer custObj = new Customer
        {
            EmailId = "testuser@test.com",
            FirstName = "first",
            LastName = "last",
            UserPassword = "password",
            Gender = "F",
            ContactNumber = 1234567890,
            DateOfBirth = new DateTime(1999, 04, 04),
            Address = "address"
        };

        public TestServiceLayer(){
            _controller = new TravelAwayController();
        }

        public void TestList()
        {
            TestValidateLogin();
            Console.WriteLine(_testCount + " tests passed");
        }

        public void TearDown()
        {
            using (var context = new TravelAwayDBContext())
            {
                context.Remove(this.custObj);
                context.SaveChanges();
            }
        }

        // !!!
        public void TestValidateLogin()
        {
        }

        // !!!
        public void TestAddCustomer()
        {
        }
    }
    #endregion
}
