<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="AAfruitCustomer.WebForms.More.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Setting</h3>
            </div>
            <div class="panel-body">
                <ul class="nav nav-tabs">
                    <li role="presentation" class="active"><a href="#">Credentials</a></li>
                </ul>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Username</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="TextBox12" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Password</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">re-enter</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Update" />
            </div>
        </div>
    </div>
</asp:Content>
