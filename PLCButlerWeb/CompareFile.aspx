<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompareFile.aspx.cs" Inherits="PLCButlerWeb.CompareFile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        
        <h1>Dateienvergleich</h1>
        <p class="lead">Pfadangabe</p>
        <p></p>
        
        <%-- TextBox 1 path 1 --%>
        Path 1 :
        <asp:TextBox ID="CompareTextBox1" Text="c:\temp\FC172 V01.xml" runat="server" Width="500px" /><asp:Button ID="Path1Button" Text="Path1" Onclick="Path1Button_Click" runat="server" />
        <br />
        <%--
            optional file searching via file explorer, but didn't work well. just get the filename not the location.
        <input type="file" id="filepath1" name="file1" class="form-control" accept=".xml" runat="server" />
        <input type="file" id="filepath2" name="file2" class="form-control" accept=".xml" runat="server" />
            --%>
        <%-- TextBox 1 path 2 --%>
        Path 2 :
        <asp:TextBox ID="CompareTextBox2" Text="c:\temp\FC173 V02.xml" runat="server" Width="500px" />
        
        <%-- Buttonto to compare--%>
        <br /><br />
        <asp:Button ID="CompareButton" Text="Compare" Onclick="CompareButton_Click" runat="server" />
        <%-- Button to clear --%>
        <asp:Button ID="ClearButton" Text="Clear" Onclick="ClearButton_Click" runat="server" />
        
        <%-- Textbox für Ergebnis --%>
        <br /><br />
        <asp:TextBox ID="ResultCompare1" Text="" runat="server" Width="1500px" Height="250" Columns="100" TextMode="MultiLine" ValidateRequestMode="Disabled" />
        <asp:TextBox ID="ResultCompare2" Text="" runat="server" Width="1500px" Height="250" Columns="100" TextMode="MultiLine" ValidateRequestMode="Disabled" />

    </div>
    
</asp:Content>
