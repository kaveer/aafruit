<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="AAfruitWholesale.WebForms.Stock.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Configuration</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Fruit</label>
                        <div class="col-sm-11">
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Description</label>
                        <div class="col-sm-11">
                            <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Available</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-sm-1 control-label">Unit</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Unit price</label>
                        <div class="col-sm-11">
                            <asp:TextBox ID="TextBox3" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Update" />
            </div>
        </div>
    </div>
</asp:Content>
