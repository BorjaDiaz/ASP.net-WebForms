<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAlumno.aspx.cs" Inherits="ASP.WebFormAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario Alumno</title>
    <link rel="stylesheet" href="CSS/EstilosAlumno.css" type="text/css" />
</head>
<body>
    <asp:Label runat="server" Text="Alumnos" Class="titulo"></asp:Label>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="panelAlumno" runat="server">
            <asp:GridView ID="gridAlumno" runat="server" AutoGenerateColumns="false" OnRowCommand="gridAlumno_RowCommand" CellPadding="5"
                Class="datagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="COD_ALU" HeaderText="Cod Alu" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                    <asp:BoundField DataField="APELLIDOS" HeaderText="Apellidos" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:ButtonField ButtonType="Button" Text="Borrar" CommandName="Borrar" />
                    <asp:ButtonField ButtonType="Button" Text="Modificar" CommandName="Modificar" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <p>
        <asp:Button ID="btnAlta" runat="server" Text="Nuevo Alumno" OnClick="btnAlta_Click" />
        <asp:Button ID="btnAltaCurso" runat="server" Text="Asignar curso" OnClick="btnAltaCurso_Click" />
        </p>
        <p>
           <asp:Literal ID="literal1" runat="server"></asp:Literal>
        </p>
    </div>
         <div>
            <asp:HyperLink ID="EnlaceInicio" 
            CssClass="EnlaceInicio"
            Text="Inicio"
            runat="server"
            BorderColor="Black"
            BorderStyle="Double"
            BackColor="White"
            Font-Bold="true"
            NavigateUrl="~/WebFormInicio.aspx">
        </asp:HyperLink>
    </div>
    </form>
</body>
</html>
