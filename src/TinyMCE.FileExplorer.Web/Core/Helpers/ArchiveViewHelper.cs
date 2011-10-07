using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Models;
using TinyMCE.FileExplorer.Web.Core.Utils;

namespace TinyMCE.FileExplorer.Web.Core.Helpers
{
	public static class ArchiveViewHelper
	{
		#region Public Static Methods

		public static Archive[] GetFiles(string virtualPath, string resourceType)
		{
			Check.Arguments.ThrowIfStringNotSafe(virtualPath, "virtualPath");
			Check.Arguments.ThrowIfStringNotSafe(resourceType, "resourceType");

			var result = new List<Archive>();
			var mappedPath = PathHelper.ToMappedPath(virtualPath);
			var dir = new DirectoryInfo(mappedPath);
			var resource = FileBrowser.Config.Settings.GetResources().FirstOrDefault(item => item.ResourceType.Equals(resourceType, StringComparison.InvariantCultureIgnoreCase));

			if (resource != null)
			{
				var extensions = resource.GetAllowedExtensions();

				foreach (var file in dir.GetFiles())
				{
					if (!extensions.Any(extension => extension.Equals(file.Extension, StringComparison.InvariantCultureIgnoreCase)))
						continue;

					result.Add(new Archive()
					{
						DateCreated = file.CreationTime,
						Name = file.Name,
						Path = PathHelper.ToRelativePath(file.FullName),
						Size = (file.Length / 1024d)
					});
				}
			}

			return result.ToArray();
		}

		#endregion
	}
}