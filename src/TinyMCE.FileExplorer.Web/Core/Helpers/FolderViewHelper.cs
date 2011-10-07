using System;
using System.IO;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Extensions;
using TinyMCE.FileExplorer.Web.Core.Models;
using TinyMCE.FileExplorer.Web.Core.Settings;

namespace TinyMCE.FileExplorer.Web.Core.Helpers
{
	public static class FolderViewHelper
	{
		#region Public Static Methods

		public static Folder GetTreeview()
		{
			if (!DirectoryHelper.Exists(FileBrowser.Config.Settings.Directory.GetUserVirtualDirectory()))
				throw new DirectoryNotFoundException("User directory not found.");

			var rootVirtualPath = FileBrowser.Config.Settings.Directory.GetUserVirtualDirectory().EnsureEndsWith("/").ToLower();
			var rootMappedPath = PathHelper.ToMappedPath(rootVirtualPath);
			var rootDir = new DirectoryInfo(rootMappedPath);
			var rootNode = FolderViewHelper.GetRootTreeviewNode(rootDir);

			foreach (var resource in FileBrowser.Config.Settings.GetResources().OrderBy(x => x.ResourceType))
			{
				if (DirectoryHelper.Exists(string.Concat(rootVirtualPath, resource.ResourceType)))
				{
					var childVirtualPath = string.Concat(rootVirtualPath, resource.ResourceType).EnsureEndsWith("/").ToLower();
					var childMappethPath = PathHelper.ToMappedPath(childVirtualPath);
					var childDir = new DirectoryInfo(childMappethPath);

					rootNode.Children.Add(FolderViewHelper.GetChildTreeviewNode(childDir, rootNode, resource, 1));
				}
			}

			return rootNode;
		}

		#endregion

		#region Private Static Methods

		private static Folder GetRootTreeviewNode(DirectoryInfo directory)
		{
			return new Folder()
			{
				IsRoot = true,
				Level = 0,
				Name = directory.Name,
				Parent = null,
				Path = PathHelper.ToVirtualPath(directory.FullName),
				ResourceType = null
			};
		}

		private static Folder GetChildTreeviewNode(DirectoryInfo directory, Folder parent, ResourcesSettings resource, int level)
		{
			var exclude = FileBrowser.Config.Settings.Directory.GetHideDirectories();

			var node = new Folder()
			{
				IsRoot = false,
				Level = level,
				Name = directory.Name,
				Parent = parent,
				Path = string.Concat(parent.Path, directory.Name, "/"),
				ResourceType = resource.ResourceType
			};

			foreach (var child in directory.GetDirectories())
				if (!exclude.Contains(child.Name, StringComparison.InvariantCultureIgnoreCase))
					node.Children.Add(FolderViewHelper.GetChildTreeviewNode(child, node, resource, (level + 1)));

			return node;
		}

		#endregion
	}
}