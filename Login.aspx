<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <div class="card narrow">
    <h2>Iniciar sesión</h2>
    <asp:Label ID="lblMsg" runat="server" CssClass="error" EnableViewState="false" />
    <label>Usuario</label>
    <asp:TextBox ID="txtUsuario" runat="server" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsuario" ErrorMessage="Requerido" CssClass="error" Display="Dynamic" />
    <label>Contraseña</label>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass" ErrorMessage="Requerido" CssClass="error" Display="Dynamic" />
    <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn" OnClick="btnLogin_Click" />
  </div>
</asp:Content>
