<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPicker.ascx.cs" Inherits="ListPicker.ListPicker" EnableViewState="true" %>
<asp:ListBox ID="ListBoxSourceList" runat="server"></asp:ListBox>
<asp:Button ID="ButtonRemoveAll" runat="server" Text="&lt;&lt;" OnClick="ButtonRemoveAll_Click" />
<asp:Button ID="ButtonRemoveOne" runat="server" OnClick="ButtonRemoveOne_Click" 
    Text="&lt;" />
<asp:Button ID="ButtonAddOne" runat="server" OnClick="ButtonAddOne_Click" 
    Text="&gt;" />
<asp:Button ID="ButtonAddAll" runat="server" OnClick="ButtonAddAll_Click" 
    Text="&gt;&gt;" />
<asp:ListBox ID="ListBoxTargetList"
    runat="server"></asp:ListBox>