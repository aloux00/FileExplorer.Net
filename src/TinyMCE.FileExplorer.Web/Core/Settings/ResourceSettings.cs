using System.Collections.Generic;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Extensions;
using TinyMCE.FileExplorer.Web.Core.Infrastructure;
using TinyMCE.FileExplorer.Web.Core.Utils;

namespace TinyMCE.FileExplorer.Web.Core.Settings
{
	public class ResourcesSettings
	{
		#region Public Static Read-Only Fields

		public static readonly ResourcesSettings General = new ResourcesSettings("General")
		{
			_fileMaxSize = FileSize.Smallest
		};

		#endregion

		#region Private Fields

		private FileSize _fileMaxSize;

		#endregion

		#region Private Read-Only Fields

		private readonly string _resourceType;
		private readonly HashSet<string> _allowedExtensions = new HashSet<string>();

		#endregion

		#region Public Properties

		public string ResourceType
		{
			get { return this._resourceType; }
		}

		#endregion

		#region Public Constructors

		public ResourcesSettings(string resourceType)
		{
			Check.Arguments.ThrowIfNotPassRegexp(resourceType, Constants.REGEXP_NUMBERS_LETTERS_UNDERSCORES, "resourceType");

			this._resourceType = resourceType;
		}

		#endregion

		#region Public Methods

		public FileSize GetFileMaxSize()
		{
			return this._fileMaxSize;
		}

		public ResourcesSettings SetFileMaxSize(FileSize fileMaxSize)
		{
			this._fileMaxSize = fileMaxSize;

			return this;
		}

		public string[] GetAllowedExtensions()
		{
			return this._allowedExtensions.ToArray();
		}

		public ResourcesSettings SetAllowedExtensions(params string[] extensions)
		{
			if (!extensions.IsNullOrEmpty())
				foreach (var extension in extensions)
					this._allowedExtensions.Add(extension);

			return this;
		}

		public bool Equals(ResourcesSettings obj)
		{
			if (obj == null) return false;

			return (obj.ResourceType == this.ResourceType);
		}

		#endregion

		#region Public Override Methods

		public override bool Equals(object obj)
		{
			return this.Equals(obj as ResourcesSettings);
		}

		public override int GetHashCode()
		{
			return (this.ResourceType.IsSafe() ? this.ResourceType.GetHashCode() : -1);
		}

		public override string ToString()
		{
			return this.ResourceType;
		}

		#endregion
	}
}