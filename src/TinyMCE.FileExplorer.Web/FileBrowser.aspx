<%@ Page Language="C#" AutoEventWireup="false" EnableViewState="false" CodeBehind="FileBrowser.aspx.cs"	Inherits="TinyMCE.FileExplorer.Web.FileBrowser" %>
<%@ Import Namespace="TinyMCE.FileExplorer.Web.Core.Infrastructure" %>
<%@ Import Namespace="L10n=TinyMCE.FileExplorer.Web.Core.Resources.Views.Messages" %>
<%@ Register Src="~/FolderView.ascx" TagName="FolderView" TagPrefix="tmceFE" %>
<%@ Register Src="~/ArchiveView.ascx" TagName="ArchiveView" TagPrefix="tmceFE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

	<%= ContentResolver.GetStyleResource("jquery.layout.1.3.css") %>
	<%= ContentResolver.GetStyleResource("main.css") %>
	
	<%= ContentResolver.GetScriptResource("jquery-1.6.4.min.js") %>
	<%= ContentResolver.GetScriptResource("jquery-ui-1.8.16.min.js") %>
	<%= ContentResolver.GetScriptResource("jquery.blockUI.2.39.js")%>
	<%= ContentResolver.GetScriptResource("jquery.fixed.thead.js")%>
	<%= ContentResolver.GetScriptResource("jquery.layout.1.3.min.js")%>
	<%= ContentResolver.GetScriptResource("jquery.live.filter.1.4MARK.js")%>
	<%= ContentResolver.GetScriptResource("jquery.tablescroll.js")%>
	<%= ContentResolver.GetScriptResource("jquery.tablesorter.min.js")%>
	<%= ContentResolver.GetScriptResource("jquery.treeview.js")%>
	<%= ContentResolver.GetScriptResource("l10n.min.js")%>
	<%= ContentResolver.GetScriptResource("l10n.localizations.js")%>
	<%= ContentResolver.GetScriptResource("main.js")%>
		
	<!--[if !IE 7]>
		<style type="text/css">
			div.ui-layout-center div#wrap
			{
				display: table;
				height: 100%;
			}
		</style>
	<![endif]-->

	<title>TinyMCE File Browser</title>
</head>
<body>
	<form id="mainForm" runat="server">
		<div class="ui-layout-north ui-background">
			<div class="controls-container">
				<ul class="treeview-controls">
					<li><a href="#" class="collapse-all" title="<%= L10n.ToolbarCollapseFolderExplorer %>"><%= L10n.ToolbarCollapseFolderExplorer %></a></li>
					<li><a href="#" class="expand-all" title="<%= L10n.ToolbarExpandFolderExplorer %>"><%= L10n.ToolbarExpandFolderExplorer %></a></li>
					<li><a href="#" class="toggle" title="<%= L10n.ToolbarToggleFolderExplorer%>"><%= L10n.ToolbarToggleFolderExplorer%></a></li>
					<li><a href="#" class="refresh" title="<%= L10n.ToolbarRefreshFolderExplorer%>"><%= L10n.ToolbarRefreshFolderExplorer%></a></li>
				</ul>
				<ul class="toolbar">
					<li><a href="#" class="upload-files" title="<%= L10n.ToolbarUploadFiles %>"><%= L10n.ToolbarUploadFiles %></a></li>
					<li><a href="#" class="delete-folder" title="<%= L10n.ToolbarDeleteFolder %>"><%= L10n.ToolbarDeleteFolder %></a></li>
					<li><a href="#" class="new-folder" title="<%= L10n.ToolbarNewFolder %>"><%= L10n.ToolbarNewFolder %></a></li>
				</ul>
				<div class="search">
					<label for="findfile"><%= L10n.ToolbarFindFile %></label>
					<input type="text" id="findfile" name="findfile" value="" />
				</div>
			</div>
		</div>
		<div class="ui-layout-west">
			<div class="folder-view-container"><!-- --></div>
		</div>
		<div class="ui-layout-center">
			<div class="archive-view-container"><!-- --></div>
		</div>
		<div class="ui-layout-south ui-background">
			<p class="selected-folder-location"><!-- --></p>
		</div>
	</form>
</body>
</html>