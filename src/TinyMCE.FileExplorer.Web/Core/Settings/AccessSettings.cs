using System.Collections.Generic;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Extensions;

namespace TinyMCE.FileExplorer.Web.Core.Settings
{
	public class AccessSettings
	{
		#region Private Read-Only Fields

		private readonly HashSet<string> _roles = new HashSet<string>();

		#endregion

		#region Public Constructors

		public AccessSettings() { }

		#endregion

		#region Public Methods

		public string[] GetRoles()
		{
			return this._roles.ToArray();
		}

		public void SetRoles(params string[] roles)
		{
			if (!roles.IsNullOrEmpty())
				foreach (var role in roles)
					this._roles.Add(role);
		}

		#endregion
	}
}