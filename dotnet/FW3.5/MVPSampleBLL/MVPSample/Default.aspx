<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MVPSample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" BackColor="#666699" Font-Bold="True" 
            Text="Nome" Width="128px"></asp:Label>
        <asp:Label ID="Label2" runat="server" BackColor="#666699" Font-Bold="True" 
            Text="Preço" Width="128px"></asp:Label>
        <asp:Label ID="Label3" runat="server" BackColor="#666699" Font-Bold="True" 
            Text="Descrição" Width="128px"></asp:Label>
        <asp:Label ID="Label4" runat="server" BackColor="#666699" Font-Bold="True" 
            Text="Calorias" Width="128px"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
        <asp:TextBox ID="txtPrice" runat="server" Width="128px"></asp:TextBox>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCalories" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnInserir" runat="server" onclick="btnInserir_Click" 
            Text="Inserir" />
        <br />
    
    </div>
    <asp:GridView ID="GridFood" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </form>
</body>
</html>
