<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ConsignmentShopFront.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="header">
            <asp:Label ID="LabelHeader" runat="server" Font-Bold="True" Font-Size="Large" Text="Consignment Shop"></asp:Label>
        </div>
        <div class ="productListLabels">
            <asp:Label ID="LabelProducts" runat="server" Font-Bold="True" Font-Size="Medium" Text="Products"></asp:Label>
            <span style="display:inline-block; width: 235px;"></span>
            <asp:Label ID="LabelShoppingCart" runat="server" Font-Bold="True" Text="Shopping Cart"></asp:Label>
        </div>

        <div class="productLists">

        <table>
            <tr>

                <td align="right" style="height: 20%; padding-left: 2%"> 
                    <asp:ListBox ID="ListBoxProducts" runat="server"></asp:ListBox>
                </td>
                <td align="right" style="height: 20%; padding-left: 2%"> 
                    <asp:Button ID="ButtonAddToCart" runat="server" Text="Add To Cart-&gt;" OnClick="ButtonAddToCart_Click" />
                <!--<br />
                    #<asp:Button ID="Button1" runat="server" Text="Add To Cart-&gt;" />
                    -->
                </td>
                <td align="right" style="height: 20%; padding-left: 2%">
                    <asp:ListBox ID="ListBoxShoppingCart" runat="server"></asp:ListBox>
                </td>

            </tr>

        </table>

    </div>
    <span style="display:inline-block; width: 405px;"></span>
    <asp:Button ID="ButtonBuy" runat="server" Text="Buy" OnClick="ButtonBuy_Click" />
    </form>
</body>
</html>
