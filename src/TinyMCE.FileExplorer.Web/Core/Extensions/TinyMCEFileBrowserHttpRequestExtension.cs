using System.Web;

namespace TinyMCE.FileExplorer.Web.Core.Extensions
{
	public static class TinyMCEFileBrowserHttpRequestExtension
	{
		#region Public Static Methods

		public static bool IsAjaxRequest(this HttpRequest request)
		{
			return (request != null && (request["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest")));
		}

		#endregion
	}
}