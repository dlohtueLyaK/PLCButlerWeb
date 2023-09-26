<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculationList.aspx.cs" Inherits="PLCButlerWeb._CalculationList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Berechnungsliste</h1>
        <p><a href="TimerList.aspx">Zurück</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="ControllerList.aspx">Weiter</a></p>
        <p><span style="font-size: medium">
            <asp:Button ID="CalculationAddButton" runat="server" Height="38px" OnClick="CalculationAddButton_Click" Text="Hinzufügen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CalculationClearButton" runat="server" Height="38px" OnClick="CalculationClearButton_Click" Text="Löschen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CalculationImpButton" runat="server" Height="38px" OnClick="CalculationImpButton_Click" Text="Import" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CalculationExpButton" runat="server" Height="38px" OnClick="CalculationExpButton_Click" Text="Export" Width="94px" />
            </span></p>
        
<table>
    <tr>
        <td><span style="font-size: medium">Name</span></td>
        <td><asp:TextBox ID="CalculationName" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td><span style="font-size: medium">Berechnung</span></td>
        <td><asp:TextBox ID="CalculationFormula" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Kommentar</td>
        <td> <asp:TextBox ID="CalculationFunction" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>
</table>     

        <p><span style="font-size: medium">
            <asp:Label ID="CalculationResult" runat="server"></asp:Label>
            </span>
        </p>
    </div>

    </asp:Content>
