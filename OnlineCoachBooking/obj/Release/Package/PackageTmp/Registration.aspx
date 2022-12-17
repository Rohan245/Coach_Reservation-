<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineCoachBooking.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 53px;
            font-size: large;
            font-weight: bold;
        }
        .auto-style3 {
            width: 309px;
        }
        .auto-style4 {
            width: 120px;
        }
        .auto-style5 {
            width: 309px;
            height: 26px;
        }
        .auto-style6 {
            width: 120px;
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            width: 157px;
        }
        .auto-style9 {
            height: 26px;
            width: 157px;
        }
        .auto-style10 {
            width: 309px;
            height: 79px;
        }
        .auto-style11 {
            width: 120px;
            height: 79px;
        }
        .auto-style12 {
            width: 157px;
            height: 79px;
        }
        .auto-style13 {
            height: 79px;
        }
        .auto-style14 {
            width: 309px;
            height: 46px;
        }
        .auto-style15 {
            width: 120px;
            height: 46px;
        }
        .auto-style16 {
            height: 46px;
            width: 157px;
        }
        .auto-style17 {
            height: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td style="background-color:#006a99" class="auto-style2" colspan="4">Online Coach Reservation - Registration Page </td>
                </tr>
                <tr>
                    <td class="auto-style14"></td>
                    <td class="auto-style15"></td>
                    <td class="auto-style16"></td>
                    <td class="auto-style17"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">Username:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtUsername" runat="server" Height="22px" Width="145px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblWarnUserName" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">Password:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Height="19px" Width="146px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblWarnPassword" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">Confirm Password:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtConfirmPW" TextMode="Password" runat="server" Height="22px" Width="145px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblWarnConfirmPW" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6">Phone(+353):</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtPhone" runat="server" Height="17px" Width="145px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblWarnPhone" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">Email ID:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtEmailID" runat="server" Height="18px" Width="144px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblEmailID" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style12">
                        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" Height="28px" Width="91px" />
                    </td>
                    <td class="auto-style13"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
