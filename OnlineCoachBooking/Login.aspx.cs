using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace OnlineCoachBooking
{
    public partial class Login : System.Web.UI.Page
    {

        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Generate a  captcha
            if(!Page.IsPostBack)
            lblCaptchca.Text = helper.generateCapthca();

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserID.Text;
                string password = txtPassword.Text;

                //Input Valiation. Throw warning if feilds are empty or contains invalid values.
                
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(txtCaptcha.Text))
                {
                    lblWarning.Text = Constants.WarningEmptyValue;
                    //Generate a  captcha
                    lblCaptchca.Text = helper.generateCapthca();
                    return;
                }
                if (txtCaptcha.Text != lblCaptchca.Text)
                {
                    lblWarning.Text = Constants.WarningInvalidCaptcha;
                    //Generate a  captcha
                    lblCaptchca.Text = helper.generateCapthca();
                    return;
                }
                if (userName.Length > 15 || password.Length > 15)
                {
                    lblWarning.Text = Constants.WarningInvalidValue;
                    //Generate a  captcha
                    lblCaptchca.Text = helper.generateCapthca();
                    return;
                }
                //Xss and SQL injection are prevented
                if (userName.Contains(" ") || password.Contains(" "))
                {
                    lblWarning.Text = Constants.WarningValueWithSpace;
                    //Generate a  captcha
                    lblCaptchca.Text = helper.generateCapthca();
                    return;
                }
                //now eligible efor athentication
                string[] userAuthenticationStatus = helper.authenticateUser(userName, password);
                string userStatus = userAuthenticationStatus[0];
                int wrongLoginCount = Convert.ToInt16(userAuthenticationStatus[1]);
                //session variables initialized
                Session[Constants.UserName] = userName;
                Session[Constants.UserStatus] = userStatus;
                switch (userStatus)
                {
                    case Constants.Authorised:
                        //inserting log msg in database in history table
                        helper.insertLog(userName, Constants.logMessageLogin);
                        //User is redirected to home page after authorisation
                        Response.Redirect(Constants.HomePage,false);
                        break;
                    case Constants.Unauthorised:
                        if (wrongLoginCount == 0)
                        {
                            lblWarning.Text = Constants.LoginErrorMessage;
                            //Generate a  captcha
                            lblCaptchca.Text = helper.generateCapthca();
                        }
                        else if (wrongLoginCount < 3)
                        {
                            lblWarning.Text = Constants.LoginLockWarningMessage;
                            //Generate a  captcha
                            lblCaptchca.Text = helper.generateCapthca();
                        }
                        //Account is locked
                        else if (wrongLoginCount >= 3)
                        {
                            lblWarning.Text = Constants.AccountLockedMessage;
                            lbUnlock.Visible = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                helper.insertLog(txtUserID.Text, ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }
        }

        protected void lbUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                //Generate a random password. 8 characters password generates here
                string newRandomPassword = helper.generateRandomPassword();

                string userName = Session[Constants.UserName].ToString();
                string emailID = helper.UnlockAccount(userName, newRandomPassword);
                lblWarning.Text = Constants.AccountUnlockedMessage;
                lbUnlock.Visible = false;
                //Generate a  captcha
                lblCaptchca.Text = helper.generateCapthca();

                //Send email code
                //Referred https://stackoverflow.com/questions/18326738/how-to-send-email-in-asp-net-c-sharp

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(emailID);
                mail.From = new MailAddress(Constants.SMTPEmailAddress, Constants.EmailDisaplyName, System.Text.Encoding.UTF8);
                mail.Subject = Constants.MailSubject;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = Constants.NewPasswordMessage + newRandomPassword;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(Constants.NetworkEmailAddress, Constants.NetworkEmailPassword);
                client.Port = 587;
                client.Host = Constants.SMTPHost;
                client.EnableSsl = true;
                try
                {
                    client.Send(mail);
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...')");
                }
                catch (Exception ex)
                {
                    helper.insertLog(txtUserID.Text, ex.Message);
                    Response.Redirect(Constants.ErrorPage, false);
                }
            }
            catch (Exception ex)
            {
                helper.insertLog(Session[Constants.UserName].ToString(), ex.Message);
                Response.Redirect(Constants.ErrorPage,false);
            }
        }



        protected void lbSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constants.RegistrationPage,false);
        }
    }

}