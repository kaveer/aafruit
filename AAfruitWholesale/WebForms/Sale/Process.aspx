<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Process.aspx.cs" Inherits="AAfruitWholesale.WebForms.Sale.Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Process Sales</h3>
            </div>
            <div class="panel-body">

                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Select order</label>
                                <div class="col-sm-11">
                                    <asp:DropDownList ID="drpOrders" AutoPostBack="true" OnSelectedIndexChanged="drpOrders_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Fruit</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtfruit" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Available</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtQuantityAvailable" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Company</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtCompany" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Request on</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtRequestedOn" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Deadline</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtDeadLine" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Quantity</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtQuantity" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblTotalPrice" Font-Bold="true" CssClass="col-sm-1 control-label" runat="server" Text="Total price"></asp:Label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="TxtTotalPrice" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
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
                                <asp:Label ID="Label1" runat="server" Text="Order processed successfully"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnProcess" OnClick="btnProcess_Click" CssClass="btn btn-primary" runat="server" Text="Process" />
            </div>
        </div>
    </div>
</asp:Content>
