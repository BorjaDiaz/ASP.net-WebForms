<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormModificarAlumno.aspx.cs" Inherits="ASP.WebFormModificarAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar Alumno</title>
    <link rel="stylesheet" href="CSS/EstilosModificarAlumno.css" type="text/css" />
</head>
<body>
    <asp:Label Text="Modificar Alumno" runat="server" CssClass="titulo"></asp:Label>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" ID="panelModificarAlumno" CssClass="PanelAlumno">
            <p>
                <asp:Label runat="server" Text="Cod Alu"></asp:Label>
                <asp:TextBox runat="server" ID="txbCodAlu"></asp:TextBox>
            </p>
            <p>
                <asp:Label runat="server" Text="DNI"></asp:Label>
                <asp:TextBox runat="server" ID="txbDNI"></asp:TextBox>
            </p>
            <p>
                <asp:Label runat="server" Text="Apellidos"></asp:Label>
                <asp:TextBox runat="server" ID="txbApellidos"></asp:TextBox>
            </p>
            <p>
                <asp:Label runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox runat="server" ID="txbNombre"></asp:TextBox>
            </p>
        </asp:Panel>
        <p class="botones">
                <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button runat="server" ID="btnRestablecer" Text="Restablecer" OnClick="btnRestablecer_Click" />
            </p>
         <p>
             <asp:Literal ID="literal1" runat="server"></asp:Literal>
        </p>
    </div>
    </form>
</body>
</html>
