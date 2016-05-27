<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebProcesadorTexto.ProcesadorTexto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Word Processor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 117px; width: 916px">
    
        <asp:TextBox ID="TextBox1" runat="server" Height="79px" OnTextChanged="TextBox1_TextChanged" Width="446px" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" Height="79px" style="margin-right: 0px; margin-top: 0px" TextMode="MultiLine" Width="395px"></asp:TextBox>
        <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
            <asp:Label ID="Label1" runat="server" Text="Number of characters"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Number"></asp:TextBox>
        </div>
    
    </div>

    </form>
</body>
</html>
