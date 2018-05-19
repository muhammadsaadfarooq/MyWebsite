<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin-Login.aspx.cs" Inherits="Admin_Admin_Login" %>


<!DOCTYPE html>
<html >
<head>
    <meta charset="UTF-8">
    <title>Admin Login</title>
    
    
    
    
    <link rel="stylesheet" href="logincss/style.css">

    
    
    
    
</head>

<body>

    
<form id="f1" runat="server">
    <header>Login</header>
    <label>Username <span>*</span></label>
    <asp:TextBox ID="t1" runat="server"></asp:TextBox>
    <div class="help">At least 6 character</div>
    <label>Password <span>*</span></label>
    <asp:TextBox ID="t2" runat="server"></asp:TextBox>
    <div class="help">Use upper and lowercase lettes as well</div>
    <br/>

    &nbsp; <asp:Button ID="b1"  runat="server" Text="LogIn" BorderStyle="Double" BackColor="red" OnClick="b1_Click"/>

    
    <br/>
    <br />
    <asp:Label ID="lb1" runat="server" Text=""></asp:Label>
</form>
    
    
    
    
</body>
</html>
