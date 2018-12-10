using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using TabletopGamesArena.Core;
using TabletopGamesArena.Core.Modules;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ErrorMsgLbl.Text = string.Empty;
        }
    }
    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Player player = GamesArena.Login(loginUsernameTxt.Text, loginPasswordTxt.Text);
            if (player is null)
            {
                ErrorMsgLbl.Text = "There was an error login in the user.";
            }
            else
            {
                Session.Add("CurrentPlayer", player);
                Response.Redirect("/GamesArenaScreen.aspx");
            }
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void RegisterBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Player player = GamesArena.InsertUser(registerUsernameTxt.Text, registerPasswordTxt.Text, registerScreenNameTxt.Text);
            if (player is null)
            {
                ErrorMsgLbl.Text = "The username already exists.";
            }
            else
            {
                Session.Add("CurrentPlayer", player);
                Response.Redirect("/GamesArenaScreen.aspx");
            }
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
        
    }
}