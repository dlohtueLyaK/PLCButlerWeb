<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CounterList.aspx.cs" Inherits="PLCButlerWeb._CounterList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Zählerliste</h1>
        <p><a href="ParameterList.aspx">Zurück</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="TimerList.aspx">Weiter</a></p>
        <p>
            <asp:Button ID="CounterAddButton" runat="server" Height="38px" OnClick="CounterAddButton_Click" Text="Hinzufügen" Width="94px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CounterClearButton" runat="server" Height="38px" OnClick="CounterClearButton_Click" Text="Löschen" Width="94px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CounterImpButton" runat="server" Height="38px" OnClick="CounterImpButton_Click" Text="Import" Width="94px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="CounterExpButton" runat="server" Height="38px" OnClick="CounterExpButton_Click" Text="Export" Width="94px" />
        </p>
        
<table>
    <tr>
        <td><span style="font-size: medium">Name</span></td>
        <td><asp:TextBox ID="CounterName" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td><span style="font-size: medium">Zielwert</span></td>
        <td><asp:TextBox ID="CounterGoalValue" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td><span style="font-size: medium">Zählimpuls</span></td>
        <td><asp:TextBox ID="CounterCountUp" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Z<span style="font-size: medium">ählwert</span></td>
        <td> <asp:TextBox ID="CounterIncreaseValue" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Einheit</td>
        <td><span style="font-size: medium"><asp:ListBox ID="CounterUnit" runat="server" Height="25px" Width="130px" Rows="1">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>%</asp:ListItem>
                <asp:ListItem>Faktor</asp:ListItem>
                <asp:ListItem>bar</asp:ListItem>
                <asp:ListItem>m³/h</asp:ListItem>
                <asp:ListItem>l/h</asp:ListItem>
                <asp:ListItem>l</asp:ListItem>
                <asp:ListItem>m²</asp:ListItem>
                <asp:ListItem>m³</asp:ListItem>
                <asp:ListItem>s</asp:ListItem>
            </asp:ListBox>
            </span>
        </td>
    </tr>

    <tr>
        <td>Startwert</td>
        <td> <asp:TextBox ID="CounterResetValue" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Kommentar</td>
        <td> <asp:TextBox ID="CounterFunction" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>
</table>        
        <p><span style="font-size: medium">
            <asp:Label ID="CounterResult" runat="server"></asp:Label>
            </span>
        </p>
    </div>

    </asp:Content>
