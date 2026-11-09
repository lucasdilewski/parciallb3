<%@ Page Title="Mis documentos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Files.aspx.cs" Inherits="FilesPage" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <div class="card">
    <h2>Espacio de <asp:Literal ID="litUsuario" runat="server" /></h2>
    <p class="hint">Formatos permitidos: PDF, DOC, DOCX, JPG, PNG, TXT. Máximo 10 MB.</p>
    <asp:Label ID="lblMsg" runat="server" EnableViewState="false" />
    <div class="upload">
      <asp:FileUpload ID="fuDoc" runat="server" />
      <asp:Button ID="btnSubir" runat="server" Text="Subir documento" CssClass="btn" OnClick="btnSubir_Click" />
    </div>
    <h3>Mis documentos</h3>
    <div class="table-wrap">
    <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="Nombre"
      OnRowCommand="gvFiles_RowCommand" EmptyDataText="Aún no ha subido documentos." GridLines="None">
      <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Archivo" />
        <asp:BoundField DataField="Tamano" HeaderText="Tamaño" />
        <asp:BoundField DataField="Fecha" HeaderText="Subido" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
        <asp:TemplateField>
          <ItemTemplate>
            <asp:LinkButton runat="server" CommandName="Descargar" CommandArgument='<%# Eval("Nombre") %>' CausesValidation="false">Descargar</asp:LinkButton>
            &nbsp;|&nbsp;
            <asp:LinkButton runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Nombre") %>' CausesValidation="false" OnClientClick="return confirm('¿Eliminar este documento?');">Eliminar</asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
    </div>
  </div>
</asp:Content>
