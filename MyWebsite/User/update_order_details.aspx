<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="update_order_details.aspx.cs" Inherits="User_update_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">

<h1 align="center"> "Registeration Form"</h1><br/><br/>

<table align="center" width="500px" height="300px" border="true" bgcolor="yellow">
    <tr>
        <td>First Name </td>
        <td> <asp:TextBox ID="name" runat="server" Width="131px"></asp:TextBox></td>
        
       
        <td>Last Name </td>
        <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>
   
    <tr>
        <td>Address </td>
        <td> <asp:TextBox ID="TextBox4" runat="server"  TextMode="MultiLine" Width="178px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>City </td>
        <td> <asp:TextBox ID="TextBox5" runat="server" Width="134px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>State </td>
        <td> <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
    </tr>
   
    <tr>
        <td>Phone Number </td>
        <td> <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
    </tr>
</table>
<br/>   
<div align="center"> <asp:Button ID="update" Text="Update & Continue" BackColor="white" Font="bold" Height="50px" width="150px"  runat="server" OnClick="update_Click"/>
</div>

</asp:Content>

