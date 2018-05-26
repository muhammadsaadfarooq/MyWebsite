<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="product_desp.aspx.cs" Inherits="User.UserProductDesp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <asp:Repeater ID="rpt" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
    <div style="height:300px; width: 600px; border-style: solid; border-width:2px">
        <div style="height:300px; float: left; width: 200px; border-style: solid; border-width:2px">
            <img src="../<%#Eval("pro_image") %>" height="300px"; width="200px"/>
        </div>
        <div style="height:300px; float: left; width: 390px; border-style: solid; border-width:2px">
        <h2>"<%#Eval("pro_name") %>"</h2><br/>
            <h2>"<%#Eval("pro_qua") %>"</h2><br/>
            <h2>"<%#Eval("pro_price") %>"</h2><br/>
        <p><strong><%#Eval("pro_desp") %>"</strong><br />
        </div>
    </div>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    <br />
    
    <table>
        <tr>
            <td>
             <asp:TextBox ID="txt" Font-Bold="True" BackColor="Yellow" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="cart" Text="Add to Cart" Font-Bold="true" BorderStyle="Double"  runat="server" OnClick="cart_Click"/>
            </td>

    
        </tr>
        <tr>
            <asp:Label ID="l1" Text="" runat="server"></asp:Label>
        </tr>
    </table>
  
    
</asp:Content>

