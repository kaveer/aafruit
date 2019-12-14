<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="AAfruitCustomer.WebForms.Main.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Details</h3>
            </div>
            <div class="panel-body">
                <asp:Panel ID="pnlSuccess" Visible="false" runat="server">
                    <div class="alert alert-success">
                        <strong>Success!</strong>
                        <asp:Label ID="Label1" runat="server" Text="Record updated successfully"></asp:Label>
                    </div>
                    <br />
                </asp:Panel>
                
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">Details</a></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Name</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtName" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Surname</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtSurname" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Address</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtAddress" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Country</label>
                                <div class="col-sm-11">
                                    <asp:DropDownList ID="drpCountry" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlErrorDetails" Visible="false" runat="server">
                            <div class="alert alert-danger">
                                <strong>Error!</strong>
                                <asp:Label ID="lblErrorDetails" runat="server" Text="Label"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">Contact details</a></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Email</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Fix</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtFixLine" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Mobile</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtmobile" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlErrorContact" Visible="false" runat="server">
                            <div class="alert alert-danger">
                                <strong>Error!</strong>
                                <asp:Label ID="lblErrorContact" runat="server" Text="Label"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">Company details</a></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Company</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtCompany" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">BRN</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtBRN" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Note</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtNote" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlErrorCompany" Visible="false" runat="server">
                            <div class="alert alert-danger">
                                <strong>Error!</strong>
                                <asp:Label ID="lblErrorCompany" runat="server" Text="Label"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-primary" runat="server" Text="Update" />
                
            </div>
        </div>
    </div>
</asp:Content>
