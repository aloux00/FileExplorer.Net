using System;
using System.Collections;
using System.Collections.Generic;

namespace TinyMCE.FileExplorer.Web.Core.Extensions
{
	public static class TinyMCEFileExplorerIEnumerableExtension
	{
		#region Public Static Methods

		public static bool IsNullOrEmpty(this IEnumerable source)
		{
			return (source != null && !source.GetEnumerator().MoveNext());
		}

		public static bool Contains(this IEnumerable<string> source, string value, StringComparison stringComparison)
		{
			if (source.IsNullOrEmpty()) return false;

			var result = false;

			foreach (var item in source)
				if ((result = item != null && item.Equals(value, stringComparison)) == true)
					break;

			return result;
		}

		#endregion
	}
}