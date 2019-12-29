<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AAfruitCustomer.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <%--<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <title>Error</title>
    <%--    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>--%>

    <%--<webopt:BundleReference runat="server" Path="~/Content/css" />--%>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <style>
        body {
            padding-top: 50px;
            padding-bottom: 20px;
        }

        * {
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }

        /*body {
            padding: 0;
            margin: 0;
        }*/

        #notfound {
            position: relative;
            height: 100vh;
        }

            #notfound .notfound {
                position: absolute;
                left: 50%;
                top: 50%;
                -webkit-transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
                transform: translate(-50%, -50%);
            }

        .notfound {
            max-width: 520px;
            width: 100%;
            line-height: 1.4;
            text-align: center;
        }

            .notfound .notfound-404 {
                position: relative;
                height: 200px;
                margin: 0px auto 20px;
                z-index: -1;
            }

                .notfound .notfound-404 h1 {
                    font-family: 'Montserrat', sans-serif;
                    font-size: 236px;
                    font-weight: 200;
                    margin: 0px;
                    color: #211b19;
                    text-transform: uppercase;
                    position: absolute;
                    left: 50%;
                    top: 50%;
                    -webkit-transform: translate(-50%, -50%);
                    -ms-transform: translate(-50%, -50%);
                    transform: translate(-50%, -50%);
                }

                .notfound .notfound-404 h2 {
                    font-family: 'Montserrat', sans-serif;
                    font-size: 28px;
                    font-weight: 400;
                    text-transform: uppercase;
                    color: #211b19;
                    background: #fff;
                    padding: 10px 5px;
                    margin: auto;
                    display: inline-block;
                    position: absolute;
                    bottom: 0px;
                    left: 0;
                    right: 0;
                }

            .notfound a {
                font-family: 'Montserrat', sans-serif;
                display: inline-block;
                font-weight: 700;
                text-decoration: none;
                color: #fff;
                text-transform: uppercase;
                padding: 13px 23px;
                background: #ff6300;
                font-size: 18px;
                -webkit-transition: 0.2s all;
                transition: 0.2s all;
            }

                .notfound a:hover {
                    color: #ff6300;
                    background: #211b19;
                }

        @media only screen and (max-width: 767px) {
            .notfound .notfound-404 h1 {
                font-size: 148px;
            }
        }

        @media only screen and (max-width: 480px) {
            .notfound .notfound-404 {
                height: 148px;
                margin: 0px auto 10px;
            }

                .notfound .notfound-404 h1 {
                    font-size: 86px;
                }

                .notfound .notfound-404 h2 {
                    font-size: 16px;
                }

            .notfound a {
                padding: 7px 15px;
                font-size: 14px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <nav class="navbar navbar-inverse">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">AA Fruits</a>
                    </div>
                </div>
            </nav>
        </div>

        <div class="container">
            <div class="jumbotron">
                <div id="notfound">
                    <div class="notfound">
                        <div class="notfound-404">
                            <h1>Oops!</h1>
                            <h2>500 - Internal Server Error</h2>
                        </div>
                        <p>
                            <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                        </p>
                        <a class="btn btn-primary" href="~/login.aspx">Go TO Homepage</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
