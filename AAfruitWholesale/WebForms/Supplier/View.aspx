<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="AAfruitWholesale.WebForms.Supplier.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Suppliers</h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Edit" />
            </div>
        </div>
    </div>
</asp:Content>
