using System;
using System.Web;
using System.Web.UI;

public partial class Register : Page
{
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        string usuario = txtUsuario.Text.Trim();
        if (UserStore.Exists(usuario))
        {
            lblMsg.Text = "Ese nombre de usuario ya existe.";
            return;
        }

        UserStore.Add(usuario, txtEmail.Text.Trim(), txtPass.Text);

        // Almacenamiento temporal solicitado: contraseña en cookie, usuario en sesión.
        // Se guarda el hash (no el texto plano) y la cookie es HttpOnly/Secure por seguridad.
        var cookie = new HttpCookie("ClaveUsuario", UserStore.Hash(txtPass.Text, UserStore.NewSalt()))
        {
            HttpOnly = true,
            Secure = Request.IsSecureConnection,
            Expires = DateTime.Now.AddMinutes(30)
        };
        Response.Cookies.Add(cookie);
        Session["Usuario"] = usuario;

        Response.Redirect("Files.aspx");
    }
}
