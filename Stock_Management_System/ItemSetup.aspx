<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemSetup.aspx.cs" Inherits="Stock_Management_System.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Item Setup
        </legend>
        <table class="nav-justified">
            <tr>
                <td>Category</td>
                <td>
                    <asp:DropDownList ID="categoryNameDropDownList" runat="server" AppendDataBoundItems="True">
                        <Items>
                            <asp:ListItem Text="--Please Select Category--" Value="0"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                <td>
                    <asp:RequiredFieldValidator ID="categoryNameddlValidator" InitialValue="0" ForeColor="red" EnableClientScript="True" ControlToValidate="categoryNameDropDownList" Display="Dynamic" SetFocusOnError="True" runat="server" ErrorMessage="Please select category name"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Company</td>
                <td>
                    <asp:DropDownList ID="companyNameDropDownList" runat="server" ></asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="ddlCompanyFieldValidator"  InitialValue="0" runat="server" ErrorMessage="Company name is required" ForeColor="red" Display="Dynamic" ControlToValidate="companyNameDropDownList" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Item Name</td>
                <td>
                    <asp:TextBox ID="itemNameTextBox" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="itemNameTextBoxValidator" runat="server" ErrorMessage="Item name is required" ForeColor="red" Display="Dynamic" ControlToValidate="itemNameTextBox" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Reorder Label</td>
                <td>
                    <asp:TextBox ID="reorderLabelTextBox" Text="0" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="reorderLabelTextBoxdValidator" runat="server" ErrorMessage="Reorder label is required" ForeColor="red" Display="Dynamic" ControlToValidate="reorderLabelTextBox" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="msgLabel" runat="server" ></asp:Label></td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
