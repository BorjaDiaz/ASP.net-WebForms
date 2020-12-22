<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInicio.aspx.cs" Inherits="ASP.WebFormInicio" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET</title>
    <link rel="stylesheet" href="CSS/EstilosInicio.css" type="text/css" />
    <style></style>
</head>
<body>
    <form id="form1" runat="server">
    <br /><br />    
    <div id="body">
        <asp:Label ID="label" runat="server" Text="Practica de ASP.NET" CssClass="Titulo"></asp:Label>
        <br /><br />
        <asp:HyperLink ID="EnlaceCursos"
            class="EnlaceCursos"
            Text="Mantenimiento de Cursos"
            runat="server"
            BorderColor="Black"
            BorderStyle="Double"
            BackColor="White"
            Font-Bold="true"
            NavigateUrl="~/WebFormCurso.aspx">
        </asp:HyperLink>
    <br /><br />
        <asp:HyperLink ID="EnlaceNotas"
            class="EnlaceNotas"
            Text="Mantenimiento de Notas"
            runat="server"
            BorderColor="Black"
            BorderStyle="Double"
            BackColor="White"
            Font-Bold="true"
            NavigateUrl="~/WebFormNotas.aspx">
        </asp:HyperLink>
    <br /><br />
        <asp:HyperLink ID="EnlaceAlumnos"
            class="EnlaceAlumnos"
            Text="Mantenimiento de Alumnos"
            runat="server"
            BorderColor="Black"
            BorderStyle="Double"
            BackColor="White"
            Font-Bold="true"
            NavigateUrl="~/WebFormAlumno.aspx">
        </asp:HyperLink>
    </div>
    </form>
</body>
</html>
