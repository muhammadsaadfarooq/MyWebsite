<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="addproduct.aspx.cs" Inherits="Admin_addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <h2> Add Product </h2>
    <table>
        <tr>
            <td>
                Product Name &nbsp;
            </td>
            <td> <asp:TextBox ID="name" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Product Price &nbsp;
            </td>
            <td> <asp:TextBox ID="price" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Product Description &nbsp;
            </td>
            <td> <asp:TextBox ID="desp" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Product Quantity &nbsp;
            </td>
            <td> <asp:TextBox ID="quantity" runat="server"></asp:TextBox></td>
        </tr>
        <br />

        <tr>
            <td>
                Product Image &nbsp;
            </td>
            
            <td> <asp:FileUpload ID="image_upload" runat="server"/></td>
        </tr>
        <tr><td colspan="2" align="center">
            <asp:Button ID="add_button" Text="Submit" runat="server" OnClick="add_button_Click"/>
        </td></tr>
    </table>
</asp:Content>

