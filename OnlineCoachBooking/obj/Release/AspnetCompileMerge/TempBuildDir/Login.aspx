<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineCoachBooking.Login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 675px;
        }
        .auto-style2 {
            height: 109px;
        }
        .auto-style3 {
            width: 499px;
        }
        .auto-style4 {
            width: 128px;
        }
        .auto-style5 {
            height: 45px;
            font-size: large;
            font-weight: bold;
        }
        .auto-style6 {
            background-color: #003399;
        }
        .auto-style7 {
            height: 35px;
        }
        .auto-style8 {
            width: 4px;
        }
        .unselectable {
    -webkit-user-select: none;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
            
         <br />
  
            
    <table class="nav-justified">
        <tr style="background-color:#006a99" class="auto-style6">
            <td colspan="5" class="auto-style5">Online Coach Reservation - Login Page</td>
        </tr>
        <tr>
            <td colspan="5" class="auto-style2"></td>
        </tr>
        <tr>
            <td colspan="5" class="auto-style7">
                <asp:Label ID="lblWarning" runat="server" style="margin-left:35%;color:red;margin-right:5px"></asp:Label>
                <asp:LinkButton ID="lbUnlock" runat="server" OnClick="lbUnlock_Click" Visible="False">Click To Unlock</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4"><strong>User ID</strong></td>
            <td>
                <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4"><strong>Password</strong></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4"><strong>Captcha</strong></td>
            <td>
                <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <asp:Label ID="lblCaptchca" CssClass="unselectable" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#660033" BackColor="#FF9933" BorderColor="#990000" Font-Names="Comic Sans MS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Login" Width="74px" OnClick="btnLogin_Click" style="height: 26px" />
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4"><strong>No Account?</strong></td>
            <td>
                <asp:LinkButton ID="lbSignUp" runat="server" OnClick="lbSignUp_Click">Sign up here</asp:LinkButton>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
    </table>
        
    </form>
</body>
</html>

