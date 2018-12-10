using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TabletopGamesArena.Core.Modules;
using static TabletopGamesArena.Core.Modules.GameRoom;

public partial class _GamesArenaScreen : System.Web.UI.Page
{
    Player currentPlayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ErrorMsgLbl.Text = string.Empty;
            }

            currentPlayer = (Player)Session["CurrentPlayer"];
            if (currentPlayer is null)
            {
                Response.Redirect("/Default.aspx");
            }
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void JoinRoomBtn_Click(object sender, EventArgs e)
    {
        JoinRoomPanel.Visible = true;
    }

    protected void CreateRoomBtn_Click(object sender, EventArgs e)
    {
        CreateRoomPanel.Visible = true;
    }

    protected void JoinBtn_Click(object sender, EventArgs e)
    {
        try
        {
            currentPlayer.JoinGameRoom(JoinRoomCodeTxt.Text);
            Response.Redirect("/GameRoomScreen.aspx");
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void CreateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            GameType gametype = GameType.None;
            switch (GamesDDL.SelectedValue)
            {
                case "1":
                    gametype = GameType.CardWar;
                    break;
                case "2":
                    gametype = GameType.Checkers;
                    break;
                case "3":
                    gametype = GameType.Chess;
                    break;
                case "4":
                    gametype = GameType.Taki;
                    break;

            }

            currentPlayer.CreateGameRoom(gametype);
            Response.Redirect("/GameRoomScreen.aspx");
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void MyHistory_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Add("CurrentPlayer", currentPlayer);
            Response.Redirect("/MyHistoryScreen.aspx");
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }
}