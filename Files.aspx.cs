using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FilesPage : Page
{
    static readonly string[] Allowed = { ".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".png", ".txt" };
    const int MaxBytes = 10 * 1024 * 1024;

    string Usuario { get { return (string)Session["Usuario"]; } }

    string UserDir()
    {
        // El nombre de usuario ya fue validado (letras, números, _ . -) al registrarse.
        string dir = Server.MapPath("~/Uploads/" + Path.GetFileName(Usuario));
        Directory.CreateDirectory(dir);
        return dir;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Usuario == null) { Response.Redirect("Login.aspx"); return; }
        litUsuario.Text = Server.HtmlEncode(Usuario);
        if (!IsPostBack) Bind();
    }

    void Bind()
    {
        gvFiles.DataSource = new DirectoryInfo(UserDir()).GetFiles()
            .OrderByDescending(f => f.CreationTime)
            .Select(f => new { Nombre = f.Name, Tamano = (f.Length / 1024) + " KB", Fecha = f.CreationTime }).ToList();
        gvFiles.DataBind();
    }

    void Msg(string text, bool ok)
    {
        lblMsg.CssClass = ok ? "ok" : "error";
        lblMsg.Text = Server.HtmlEncode(text);
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        if (!fuDoc.HasFile) { Msg("Seleccione un archivo.", false); return; }
        string ext = Path.GetExtension(fuDoc.FileName).ToLowerInvariant();
        if (!Allowed.Contains(ext)) { Msg("Tipo de archivo no permitido.", false); return; }
        if (fuDoc.PostedFile.ContentLength > MaxBytes) { Msg("El archivo supera 10 MB.", false); return; }

        string baseName = Path.GetFileNameWithoutExtension(fuDoc.FileName);
        foreach (char c in Path.GetInvalidFileNameChars()) baseName = baseName.Replace(c, '_');
        string name = baseName + ext, full = Path.Combine(UserDir(), name);
        int i = 1;
        while (File.Exists(full)) { name = baseName + "_" + i++ + ext; full = Path.Combine(UserDir(), name); }

        fuDoc.SaveAs(full);
        Msg("Documento subido correctamente.", true);
        Bind();
    }

    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string name = Path.GetFileName((string)e.CommandArgument); // evita path traversal
        string full = Path.Combine(UserDir(), name);
        if (!File.Exists(full)) return;

        if (e.CommandName == "Descargar")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + name + "\"");
            Response.TransmitFile(full);
            Response.End();
        }
        else if (e.CommandName == "Eliminar")
        {
            File.Delete(full);
            Msg("Documento eliminado.", true);
            Bind();
        }
    }
}
