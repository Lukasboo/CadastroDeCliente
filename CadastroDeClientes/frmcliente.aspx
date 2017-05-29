<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmcliente.aspx.cs" Inherits="frmcliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="js/jquery-3.2.1.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Clientes</title>
</head>
<body>
    <div id="msg" class="msg"></div>
    <h1 class="titulo">Cadastro de Clientes</h1>
    <form id="form1" runat="server" >
        <fieldset>
            <div class="campo">
                <asp:Label ID="Label1" runat="server" Text="Pesquisar por nome: "></asp:Label> <br />
                <asp:TextBox ID="txt_pesqnome" Width="300px" runat="server"></asp:TextBox>
                <asp:Button ID="btn_pesq"  runat="server" Text="Pesquisar" OnClick="btn_pesq_Click" />
            </div>
            
		    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <div class="campo">
                <label>Codigo: </label>  
                <asp:TextBox ID="txt_cod" runat="server" Width="20" Enabled="false"></asp:TextBox>
            </div>
		    <div class="campo">
		        <label>Nome:   </label>
                <asp:TextBox ID="txt_nome" runat="server" Width="300"></asp:TextBox>
            </div> 
		    <div class="campo">
		        <label>Email   :</label>
                <asp:TextBox ID="txt_email" runat="server" Width="300"></asp:TextBox>
            </div> 
            <br />
		    <asp:Button class="botao"  ID="btn_incluir" runat="server" Text="Incluir" OnClick="btn_incluir_Click" />
            <asp:Button class="botao" ID="btn_excluir" runat="server" Text="Excluir" OnClientClick="return confirm('Deseja realmente excluir este cliente ?');" OnClick="btn_excluir_Click" />
            <asp:Button class="botao" ID="btn_alt" runat="server" Text="Alterar" OnClick="btn_alt_Click" />
            <br />
        </fieldset>
    <div class="divv">
    
		<asp:GridView ID="grid_cliente" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grid_cliente_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanged="grid_cliente_PageIndexChanged" OnPageIndexChanging="grid_cliente_PageIndexChanging" PageSize="5" EmptyDataText="Nenhum registro encontrado" >
			<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
			<Columns>
				<asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="~/img/11379_16x16.png" />
				<asp:BoundField DataField="CLI_ID" HeaderText="CODIGO" />
				<asp:BoundField DataField="CLI_NOME" HeaderText="NOME" />
				<asp:BoundField DataField="CLI_EMAIL" HeaderText="EMAIL" />
			</Columns>
			<EditRowStyle BackColor="#999999" />
			<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
			<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
			<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			<SortedAscendingCellStyle BackColor="#E9E7E2" />
			<SortedAscendingHeaderStyle BackColor="#506C8C" />
			<SortedDescendingCellStyle BackColor="#FFFDF8" />
			<SortedDescendingHeaderStyle BackColor="#6F8DAE" />
		</asp:GridView>

    </div>
    </form>
</body>
</html>
