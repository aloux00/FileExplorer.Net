using TinyMCE.FileExplorer.Web.Core.Helpers;

namespace TinyMCE.FileExplorer.Web.Core.Infrastructure
{
	public static class ContentResolver
	{
		#region Public Static Methods

		public static string GetScriptResource(string name)
		{
			return string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", ContentResolver.GetResourcePath("scripts/" + name));
		}

		public static string GetStyleResource(string name)
		{
			return string.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\" />", ContentResolver.GetResourcePath("styles/" + name));
		}

		public static string GetImageResource(string name)
		{
			return ContentResolver.GetImageResource(name, string.Empty, string.Empty);
		}

		public static string GetImageResource(string name, string alt, string title)
		{
			return string.Format("<img src=\"{0}\" alt=\"{1}\" title=\"{2}\" />", ContentResolver.GetResourcePath("images/" + name), alt, title);
		}

		#endregion

		#region Private Static Methods

		private static string GetResourcePath(string name)
		{
			var baseDir = FileBrowser.Config.Settings.Directory.GetBaseVirtualDirectory();

			return string.Concat(PathHelper.VirtualPathToRelativePath(baseDir), name);
		}

		private static string GetUserResourcePath(string name)
		{
			var userDir = FileBrowser.Config.Settings.Directory.GetUserVirtualDirectory();

			return string.Concat(PathHelper.VirtualPathToRelativePath(userDir), name);
		}

		#endregion
	}
}
