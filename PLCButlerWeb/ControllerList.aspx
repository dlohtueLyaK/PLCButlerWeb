<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControllerList.aspx.cs" Inherits="PLCButlerWeb._ControllerList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Steuerbefehle</h1>
        <p><a href="CalculationList.aspx">Zurück</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="PipingInstrumentationDiagram.aspx">Weiter</a></p>
        <p><span style="font-size: medium">
            <asp:Button ID="ContollerAddButton" runat="server" Height="38px" OnClick="ControllerAddButton_Click" Text="Hinzufügen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ControllerClearButton" runat="server" Height="38px" OnClick="ControllerClearButton_Click" Text="Löschen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ContollerImpButton" runat="server" Height="38px" OnClick="ControllerImpButton_Click" Text="Import" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ContollerExpButton" runat="server" Height="38px" OnClick="ControllerExpButton_Click" Text="Export" Width="94px" />
            </span></p>
        
<table>
    <tr>
        <td><span style="font-size: medium">Name</span></td>
        <td><asp:TextBox ID="ControllerName" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td><span style="font-size: medium">Steuerbefehl</span></td>
        <td><asp:TextBox ID="ControllerController" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Kommentar</td>
        <td> <asp:TextBox ID="ControllerFunction" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>
</table>    

        <p><span style="font-size: medium">
            <asp:Label ID="ControllerResult" runat="server"></asp:Label>
            </span>
        </p>
    </div>

    </asp:Content>
