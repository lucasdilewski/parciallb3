using System;
using System.Web.UI;

public partial class SiteMaster : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool logged = Session["Usuario"] != null;
        lnkRegister.Visible = !logged;
        lnkLogin.Visible = !logged;
        lnkFiles.Visible = logged;
        lnkLogout.Visible = logged;
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}
