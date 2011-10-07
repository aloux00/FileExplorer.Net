<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" CodeBehind="FolderView.ascx.cs" Inherits="TinyMCE.FileExplorer.Web.FolderView" %>

<asp:Repeater ID="treeviewRepeater" runat="server" OnItemDataBound="treeviewRepeater_ItemDataBound">
	<HeaderTemplate><ul></HeaderTemplate>
	<FooterTemplate></ul></FooterTemplate>
	<ItemTemplate>
		<li class="level-<%# DataBinder.Eval(Container.DataItem, "Level") %>">
			<input type="hidden" name="path" value="<%# DataBinder.Eval(Container.DataItem, "Path") %>" />
			<input type="hidden" name="resource_type" value="<%# DataBinder.Eval(Container.DataItem, "ResourceType") %>" />
			<span class="<%# ((bool)DataBinder.Eval(Container.DataItem, "IsRoot")) ? "root folder" : (Container.ItemIndex % 2 == 0 ? "striped folder" : "normal folder") %>"><%# DataBinder.Eval(Container.DataItem, "Name") %></span>
			<asp:PlaceHolder ID="innerPlaceHolder" runat="server" />
		</li>
	</ItemTemplate>
</asp:Repeater>