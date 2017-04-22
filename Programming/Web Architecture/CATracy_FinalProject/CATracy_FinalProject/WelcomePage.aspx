<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="CATracy_FinalProject.WelcomePage" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link rel ="stylesheet" href="~/Webforms/site.css"/>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 171px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to the Shopping Plaza!!!</h1>
        <p>Here you can purchase books and DVDs. Simply follow the instructions provided below.</p>
        <p>Instructions:</p>
        <p>1. Select the book and enter the quantity. Click Add<p>
        <p>2. Select the DVD and enter the quantity. Click Add</p>
        <p>3. To check out, click Check-Out</p>
        <p>4. To close the application, click Exit. You will lose your selections</p>
        <p>5. In the check out screen, revise the quantities if you wish to. If you do, click Edit</p>
        <p>6. To place final order, click Pay</p>
        <p>7. To close the application, click Exit. You will lose your selections<table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="plazaBtn" runat="server" Text="Go to Shopping Plaza" Width="155px"  CssClass="mybutton" PostBackUrl="~/Webforms/ShoppingPlazaForm.aspx"/>
                </td>
                <td>
                    <asp:Button ID="exitBtn" runat="server" ForeColor="Red" Text="Exit"  Width="70px" CssClass="mybutton" PostBackUrl="~/Webforms/ExitPage.aspx"/>
                </td>
            </tr>
            </table>
        </p>
    </div>
        
    </form>
</body>
</html>
