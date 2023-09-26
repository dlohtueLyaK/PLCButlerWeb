<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParameterList.aspx.cs" Inherits="PLCButlerWeb._ParameterList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Parameterliste</h1>
        <p><a href="DeviceList.aspx">Zurück</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="CounterList.aspx">Weiter</a></p>
        <p>
            <asp:Button ID="ParameterAddButton" runat="server" Height="38px" OnClick="ParameterAddButton_Click" Text="Hinzufügen" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ParameterClearButton" runat="server" Height="38px" OnClick="ParameterClearButton_Click" Text="Löschen" Width="94px" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ParameterImpButton" runat="server" Height="38px" OnClick="ParameterImpButton_Click" Text="Import" Width="94px" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ParameterExpButton" runat="server" Height="38px" OnClick="ParameterExpButton_Click" Text="Export" Width="94px" />
        </p>
        
<table>
    <tr>
        <td><span style="font-size: medium">Name</span></td>
        <td><span style="font-size: medium"><asp:TextBox ID="ParameterName" runat="server" Height="25px" Width="130px"></asp:TextBox>
            </span></td>
    </tr>

    <tr>
        <td><span style="font-size: medium">Parametertyp</span></td>
        <td><span style="font-size: medium"> <asp:ListBox ID="ParameterTyp" runat="server" Height="25px" Width="130px" Rows="1">
                <asp:ListItem>INT</asp:ListItem>
                <asp:ListItem>REAL</asp:ListItem>
            </asp:ListBox>
            </span>
        </td>
    </tr>

    <tr>
        <td>Bereich min</td>
        <td><asp:TextBox ID="ParameterRangeMin" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Bereich max</td>
        <td><asp:TextBox ID="ParameterRangeMax" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Standard<span style="font-size: medium">wert</span></td>
        <td><asp:TextBox ID="ParameterDefaultValue" runat="server" Height="25px" Width="130px"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Einheit</td>
        <td><span style="font-size: medium"> <asp:ListBox ID="ParameterUnit" runat="server" Height="25px" Width="130px" Rows="1">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>%</asp:ListItem>
                <asp:ListItem>factor</asp:ListItem>
                <asp:ListItem>bar</asp:ListItem>
                <asp:ListItem>m³/h</asp:ListItem>
                <asp:ListItem>l/h</asp:ListItem>
                <asp:ListItem>l</asp:ListItem>
                <asp:ListItem>m²</asp:ListItem>
                <asp:ListItem>m³</asp:ListItem>
                <asp:ListItem>s</asp:ListItem>
                <asp:ListItem>min</asp:ListItem>
                <asp:ListItem>h</asp:ListItem>    
        </asp:ListBox>
            </span>
        </td>
    </tr>

    <tr>
        <td>Kommentar&nbsp;</td>
        <td> <asp:TextBox ID="ParameterFunction" runat="server" Height="25px" Width="300px"></asp:TextBox>
        </td>
    </tr>
</table>        
        
        <p><span style="font-size: medium">
            <asp:Label ID="ParameterResult" runat="server"></asp:Label>
            </span>
        </p>
    </div>

    </asp:Content>
