using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Optimization;
using System.Web.UI;
using OnlineCoachBooking;

/// <summary>
/// Summary description for Helper
/// </summary>


public class Helper
{
    public Helper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string getConnString()
    {
        string connString = ConfigurationManager.ConnectionStrings["coachConnectionString"].ConnectionString;
        return connString;
    }
    public string[] authenticateUser(string userName, string userPassword)
    {
        
        string hashSaltedPassword = getPasswordHash(userPassword);
        string storedHashPassword = getStoredHashPassword(userName);
        // if user does not exist, it returns an empty password
        if(storedHashPassword == string.Empty)
            return new string[] { Constants.Unauthorised, "0" };
        //BCrypt encription is implemented 
        if (BCrypt.Net.BCrypt.Verify(userPassword, storedHashPassword))
            hashSaltedPassword = storedHashPassword;

        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "AuthenticateUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@username", userName));
            cmd.Parameters.Add(new SqlParameter("@password", hashSaltedPassword));
            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.VarChar, 50));
            cmd.Parameters["@RoleName"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new SqlParameter("@WrongLoginCount", SqlDbType.Int));
            cmd.Parameters["@WrongLoginCount"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            string[] result = new string[2];
            result[0] = cmd.Parameters["@RoleName"].Value.ToString();
            result[1] = cmd.Parameters["@WrongLoginCount"].Value.ToString();
            return result;
        }
    }

    public void registerSessionTimeout()
    {
        
    }

    private string getPasswordHash(string userPassword)
    {
        //BCrypt Hashing and salting the password to prevent brute force attack
        //Referred :   https://cmatskas.com/a-simple-net-password-hashing-implementation-using-bcrypt/
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        string hashedSaltedPassword = BCrypt.Net.BCrypt.HashPassword(userPassword, salt);
      

        //SHA Hashing and salting the password to prevent brute force attack
        //Referred : https://stackoverflow.com/questions/5216708/hash-function-net
        //string salt = "a9g8^7k%";
        ////using SHA256 hashing alogorithm is implemented
        //System.Security.Cryptography.SHA256 sha = System.Security.Cryptography.SHA256.Create();
        //byte[] hashSalted = sha.ComputeHash(System.Text.Encoding.UTF32.GetBytes(userPassword + salt));
        //string newPassword = System.Convert.ToBase64String(hashSalted, 0, 15);
        return hashedSaltedPassword;

    }
    public string getStoredHashPassword(string userName)
    {
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "getHashPassword";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            cmd.Parameters.Add(new SqlParameter("@hashPassword", SqlDbType.VarChar, 500));
            cmd.Parameters["@hashPassword"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            string result = cmd.Parameters["@hashPassword"].Value.ToString();
            return result;
        }
    }
    public string UnlockAccount(string userName, string userPassword)
    {
        string hashSaltedPassword = getPasswordHash(userPassword);
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "UnlockAccount";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@username", userName));
            cmd.Parameters.Add(new SqlParameter("@password", hashSaltedPassword));
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
            cmd.Parameters["@email"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            string result = cmd.Parameters["@email"].Value.ToString();
            return result;
        }
    }

    public string checkUserExists(string userName, string phone, string email)
    {
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "checkUserExists";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            cmd.Parameters.Add(new SqlParameter("@phone", phone));
            cmd.Parameters.Add(new SqlParameter("@emailID", email));
            cmd.Parameters.Add(new SqlParameter("@userExists", SqlDbType.VarChar, 20));
            cmd.Parameters["@userExists"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            string result = cmd.Parameters["@userExists"].Value.ToString();
            return result;
        }
    }

    public void RegisterUser(string userName, string password, string phone, string email)
    {
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "RegisterUser";
            cmd.CommandType = CommandType.StoredProcedure;
            string saltedHashPassword = getPasswordHash(password);
            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            cmd.Parameters.Add(new SqlParameter("@password", saltedHashPassword));
            cmd.Parameters.Add(new SqlParameter("@phone", phone));
            cmd.Parameters.Add(new SqlParameter("@emailID", email));
            
            conn.Open();
            cmd.ExecuteNonQuery();
            
        }
    }

    public DataTable getUpcomingSeats(string userName)
    {
        DataTable dtUpcomingSeats = new DataTable();
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (var cmd = new SqlCommand("getUpcomingSeats", conn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.Parameters.Add(new SqlParameter("@username", userName));
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dtUpcomingSeats);
        }
        return dtUpcomingSeats;
    }

    public string generateRandomPassword()
    {
        //Generate a random password
        Random random = new Random();
        const string chars = Constants.AllCharaters;
        //8 characters password generates here
        string newRandomPassword = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        return newRandomPassword;
    }

    public string generateCapthca()
    {
        Random random = new Random();
        const string chars = Constants.AllCharaters;
        //6 characters captcha
        string newRandomCaptcha = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        return newRandomCaptcha;
    }

    public DataTable chooseBus(string source, string destination, string journetDate)
    {
        DataTable dtChooseBus = new DataTable();
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (var cmd = new SqlCommand("chooseBus", conn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.Parameters.Add(new SqlParameter("@source", source));
            cmd.Parameters.Add(new SqlParameter("@destination", destination));
            cmd.Parameters.Add(new SqlParameter("@journetDate", journetDate));
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dtChooseBus);
        }
        return dtChooseBus;
    }

    public DataSet getBusSeats(int busID, string journetDate)
    {
        DataSet dsBusSeats = new DataSet();
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (var cmd = new SqlCommand("getBusSeats", conn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.Parameters.Add(new SqlParameter("@busID", busID));
            cmd.Parameters.Add(new SqlParameter("@journetDate", journetDate));
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dsBusSeats);
        }
        return dsBusSeats;
    }

    public DataTable getLocations()
    {
        DataTable dtLocations = new DataTable();
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (var cmd = new SqlCommand("getLocations", conn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dtLocations);
        }
        return dtLocations;
    }

    public string checkSeatAlreadyBooked(int busID, int seat, string journeyDate)
    {
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "checkSeatAlreadyBooked";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@busID", busID));
            cmd.Parameters.Add(new SqlParameter("@seat", seat));
            cmd.Parameters.Add(new SqlParameter("@journeyDate", journeyDate));
            cmd.Parameters.Add(new SqlParameter("@bookedFlag", SqlDbType.VarChar, 20));
            cmd.Parameters["@bookedFlag"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            string result = cmd.Parameters["@bookedFlag"].Value.ToString();
            return result;
        }
    }

    public void bookSeat(string userName, int busID, int seat, string passengerName,float price, string transactionDate, string journeyDate)
    {
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "bookSeat";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            cmd.Parameters.Add(new SqlParameter("@busID", busID));
            cmd.Parameters.Add(new SqlParameter("@seat", seat));
            cmd.Parameters.Add(new SqlParameter("@passengerName", passengerName));
            cmd.Parameters.Add(new SqlParameter("@price", price));
            cmd.Parameters.Add(new SqlParameter("@transactionDate", transactionDate));
            cmd.Parameters.Add(new SqlParameter("@journeyDate", journeyDate));
            conn.Open();
            cmd.ExecuteNonQuery();

        }
    }

    public void insertLog(string userName, string logMessage)
    {
        using (SqlConnection conn = new SqlConnection(getConnString()))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "InsertLog";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            cmd.Parameters.Add(new SqlParameter("@logMessage", logMessage));
            
            conn.Open();
            cmd.ExecuteNonQuery();

        }
    }
}