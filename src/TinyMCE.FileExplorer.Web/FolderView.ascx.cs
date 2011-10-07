using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinyMCE.FileExplorer.Web.Core;
using TinyMCE.FileExplorer.Web.Core.Models;

namespace TinyMCE.FileExplorer.Web
{
	public partial class FolderView : UserControl
	{
		#region Public Properties

		public string CssClass { get; set; }
		public Folder[] DataSource { get; set; }

		#endregion

		#region Public Override Methods

		public override void DataBind()
		{
			this.treeviewRepeater.DataSource = this.DataSource;
			this.treeviewRepeater.DataBind();
		}

		#endregion

		#region Protected Methods

		protected void treeviewRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var node = e.Item.DataItem as Folder;

			if (node != null && node.Children.Count > 0)
			{
				var folderView = this.LoadControl(string.Concat(Config.GetTinyMCEFilExplorerVirtualFolder(), "FolderView.ascx")) as FolderView;
				var placeHolder = e.Item.FindControl("innerPlaceHolder") as PlaceHolder;

				folderView.DataSource = node.Children.ToArray();
				folderView.DataBind();

				placeHolder.Controls.Add(folderView);
			}
		}

		#endregion

		#region Protected Override Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		#endregion
	}
}