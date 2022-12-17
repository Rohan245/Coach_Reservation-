using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Helpers;

namespace OnlineCoachBooking
{
    public partial class Booking : System.Web.UI.Page
    {
        Helper helper = new Helper();
        List<string> seatList;
        List<string> lstSelectedSeats;
        Dictionary<string, string> dictSelectedSeats = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    //if the antiforgery token passed from user is not valid, request will not be server back to browser.
                    AntiForgery.Validate();
                }
                if (!Page.IsPostBack)
                {
                    //Verifying if session is valid before executing the code
                    if (Session[Constants.UserStatus] != null && Session[Constants.UserStatus].ToString() == Constants.Authorised)
                    {

                        lblUserName.Text = string.Format(Constants.Welcome, Session[Constants.UserName].ToString());
                        int busID = 0;
                        string journeyDate = string.Empty;
                        lstSelectedSeats = new List<string>();
                        Session[Constants.SeatsBooked] = lstSelectedSeats;
                        Session[Constants.SeatsBookedWithName] = dictSelectedSeats;
                        if (Session[Constants.BusID] != null && Session[Constants.JourneyDate] != null)
                        {
                            busID = Convert.ToInt32(Session[Constants.BusID]);
                            journeyDate = Session[Constants.JourneyDate].ToString();
                            DataSet dsBusSeats = helper.getBusSeats(busID, journeyDate);
                            seatList = dsBusSeats.Tables[1].AsEnumerable().Select(x => x[0].ToString()).ToList();
                            Session[Constants.SeatsUnavailable] = seatList;
                            gvBusSeats.DataSource = dsBusSeats.Tables[0];
                            gvBusSeats.DataBind();
                            if (gvBusSeats.Rows.Count > 0)
                            {
                                //Looping over every row and cell and change it to red colour wherever already booked list value matches
                                foreach (GridViewRow gvRow in gvBusSeats.Rows)
                                {
                                    for (int i = 0; i <= 4; i++)
                                    {
                                        if (i == 2)
                                            continue;
                                        if (seatList.Contains(gvRow.Cells[i].Text))
                                            gvRow.Cells[i].Attributes.Add("Style", "background-color: red;");
                                    }

                                }
                            }
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

        protected void gvBusSeats_Load(object sender, EventArgs e)
        {

        }


        protected void gvBusSeats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifying if session is valid before executing the code
                if (Session[Constants.UserName] == null)
                {
                    Session.Clear();
                    Response.Redirect(Constants.LoginPage,false);
                }
                lblMessage.Text = string.Empty;

                if (txtSeatNumber.Text == string.Empty || txtPassengerName.Text == string.Empty)
                {
                    lblMessage.Text = Constants.WarningEmptyValue;
                    return;
                }
                Regex regexNameValidator = new Regex(@"^[a-zA-Z\s]+$");
                if (!regexNameValidator.IsMatch(txtPassengerName.Text) ||
                    txtPassengerName.Text.Split(' ').Count() > 2)
                {
                    lblMessage.Text = Constants.WarnPassengerName;
                    return;
                }
                if ((txtPassengerName.Text).Length < 3 || (txtPassengerName.Text).Length > 20)
                {
                    lblMessage.Text = Constants.WarnPassengerNameLength;
                    return;
                }
                try
                {
                    if (Convert.ToInt32(txtSeatNumber.Text) < 1 || Convert.ToInt32(txtSeatNumber.Text) > 40)
                    {
                        lblMessage.Text = Constants.WarningSeatRange;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = Constants.WarningSeatRange;
                    return;
                }
                lstSelectedSeats = (List<string>)Session[Constants.SeatsBooked];
                dictSelectedSeats = (Dictionary<string, string>)Session[Constants.SeatsBookedWithName];
                if (lstSelectedSeats.Contains(txtSeatNumber.Text))
                {
                    lblMessage.Text = Constants.WarningSeatAlreadyBooked;
                    return;
                }
                seatList = (List<string>)Session[Constants.SeatsUnavailable];
                if (seatList.Contains(txtSeatNumber.Text))
                {
                    lblMessage.Text = Constants.WarningSeatNotAvailable;
                    return;
                }
                else
                {
                    if (gvBusSeats.Rows.Count > 0)
                    {
                        //Looping over every row and cell and change it to gree colour wherever value matches
                        foreach (GridViewRow gvRow in gvBusSeats.Rows)
                        {
                            for (int i = 0; i <= 4; i++)
                            {
                                if (i == 2)
                                    continue;
                                if (gvRow.Cells[i].Text == txtSeatNumber.Text)
                                {
                                    ListItem lvItem = new ListItem(txtSeatNumber.Text, txtPassengerName.Text);
                                    //Adding newly selected seat to the dictionary
                                    dictSelectedSeats.Add(txtSeatNumber.Text, txtPassengerName.Text);
                                    lstSelectedSeats.Add(txtSeatNumber.Text);
                                    Session[Constants.SeatsBooked] = lstSelectedSeats;
                                    Session[Constants.SeatsBookedWithName] = dictSelectedSeats;
                                    gvRow.Cells[i].Attributes.Add("Style", "background-color: green;");
                                    gvSelectedSeats.DataSource = dictSelectedSeats;
                                    gvSelectedSeats.DataBind();
                                    return;
                                }
                            }

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

        protected void btnUnselect_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifying if session is valid before executing the code
                //Validating input values seat and passenger name.
                if (Session[Constants.UserName] == null)
                {
                    Session.Clear();
                    Response.Redirect(Constants.LoginPage,false);
                }
                lblMessage.Text = string.Empty;

                if (txtSeatNumber.Text == string.Empty)
                {
                    lblMessage.Text = Constants.WarningSeatEmptyValue;
                    return;
                }
                try
                {
                    if (Convert.ToInt32(txtSeatNumber.Text) < 1 || Convert.ToInt32(txtSeatNumber.Text) > 40)
                    {
                        lblMessage.Text = Constants.WarningSeatRange;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = Constants.WarningSeatRange;
                    return;
                }
                int busID = Convert.ToInt32(Session[Constants.BusID]);
                string journeyDate = Session[Constants.JourneyDate].ToString();
                DataSet dsBusSeats = helper.getBusSeats(busID, journeyDate);
                seatList = dsBusSeats.Tables[1].AsEnumerable().Select(x => x[0].ToString()).ToList();
                if (seatList.Contains(txtSeatNumber.Text))
                {
                    lblMessage.Text = Constants.WarningSeatNotAvailable;
                    return;
                }
                else
                {
                    lstSelectedSeats = (List<string>)Session[Constants.SeatsBooked];
                    dictSelectedSeats = (Dictionary<string, string>)Session[Constants.SeatsBookedWithName];
                    if (!lstSelectedSeats.Contains(txtSeatNumber.Text))
                    {
                        lblMessage.Text = Constants.WarningSeatCannotUnselct;
                        return;
                    }
                    if (gvBusSeats.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvRow in gvBusSeats.Rows)
                        {
                            for (int i = 0; i <= 4; i++)
                            {
                                if (i == 2)
                                    continue;
                                if (gvRow.Cells[i].Text == txtSeatNumber.Text)
                                {
                                    lstSelectedSeats.Remove(txtSeatNumber.Text);
                                    Session[Constants.SeatsBooked] = lstSelectedSeats;
                                    //Removing the seat from dictionary
                                    dictSelectedSeats.Remove(txtSeatNumber.Text);
                                    Session[Constants.SeatsBookedWithName] = dictSelectedSeats;
                                    gvRow.Cells[i].Attributes.Remove("Style");
                                    gvSelectedSeats.DataSource = dictSelectedSeats;
                                    gvSelectedSeats.DataBind();
                                    return;
                                }
                            }

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

        protected void btnFinalBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifying if session is valid before executing the code
                if (Session[Constants.UserName] == null)
                {
                    Session.Clear();
                    Response.Redirect(Constants.LoginPage,false);
                }
                Dictionary<string, string> dictSelectedSeats = (Dictionary<string, string>)Session[Constants.SeatsBookedWithName];
                if (dictSelectedSeats.Count != 0)
                    Response.Redirect(Constants.ConfirmationPage,false);
                else
                    lblMessage.Text = Constants.WarnFinalBooking;
            }
            catch (Exception ex)
            {
                helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }
        }
    }
}