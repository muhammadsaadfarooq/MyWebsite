<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="view_full_order.aspx.cs" Inherits="Admin_view_full_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    
    <asp:Repeater ID="r1" runat="server">
   
        <HeaderTemplate>
            <table border="true">
            <tr style="background-color: gray; color:whitesmoke">
                <td>
                   Order-No
                </td>
                <td>
                    Product Image
                </td>
                <td>
                    Product Name
                </td>
                <td>
                    Product Price
                </td>
                <td>
                    Product Quantity
                </td>
       


            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr >
                <td align="center">
                    <%#Eval("order_id") %>
                </td>
                <td align="center">
                   
                    <img src="<%#Eval("product_images") %>" height="300px"; width="200px"/>
                </td>
                <td align="center">
                    <%#Eval("product_name") %>
                </td>
                <td>
                    <%#Eval("product_price") %>
                </td>
                <td align="center">
                    <%#Eval("product_qty") %>
                </td>
         
            </tr>

        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
      
    </asp:Repeater>
    <br/>
    <asp:Label ID="ac" Text="" runat="server"> </asp:Label>
    

</asp:Content>

