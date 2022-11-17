<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SQL_Injection_Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>SQL Injection Demo</h1>
        <p class="lead">Simple demo project of an ASP.NET application vulnerable to SQL injection attacks</p>
    </div>

    <asp:Label ID="labelInput" runat="server" Text="Please enter your account details to login."></asp:Label>
    <br />
    <asp:Label ID="labelOutput" runat="server" Text="The relevant details will be displayed after form submission."></asp:Label>
    
    <br />
    <br />

    <asp:Label ID="labelFirstName" runat="server" Text="First Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtBoxFirstName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="labelLastName" runat="server" Text="Last Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtBoxLastName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <br />
    <br />
    <asp:Label ID="labelOutputData" runat="server" Text="Output:"></asp:Label>
    <br />
    <asp:ListBox ID="listBoxDatabase" runat="server"></asp:ListBox>

</asp:Content>
