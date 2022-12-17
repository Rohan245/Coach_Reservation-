using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCoachBooking
{
    public static class Constants
    {
        public const string UserName = "UserName";
        public const string UserStatus = "UserStatus";
        public const string Unauthorised = "Unauthorised";
        public const string Authorised = "Authorised";
        public const string HomePage = "Home.aspx";
        public const string LoginPage = "Login.aspx";
        public const string RegistrationPage = "Registration.aspx";
        public const string ChooseBusPage = "ChooseBus.aspx";
        public const string BookingPage = "Booking.aspx";
        public const string ConfirmationPage = "Confirmation.aspx";
        public const string ErrorPage = "ErrorPage.aspx";
        public const string Phone = "Phone";
        public const string EmailID = "EmailID";
        public const string Valid = "Valid";
        public const string Source = "Source";
        public const string Destination = "Destination";
        public const string JourneyDate = "JourneyDate";
        public const string BusID = "BusID"; 
        public const string Price = "Price";
        public const string SeatsUnavailable = "SeatsUnavailable";
        public const string SeatsBooked = "SeatsBooked";
        public const string SeatsBookedWithName = "SeatsBookedWithName";

        

        public const string AllCharaters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        public const string SMTPEmailAddress = "iamharshithpatel@gmail.com";
        public const string EmailDisaplyName = "Online Coach Reservation";
        public const string NetworkEmailAddress = "iamharshithpatel@gmail.com";
        public const string NetworkEmailPassword = "Explore@4";
        public const string SMTPHost = "smtp.gmail.com";

        //Messages 
        public const string LoginErrorMessage = "User ID or Password is wrong !!!";
        public const string LoginLockWarningMessage = "Invalid Login. Account will be locked after 3 invalid login attempts !!!";
        public const string AccountLockedMessage = "Account is locked after 3 or more invalid login attempts. Please reset the password !!!";
        public const string AccountUnlockedMessage = "Account unlocked and new password sent to your email. Please login with the new password !!!";
        public const string Welcome = "Welcome {0} ";
        public const string MailSubject = "Account Unlocked for Online Coach Reservation System";
        public const string NewPasswordMessage = "Use this new password to login into your account : ";
        public const string WarningEmptyValue = "One of the fileds is empty. Please fill and try again !!!";
        public const string WarningInvalidCaptcha = "Captcha entered doesnt match. Try again";
        public const string WarningSeatEmptyValue = "Seat Number is mandatory !!!";
        public const string WarningSeatRange = "Seat Number entered in out of range !!!";
        public const string WarningSeatNotAvailable = "This seat is not available !!!";
        public const string WarningSeatAlreadyBooked = "This seat is already booked !!!";
        public const string WarningSeatCannotUnselct = "Cannot remove unselected seat !!!";
        public const string WarningValueWithSpace = "One of the fileds value is invalid. Remove spaces and try !!!";
        public const string WarningInvalidValue = "One of the fileds has invalid value. Please enter valid text and try again !!!";
        public const string WarningJourneyDateEmpty = "Journey Date is mandatory for searching."; 
        public const string WarningSourceDestinationSame = "Journey source and destination cannot be same."; 
        public const string WarnPassengerName = "Passenger name must follow the format Firstname LastName";
        public const string WarnPassengerNameLength = "Passenger name length is limited to 20 characters."; 
        public const string WarnFinalBooking = "Please book seats before proceeding to final booking."; 
        public const string confirmationMessageExists = "Sorry, the seats are booked by someone else.";
        public const string confirmationMessageBooked = "Congratulations. You have booked your seats successfully.";
        public const string logMessageLogin = "Logged in successfully.";
        public const string logMessageLogout = "Logged out successfully.";
        public const string logMessageBookSeats = "Booked seats succesfully.";



        //Resigter validation Messages
        public const string WarnRegUserName = "Must contain only alphanumeric and between 5 - 15 characters";
        public const string WarnRegPassword = "Must contain atleast one lower case, upper case, numer and symbol and between 8 - 15 characters";
        public const string WarnRegPhone = "Must contain only numeric and 10 digits";
        public const string WarnRegEmailID = "Must follow a valid email format and less than 30 characters";
        public const string WarnConfirmPW = "Passwords must match";
        public const string UserNameExists = "UserName already exists";
        public const string PhoneExists = "Phone number already exists";
        public const string EmailIDExists = "EmailID already exists";
    }
}