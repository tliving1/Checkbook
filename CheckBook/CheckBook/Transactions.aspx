<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Checkbook.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="CheckBook.Transactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Checkbook - Transactions
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <h2><asp:Label ID="lblPageTitle" runat="server" Text="All Transactions" /></h2>
    <asp:RadioButtonList ID="rdoTransactions" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
        <asp:ListItem Text="All Transactions" Value="All" Selected="True" />
        <asp:ListItem Text="Pending Transactions"  Value="Pending" />
    </asp:RadioButtonList>
    <hr />
    <br />
        <div style="margin-top:-20px;margin-left:210px;">Results per page: 
            <asp:DropDownList ID="drpdownResults" runat="server" AutoPostBack="true">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="50" Value="50" />
            </asp:DropDownList>
        </div>
    
            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="true" AlternatingRowStyle-BackColor="Aqua" AutoGenerateColumns="false">
               <Columns>
                <asp:BoundField HeaderText="Transaction Date" DataField="TransactionOccured" HeaderStyle-HorizontalAlign = "Center"/>
                <asp:HyperLinkField HeaderText="Description" DataNavigateUrlFormatString="Transaction.aspx?TransactionID={0}" DataNavigateUrlFields="TransactionID" DataTextField="Description" />
                <asp:BoundField HeaderText="Amount" DataField="Amount" />
                <asp:CheckBoxField HeaderText="Transaction Cleared?" DataField="TransactionCleared" />
               </Columns>
           </asp:GridView>
       </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
