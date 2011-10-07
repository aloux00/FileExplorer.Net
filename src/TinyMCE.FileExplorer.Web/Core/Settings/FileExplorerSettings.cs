using System.Collections.Generic;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Extensions;

namespace TinyMCE.FileExplorer.Web.Core.Settings
{
	public class FileExplorerSettings
	{
		#region Private Read-Only Fields

		private readonly AccessSettings _access = new AccessSettings();
		private readonly DirectorySettings _directory = new DirectorySettings();
		private readonly FileSettings _file = new FileSettings();
		private readonly HashSet<ResourcesSettings> _resources = new HashSet<ResourcesSettings>();

		#endregion

		#region Public Properties

		public AccessSettings Access
		{
			get { return this._access; }
		}
		public DirectorySettings Directory
		{
			get { return this._directory; }
		}
		public FileSettings File
		{
			get { return this._file; }
		}

		#endregion

		#region Public Methods

		public ResourcesSettings[] GetResources()
		{
			return this._resources.ToArray();
		}

		public FileExplorerSettings SetResources(params ResourcesSettings[] resources)
		{
			if (!resources.IsNullOrEmpty())
				foreach (var resource in resources)
					this._resources.Add(resource);

			return this;
		}

		#endregion
	}
}