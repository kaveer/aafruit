<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="AAfruitWholesale.WebForms.Customer.Customer" %>

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
                <h3 class="panel-title">Customer</h3>
            </div>
            <div class="panel-body">
                <asp:GridView
                    ID="grdCustomer"
                    UseAccessibleHeader="true"
                    CssClass="table table-condensed table-hover"
                    OnRowDataBound="grdCustomer_RowDataBound"
                    OnSelectedIndexChanged="grdCustomer_SelectedIndexChanged"
                    runat="server">
                </asp:GridView>
                <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-primary" runat="server" Text="Delete" />
                <asp:Button ID="btnSuspend" OnClick="btnSuspend_Click" CssClass="btn btn-primary" runat="server" Text="Suspend" />
                <br />
                <br />
                <asp:Panel ID="pnlError" Visible="false" runat="server">
                    <div class="alert alert-danger">
                        <strong>Error!</strong>
                        <asp:Label ID="lblErrorCredential" runat="server" Text="Select a customer to continue"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
