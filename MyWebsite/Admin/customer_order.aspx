<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="customer_order.aspx.cs" Inherits="Admin_customer_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    
   <asp:Repeater ID="r1" runat="server">
   
   <HeaderTemplate>
<table border="true">
<tr style="background-color: gray; color:whitesmoke">
    <td>
        ID
    </td>
    <td>
       First Name
    </td>
    <td>
        Last Name
    </td>
    <td>
        Email
    </td>
    <td>
       Address
    </td>
    <td>
       State
    </td>
    <td>
       City
    </td>
    <td>
        Pin Code
    </td>
    <td>
        Phone
    </td>
    <td>
        Order
    </td>


</tr>
   </HeaderTemplate>
       <ItemTemplate>
           <tr >
               <td align="center">
                   <%#Eval("id") %>
               </td>
               <td align="center">
                   <%#Eval("firstname") %>
               </td>
               <td align="center">
                   <%#Eval("lastname") %>
               </td>
               <td>
                   <%#Eval("email") %>
               </td>
               <td align="center">
                   <%#Eval("address") %>
               </td>
               <td align="center">
                   <%#Eval("state") %>
               </td>
               <td align="center">
                   <%#Eval("city") %>
               </td>
               <td align="center">
                   <%#Eval("pincode") %>
               </td>
               <td align="center">
                   <%#Eval("mobile") %>
               </td>
               <td align="center">
                <a href="view_full_order.aspx?id=<%#Eval("id") %>"> View Full Order</a>
               </td>
           </tr>

       </ItemTemplate>
       <FooterTemplate>
           </table>
       </FooterTemplate>
   
   </asp:Repeater>

</asp:Content>

