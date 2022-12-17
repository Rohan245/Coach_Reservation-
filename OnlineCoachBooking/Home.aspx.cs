using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace OnlineCoachBooking
{
    public partial class Home : System.Web.UI.Page
    {
        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // verifing session values before executing the page
                if (Session[Constants.UserStatus] != null && Session[Constants.UserStatus].ToString() == Constants.Authorised)
                {
                    try
                    {
                        lblUserName.Text = string.Format(Constants.Welcome, Session[Constants.UserName].ToString());
                        gvUpcomingSeats.DataSource = helper.getUpcomingSeats(Session[Constants.UserName].ToString());
                        gvUpcomingSeats.DataBind();
                        ddlSource.DataSource = ddlDestination.DataSource = helper.getLocations();
                        ddlSource.DataValueField = ddlDestination.DataValueField = "Location";
                        ddlSource.DataTextField = ddlDestination.DataTextField = "Location";
                        ddlSource.DataBind();
                        ddlDestination.DataBind();
                    }
                    catch (Exception ex)
                    {
                        helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                        Response.Redirect(Constants.ErrorPage,false);
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect(Constants.LoginPage,false);
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(Constants.LoginPage,false);
        }

       
        protected void calTravel_SelectionChanged(object sender, EventArgs e)
        {
            txtTravelDate.Text = calTravel.SelectedDate.ToString("yyyy-MM-dd");
            calTravel.Visible = false;
        }

        protected void imgcraDate_Click(object sender, ImageClickEventArgs e)
        {
            calTravel.Visible = !calTravel.Visible;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session[Constants.UserName] == null)
                {
                    Session.Clear();
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Session Timeout or user logged out');", true);
                    Response.Redirect(Constants.LoginPage,false);
                }
                // Validation of inputs
                if (txtTravelDate.Text == string.Empty)
                {
                    lblWarning.Text = Constants.WarningJourneyDateEmpty;
                    return;
                }
                if (ddlSource.SelectedValue == ddlDestination.SelectedValue)
                {
                    lblWarning.Text = Constants.WarningSourceDestinationSame;
                    return;
                }
                lblWarning.Text = string.Empty;
                Session[Constants.Source] = ddlSource.Text;
                Session[Constants.Destination] = ddlDestination.Text;
                Session[Constants.JourneyDate] = txtTravelDate.Text;

                Response.Redirect(Constants.ChooseBusPage,false);
            }
            catch (Exception ex)
            {
                helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }

        }
        }
}