<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineCoachBooking.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 45px;
            font-size: large;
            font-weight: bold;
        }
        .auto-style4 {
            height: 15px;
        }
        .auto-style5 {
            height: 81px;
        }
        .auto-style6 {
            height: 161px;
        }
        .auto-style7 {
            width: 134px;
        }
        .auto-style8 {
            width: 144px;
        }
        .auto-style10 {
            width: 100px;
        }
        .auto-style11 {
            width: 19px;
        }
        .auto-style12 {
            height: 166px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr style="background-color:#006a99;color:#ffffff;" class="auto-style3">
            <td class="auto-style4" colspan="2">
                Online Coach Reservation - Home Page
                <asp:button ID="btnLogout" runat="server" Text="Logout" style="float:right" OnClick="btnLogout_Click"></asp:button>
                <asp:Label ID="lblUserName" runat="server" Text="Label" style="margin-right:15px;float:right"></asp:Label>
            </td>
        </tr>
        <tr style="background-color:#ffffff" class="auto-style3">
            <td class="auto-style6" colspan="2">
                <asp:GridView ID="gvUpcomingSeats" runat="server" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                    Caption="Information of Your upcoming trips" CaptionAlign="Left" 
                    EmptyDataText="You dont have any upcoming trips reserved">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <table class="auto-style1">
                    <tr>
                        <td colspan="5" style="background-color:#006a99;color:#ffffff;font-weight:bold">Book your new trip. Search for the routes below.</td>
                    </tr>
                    <tr>
                        <td colspan="4" >
                            <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td >&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <strong>Journey From:</strong><asp:DropDownList ID="ddlSource"  runat="server"></asp:DropDownList>
                        </td>
                        <td class="auto-style8">
                            <strong>Destination</strong>:<asp:DropDownList ID="ddlDestination" runat="server"></asp:DropDownList>
                        </td>
                        <td class="auto-style10">
                           
                            <strong>Journey Date:</strong><asp:TextBox ID="txtTravelDate" runat="server" ReadOnly="true"  ></asp:TextBox>
                           
                            <br />
                        </td>
                        <td class="auto-style11">
                           <asp:ImageButton ID="imgcraDate" style="margin-top:18px" runat="server"
                       AlternateText="Click here to display calendar" ImageUrl="~/Images/Calendar.png"
                       onclick="imgcraDate_Click" Height="24px" />
                           
                        </td>
                        <td rowspan="2">
                   <asp:Calendar ID="calTravel" runat="server"
                       onselectionchanged="calTravel_SelectionChanged" Visible="False">
                  </asp:Calendar>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12" colspan="4">
                            <asp:Button ID="btnSearch" style="margin-left:40%;margin-bottom:20%" runat="server" OnClick="btnSearch_Click" Text="Search" />
                        </td>
                    </tr>
                    </table>
            </td>
            <td class="auto-style5"></td>
        </tr>
    </table>
    </form>
</body>
</html>
