<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CATracy_FinalProject.Webforms.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 101px;
        }
        .auto-style3 {
            width: 166px;
        }
    </style>
    <link rel="stylesheet" href="~/Webforms/CheckoutStyle.css"/>
</head>
<body style="width: 571px; height: 360px">
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="productListBox" runat="server" Height="199px" Width="566px" AutoPostBack="True" OnSelectedIndexChanged="productListBox_SelectedIndexChanged"></asp:ListBox>
    
    </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Change Quantity:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="quantityChangeTB" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="acceptBtn" runat="server" Text="Accept Change" Width="116px" OnClick="acceptBtn_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="payBtn" runat="server" Text="Pay" Width="91px" OnClick="payBtn_Click" />
                </td>
                <td>
                    <asp:Button ID="exitBtn" runat="server" ForeColor="Red" Text="Exit" Width="97px" OnClick="exitBtn_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total:</td>
                <td class="auto-style3">
                    <asp:Label ID="totalLabel" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
