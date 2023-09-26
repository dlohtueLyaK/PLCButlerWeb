<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeviceList.aspx.cs" Inherits="PLCButlerWeb._DeviceList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Device list</h1>
        <p><span style="font-size: medium">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ParameterList.aspx">next</asp:HyperLink>
            </span></p>
        <p><span style="font-size: medium">
            <asp:Button ID="DeviceAddButton" runat="server" Height="38px" OnClick="DeviceAddButton_Click" Text="Add" Width="94px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeviceClearButton" runat="server" Height="38px" OnClick="DeviceClearButton_Click" Text="Delete" Width="94px" />
            &nbsp;&nbsp;&nbsp;
<table>
  <tr>
    <td><span style="font-size: medium">Name</span></td>
    <td><asp:TextBox ID="DeviceName" runat="server" Height="25px" Width="130px"></asp:TextBox></td>
  </tr>

  <tr>
    <td><p style="margin-bottom: 5px">Device type<span style="font-size: medium"></td>
    <td>        <asp:ListBox ID="DeviceTyp" runat="server" Height="25px" Width="130px" Rows="1">
                <asp:ListItem>Sensor analog</asp:ListItem>
                <asp:ListItem>Sensor digital</asp:ListItem>
                <asp:ListItem>Ventil digital</asp:ListItem>
                <asp:ListItem>Ventil analog</asp:ListItem>
                <asp:ListItem>Pumpe</asp:ListItem>
                <asp:ListItem>Pumpe with FC</asp:ListItem>
              <%--   <asp:ListItem>Tank</asp:ListItem> --%>
              <%--   <asp:ListItem>Membrane</asp:ListItem> --%>
            </asp:ListBox></td>
   </tr>

  <tr>
    <td><p style="margin-bottom: 5px">measurement range min</td>
    <td><asp:TextBox ID="DeviceRangeMin" runat="server" Height="25px" Width="130px"></asp:TextBox></td>
   </tr>

  <tr>
    <td><p style="margin-bottom: 5px">measurement range max</td>
    <td><asp:TextBox ID="DeviceRangeMax" runat="server" Height="25px" Width="130px"></asp:TextBox></td>
   </tr>

  <tr>
    <td><p style="margin-bottom: 5px">Unit<span style="font-size: medium"></span></td>
    <td><asp:ListBox ID="DeviceUnit" runat="server" Height="25px" Width="130px" Rows="1">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>-</asp:ListItem>
                <asp:ListItem>%</asp:ListItem>
                <asp:ListItem>factor</asp:ListItem>
                <asp:ListItem>bar</asp:ListItem>
                <asp:ListItem>m³/h</asp:ListItem>
                <asp:ListItem>l/h</asp:ListItem>
                <asp:ListItem>l</asp:ListItem>
                <asp:ListItem>m²</asp:ListItem>
                <asp:ListItem>m³</asp:ListItem>
                <asp:ListItem>s</asp:ListItem>
            </asp:ListBox></td>
   </tr>

  <tr>
    <td><p style="margin-bottom: 5px">Comment</td>
    <td><asp:TextBox ID="DeviceFunction" runat="server" Height="25px" Width="300px"></asp:TextBox></td>
   </tr>
</table>
               
        <p><span style="font-size: medium">
            &nbsp;</span></p>
        <p><span style="font-size: medium">
            <asp:Label ID="DeviceResult" runat="server"></asp:Label>
            </span>
        </p>
    </div>

    </asp:Content>
