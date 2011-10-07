using System.IO;
using System.Web.UI;

namespace TinyMCE.FileExplorer.Web.Core.Extensions
{
	public static class TinyMCEFileExplorerControlExtension
	{
		#region Public Static Methods

		public static string RenderHtml(this Control control)
		{
			var result = string.Empty;

			if (control != null)
			{
				using (var stringWriter = new StringWriter())
				using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
				{
					control.RenderControl(htmlTextWriter);

					result = stringWriter.ToString();
				}
			}

			return result;
		}

		#endregion
	}
}