<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upsert.aspx.cs" Inherits="AAfruitWholesale.WebForms.Supplier.Upsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Add Supplier</h3>
            </div>
            <div class="panel-body">
                <asp:Panel ID="pnlSuccess" Visible="false" runat="server">
                    <div class="alert alert-success">
                        <strong>Success!</strong>
                        <asp:Label ID="Label1" runat="server" Text="Supplier added successfully"></asp:Label>
                    </div>
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
                                    <asp:TextBox ID="txtEmailDetail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Telephone</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtPhoneFix" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Mobile</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtPhoneMobile" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Fax</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtFax" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-primary" runat="server" Text="Add Supplier" />
            </div>
        </div>
    </div>
</asp:Content>
