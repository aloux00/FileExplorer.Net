using System;
using System.Text;
using TinyMCE.FileExplorer.Web.Core.Extensions;

namespace TinyMCE.FileExplorer.Web.Core.Models
{
	public class Archive
	{
		#region Public Properties

		public string Name { get; set; }
		public string Path { get; set; }
		public double Size { get; set; }
		public DateTime DateCreated { get; set; }

		#endregion

		#region Public Methods

		public string GetIdentifier()
		{
			if (this.Path.IsSafe())
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Path));

			return string.Empty;
		}

		public bool Equals(Archive obj)
		{
			return (obj != null && string.Compare(obj.Path, this.Path, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		#endregion

		#region Public Override Methods

		public override bool Equals(object obj)
		{
			return this.Equals(obj as Archive);
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