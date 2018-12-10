<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <style>
        header {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .content {
            display: flex;
            flex-direction:row;
            justify-content: center;
            align-items: center;
        }

        .content-column {
            width: 30vw;
            height: 30vh;
            border: 1px solid #ebebeb;
            border-radius: 36px;
            display: flex;
            flex-direction:column;
            justify-content: space-around;
            align-items: center;
            margin: 1vw;
            padding-bottom: 1vw;
        }
        .content-column > div{
            width: 25vw;
            display: flex;
            flex-direction:row;
            justify-content: space-between;
            padding-bottom: 5px;
        }

    </style>
    <form id="form1" runat="server">
        <header>
            <h1>Welcome to Tabletop Games Arena!</h1>
        </header>
        <div class="content">
            <div class="content-column">
                <h2>Login</h2>
                <div>
                    <label>UserName:</label>
                    <asp:TextBox ID="loginUsernameTxt" runat="server" />
                </div>
                <div>
                    <label>Password:</label>
                    <asp:TextBox ID="loginPasswordTxt" TextMode="Password" runat="server" />
                </div>
                <asp:Button ID="LoginBtn" runat="server" OnClick="LoginBtn_Click" Text="Login" />
            </div>
            <div class="content-column">
                <h2>Register</h2>
                <div>
                    <label>Username:</label>
                    <asp:TextBox ID="registerUsernameTxt" runat="server" />
                </div>
                <div>
                    <label>Password:</label>
                    <asp:TextBox ID="registerPasswordTxt" TextMode="Password" runat="server" />
                </div>
                <div>
                    <label>Screen Name:</label>
                    <asp:TextBox ID="registerScreenNameTxt" runat="server" />
                </div>
                <asp:Button ID="RegisterBtn" runat="server" OnClick="RegisterBtn_Click" Text="Register" />
            </div>
        </div>
        <asp:Label ID="ErrorMsgLbl" runat="server" style="color:red;"/>
    </form>
</body>
</html>
