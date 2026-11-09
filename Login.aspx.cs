using System;
using System.Web.UI;

public partial class Login : Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        if (UserStore.Validate(txtUsuario.Text.Trim(), txtPass.Text))
        {
            Session["Usuario"] = txtUsuario.Text.Trim();
            Response.Redirect("Files.aspx");
        }
        else lblMsg.Text = "Usuario o contraseña incorrectos.";
    }
}
