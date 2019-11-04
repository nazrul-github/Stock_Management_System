<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemsSummary.aspx.cs" Inherits="Stock_Management_System.ItemsSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="companyLabel" runat="server" Text="Company"></asp:Label>
    <asp:DropDownList ID="ddlCompany" runat="server">
        <Items>
            <asp:ListItem Text="--Select Company--" Value="0"></asp:ListItem>
        </Items>
    </asp:DropDownList>
    <asp:Label ID="categoryLabel" runat="server" Text="Category"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server">
      
            <Items>
                <asp:ListItem Text="--Select Category--" Value="0"></asp:ListItem>
            </Items>
    </asp:DropDownList>
    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
    <asp:GridView ID="showAllGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Sr#">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Item">
                <ItemTemplate>
                    <%#Eval("ItemName") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Company Name">
                <ItemTemplate>
                    <%#Eval("CompanyName") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <%#Eval("CategoryName")%>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Available Quantity">
                <ItemTemplate>
                    <%#Eval("Quantity") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Reorder Label">
                <ItemTemplate>
                    <%#Eval("ReorderLabel") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
