using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineCoachBooking
{
    public partial class ChooseBus : System.Web.UI.Page
    {
        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                //Verifying if session is valid before executing the code
                if (Session[Constants.UserStatus] != null && Session[Constants.UserStatus].ToString() == Constants.Authorised)
                {
                    //Double Verifying if session is valid before executing the code
                    if (Session[Constants.JourneyDate] != null && Session[Constants.Source] != null && Session[Constants.Destination] != null)
                    {
                        try
                        {
                            lblUserName.Text = string.Format(Constants.Welcome, Session[Constants.UserName].ToString());
                            lblSource.Text = Session[Constants.Source].ToString();
                            lblDest.Text = Session[Constants.Destination].ToString();
                            lblJourneyDate.Text = Session[Constants.JourneyDate].ToString();
                            gvChooseBus.DataSource = helper.chooseBus(lblSource.Text, lblDest.Text, lblJourneyDate.Text);
                            gvChooseBus.DataBind();
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

        protected void btnRefine_Click(object sender, EventArgs e)
        {
            //Verifying if session is valid before executing the code
            if (Session[Constants.UserName] == null)
            {
                Session.Clear();
                Response.Redirect(Constants.LoginPage,false);
            }
            Response.Redirect(Constants.HomePage,false);
        }


        protected void gvChooseBus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Verifying if session is valid before executing the code
                if (Session[Constants.UserName] == null)
                {
                    Session.Clear();
                    Response.Redirect(Constants.LoginPage,false);
                }
                if (Session[Constants.UserStatus] == null)
                {
                    Response.Redirect(Constants.LoginPage,false);
                }
                if (e.CommandName == "BookBus")
                {
                    int index = Convert.ToInt16(e.CommandArgument);
                    GridViewRow gvChooseBusRow = gvChooseBus.Rows[index];
                    Session[Constants.BusID] = gvChooseBusRow.Cells[4].Text;
                    Session[Constants.Price] = gvChooseBusRow.Cells[9].Text;
                    Response.Redirect(Constants.BookingPage,false);
                }
            }
            catch (Exception ex)
            {
                helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }
        }



        protected void gvChooseBus_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //Hiding bus ID column as it is not relevant user, 
                //but its needed for backend information for nextp page
                if (e.Row.Cells.Count > 4)
                    e.Row.Cells[4].Visible = false; // hides the bus ID column
            }
            catch (Exception ex)
            {
                helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }
        }
    }
}