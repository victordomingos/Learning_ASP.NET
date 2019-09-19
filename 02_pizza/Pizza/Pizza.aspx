<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pizza.aspx.cs" Inherits="Pizza.Pizza" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="drop_base" runat="server" Height="16px" Width="90px">
                <asp:ListItem>Milana</asp:ListItem>
                <asp:ListItem>Veneza</asp:ListItem>
                <asp:ListItem>4 Estações</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drop_qtd_pizzas" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="drop_bebida" runat="server" Height="16px" Width="90px">
                <asp:ListItem>Cola</asp:ListItem>
                <asp:ListItem>Cerveja</asp:ListItem>
                <asp:ListItem>Sumo</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drop_qtd_bebidas" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Pimentos" />
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" Text="Salada" />
            <br />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Queijo" />
            <br />
            <br />
            <br />
            <asp:Button ID="btn_calcular" runat="server" Text="Calcular" OnClick="Button1_Click" Width="120px" />
&nbsp;<br />
            <br />
            <strong>TOTAL:</strong><br />
&nbsp;<asp:TextBox ID="txt_total" runat="server" OnTextChanged="TextBox1_TextChanged" Width="112px"></asp:TextBox>
        </div>
    </form>
    <div id="legenda">

        Preçário:<br />
        ...</div>
</body>
</html>
