using System.Web;
using TinyMCE.FileExplorer.Web.Core.Utils;

namespace TinyMCE.FileExplorer.Web.Core.Helpers
{
	public sealed class PathHelper
	{
		#region Singleton

		private static readonly object padlock = new object();
		private static PathHelper _instance;
		private static PathHelper Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
						_instance = new PathHelper();

					return _instance;
				}
			}
		}

		private PathHelper() { }

		#endregion

		#region Private Constants

		private const string APPL_PHYSICAL_PATH_KEY = "APPL_PHYSICAL_PATH";

		#endregion

		#region Private Properties

		private string ApplicationPhysicalPath
		{
			get { return HttpContext.Current.Request.ServerVariables[APPL_PHYSICAL_PATH_KEY]; }
		}

		#endregion

		#region Public Static Methods

		public static string ToRelativePath(string mappedPath)
		{
			return Instance.MappedPathToRelativePath(mappedPath);
		}

		public static string ToVirtualPath(string mappedPath)
		{
			return Instance.MappedPathToVirtualPath(mappedPath);
		}

		public static string ToMappedPath(string virtualPath)
		{
			return Instance.VirtualPathToMappedPath(virtualPath);
		}

		public static string VirtualPathToRelativePath(string virtualPath)
		{
			return Instance.FromVirtualPathToRelativePath(virtualPath);
		}

		#endregion

		#region Private Methods

		private string MappedPathToRelativePath(string mappedPath)
		{
			Check.Arguments.ThrowIfStringNotSafe(mappedPath, "mappedPath");

			return string.Concat("/", mappedPath.Replace(this.ApplicationPhysicalPath, string.Empty).Replace("\\", "/"));
		}

		private string MappedPathToVirtualPath(string mappedPath)
		{
			Check.Arguments.ThrowIfStringNotSafe(mappedPath, "mappedPath");

			return string.Concat("~", this.MappedPathToRelativePath(mappedPath));
		}

		private string VirtualPathToMappedPath(string virtualPath)
		{
			Check.Arguments.ThrowIfStringNotSafe(virtualPath, "virtualPath");

			return HttpContext.Current.Server.MapPath(virtualPath);
		}

		private string FromVirtualPathToRelativePath(string virtualPath)
		{
			Check.Arguments.ThrowIfStringNotSafe(virtualPath, "virtualPath");

			var path = this.VirtualPathToMappedPath(virtualPath);

			return this.MappedPathToRelativePath(path);
		}

		#endregion
	}
}