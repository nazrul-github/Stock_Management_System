<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanySetup.aspx.cs" Inherits="Stock_Management_System.CompanySetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Category Setup
        </legend>

        <table class="nav-justified" style="width: 500px">
            <tr>
                <td>Company Name:</td>
                <td>
                    <asp:TextBox ID="companyNameTextBox" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="companyNameTextBoxValidator" ForeColor="red" ControlToValidate="companyNameTextBox" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="Company name is required"></asp:RequiredFieldValidator></td>
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
            <asp:TemplateField HeaderText="SR#">
                <ItemTemplate>
                    <%#Eval("CompanyID") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%#Eval("CompanyName") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
