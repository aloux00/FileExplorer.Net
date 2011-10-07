using System;
using System.Collections.Generic;
using System.Text;
using TinyMCE.FileExplorer.Web.Core.Extensions;

namespace TinyMCE.FileExplorer.Web.Core.Models
{
	public class Folder
	{
		#region Public Properties

		public string Path { get; set; }
		public string Name { get; set; }
		public string ResourceType { get; set; }
		public bool IsRoot { get; set; }
		public int Level { get; set; }
		public Folder Parent { get; set; }
		public HashSet<Folder> Children { get; private set; }

		#endregion

		#region Public Constructors

		public Folder()
		{
			this.Children = new HashSet<Folder>();
		}

		#endregion

		#region Public Methods

		public string GetIdentifier()
		{
			if (this.Path.IsSafe())
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Path));

			return string.Empty;
		}

		public bool Equals(Folder obj)
		{
			return (obj != null && string.Compare(obj.Path, this.Path, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		#endregion

		#region Public Override Methods

		public override bool Equals(object obj)
		{
			return this.Equals(obj as Folder);
		}

		public override int GetHashCode()
		{
			return (this.GetIdentifier().IsSafe() ? this.GetIdentifier().GetHashCode() : -1);
		}

		public override string ToString()
		{
			return this.Path;
		}

		#endregion
	}
}