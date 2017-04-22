<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingPlazaForm.aspx.cs" Inherits="CATracy_FinalProject.Webforms.ShoppingPlazaForm" %>
<%@ PreviousPageType VirtualPath="~/WelcomePage.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Plaza</title>
    <link rel="stylesheet" href="~/Webforms/ShoppingPlazaStyle.css"/>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 40px;
        }
        .auto-style4 {
            width: 463px;
        }
        .auto-style5 {
            width: 128px;
        }
        .auto-style6 {
            width: 479px;
        }
    </style>
</head>
<body style="width: 757px; height: 269px">
    <form id="form1" runat="server">
    <div>
    
        Here you make your selections. You can select one book title and one DVD title.<table class="auto-style1">
            <tr>
                <td class="auto-style2">Books</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="bookDropDown" runat="server" Height="16px" Width="412px" AutoPostBack="True" OnSelectedIndexChanged="bookDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                    Quantity </td>
                <td class="auto-style5">
                    <asp:TextBox ID="bookQuantityTB" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">Price of Book:</td>
                <td>
                    <asp:Label ID="bookPriceLabel" runat="server">$50.55</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">DVDs</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="dvdDropDown" runat="server" Height="18px" Width="410px" AutoPostBack="True" OnSelectedIndexChanged="dvdDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                    Quantity</td>
                <td class="auto-style5">
                    <asp:TextBox ID="dvdQuantityTB" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">Price of DVD:</td>
                <td>
                    <asp:Label ID="dvdPriceLabel" runat="server">$10.00</asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="addBtn" runat="server" Text="Add" OnClick="addBtn_Click" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="checkoutBtn" runat="server" Text="Checkout" OnClick="checkoutBtn_Click" />
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>
                    <asp:Button ID="exitBtn" runat="server" ForeColor="Red" Text="Exit" OnClick="exitBtn_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="errLabel" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
