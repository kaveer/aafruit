<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="AAfruitCustomer.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <nav class="navbar navbar-default navbar-fixed-top">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">AA fruits - Customers</a>
                    </div>
                </div>
            </nav>
        </div>
        <br />
        <div class="container">
            <div class="jumbotron">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">SignUp</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">
                            <li role="presentation" class="active"><a href="#">Credentials</a></li>
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
                                        <label for="inputEmail3" class="col-sm-1 control-label">Password</label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="inputEmail3" class="col-sm-1 control-label">re-enter</label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtReEnterPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlErrorCredential" Visible="false" runat="server">
                                    <div class="alert alert-danger">
                                        <strong>Error!</strong>
                                        <asp:Label ID="lblErrorCredential" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
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
                                        <label for="inputEmail3" class="col-sm-1 control-label">Fix</label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtPhoneFix" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="inputEmail3" class="col-sm-1 control-label">Mobile</label>
                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtPhoneMobile" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
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
                        <asp:Button ID="btnSignUp" OnClick="btnSignUp_Click" CssClass="btn btn-primary" runat="server" Text="Sign Up" />
                    </div>
                </div>
            </div>
        </div>

        <footer>
            <div class="container">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="container-fluid text-center text-md-left">
                            <div class="row">
                                <div class="col-md-6 mt-md-0 mt-3">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <h3 class="panel-title text-uppercase">Footer Content</h3>
                                        </div>
                                        <div class="panel-body">
                                            <p>Here you can use rows and columns to organize your footer content.</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 mt-md-0 mt-3">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <h3 class="panel-title text-uppercase">links</h3>
                                        </div>
                                        <div class="panel-body text-left">
                                            <ul class="list-unstyled">
                                                <li>
                                                    <asp:HyperLink ID="HyperLink5" runat="server"><span class="glyphicon glyphicon-globe" aria-hidden="true"></span> Mail</asp:HyperLink></li>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink6" runat="server"><span class="glyphicon glyphicon-globe" aria-hidden="true"></span> Facebook</asp:HyperLink></li>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink7" runat="server"><span class="glyphicon glyphicon-globe" aria-hidden="true"></span> Twitter</asp:HyperLink></li>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink8" runat="server"><span class="glyphicon glyphicon-globe" aria-hidden="true"></span> LinkedIn</asp:HyperLink></li>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink9" runat="server"><span class="glyphicon glyphicon-globe" aria-hidden="true"></span> Instagram</asp:HyperLink></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-center">
                        © 2019 Copyright:<a href="#">AA fruits</a>
                    </div>
                </div>
            </div>
        </footer>

    </form>
</body>
</html>
