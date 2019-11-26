<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="AAfruitWholesale.WebForms.Sale.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Sales Transaction</h3>
            </div>
            <div class="panel-body">
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="LinkButton6" runat="server">Pending</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="LinkButton1" runat="server">Processing</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="LinkButton2" runat="server">Await payment</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="LinkButton3" runat="server">Dispatched</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="LinkButton4" runat="server">Delivered</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="LinkButton5" runat="server">Returned/incomplete</asp:LinkButton></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Panel ID="pnlPending" runat="server">
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Process" />
                        </asp:Panel>
                        <asp:Panel ID="pnlProcessing" runat="server">
                            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                            <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Mark as await payment" />
                        </asp:Panel>
                        <asp:Panel ID="pnlAwaitPayment" runat="server">
                            <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                            <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Dispatch" />
                        </asp:Panel>
                        <asp:Panel ID="pnlDispatched" runat="server">
                            <asp:GridView ID="GridView4" runat="server"></asp:GridView>
                            <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Mark as delivered" />
                        </asp:Panel>
                        <asp:Panel ID="pnlDelivered" runat="server">
                            <asp:GridView ID="GridView5" runat="server"></asp:GridView>
                        </asp:Panel>
                        <asp:Panel ID="pnlReturned" runat="server">
                            <asp:GridView ID="GridView6" runat="server"></asp:GridView>
                            <asp:Button ID="Button6" CssClass="btn btn-primary" runat="server" Text="Process" />
                            <asp:Button ID="Button5" CssClass="btn btn-primary" runat="server" Text="Mark as pending" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
