<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Checkbook.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CheckBook.Index" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
 Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Current Balance</h2>
Current Balance: 
    <asp:Label ID="lblCurrentBalance" runat="server"></asp:Label><span style="padding-left:45px;" /> Pending Balances:<asp:Label ID="lblPendingBalance" runat="server" />

<p />
<h3>New Transaction</h3>
<%--<asp:UpdatePanel runat="server">
    <ContentTemplate>--%>
        <div class="FormLeftColumn">
            <ul>
                <li>
                <asp:Label ID="lblTransactionDate" Text="Date: " runat="server"/>  
                <telerik:RadDatePicker ID="datePicker" runat="server" Width="100px"  />
                </li>
                <li>
                <asp:Label ID="lblAmount" Text="Amount: " runat="server" /><br />
                <asp:TextBox ID="txtAmount" runat="server" />
                </li>
                <li>
                <asp:Label ID="lblDebit" Text="Debit or Credit " runat="server" />
                <asp:RadioButtonList ID="radioDebit" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Debit" Value="Debit" Selected="True" />
                    <asp:ListItem Text="Credit" Value="Credit" />
                </asp:RadioButtonList>
                </li>
            </ul>
        </div>
        <div class="FormRightColumn">
            <ul>
                <li>
                    <asp:Label ID="lblTransactionType" Text="Transaction Type" runat="server" /><br />
                    <asp:DropDownList ID="ddlTransactionType" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="--Select Transaction Type--" Value="0" />
                    </asp:DropDownList>
                </li>
                <li>
                    <asp:Label ID="lblDescription" Text="Description" runat="server" /><br />
                    <asp:TextBox ID="txtDescription" runat="server" />
                </li>
                <li>
                    <asp:Label ID="lblCheckNumber" Text="Check Number:" runat="server" /><br />
                    <asp:TextBox ID="txtCheckNumber" runat="server" MaxLength="4" Width="40px" />
                </li>
                <li>
                    <asp:Label ID="lblTransactionCleared" Text="Has transaction cleared? " runat="server" />
                    <asp:CheckBox ID="chkTransactionCleared" runat="server" />
                </li>            
            </ul>
        </div>
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>
<p>
<span style="text-align:center;">
    <asp:Button ID="btnSubtmit" runat="server" Text="Submit" OnClick="submitTransaction" /> &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" /></span>
</p>
</asp:Content>
