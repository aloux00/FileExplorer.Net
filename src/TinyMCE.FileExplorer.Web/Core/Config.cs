using System.Configuration;
using System.Web.UI;
using TinyMCE.FileExplorer.Web.Core.Settings;

namespace TinyMCE.FileExplorer.Web.Core
{
	public class Config : UserControl
	{
		#region Private Read-Only Fields

		private readonly FileExplorerSettings _settings = new FileExplorerSettings();

		#endregion

		#region Public Properties

		public FileExplorerSettings Settings
		{
			get { return this._settings; }
		}

		#endregion

		#region Public Static Methods

		public static string GetTinyMCEFilExplorerVirtualFolder()
		{
			return ConfigurationManager.AppSettings.Get("tinymce.filebrowser.virtual.folder");
		}

		#endregion

		#region Public Virtual Methods

		public virtual bool IsAuthenticated() { return false; }
		public virtual void Configure() { }

		#endregion
	}
}