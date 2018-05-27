<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="User_Registration" %>

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
            <td> Email </td>
            <td> <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password </td>
            <td> <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address </td>
            <td> <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged" TextMode="MultiLine" Width="178px"></asp:TextBox></td>
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
            <td>Pin Code </td>
            <td> <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Phone Number </td>
            <td> <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br/>    
<div align="center"> <asp:Button ID="register" Text=" Register Now" BackColor="white" Font="bold" Height="50px" width="100px"  runat="server" OnClick="register_Click"/>
</div>
    <br/>
    <br/>

    <asp:Label ID="ll" Text="" Font-Bold="True" BackColor="yellow" runat="server"></asp:Label>
</asp:Content>

