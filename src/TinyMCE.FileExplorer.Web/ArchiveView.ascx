<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" CodeBehind="ArchiveView.ascx.cs" Inherits="TinyMCE.FileExplorer.Web.ArchiveView" %>
<%@ Import Namespace="L10n=TinyMCE.FileExplorer.Web.Core.Resources.Views.Messages" %>

<asp:Repeater ID="archiveViewRepeater" runat="server" OnItemDataBound="archiveViewRepeater_ItemDataBound">
	<HeaderTemplate>
		<table class="archive-view fixed-thead" summary="<%= L10n.ArchiveViewSummary %>">
			<thead>
				<tr>
					<td class="name"><span><%= L10n.ArchiveViewName %></span></td>
					<td class="path"><span><%= L10n.ArchiveViewPath %></span></td>
					<td class="size"><span><%= L10n.ArchiveViewSize %></span></td>
					<td class="date-created"><span><%= L10n.ArchiveViewDateCreated %></span></td>
					<td class="preview"><span><%= L10n.ArchiveViewPreview %></span></td>
					<td class="download"><span><%= L10n.ArchiveViewDownload %></span></td>
					<td class="select"><span><%= L10n.ArchiveViewSelect %></span></td>
					<td class="delete"><span><%= L10n.ArchiveViewDelete %></span></td>
				</tr>
			</thead>
			<tfoot>
				<tr>
					<td class="foot" colspan="8">
						<span><%= L10n.ArchiveViewTotalFiles %></span>
						<strong><asp:Literal ID="totalFilesLiteral" runat="server" /></strong>
					</td>
				</tr>
			</tfoot>
			<tbody>
	</HeaderTemplate>
	<FooterTemplate>
			</tbody>
		</table>
	</FooterTemplate>
	<ItemTemplate>
				<tr class="<%# (Container.ItemIndex % 2 == 0 ? "normal" : "striped") %>">
					<td class="name"><span><%# DataBinder.Eval(Container.DataItem, "Name") %></span></td>
					<td class="path"><span><%# DataBinder.Eval(Container.DataItem, "Path") %></span></td>
					<td class="size"><span><%# string.Format("{0:0.# Kb}", DataBinder.Eval(Container.DataItem, "Size"))%></span></td>
					<td class="date-created"><span><%# ((DateTime)DataBinder.Eval(Container.DataItem, "DateCreated")).ToString("dd/MM/yyyy HH:mm:ss") %></span></td>
					<td class="preview"><span><a href="#" class="preview"><%= L10n.ArchiveViewPreview %></a></span></td>
					<td class="download"><span><a href="#" class="download"><%= L10n.ArchiveViewDownload %></a></span></td>
					<td class="select"><span><a href="#" class="select"><%= L10n.ArchiveViewSelect %></a></span></td>
					<td class="delete"><span><a href="#" class="delete"><%= L10n.ArchiveViewDelete %></a></span></td>
				</tr>
	</ItemTemplate>
</asp:Repeater>