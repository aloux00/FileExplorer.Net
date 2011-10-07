namespace TinyMCE.FileExplorer.Web.Core.Extensions
{
	public static class TinyMCEFileExplorerStringExtension
	{
		#region Public Static Methods

		public static bool IsSafe(this string source)
		{
			return (source != null && source.Trim().Length > 0);
		}

		public static string EnsureEndsWith(this string source, string value)
		{
			if (!source.IsSafe())
				return value;

			if (!source.EndsWith(value))
				return string.Concat(source, value);

			return source;
		}

		public static string EnsureStartsWith(this string source, string value)
		{
			if (!source.IsSafe())
				return value;

			if (!source.StartsWith(value))
				return string.Concat(value, source);

			return source;
		}

		#endregion
	}
}