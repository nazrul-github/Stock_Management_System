<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockOutRecord.aspx.cs" Inherits="Stock_Management_System.StockOutRecord" %>
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
                <td>Stock Out Quantity</td>
                <td>
                    <asp:TextBox ID="stockOutTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="stockOutTextBoxValidator" runat="server" ErrorMessage="Stock out quantity is required" ForeColor="red" Display="Dynamic" ControlToValidate="stockOutTextBox" SetFocusOnError="True"   ></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="stockOutTextBoxCompareValidator" runat="server" ErrorMessage="Qunatity must be number" ForeColor="red" Display="Dynamic" ControlToValidate="stockOutTextBox" SetFocusOnError="True" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="addButton" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="addButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="msgLabel" runat="server" ></asp:Label></td>
            </tr>
        </table>
    </fieldset>
    <asp:GridView ID="showAllGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Sr#">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="Item Name">
    <ItemTemplate>
        <%#Eval("ItemName") %>
    </ItemTemplate>
</asp:TemplateField><asp:TemplateField HeaderText="Company Name">
    <ItemTemplate>
        <%#Eval("CompanyName") %>
    </ItemTemplate>
</asp:TemplateField><asp:TemplateField HeaderText="Quantity">
    <ItemTemplate>
        <%#Eval("StockOutQuantity") %>
    </ItemTemplate>
</asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="sellButton" runat="server" CssClass="btn btn-primary" Text="Sell" OnClick="sellButton_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Damage" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Lost" />
</asp:Content>
