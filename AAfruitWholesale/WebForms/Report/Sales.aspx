<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="AAfruitWholesale.WebForms.Report.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Sales Report</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">From</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-sm-1 control-label">To</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox4" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Search" />
                        </div>
                    </div>
                </div>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Print" />
            </div>
        </div>
    </div>
</asp:Content>
