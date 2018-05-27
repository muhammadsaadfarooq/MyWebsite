<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="viewcart.aspx.cs" Inherits="User.UserViewcart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
	
	<asp:Button ID="viewcart"  Text="View Cart" runat="server" OnClick="viewcart_Click"/>
	<asp:DataList ID="data_list" runat="server">
		<HeaderTemplate>
			<table>
		</HeaderTemplate>
		<ItemTemplate>
			<tr>
				<td>
					<img src="../<%# Eval("product_image")%>" height="300" width="200" />
				</td>
				<td>
					Product Name - <%# Eval("product_name")%>
				</td>
				<td>
					Product Price - <%# Eval("product_price")%>
				</td>
				<td>
					Product - QTY <%# Eval("product_qty")%>

				</td>
				<td>
					Product - Desp <%# Eval("product_desp")%>
				</td>
				<td>
					<a href="delete_cart.aspx?id=<%#Eval("id") %>"> Delete </a>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</asp:DataList>
    <p>
  <label>Grand Total : </label>
    <asp:TextBox ID="total" runat="server"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="chck" Text="Check Out" BackColor="silver" Font-Bold="True" runat="server" OnClick="chck_Click"/>
    </p>
</asp:Content>

