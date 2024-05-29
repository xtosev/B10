<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uputstvo.aspx.cs" Inherits="Zadatak_B10.Uputstvo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/StyleSheet2.css">
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

        
        
    </form>

    <p>
        Ovo je projekat u kojem korisnik moze prevesti reci sa engleskog na srpskom, kao i ukoliko rec ne postoji u bazi dodati je na stranici dodavanje novih reci uz kratak opis.</p>

    </body>
</html>
