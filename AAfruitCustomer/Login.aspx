<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AAfruitCustomer.Login" %>

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
                <h1>Welcome to AA fruits</h1>

                <div class="form-group">
                    <label for="exampleInputEmail1">Email address</label>
                    <asp:TextBox TextMode="Email" ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Password</label>
                    <asp:TextBox TextMode="Password" ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-primary" runat="server" Text="Login" />
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
