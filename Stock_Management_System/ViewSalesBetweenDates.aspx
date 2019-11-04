<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSalesBetweenDates.aspx.cs" Inherits="Stock_Management_System.ViewSalesBetweenDates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Show Sales</legend>
        <asp:Label ID="fromDateLabel" runat="server" Text="From Date"></asp:Label>
        <asp:TextBox ID="fromdateTextBox" TextMode="Date" runat="server"></asp:TextBox>
        <asp:Label ID="toDateLabel" runat="server" Text="To Date"></asp:Label>
        <asp:TextBox ID="todateTextbox" TextMode="Date" runat="server"></asp:TextBox>
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
                </asp:TemplateField><asp:TemplateField HeaderText="Sale Quantity">
                    <ItemTemplate>
                        <%#Eval("StockOutQuantity")%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </fieldset>
    
</asp:Content>
