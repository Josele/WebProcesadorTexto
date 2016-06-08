<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebProcesadorTexto.ProcesadorTexto"  ValidateRequest="false" %>

<script runat="server">

  void submitBtn_Click(object sender, EventArgs e)
  {
    // Encode the string input
    StringBuilder sb = new StringBuilder(
                            HttpUtility.HtmlEncode(TextBox4.Text));
    // Selectively allow  <b> and <i>
    sb.Replace("&lt;b&gt;", "<b>");
    sb.Replace("&lt;/b&gt;", "");
    sb.Replace("&lt;i&gt;", "<i>");
    sb.Replace("&lt;/i&gt;", "");
    Response.Write(sb.ToString());
  }
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Word Processor</title>
    <link rel="stylesheet" type="text/css" href="StyleIndex.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="form-style-1">
            <li>
                <label>Set your text <span class="required">*</span></label><asp:TextBox ID="TextBox1" runat="server" Height="79px" CssClass="field-divided" OnTextChanged="TextBox1_TextChanged" Width="446px" TextMode="MultiLine"></asp:TextBox></li>
            <li>
                <label>Output</label>
                <asp:TextBox ID="TextBox4" runat="server" Height="79px" CssClass="field-divided" TextMode="MultiLine" Width="395px"></asp:TextBox>
            </li>
            <li>
                <label>Number of characters</label> 
                <asp:TextBox ID="TextBox2" runat="server" CssClass="field-long" OnTextChanged="TextBox2_TextChanged" TextMode="Number"></asp:TextBox> 
            </li>
            <li>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </li>
        </ul>
            


    </form>
    <p>
        <a href="http://jigsaw.w3.org/css-validator/check/referer">
            <img style="border:0;width:88px;height:31px"
            src="http://jigsaw.w3.org/css-validator/images/vcss-blue"
            alt="¡CSS Válido!" />
        </a>
    </p>
</body>
</html>
