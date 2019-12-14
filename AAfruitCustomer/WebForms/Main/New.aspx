<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="AAfruitCustomer.WebForms.Main.New" %>

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
                                <label for="inputEmail3" class="col-sm-1 control-label">Fruit</label>
                                <div class="col-sm-5">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Available</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Unit price</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" TextMode="SingleLine" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Request on</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Deadline</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Quantity</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Total price</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Discount</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server"></asp:TextBox>

                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Discount price</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Place order" />
            </div>
        </div>
    </div>
</asp:Content>
