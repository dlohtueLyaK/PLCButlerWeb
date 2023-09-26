
var netDiagramInfo =
	'<hr />' +
	'<h1>About NetDiagram</h1>' +
	'<p>NetDiagram is fully interactive flow diagramming control for ASP.NET. Flowchart and diagram graphics are render on a web page using the HTML5 Canvas element. Diagrams can be drawn on the client side by the user, or generated and arranged on server side via the provided .NET API. The package includes miscellaneous UI controls such as Overview providing scaled down view of the drawing, and NodeListView displaying a palette of diagram elements. Additional features include export to PDF, SVG, and Visio.</p>' +
	'<p>NetDiagram is part of <a href="http://mindfusion.eu/webforms-pack.html" title="MindFusion ASP.NET Pack">MindFusion ASP.NET Pack</a> &mdash; a comprehensive set of UI components which can help you create rich business applications with ease.</p>' +
	'<h2>Features</h2>' +
	'<ul>' +
		'<li>Several client-side interaction modes, including JavaApplet, image map, and HTML5 Canvas</li>' +
		'<li>Interactive zooming, scrolling, and panning</li>' +
		'<li>Hundreds of built-in shapes and the ability to define custom shapes</li>' +
		'<li>Table nodes with collapsible rows and spanning cells</li>' +
		'<li>Many ready-to-use layouts, including spring, tree, layered, orthogonal, and more</li>' +
		'<li>Automatic link routing</li>' +
		'<li>Lane grid</li>' +
		'<li>Hierarchical grouping of diagram elements</li>' +
		'<li>Undo and redo support</li>' +
		'<li>Styles and themes</li>' +
		'<li>Node effects</li>' +
		'<li>Overview control</li>' +
		'<li>Import from Visio and OpenOffice</li>' +
		'<li>Export to images, Visio, PDF, SVG, and DXF</li>' +
	'</ul>';

$(function() {
	$('select').selectmenu();
	$('input[type=submit], input[type=button], button')
		.button();

	$('#copyright').html("&copy; " + new Date().getFullYear() + " MindFusion");
	$('#infoTab :last-child').after(netDiagramInfo);
});

var collapsed = false;
function onExpandCollapse() {
	if (collapsed) {
		$('#info').css('width', '400px');
		$('#content').css('right', '401px');
		$('#expandButton').button("option", "label", ">");
		collapsed = false;
	}
	else {
		$('#info').css('width', '0px');
		$('#content').css('right', '0px');
		$('#expandButton').button("option", "label", "<");
		collapsed = true;
	}
}
