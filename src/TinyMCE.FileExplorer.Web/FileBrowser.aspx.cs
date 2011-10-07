using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using TinyMCE.FileExplorer.Web.Core;
using TinyMCE.FileExplorer.Web.Core.Extensions;
using TinyMCE.FileExplorer.Web.Core.Models;
using System.Collections.Generic;
using TinyMCE.FileExplorer.Web.Core.Infrastructure;
using System.Text;
using TinyMCE.FileExplorer.Web.Core.Helpers;

namespace TinyMCE.FileExplorer.Web
{
	public partial class FileBrowser : Page
	{
		#region Public Static Properties

		public static Config Config { get; private set; }

		#endregion

		#region Protected Override Methods

		protected override void OnLoad(EventArgs e)
		{
			this.Run();
		}

		#endregion

		#region Private Methods

		private void Initialize()
		{
			FileBrowser.Config = Page.LoadControl(string.Concat(Config.GetTinyMCEFilExplorerVirtualFolder(), "Config.ascx")) as Config;
			FileBrowser.Config.Configure();
		}

		// TODO : Dar um nome melhor a este método.
		private bool CheckAuthentication()
		{
			var authenticated = FileBrowser.Config.IsAuthenticated();
			var authorized = false;

			if (!FileBrowser.Config.Settings.Access.GetRoles().Contains("*"))
			{
				foreach (var role in FileBrowser.Config.Settings.Access.GetRoles())
				{
					authorized = User.IsInRole(role);

					if (authorized) break;
				}
			}
			else
				authorized = true;

			return authenticated && authorized;
		}

		private void Run()
		{
			this.Initialize();

			if (this.CheckAuthentication() && this.Request.IsAjaxRequest())
				this.RunAjaxCall();
		}

		private void RunAjaxCall()
		{
			switch (Request["ajax_call"])
			{
				case "render_folder_view": this.RenderFolderViewAjaxCall(); break;
				case "render_archive_view": this.RenderArchiveViewAjaxCall(); break;
				default: break;
			}
		}

		private void RenderFolderViewAjaxCall()
		{
			Response.ContentEncoding = Encoding.UTF8;
			Response.ContentType = "text/html";

			var folderView = Page.LoadControl(string.Concat(Config.GetTinyMCEFilExplorerVirtualFolder(), "FolderView.ascx")) as FolderView;
			var root = FolderViewHelper.GetTreeview();

			folderView.DataSource = new Folder[] { root };
			folderView.DataBind();

			Response.Write(folderView.RenderHtml());
			Response.End();
		}

		private void RenderArchiveViewAjaxCall()
		{
			Response.ContentEncoding = Encoding.UTF8;
			Response.ContentType = "text/html";

			var archiveView = Page.LoadControl(string.Concat(Config.GetTinyMCEFilExplorerVirtualFolder(), "ArchiveView.ascx")) as ArchiveView;
			var virtualPath = Request["path"];
			var resourceType = Request["resource"];

			archiveView.DataSource = ArchiveViewHelper.GetFiles(virtualPath, resourceType);
			archiveView.DataBind();

			Response.Write(archiveView.RenderHtml());
			Response.End();
		}

		private void RegisterStartupScriptMessage(string message)
		{
			ClientScript.RegisterStartupScript(this.GetType()
				, Guid.NewGuid().ToString()
				, string.Format("alert('{0}');", message)
				, true);
		}

		#endregion
	}
}