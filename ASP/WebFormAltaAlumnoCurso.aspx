<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAltaAlumnoCurso.aspx.cs" Inherits="ASP.WebFormAltaAlumnoCurso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignar curso</title>
     <link rel="stylesheet" href="CSS/EstilosAlumnoCurso.css" type="text/css" />
</head>
<body>
    <asp:Label Text="ASIGNAR CURSO" runat="server" Class="titulo"></asp:Label>
    <form id="form1" runat="server">
    <div>
       <asp:Panel runat="server" ID="panelModificarAlumno" Class="PanelAlumno">
            <p>
                <asp:Label runat="server" Text="Codigo del Alumno"></asp:Label>
                <asp:DropDownList runat="server" ID="ddAlumnos" OnSelectedIndexChanged="ddAlumnos_SelectedIndexChanged"
                     AppendDataBoundItems="true" AutoPostBack="true">
                    <asp:ListItem Text=""></asp:ListItem>
                </asp:DropDownList>
            </p>
           <p>
               <asp:Label runat="server" Text="DNI"></asp:Label>
               <asp:TextBox runat="server" ID="txbDNI"></asp:TextBox>
           </p>
           <p>
               <asp:Label runat="server" Text="Nombre"></asp:Label>
               <asp:TextBox runat="server" ID="txbNombre"></asp:TextBox>
           </p>
           <p>
               <asp:Label runat="server" Text="Apellidos"></asp:Label>
               <asp:TextBox runat="server" ID="txbApellidos"></asp:TextBox>
           </p>
           <p>
                <asp:Label runat="server" Text="Codigo del Curso"></asp:Label>
                <asp:DropDownList runat="server" ID="ddCursos" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text=""></asp:ListItem>
                </asp:DropDownList>
            </p>
        </asp:Panel>
            <p class="botones">
                <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click"/>
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click"/>
            </p>
            <p>
                <asp:Literal ID="literal1" runat="server"></asp:Literal>
            </p>
    </div>
    </form>
</body>
</html>
