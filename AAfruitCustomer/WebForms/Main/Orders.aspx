<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="AAfruitCustomer.WebForms.Main.Orders" %>

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
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="lkPending" OnClick="lkPending_Click" runat="server">Pending</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="lkProcessing" OnClick="lkProcessing_Click" runat="server">Processing</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="lkReadyForDelivery" OnClick="lkReadyForDelivery_Click" runat="server">Ready to deliver</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="lkDelivery" OnClick="lkDelivery_Click" runat="server">Delivered</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="lkReturned" OnClick="lkReturned_Click" runat="server">Returned/incomplete</asp:LinkButton></li>
                    <li role="presentation" class="active">
                        <asp:LinkButton ID="lkHold" OnClick="lkHold_Click" runat="server">Hold</asp:LinkButton></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Panel ID="pnlGrid" runat="server">
                            <asp:GridView 
                                ID="grdOrder" 
                                UseAccessibleHeader="true" 
                                CssClass="table table-condensed table-hover" 
                                runat="server">

                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
