using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TabletopGamesArena.Core.Modules;

public partial class GameRoomScreen : System.Web.UI.Page
{
    Player currentPlayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            currentPlayer = (Player)Session["CurrentPlayer"];

            if (currentPlayer is null )
            {
                Response.Redirect("/Default.aspx");
            }

            PlayerNameHF.Value = currentPlayer.ScreenName;
            RoomCodeHF.Value = currentPlayer.CurrentGameRoom.RoomCode;
            NumOfPlayersHF.Value = currentPlayer.CurrentGameRoom.GetNumOfPlayers().ToString();

            if (currentPlayer.CurrentGameRoom.GameCanStart())
            {
                if (!currentPlayer.CurrentGameRoom.RoomIsClosed)
                {
                    ErrMsgLbl.Visible = false;
                    StartGameBtn.Visible = true;
                }
            }
            else
            {
                ErrMsgLbl.Visible = true;
                StartGameBtn.Visible = false;
            }
        }
        catch
        {
            ErrMsgLbl.Text = "Something went wrong.";
        }
    }
    protected void Timer_Tick(object sender, EventArgs e)
    {
    }

    protected void StartGameBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Player winner = currentPlayer.CurrentGameRoom.StartGame();
            WinnerLbl.Text = $"The Winner Is { winner.ScreenName }!";
            StartGameBtn.Visible = false;
        }
        catch
        {
            ErrMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void ExitRoomBtn_Click(object sender, EventArgs e)
    {
        try
        {
            currentPlayer.ExitGameRoom();
            Response.Redirect("/GamesArenaScreen.aspx");
        }
        catch
        {
            ErrMsgLbl.Text = "Something went wrong.";
        }
    }
}