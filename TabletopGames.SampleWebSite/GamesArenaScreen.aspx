<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GamesArenaScreen.aspx.cs" Inherits="_GamesArenaScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Welcome to the Arena!</h1>
        </header>

        <div class="content">
            <p>what would you like to do?</p>
            <asp:Button ID="CreateRoomBtn" runat="server" Text="Create New Game Room" OnClick="CreateRoomBtn_Click" />
            <asp:Panel Visible="false" ID="CreateRoomPanel" runat="server">
                <label>Select a Game</label>
                <asp:DropDownList ID="GamesDDL" runat="server">
                    <asp:ListItem Text="Card War" Value="1"/>
                    <asp:ListItem Text="Checkers" Value="2"/>
                    <asp:ListItem Text="Chess" Value="3"/>
                    <asp:ListItem Text="Taki" Value="4"/>
                </asp:DropDownList>
                <asp:Button ID="CreateBtn" runat="server" OnClick="CreateBtn_Click" Text="Create"/>
            </asp:Panel>
            <asp:Button ID="JoinRoomBtn" runat="server" Text="Join a Game Room" OnClick="JoinRoomBtn_Click"/>
            <asp:Panel Visible="false" ID="JoinRoomPanel" runat="server">
                <label>Room Code:</label>
                <asp:TextBox ID="JoinRoomCodeTxt" runat="server" />
                <asp:Button ID="JoinBtn" runat="server" OnClick="JoinBtn_Click" Text="Join"/>
            </asp:Panel>
            <asp:Button ID="MyHistory" runat="server" Text="View My Games History" OnClick="MyHistory_Click" />
        <asp:Label ID="ErrorMsgLbl" runat="server" style="color:red;"/>
        </div>
    </form>
</body>
</html>
