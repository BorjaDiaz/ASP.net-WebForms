<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormNotas.aspx.cs" Inherits="ASP.WebFormNotas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Formulario de Notas</title>
    <link rel="stylesheet" href="CSS/EstilosAlumno.css" type="text/css" />
   
</head>
<body>
    <asp:Label Text="Notas" runat="server" Class="titulo"></asp:Label>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="dropNotasCurso" runat="server" OnSelectedIndexChanged="dropNotas_SelectedIndexChanged"
            AutoPostBack="true"  AppendDataBoundItems="true">
            <asp:ListItem Text=""></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridviewNota" runat="server" AutoGenerateColumns="false" OnRowCommand="GridviewNota_RowCommand" CellPadding="5"
             Class="datagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="COD_ALU" HeaderText="COD_ALU" />
                <asp:BoundField DataField="COD_CUR" HeaderText="COD_CUR" />
                <asp:BoundField DataField="APELLIDOS" HeaderText="APELLIDOS" />
                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                <asp:BoundField DataField="NOTA1" HeaderText="NOTA1" />
                <asp:BoundField DataField="NOTA2" HeaderText="NOTA2" />
                <asp:BoundField DataField="NOTA3" HeaderText="NOTA3" />
                <asp:BoundField DataField="MEDIA" HeaderText="MEDIA" />
                <asp:ButtonField ButtonType="Button" Text="Modificar" CommandName="Modificar"/>
                <asp:ButtonField ButtonType="Button" Text="Borrar" CommandName="Borrar" />
            </Columns>
        </asp:GridView>
    </div>
        <br /><br />
        <asp:Panel ID="PanelNotas" runat="server" Class="PanelNotas">
        <p>
            <asp:TextBox ID="txbCodAlu" runat="server" Text=""></asp:TextBox>
            <asp:TextBox ID="txbCodCur" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelApellidos" runat="server" Text="Apellidos"></asp:Label>
            <asp:TextBox ID="txbApellidos" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txbNombre" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelNota1" runat="server" Text="Nota1"></asp:Label>
            <asp:TextBox ID="txbNota1" runat="server"  Text=""></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelNota2" runat="server" Text="Nota2"></asp:Label>
            <asp:TextBox ID="txbNota2" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelNota3" runat="server" Text="Nota3"></asp:Label>
            <asp:TextBox ID="txbNota3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelMedia" runat="server" Text="Media"></asp:Label>
            <asp:TextBox ID="txbMedia" runat="server"></asp:TextBox>
        </p>
            <asp:Button  runat="server" ID="btnModificar" Text="Aceptar" OnClick="btnModificar_Click" />
            <asp:Button runat="server" ID="MediaNota" Text="Media Nota" OnClick="MediaNota_Click" />
            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
        </asp:Panel>
        <p>
           <asp:Literal ID="literal1" runat="server"></asp:Literal>
        </p>
        <br /><br />
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
