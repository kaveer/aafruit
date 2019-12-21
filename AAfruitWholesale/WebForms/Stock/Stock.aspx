<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="AAfruitWholesale.WebForms.Stock.Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Add Stock</h3>
            </div>
            <div class="panel-body">
                <asp:Panel ID="pnlSuccess" Visible="false" runat="server">
                    <div class="alert alert-success">
                        <strong>Success!</strong>
                        <asp:Label ID="Label1" runat="server" Text="Record added successfully"></asp:Label>
                    </div>
                    <br />
                </asp:Panel>
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">New stock details</a></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Fruit</label>
                                <div class="col-sm-11">
                                    <asp:DropDownList ID="drpFruit" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                             <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Supplier</label>
                                <div class="col-sm-11">
                                    <asp:DropDownList ID="drpSuppliers" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Date</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Quantity</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtQuantity" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Purchase price</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtPurchasePrice" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Note</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtNote" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlError" Visible="false" runat="server">
                            <div class="alert alert-danger">
                                <strong>Error!</strong>
                                <asp:Label ID="lblErrorFruit" runat="server" Text="Label"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-primary" runat="server" Text="Add" />
            </div>
        </div>
    </div>
</asp:Content>
