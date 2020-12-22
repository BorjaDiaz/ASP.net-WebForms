<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCurso.aspx.cs" Inherits="ASP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de Curso</title>
    <link rel="stylesheet" href="CSS/EstilosCurso.css" type="text/css" />
</head>
<body>
    <asp:Label Text="CURSO" runat="server" Class="titulo"></asp:Label>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server"  ID="PanelCurso" Class="PanelCurso">
            <p>
               <asp:Label Text="Curso" runat="server"></asp:Label>
               <asp:TextBox runat="server" ID="TxtboxCurso" ReadOnly="true"></asp:TextBox>
            </p>
            <p>
               <asp:Label Text="Descripcion" runat="server"></asp:Label>
               <asp:TextBox runat="server" ID="TxtboxDescripcion"></asp:TextBox>
            </p>
            <p>
                <asp:Label Text="Horas" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="TxtboxHoras"></asp:TextBox>
            </p>
            <p>
                <asp:Label Text="Tutor" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="TxtboxTutor"></asp:TextBox>
            </p>
        </asp:Panel>
        <p class="botones">
            <asp:Button Text="|<" runat="server" ID="BtnPrimero" OnClick="BtnPrimero_Click" />
            <asp:Button Text="<" runat="server" ID="BtnAnterior" OnClick="BtnAnterior_Click" />
            <asp:Button Text=">" runat="server" ID="BtnSiguiente" OnClick="BtnSiguiente_Click" />
            <asp:Button Text=">|" runat="server" ID="BtnUltimo" OnClick="BtnUltimo_Click" />
            <asp:Button Text="Modificar" runat="server" ID="BtnModificar" OnClick="BtnModificar_Click" />
            <asp:Button Text="Borrar" runat="server" ID="BtnBorrar" OnClick="BtnBorrar_Click" />
            <asp:Button Text="Nuevo" runat="server" ID="BtnNuevo" OnClick="BtnNuevo_Click" />
            <asp:Button Text="Cancelar" runat="server" ID="BtnCancelar" OnClick="BtnCancelar_Click" />
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
         <p>
             <asp:Literal ID="literal1" runat="server"></asp:Literal>
        </p>
    </form>
</body>
</html>
