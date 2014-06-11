<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rock, Paper, Scissors, Lizard, Spock.</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 131px;
            font-weight: 700;
        }
        .auto-style3 {
            width: 131px;
            height: 23px;
            font-weight: 700;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 230px; width: 540px;">
        <h1>Rock, Paper, Scissors, Lizard, Spock</h1>
        <asp:Label ID="Label1" runat="server" Text="Welcome, " CssClass="auto-style5"></asp:Label>
        <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" CssClass="auto-style5"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=", try and beat the computer!" CssClass="auto-style5"></asp:Label>
        <br />
        <asp:Label ID="lblBirthday" runat="server" style="font-style: italic"></asp:Label>
        <br />
        <br />
        <asp:RadioButton id="rbRock" runat="server" Text="Rock" GroupName="options" />
        <br />
        <asp:RadioButton id="rbPaper" runat="server" Text="Paper" GroupName="options" />
        <br />
        <asp:RadioButton id="rbScissors" runat="server" Text="Scissors" GroupName="options" />
        <br />
        <asp:RadioButton id="rbLizard" runat="server" Text="Lizard" GroupName="options" />
        <br />
        <asp:RadioButton id="rbSpock" runat="server" Text="Spock" GroupName="options" />
        <br />
        <br />
        <asp:Label ID="lblOption" ForeColor="Red" runat="server"></asp:Label>
        <br />
        <asp:Button id="playButton" Text="Play" runat="server" OnClick="playButton_Click" />  
        <br />
        <br />
        <asp:Label ID="UserLabel" ForeColor="SeaGreen" runat="server" Text=" "></asp:Label> 
        <br />
        <asp:Label ID="CompLabel" ForeColor="Blue" runat="server" Text=" "></asp:Label> 
        <br />
        <asp:Label ID="ResultLabel" ForeColor="Red" runat="server" Text=" "></asp:Label> 
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Played:</td>
                <td>
                    <asp:Label ID="lblPlayed" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Wins:</td>
                <td class="auto-style4">
                    <asp:Label ID="lblWin" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Loss:</td>
                <td>
                    <asp:Label ID="lblLoss" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Draw:</td>
                <td>
                    <asp:Label ID="lblDraw" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
        <br />
        <br />
    </div>        
    </form>
</body>
</html>
