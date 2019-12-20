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
                            <asp:DropDownList ID="drpFruit" AutoPostBack="true" OnSelectedIndexChanged="drpFruit_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Fruit</label>
                        <div class="col-sm-11">
                            <asp:TextBox ID="txtname" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Description</label>
                        <div class="col-sm-11">
                            <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Quantity</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtQuatity" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-sm-1 control-label">Unit</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="drpMeasureUnit" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">Unit price</label>
                        <div class="col-sm-11">
                            <asp:TextBox ID="txtUnitPrice" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlError" Visible="false" runat="server">
                    <div class="alert alert-danger">
                        <strong>Error!</strong>
                        <asp:Label ID="lblErrorDetails" runat="server" Text="Label"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlSuccess" Visible="false" runat="server">
                    <div class="alert alert-success">
                        <strong>Success!</strong>
                        <asp:Label ID="Label1" runat="server" Text="Inventory update successfully"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-primary" runat="server" Text="Update" />
            </div>
        </div>
    </div>
</asp:Content>
