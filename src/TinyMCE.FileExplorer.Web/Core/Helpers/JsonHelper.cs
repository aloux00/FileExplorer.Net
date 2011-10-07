using System.Web.Script.Serialization;

namespace TinyMCE.FileExplorer.Web.Core.Helpers
{
	public static class JsonHelper
	{
		#region Public Static Methods

		public static string ToJson(object obj)
		{
			return (new JavaScriptSerializer()).Serialize(obj);
		}

		#endregion
	}
}