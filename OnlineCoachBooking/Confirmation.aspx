<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="OnlineCoachBooking.Confirmation" %>

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
        .auto-style4 {
            width: 288px;
        }
        .auto-style5 {
            width: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td style="background-color: #006a99;color:#ffffff;" class="auto-style2" colspan="3">Final Confirmation Page 
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" Style="float: right" OnClick="btnLogout_Click"></asp:Button>
                        <asp:Label ID="lblUserName" runat="server" Style="margin-right: 15px; float: right"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblConfirmationMessage" runat="server" ForeColor="Green"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkHome" runat="server" OnClick="lnkHome_Click" Visible="False">Click to view your seats booked</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
