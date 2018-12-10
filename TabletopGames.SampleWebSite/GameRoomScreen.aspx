<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GameRoomScreen.aspx.cs" Inherits="GameRoomScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        .content {
            display: inline-flex;
            flex-direction: column;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        <header>
            <asp:HiddenField ID="PlayerNameHF" runat="server" Value="" />
            <h1>Hello, <%= PlayerNameHF.Value %></h1>
            <asp:HiddenField ID="RoomCodeHF" runat="server" Value="" />
            <h2>Room Code: <%= RoomCodeHF.Value %></h2>
        </header>
        <asp:UpdatePanel ID="UpdatePanel" class="content" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
                <asp:AsyncPostBackTrigger ControlID="StartGameBtn" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:HiddenField ID="NumOfPlayersHF" runat="server" Value="" />
                <h2>Num Of Players in this room: <%= NumOfPlayersHF.Value %></h2>
                <asp:Label ID="ErrMsgLbl" runat="server" Style="color: red;"
                    Text="Not Enough players yet to play this game. Invite Friends using the code above." />
                <asp:Button ID="StartGameBtn" runat="server" Visible="false" Text="Start" OnClick="StartGameBtn_Click" />
                <asp:Button ID="ExitRoomBtn" runat="server" Text="Back To The Arena" OnClick="ExitRoomBtn_Click" />
                <asp:Label ID="WinnerLbl" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer" runat="server" Interval="500" OnTick="Timer_Tick">
        </asp:Timer>
    </form>
</body>
</html>
