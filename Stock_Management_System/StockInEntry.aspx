<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockInEntry.aspx.cs" Inherits="Stock_Management_System.StockInEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>Stock In</legend>
        <table class="nav-justified">
            <tr>
                <td>Company</td>
                <td>
                    <asp:DropDownList ID="ddlCompany" AppendDataBoundItems="True" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                        <Items>
                            <asp:ListItem Text="--Please Select Company--" Value="0"></asp:ListItem>
                        </Items>
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="ddlCompanyValidator" InitialValue="0" runat="server" ErrorMessage="Please select company" ForeColor="red" Display="Dynamic" ControlToValidate="ddlCompany" SetFocusOnError="True" ></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Item</td>
                <td>
                    <asp:DropDownList ID="ddlItem" AppendDataBoundItems="False" runat="server" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" AutoPostBack="True">
                        <Items>
                            <asp:ListItem Text="--Please select item--" Value="0" ></asp:ListItem>
                        </Items>
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="ddlItemValidator" ForeColor="red" Display="Dynamic" ControlToValidate="ddlItem" SetFocusOnError="True" InitialValue="0" runat="server" ErrorMessage="Please select item"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Reorder Label</td>
                <td>
                    <asp:Label ID="reorderLabel" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Available Quantity</td>
                <td>
                    <asp:Label ID="quantityLabel" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Stock In Quantity</td>
                <td>
                    <asp:TextBox ID="stockInTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="stockInTextBoxValidator" runat="server" ErrorMessage="Stock in quantity is required" ForeColor="red" Display="Dynamic" ControlToValidate="stockInTextBox" SetFocusOnError="True"   ></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="stockInTextBoxCompareValidator" runat="server" ErrorMessage="Qunatity must be number" ForeColor="red" Display="Dynamic" ControlToValidate="stockInTextBox" SetFocusOnError="True" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="msgLabel" runat="server" ></asp:Label></td>
            </tr>
        </table>
    </fieldset>

</asp:Content>
