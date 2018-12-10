using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TabletopGamesArena.Core.Modules;

public partial class MyHistoryScreen : System.Web.UI.Page
{
    Player currentPlayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            currentPlayer = (Player)Session["CurrentPlayer"];
            if (currentPlayer is null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (!IsPostBack)
            {
                ErrorMsgLbl.Text = string.Empty;

                UpdateTable();
            }
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void MyHistoryGridView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        MyHistoryGridView.PageIndex = e.NewPageIndex;
        UpdateTable();

    }

    private void UpdateTable()
    {
        try
        {
            DataTable history = currentPlayer.MyHistory();
            MyHistoryGridView.DataSource = history;
            MyHistoryGridView.VirtualItemCount = history.Rows.Count;

            string selected = ResultsPerPageDDL.SelectedValue;
            int.TryParse(selected, out int resultsPerPage);
            MyHistoryGridView.PageSize = resultsPerPage;

            MyHistoryGridView.DataBind();
        }
        catch
        {
            ErrorMsgLbl.Text = "Something went wrong.";
        }
    }

    protected void ResultsPerPageTB_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTable();
    }

}