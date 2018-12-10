<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyHistoryScreen.aspx.cs" Inherits="MyHistoryScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="InitialPageSize" Value="2" runat="server" />
            <label>Results Per Page</label>
            <asp:DropDownList ID="ResultsPerPageDDL" runat="server" AutoPostBack ="True" OnSelectedIndexChanged="ResultsPerPageTB_SelectedIndexChanged" >
                <asp:ListItem Text="2" Value="2"/>
                <asp:ListItem Text="5" Value="5"/>
                <asp:ListItem Selected="True" Text="10" Value="10"/>
                <asp:ListItem Text="20" Value="20"/>
                <asp:ListItem Text="50" Value="50"/>
                <asp:ListItem Text="100" Value="100"/>
            </asp:DropDownList>
            <asp:GridView ID="MyHistoryGridView" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                OnPageIndexChanging="MyHistoryGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Date of Game">
                        <ItemTemplate>
                            <asp:Label ID="CreationTimeLbl" runat="server" Text='<%# Eval("CreationTime") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Game Name">
                        <ItemTemplate>
                            <asp:Label ID="GameNameLbl" runat="server" Text='<%# Eval("GameName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>

            <i>You are viewing page
                <%=MyHistoryGridView.PageIndex + 1%>
                of
                <%=MyHistoryGridView.PageCount%>
            </i>
        </div>
                <asp:Label ID="ErrorMsgLbl" runat="server" style="color:red;"/>
    </form>
</body>
</html>
