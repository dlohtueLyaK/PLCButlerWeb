<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TIAPortalOpennessWeb.aspx.cs" Inherits="PLCButlerWeb.TIAPortalOpennessWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />

    <p>
         <asp:Button ID="TIAStart" runat="server" Height="35px" OnClick="TIAStart_Click" Text="TIA start" Width="200px" />     
         <asp:Button ID="ConnectToTIA" runat="server" Height="35px" OnClick="ConnectToTIA_Click" Text="Connect to TIA" Width="200px" />
         <asp:Button ID="OpenProject" runat="server" Height="35px" OnClick="OpenProject_Click" Text="Open Project" Width="200px" />
         <asp:Button ID="DisconnectAndSave" runat="server" Height="35px" OnClick="DisconnectAndSave_Click" Text="Disconnect and Save" Width="200px" />
    </p>
    <p>
        <asp:Button ID="Import" runat="server" Height="35px" OnClick="Import_Click" Text="Import" Width="200px" />
        <asp:Button ID="Export" runat="server" Height="35px" OnClick="Export_Click" Text="Export" Width="200px" />
        <asp:Button ID="CreateGroup" runat="server" Height="35px" OnClick="CreateGroup_Click" Text="Create Group" Width="200px" />
    </p>
    
        <p>InfoBox_____<asp:TextBox ID="InfoBox" runat="server" Height="95px" Rows="5" Width="422px" TextMode="MultiLine"></asp:TextBox></p>
   
        <p>ProjectPath__<asp:TextBox ID="ProjectPath" runat="server" Width="600px">C:\temp\TIATemplate\template_V15_1.ap15_1</asp:TextBox></p>
  
        <p>XMLPath____<asp:TextBox ID="XMLPath" runat="server" Width="600px">C:\temp\FC172 V01.xml</asp:TextBox></p>

        <p>ExportName_<asp:TextBox ID="ExportName" runat="server" Width="600px"></asp:TextBox></p>

        <p>Group______<asp:TextBox ID="Group" runat="server" Width="600px"></asp:TextBox></p>
  
        <asp:RadioButtonList ID="ImportTyp" runat="server">
            <asp:ListItem Value="FC, FB, OB, DB" Selected="True"></asp:ListItem>
            <asp:ListItem Value="TAG"></asp:ListItem>
            <asp:ListItem Value="UDT"></asp:ListItem>
            <asp:ListItem Value="HMI Picture"></asp:ListItem>
            <asp:ListItem Value="HMI Template"></asp:ListItem>
            <asp:ListItem Value="HMI PopUp"></asp:ListItem>
            <asp:ListItem Value="HMI Variable"></asp:ListItem>
            <asp:ListItem Value="HMI VB-Script"></asp:ListItem>
        </asp:RadioButtonList>
   
</asp:Content>
