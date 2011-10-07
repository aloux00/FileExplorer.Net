using System;
using System.Web.UI;
using TinyMCE.FileExplorer.Web.Core.Models;
using System.Web.UI.WebControls;
using TinyMCE.FileExplorer.Web.Core;

namespace TinyMCE.FileExplorer.Web
{
	public partial class ArchiveView : UserControl
	{
		#region Public Properties

		public string CssClass { get; set; }
		public Archive[] DataSource { get; set; }

		#endregion

		#region Public Override Methods

		public override void DataBind()
		{
			this.archiveViewRepeater.DataSource = this.DataSource;
			this.archiveViewRepeater.DataBind();
		}

		#endregion

		#region Protected Methods

		protected void archiveViewRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Header)
				((Literal)e.Item.FindControl("totalFilesLiteral")).Text = ((Archive[])((Repeater)sender).DataSource).Length.ToString();
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