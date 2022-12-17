<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="OnlineCoachBooking.Booking" %>

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
            margin-top: 19px;
            margin-left: 15%;
        }

        .auto-style4 {
            width: 542px;
        }
        .auto-style5 {
            width: 332px;
        }
        .auto-style8 {
            width: 8px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <%--CSRF token __RequestVerificationToken added--%>
                    <%= System.Web.Helpers.AntiForgery.GetHtml() %>
                    <td style="background-color: #006a99;color:#ffffff;" class="auto-style2" colspan="3">Seat Booking Page 
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" Style="float: right" OnClick="btnLogout_Click"></asp:Button>
                        <asp:Label ID="lblUserName" runat="server" Style="margin-right: 15px; float: right"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style4" rowspan="3">
                        <asp:GridView ID="gvBusSeats" runat="server" AutoGenerateColumns="False" CellPadding="13" Caption="Driver Side" OnLoad="gvBusSeats_Load"
                            CssClass="auto-style3" ShowHeader="False" OnSelectedIndexChanged="gvBusSeats_SelectedIndexChanged" Width="450px">
                            <Columns>
                                <asp:BoundField DataField="Col1" SortExpression="Col1" ShowHeader="False" />
                                <asp:BoundField DataField="Col2" ShowHeader="False" SortExpression="Col2" />
                                <asp:BoundField DataField="Aisle" ShowHeader="False" SortExpression="Aisle" />
                                <asp:BoundField DataField="Col3" ShowHeader="False" SortExpression="Col3" />
                                <asp:BoundField DataField="Col4" ShowHeader="False" SortExpression="Col4" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td class="auto-style8" rowspan="3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="Label1" runat="server" Text="Enter 1 seat number &amp; passenger name at a time"></asp:Label><br />
                        <asp:TextBox ID="txtSeatNumber" ToolTip="Seat Number" runat="server" Height="16px" Width="23px" ></asp:TextBox>
                        <asp:TextBox ID="txtPassengerName" ToolTip="Passenger Name" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSelect" style="margin-left:8px" runat="server" Text="Select" OnClick="btnSelect_Click" />
                        <asp:Button ID="btnUnselect" style="margin-left:8px" runat="server" Text="Remove" OnClick="btnUnselect_Click" /><br />
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:GridView ID="gvSelectedSeats" runat="server"
                              Caption="Selected Seats" EmptyDataText="No seats selected" AutoGenerateColumns="False" CellPadding="5">
                            <Columns>
                                <asp:BoundField DataField="Key" HeaderText="Seat" SortExpression="Key" />
                                <asp:BoundField DataField="Value" HeaderText="Passenger Name" SortExpression="Value" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnFinalBooking" style="margin-left:40px;margin-bottom:20px" runat="server" Text="Proceed For Booking" OnClick="btnFinalBooking_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
