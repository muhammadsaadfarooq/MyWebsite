<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_login.aspx.cs" Inherits="User_user_login" %>



<!DOCTYPE html>
<html >
<head>
    <meta charset="UTF-8">
    <title>User Login</title>
    
    
    
    
    <link rel="stylesheet" href="../User/style.css">

    
    
    
    
</head>

<body>

    
<form id="f1" runat="server">
    <header>User Login</header>
    <label>Email <span>*</span></label>
    <asp:TextBox ID="t1" runat="server"></asp:TextBox>
    <div class="help">Valid Email</div>
    <label>Password <span>*</span></label>
    <asp:TextBox ID="t2" runat="server" TextMode="Password"></asp:TextBox>
    <div class="help">Use upper and lowercase lettes as well</div>
    <br/>

    &nbsp; <asp:Button ID="b1"  runat="server" Text="LogIn" BorderStyle="Double" BackColor="red" OnClick="b1_Click" />

    
    <br/>
    <br />
    <asp:Label ID="lb1" runat="server" Text=""></asp:Label>
</form>
    
    
    
    
</body>
</html>
