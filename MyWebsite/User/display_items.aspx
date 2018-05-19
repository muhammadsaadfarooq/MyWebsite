<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="display_items.aspx.cs" Inherits="User_display_items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
   <asp:Repeater ID="rept" runat="server">
       <HeaderTemplate>
           <ul>
       </HeaderTemplate>
       <ItemTemplate>
          
           <li class="product"> <a href="product_desp.aspx?id=<%#Eval("id") %>"><img src="../<%#Eval("pro_image") %>" alt="" /></a>
               <div class="product-info">
                   <h3>"<%#Eval("pro_name") %>"</h3>
                   <div class="product-desc">
                       <h4>Available : <%#Eval("pro_qua") %>"</h4>
                       <p><%#Eval("pro_desp") %>"<br />
                          </p>
                       <strong class="price"><%#Eval("pro_price") %>"</strong> </div>
               </div>
           </li>
           
    </ItemTemplate>
       <FooterTemplate>
           </ul>

       </FooterTemplate>
    </asp:Repeater>
    
</asp:Content>

