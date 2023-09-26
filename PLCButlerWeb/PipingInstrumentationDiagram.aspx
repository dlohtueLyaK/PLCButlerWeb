<%@ Page Title="PLCButlerWeb" Language="C#" AutoEventWireup="true" CodeBehind="PipingInstrumentationDiagram.aspx.cs" Inherits="PLCButlerWeb.PipingInstrumentationDiagram" %>

<%@ Register Assembly="MindFusion.Diagramming.WebForms" Namespace="MindFusion.Diagramming.WebForms" TagPrefix="ndiag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>MindFusion NetDiagram Sample - SVG Nodes</title>
  <link href="common/jquery-ui.min.css" rel="stylesheet" />
  <link href="common/samples.css" rel="stylesheet" />
  <script type="text/javascript" src="common/jquery.min.js"></script>
  <script type="text/javascript" src="common/jquery-ui.min.js"></script>
  <script type="text/javascript" src="common/samples.js"></script>
</head>
<body>
<form id="form1" runat="server">

  <asp:ScriptManager ID="ScriptManager1" runat="server" />

  <div id="header" style="height: 49px;">
    <div style="float: left; margin-right: 5px; margin-top: 17px;">
      <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
      <asp:Button ID="btnLoad" runat="server" onclick="btnLoad_Click" Text="Load" />
      <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="Reset" />
      <asp:Button ID="DeleteButton" runat="server" onclick="btnDelete_Click" Text="Delete" />
        <asp:Button ID="back" runat="server" onclick="btnBack_Click" Text="<<" />
        <asp:Button ID="undone" runat="server" onclick="btnUndone_Click" Text=">>" />
      <asp:TextBox ID="Textbox" runat="server" Width="451px" /> 
      
      <asp:Button ID="btnValve" runat="server" onclick="btnValve_Click" Text="Valve" />
      <asp:Button ID="btnPump" runat="server" onclick="btnPump_Click" Text="Pump" />
      <asp:Button ID="btnTank" runat="server" onclick="btnTank_Click" Text="Tank" />
      <asp:Button ID="btnMem" runat="server" onclick="btnMem_Click" Text="Membrane" />
      <asp:Button ID="btnDrain" runat="server" onclick="btnDrain_Click" Text="Drain" />
      <asp:Button ID="btnIni" runat="server" onclick="btnIni_Click" Text="Initiator" />
      <asp:Button ID="btnTimer" runat="server" onclick="btnTimer_Click" Text="Timer" />
    </div>  
  </div>
  
     

  <div id="content" style="top: 60px; bottom: 24px;">
    <ndiag:DiagramView runat="server" ID="diagramView" style="position: absolute; left: 0px; top: 0px; right: 0px; bottom: 0px; overflow: hidden;"
      ClientSideMode="Canvas"  Diagram-BackgroundImageAlign="Stretch" />
      
  </div>

  <div id="bottom" style="height: 49px;">
    <div style="float: left; margin-right: 5px; margin-top: 550px;">

      <asp:Button ID="btnActive" runat="server" onclick="btnActive_Click" Text="Active" />
      <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="|<" />
      <asp:Button ID="btnPlay" runat="server" onclick="btnPlay_Click" Text="Play" />
      <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" Text=">|" />
      
        <asp:Label ID="ItemsLabel" runat="server"></asp:Label>
        <asp:Label ID="StepNumber" runat="server"></asp:Label>

    </div>
  </div>
</form>
</body>
</html>
