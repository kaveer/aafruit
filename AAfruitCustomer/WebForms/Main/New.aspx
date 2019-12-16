<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="AAfruitCustomer.WebForms.Main.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function CalculatePrice() {
            var quantity = document.getElementById('<%= txtQuantity.ClientID %>');
            var available = document.getElementById('<%= hidAvailable.ClientID %>');
            var unitPrice = document.getElementById('<%= hidUnitPrice.ClientID %>');
            var totalPrice = document.getElementById('<%= txtTotalPrice.ClientID %>');
            var measurementType = document.getElementById('<%= hidMeasurement.ClientID %>');
            var discountPercentage = document.getElementById('<%= txtDiscount.ClientID %>');
            var discountTotalPrice = document.getElementById('<%= txtDiscountPrice.ClientID %>');

            var discountJson = document.getElementById('<%= hidDiscount.ClientID %>');
            var discountObject = JSON.parse(discountJson.value);
            var discount = null;

            if (quantity.value > 0) {
                totalPrice.value = parseFloat(quantity.value * unitPrice.value).toFixed(2)
                for (i = 0; i < discountObject.length; i++) {
                    var item = discountObject[i];
                    if (totalPrice.value >= item.dePriceRange && totalPrice.value <= item.dePriceRangeMax) {
                        discount = discountObject.find(x => x.iDiscountId >= item.iDiscountId)
                        break;
                    }
                }

                if (discount != null) {
                    discountPercentage.value = discount.iValue + "%";
                    var percentageDeduce = (parseFloat(totalPrice.value) * parseFloat(discount.iValue)) / 100;
                    discountTotalPrice.value = parseFloat(totalPrice.value - percentageDeduce)
                } else {
                    discountPercentage.value = null;
                    discountTotalPrice.value = null;
                }

                document.getElementById('<%= txtDiscount.ClientID %>').value = discountPercentage.value;

            } else {
                alert("Please enter quantity")
            }
        }
    </script>
    <asp:HiddenField ID="hidAvailable" runat="server" />
    <asp:HiddenField ID="hidUnitPrice" runat="server" />
    <asp:HiddenField ID="hidMeasurement" runat="server" />
    <asp:HiddenField ID="hidDiscount" runat="server" />

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
                                    <asp:DropDownList ID="drpFruit" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Available</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtAvailable" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Unit price</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtUnitPrice" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Quantity</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtQuantity" OnBlur="CalculatePrice()" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Request on</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtRequestedOn" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Deadline</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtDeadLine" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Total price</label>
                                <div class="col-sm-11">
                                    <asp:TextBox ID="txtTotalPrice" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-1 control-label">Discount</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtDiscount" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>

                                </div>
                                <label for="inputEmail3" class="col-sm-1 control-label">Discount price</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtDiscountPrice" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
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
                                <asp:Label ID="Label1" runat="server" Text="Order placed successfully"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <asp:Button ID="btnOrder" OnClick="btnOrder_Click" CssClass="btn btn-primary" runat="server" Text="Place order" />
            </div>
        </div>
    </div>
</asp:Content>
