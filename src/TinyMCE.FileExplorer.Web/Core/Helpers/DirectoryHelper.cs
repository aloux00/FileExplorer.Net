using System.IO;
using TinyMCE.FileExplorer.Web.Core.Utils;

namespace TinyMCE.FileExplorer.Web.Core.Helpers
{
	public sealed class DirectoryHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static DirectoryHelper _instance;
		private static DirectoryHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new DirectoryHelper();

					return _instance;
				}
			}
		}

		private DirectoryHelper() { }

		#endregion

		#region Public Static Methods

		public static bool Exists(string path)
		{
			Check.Arguments.ThrowIfStringNotSafe(path, "path");

			if (path.StartsWith("~"))
				return Instance.VirtualPathExists(path);

			return Instance.MappedPathExists(path);
		}

		public static void EnsureExistence(string path)
		{
			Instance.EnsureDirectoryExistence(path);
		}

		#endregion

		#region Private Methods

		private bool VirtualPathExists(string virtualPath)
		{
			Check.Arguments.ThrowIfStringNotSafe(virtualPath, "virtualPath");

			return this.MappedPathExists(PathHelper.ToMappedPath(virtualPath));
		}

		private bool MappedPathExists(string mappedPath)
		{
			Check.Arguments.ThrowIfStringNotSafe(mappedPath, "mappedPath");

			return Directory.Exists(mappedPath);
		}

		private void EnsureDirectoryExistence(string path)
		{
			Check.Arguments.ThrowIfStringNotSafe(path, "path");

			if (path.StartsWith("~"))
				path = PathHelper.ToMappedPath(path);

			if (!this.MappedPathExists(path))
				Directory.CreateDirectory(path);
		}

		#endregion
	}
}