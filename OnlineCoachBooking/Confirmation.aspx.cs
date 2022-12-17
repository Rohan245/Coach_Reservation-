using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineCoachBooking
{
    public partial class Confirmation : System.Web.UI.Page
    {
        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (!Page.IsPostBack)
                {
                    //Verifying if session is valid before executing the code
                    if (Session[Constants.UserStatus] != null && Session[Constants.UserStatus].ToString() == Constants.Authorised)
                    {
                        //Double Verifying if session is valid before executing the code
                        if (Session[Constants.JourneyDate] != null && Session[Constants.Price] != null && Session[Constants.SeatsBooked] != null)
                        {
                            Dictionary<string, string> dictSelectedSeats = (Dictionary<string, string>)Session[Constants.SeatsBookedWithName];
                            int busID = Convert.ToInt32(Session[Constants.BusID]);
                            string userName = Session[Constants.UserName].ToString();
                            int price = Convert.ToInt32(Session[Constants.Price]);
                            string journeyDate = Session[Constants.JourneyDate].ToString();
                            string transactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                            //Checknig for concurrency. Dont book the seat it is already booked by someone.
                            foreach (KeyValuePair<string, string> item in dictSelectedSeats)
                            {
                                int seat = Convert.ToInt16(item.Key);
                                string passengerName = item.Value;
                                string exists = helper.checkSeatAlreadyBooked(busID, seat, journeyDate);
                                if (exists == "Exists")
                                {
                                    lblConfirmationMessage.Attributes.Add("Style", "ForeColor:Red");
                                    lblConfirmationMessage.Text = Constants.confirmationMessageExists;
                                    lnkHome.Visible = true;
                                    return;
                                }

                            }
                            //Concurrency is passed. Now book the seats in database
                            foreach (KeyValuePair<string, string> item in dictSelectedSeats)
                            {
                                int seat = Convert.ToInt16(item.Key);
                                string passengerName = item.Value;
                                helper.bookSeat(userName, busID, seat, passengerName, price, transactionDate, journeyDate);
                                lblConfirmationMessage.Attributes.Add("Style", "ForeColor:Green");
                                lblConfirmationMessage.Text = Constants.confirmationMessageBooked;
                                lnkHome.Visible = true;
                            }
                            helper.insertLog(userName, Constants.logMessageBookSeats);
                        }
                        else
                        {
                            Session.Clear();
                            Response.Redirect(Constants.LoginPage,false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(Constants.LoginPage,false);

        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            //Verifying if session is valid before executing the code
            if (Session[Constants.UserName] == null)
            {
                Session.Clear();
                Response.Redirect(Constants.LoginPage, false);
            }
            Response.Redirect(Constants.HomePage,false);
        }
    }
}