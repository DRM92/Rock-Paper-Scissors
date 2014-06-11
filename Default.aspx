<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 291px;
        }
        .auto-style3 {
            width: 291px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            text-decoration: underline;
        }
    </style>
</head>
<body style="height: 191px">
    <form id="form1" runat="server">
        <h1 class="auto-style5">Registration Form</h1>
        <asp:Label ID="lblFill" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Username</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="tbUser" runat="server" Width="260px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblExist" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">D.O.B (mm/dd/yyyy)</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:TextBox ID="tbdob" runat="server" Width="255px"></asp:TextBox>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:TextBox ID="tbPassword" TextMode="password" runat="server" Width="257px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblPmatch2" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Confirm Password</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="tbConfirm" TextMode="password" runat="server" Width="255px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblPmatch" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="Confirm" runat="server" Height="37px" Text="Confirm" Width="96px" OnClick="Confirm_Click" />
        <asp:Button ID="Cancel" runat="server" Height="37px" Text="Cancel" Width="88px" OnClick="Cancel_Click" />
        <asp:Button ID="btnLogin" runat="server" Height="36px" OnClick="btnLogin_Click" Text="Login" Width="88px" />
    </form>
</body>
</html>
