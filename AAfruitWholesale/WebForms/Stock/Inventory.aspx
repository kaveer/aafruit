<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="AAfruitWholesale.WebForms.Stock.Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Inventory</h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Add" />
                <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Edit" />
                <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Configure" />
            </div>
        </div>
    </div>
</asp:Content>
