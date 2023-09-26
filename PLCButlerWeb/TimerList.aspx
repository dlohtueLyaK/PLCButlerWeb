<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimerList.aspx.cs" Inherits="PLCButlerWeb._TimerList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Zeitglieder</h1>
        <p><a href="CounterList.aspx">Zurück</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="CalculationList.aspx">Weiter</a></p>
        <p><span style="font-size: medium">
            <asp:Button ID="TimerAddButton" runat="server" Height="38px" OnClick="TimerAddButton_Click" Text="Hinzufügen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="TimerClearButton" runat="server" Height="38px" OnClick="TimerClearButton_Click" Text="Löschen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="TimerImButton" runat="server" Height="38px" OnClick="TimerImpButton_Click" Text="Import" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="TimerExpButton" runat="server" Height="38px" OnClick="TimerExpButton_Click" Text="Export" Width="94px" />
            </span></p>
<table>
    <tr>
        <td><span style="font-size: medium">Name</span></td>
        <td><asp:TextBox ID="TimerName" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td><span style="font-size: medium">Zielwert</span></td>
        <td><span style="font-size: medium"> <asp:TextBox ID="TimerGoalValue" runat="server" Height="25px" Width="130px"></asp:TextBox>
            </span>
        </td>
    </tr>

    <tr>
        <td>Einheit<span style="font-size: medium">&nbsp;</span></td>
        <td><span style="font-size: medium"> <asp:ListBox ID="TimerUnit" runat="server" Height="25px" Width="130px" Rows="1">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>h</asp:ListItem>
                <asp:ListItem>min</asp:ListItem>
                <asp:ListItem>s</asp:ListItem>
            </asp:ListBox>
            </span>
        </td>
    </tr>

    <tr>
        <td>Kommentar</td>
        <td> <asp:TextBox ID="TimerFunction" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>

 
</table>        
        <p><span style="font-size: medium">
            <asp:Label ID="TimerResult" runat="server"></asp:Label>
            </span>
        </p>
    </div>

    </asp:Content>
