<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategorySetup.aspx.cs" Inherits="Stock_Management_System.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Category Setup
        </legend>

        <table class="nav-justified" style="width: 500px">
            <tr>
                <td>Category Name:</td>
                <td>
                    <asp:TextBox ID="categoryNameTextBox" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="categoryNameTextBoxValidator" ForeColor="red" ControlToValidate="categoryNameTextBox" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="Category name is required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="msgLabel" runat="server"></asp:Label></td>
            </tr>
        </table>
    </fieldset>
        <asp:GridView ID="showAllGridView" runat="server" AutoGenerateColumns="False" Width="292px">
            <Columns>
                <asp:TemplateField HeaderText="Sr#">
                    <ItemTemplate>
                        <%#Eval("CategoryID") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%#Eval("CategoryName") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

</asp:Content>
