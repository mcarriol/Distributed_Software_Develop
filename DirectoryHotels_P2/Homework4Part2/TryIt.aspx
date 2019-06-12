<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Homework4Part2.TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Verification and XPathSearch<br />
            <br />
            <br />
            <br />
            Verify<br />
            <br />
            XML
            URL:
            <asp:TextBox ID="TextBox1" runat="server">http://localhost:59271/XMLFile1.xml</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; XSD URL:
            <asp:TextBox ID="TextBox4" runat="server">http://localhost:59271/XMLSchema1.xsd</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            Output:
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            XPathSearch<br />
            <br />
            URL:<asp:TextBox ID="TextBox2" runat="server">http://localhost:59271/XMLFile1.xml</asp:TextBox>
            <br />
            <br />
            Path:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            <br />
            <br />
            Output:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
