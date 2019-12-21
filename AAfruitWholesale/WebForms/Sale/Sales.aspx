<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="AAfruitWholesale.WebForms.Sale.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .table-condensed tr th {
            border: 0px solid #6e7bd9;
            color: white;
            background-color: #6e7bd9;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #000;
        }

        tr:nth-child(even) {
            background: #f8f7ff
        }

        tr:nth-child(odd) {
            background: #fff;
        }
    </style>

    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Sales Transaction</h3>
            </div>
            <div class="panel-body">
                <ul class="nav nav-tabs">
                    <li id="liPendind" role="presentation" runat="server">
                        <asp:LinkButton ID="lkPending" OnClick="lkPending_Click" runat="server">Pending</asp:LinkButton></li>
                    <li id="liProcessing" role="presentation" runat="server">
                        <asp:LinkButton ID="lkProcessing" OnClick="lkProcessing_Click" runat="server">Processing</asp:LinkButton></li>
                    <li id="liReady" role="presentation" runat="server">
                        <asp:LinkButton ID="lkReadyForDelivery" OnClick="lkReadyForDelivery_Click" runat="server">Ready for delivery</asp:LinkButton></li>
                    <li id="liDelivered" role="presentation" runat="server">
                        <asp:LinkButton ID="lkDelivered" OnClick="lkDelivered_Click" runat="server">Delivered</asp:LinkButton></li>
                    <li id="liReturned" role="presentation" runat="server">
                        <asp:LinkButton ID="lkReturened" OnClick="lkReturened_Click" runat="server">Returned/incomplete</asp:LinkButton></li>
                    <li id="liHold" role="presentation" runat="server">
                        <asp:LinkButton ID="lkHold" OnClick="lkHold_Click" runat="server">Hold</asp:LinkButton></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:GridView
                            ID="grdOrder"
                            UseAccessibleHeader="true"
                            CssClass="table table-condensed table-hover"
                            OnRowDataBound="grdOrder_RowDataBound"
                            OnSelectedIndexChanged="grdOrder_SelectedIndexChanged"
                            runat="server">
                        </asp:GridView>
                        <asp:Panel ID="pnlError" Visible="false" runat="server">
                            <div class="alert alert-danger">
                                <strong>Error!</strong>
                                <asp:Label ID="lblErrorCredential" runat="server" Text="Select an order to continue"></asp:Label>
                            </div>
                        </asp:Panel>
                        <asp:Button ID="btnPending" OnClick="btnPending_Click" CssClass="btn btn-primary" runat="server" Text="Move to pending" />
                        <asp:Button ID="btnProcessing" OnClick="btnProcessing_Click" CssClass="btn btn-primary" runat="server" Text="Process" />
                        <asp:Button ID="btnReadyForDelivery" OnClick="btnReadyForDelivery_Click" CssClass="btn btn-primary" runat="server" Text="Move to ready for delivery" />
                        <asp:Button ID="btnDelivered" OnClick="btnDelivered_Click" CssClass="btn btn-primary" runat="server" Text="Move to delivered" />
                        <asp:Button ID="btnReturned" OnClick="btnReturned_Click" CssClass="btn btn-primary" runat="server" Text="Move to returned" />
                        <asp:Button ID="btnHold" OnClick="btnHold_Click" CssClass="btn btn-primary" runat="server" Text="Move to Hold" />
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
