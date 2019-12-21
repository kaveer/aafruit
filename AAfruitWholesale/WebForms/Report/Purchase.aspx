<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="AAfruitWholesale.WebForms.Report.Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Purchase Report</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-1 control-label">From</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtFrom" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <label for="inputEmail3" class="col-sm-1 control-label">To</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtTo" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary" runat="server" Text="Search" />
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlError" Visible="false" runat="server">
                    <div class="alert alert-danger">
                        <strong>Error!</strong>
                        <asp:Label ID="lblErrorCredential" runat="server" Text="Select an order to continue"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:GridView ID="grdPurchase" runat="server"></asp:GridView>
                <asp:Button ID="btnDownload" OnClick="btnDownload_Click" CssClass="btn btn-primary" runat="server" Text="Download" />
            </div>
        </div>
    </div>
</asp:Content>
