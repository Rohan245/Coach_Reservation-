using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace OnlineCoachBooking
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblWarnUserName.Text = lblWarnPhone.Text = lblEmailID.Text = lblWarnPassword.Text = lblWarnConfirmPW.Text = string.Empty;
            bool validationSuccess = true;
            Helper helper = new Helper();
            Regex regexNameValidator = new Regex("^[a-zA-Z0-9]{5,15}$");
            if (!regexNameValidator.IsMatch(txtUsername.Text))
            {
                validationSuccess = false;
                lblWarnUserName.Text = Constants.WarnRegUserName;
            }
            Regex regexPhoneValidator = new Regex("^[0-9]{10}$");
            if (!regexPhoneValidator.IsMatch(txtPhone.Text))
            {
                validationSuccess = false;
                lblWarnPhone.Text = Constants.WarnRegPhone;
            }
            if (!ValidateEmail(txtEmailID.Text))
            {
                validationSuccess = false;
                lblEmailID.Text = Constants.WarnRegEmailID;
            }
            if (!ValidatePassword(txtPassword.Text))
            {
                validationSuccess = false;
                lblWarnPassword.Text = Constants.WarnRegPassword;
            }
            if (txtPassword.Text != txtConfirmPW.Text)
            {
                validationSuccess = false;
                lblWarnConfirmPW.Text = Constants.WarnConfirmPW;
            }

            if (validationSuccess)
            {
                string userExists = helper.checkUserExists(txtUsername.Text, txtPhone.Text, txtEmailID.Text);
                switch(userExists)
                {
                    case Constants.UserName:
                        lblWarnUserName.Text = Constants.UserNameExists;
                        lblWarnUserName.Visible = true;
                        break;
                    case Constants.Phone:
                        lblWarnUserName.Text = Constants.PhoneExists;
                        lblWarnUserName.Visible = true;
                        break;
                    case Constants.EmailID:
                        lblWarnUserName.Text = Constants.EmailIDExists;
                        lblWarnUserName.Visible = true;
                        break;
                    case Constants.Valid:
                        helper.RegisterUser(txtUsername.Text, txtPassword.Text, txtPhone.Text, txtEmailID.Text);
                        Page.RegisterStartupScript("UserMsg", "<script>alert('User registered successfully')");
                        Response.Redirect(Constants.LoginPage,false);
                        break;
                }
            }
        }

        private bool ValidateEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Referred https://stackoverflow.com/questions/5859632/regular-expression-for-password-validation

        private bool ValidatePassword(string password)
        {
            var input = password;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}