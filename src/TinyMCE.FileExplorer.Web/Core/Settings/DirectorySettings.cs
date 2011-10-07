using System.Collections.Generic;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Extensions;

namespace TinyMCE.FileExplorer.Web.Core.Settings
{
	public class DirectorySettings
	{
		#region Private Constants

		private const string DEFAULT_BASE_VIRTUAL_DIRECTORY = "~/tinymce_fileexplorer/content/";
		private const string DEFAULT_USER_VIRTUAL_DIRECTORY = "~/tinymce_fileexplorer/user/";

		#endregion

		#region Private Fields

		private string _baseVirtualDirectory;
		private string _userVirtualDirectory;
		
		#endregion

		#region Private Read-Only Fields

		private readonly HashSet<string> _hideDirectories = new HashSet<string>();

		#endregion

		#region Public Methods

		public string GetBaseVirtualDirectory()
		{
			return (this._baseVirtualDirectory.IsSafe() ? this._baseVirtualDirectory : DirectorySettings.DEFAULT_BASE_VIRTUAL_DIRECTORY);
		}

		public DirectorySettings SetBaseVirtualDirectory(string baseVirtualDirectory)
		{
			if (baseVirtualDirectory.IsSafe())
				this._baseVirtualDirectory = baseVirtualDirectory;

			return this;
		}

		public string GetUserVirtualDirectory()
		{
			return (this._userVirtualDirectory.IsSafe() ? this._userVirtualDirectory : DirectorySettings.DEFAULT_USER_VIRTUAL_DIRECTORY);
		}

		public DirectorySettings SetUserVirtualDirectory(string userVirtualDirectory)
		{
			if (userVirtualDirectory.IsSafe())
				this._userVirtualDirectory = userVirtualDirectory;

			return this;
		}

		public string[] GetHideDirectories()
		{
			return this._hideDirectories.ToArray();
		}

		public DirectorySettings SetHideDirectories(params string[] directories)
		{
			if (!directories.IsNullOrEmpty())
				foreach (var directory in directories)
					this._hideDirectories.Add(directory);

			return this;
		}

		#endregion
	}
}