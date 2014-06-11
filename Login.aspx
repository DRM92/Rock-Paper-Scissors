<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            font-size: xx-large;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="auto-style2"><strong>Login Page</strong></span><br />
        <br />
        <table class="auto-style1">
            <tr>
                <td>Username</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbLoginUser" runat="server" Width="274px"></asp:TextBox>
                    <asp:Label ID="lblNotuser" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Password</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbLoginPass" runat="server" TextMode="Password" Width="272px"></asp:TextBox>
                    <asp:Label ID="lblPass" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnLogin" runat="server" Height="38px" OnClick="btnLogin_Click" Text="Login" Width="79px" />
        <asp:Button ID="btnRegister" runat="server" Height="38px" OnClick="btnRegister_Click" Text="Register" Width="78px" />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
