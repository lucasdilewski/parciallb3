<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <div class="card">
    <img src="Images/logo_3.png" alt="Pissecoria ELama" class="card-logo" />
    <h2>Registro de clientes</h2>
    <asp:ValidationSummary runat="server" CssClass="error" HeaderText="Corrija los siguientes errores:" />
    <asp:Label ID="lblMsg" runat="server" CssClass="error" EnableViewState="false" />

    <div class="grid">
      <div><label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." Display="None" /></div>
      <div><label>Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio." Display="None" /></div>
      <div><label>Correo electrónico</label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="El correo es obligatorio." Display="None" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Formato de correo inválido." Display="None" /></div>
      <div><label>Nombre de usuario</label>
        <asp:TextBox ID="txtUsuario" runat="server" MaxLength="30" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsuario" ErrorMessage="El usuario es obligatorio." Display="None" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtUsuario" ValidationExpression="^[A-Za-z0-9_.-]{3,30}$" ErrorMessage="Usuario: 3-30 caracteres (letras, números, _ . -)." Display="None" /></div>
      <div><label>Edad</label>
        <asp:TextBox ID="txtEdad" runat="server" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEdad" ErrorMessage="La edad es obligatoria." Display="None" />
        <asp:RangeValidator runat="server" ControlToValidate="txtEdad" Type="Integer" MinimumValue="16" MaximumValue="120" ErrorMessage="La edad debe ser numérica y mayor de 15 años." Display="None" /></div>
      <div></div>
      <div><label>Contraseña</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass" ErrorMessage="La contraseña es obligatoria." Display="None" /></div>
      <div><label>Confirmar contraseña</label>
        <asp:TextBox ID="txtPass2" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass2" ErrorMessage="Confirme la contraseña." Display="None" />
        <asp:CompareValidator runat="server" ControlToValidate="txtPass2" ControlToCompare="txtPass" ErrorMessage="Las contraseñas no coinciden." Display="None" /></div>
    </div>
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn" OnClick="btnRegistrar_Click" />
  </div>
</asp:Content>
