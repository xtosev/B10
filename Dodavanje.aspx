<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dodavanje.aspx.cs" Inherits="Zadatak_B10.Dodavanje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/StyleSheet1.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <p>Elektronski Recnik</p>
            </header>
        </div>

        <div class="menu">
            <asp:Button class="dumge" ID="Button1" runat="server" Text="Recnik" OnClick="Button1_Click"  />
            <asp:Button class="dumge" ID="Button2" runat="server" Text="Dodavanje novih reci" OnClick="Button2_Click" />
            <asp:Button class="dumge" ID="Button3" runat="server" Text="Uputstvo" OnClick="Button3_Click"  />
        </div>

        
    <table class="auto-style2">
        
        <tr>
            <td class="auto-style4">Engleska rec:</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxEngl" runat="server" Width="131px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Srpska rec:</td>
            <td>
                <asp:TextBox ID="TextBoxSrp" runat="server" Width="131px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <br />
                <br />
                <br />
                <br />
                Opis:</td>
            <td class="auto-style7">
                <asp:TextBox ID="TextBoxOpis" runat="server" Height="86px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Dodaj" Width="90px" OnClick="Button4_Click" />
            </td>
        </tr>
    </table>

        
   
        
    </form>

    </body>
</html>
