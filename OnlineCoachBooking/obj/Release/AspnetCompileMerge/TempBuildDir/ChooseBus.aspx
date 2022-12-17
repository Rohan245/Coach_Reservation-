<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseBus.aspx.cs" Inherits="OnlineCoachBooking.ChooseBus" %>

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
            width: 164px;
            height: 76px;
        }

        .auto-style5 {
            width: 226px;
            height: 76px;
        }
        .auto-style6 {
            height: 76px;
        }
        .auto-style7 {
            width: 168px;
            height: 76px;
        }
        .auto-style11 {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td style="background-color: #006a99;color:#ffffff;" class="auto-style2" colspan="4">Choose Your Bus - Registration Page 
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" Style="float: right" OnClick="btnLogout_Click"></asp:Button>
                        <asp:Label ID="lblUserName" runat="server" Text="Label" Style="margin-right: 15px; float: right"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Source</strong>:
                        <asp:Label ID="lblSource" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style7"><strong>Destination</strong>:
                        <asp:Label ID="lblDest" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5"><strong>Journey Date</strong>:
                        <asp:Label ID="lblJourneyDate" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnRefine" runat="server" Text="Refine Your Search" OnClick="btnRefine_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11" style="background-color:#006a99;color:#ffffff;font-weight:bold" colspan="4"><strong>Choose Your Preferred Bus</strong></td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvChooseBus" runat="server" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3"
                            EmptyDataText="Sorry, No Buses Found. Try with differnet routes/dates"
                            OnRowCommand="gvChooseBus_RowCommand"
                            OnRowCreated="gvChooseBus_RowCreated">

                            <Columns>
                                <%--<asp:ButtonField CommandName="Select" Text="Book This Bus" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="AddButton" runat="server"
                                            CommandName="BookBus"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Book This Bus" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BusID" HeaderText="BusID" SortExpression="BusID" Visible="False" />
                            </Columns>

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
            </table>
        </div>
    </form>
</body>
</html>
