<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="AAfruitWholesale.WebForms.Stock.Inventory" %>

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
                <h3 class="panel-title">Inventory</h3>
            </div>
            <div class="panel-body">
                <asp:GridView
                    ID="grdInventory"
                    runat="server"
                    UseAccessibleHeader="true"
                    CssClass="table table-condensed table-hover"
                    OnRowDataBound="grdInventory_RowDataBound"
                    OnSelectedIndexChanged="grdInventory_SelectedIndexChanged">
                </asp:GridView>

                <asp:Panel ID="pnlError" Visible="false" runat="server">
                    <div class="alert alert-danger">
                        <strong>Error!</strong>
                        <asp:Label ID="lblErrorCredential" runat="server" Text="Select a fruit to continue"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-primary" runat="server" Text="Add" />
                <asp:Button ID="btnEdit" OnClick="btnEdit_Click" CssClass="btn btn-primary" runat="server" Text="Edit" />
            </div>
        </div>
    </div>
</asp:Content>
