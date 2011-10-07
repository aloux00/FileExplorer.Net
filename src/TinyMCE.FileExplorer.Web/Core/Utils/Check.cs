using System;
using System.Text.RegularExpressions;

namespace TinyMCE.FileExplorer.Web.Core.Utils
{
	public static class Check
	{
		#region Public Static Inner Classes

		public static class Arguments
		{
			#region Public Static Methods

			public static void ThrowIfNull(object argument, string argumentName)
			{
				if (argument == null)
					throw new ArgumentNullException(argumentName, string.Format("The argument \"{0}\" is null.", argumentName));
			}

			public static void ThrowIfStringNotSafe(string argument, string argumentName)
			{
				Check.Arguments.ThrowIfNull(argument, argumentName);

				if (argument.Trim().Length == 0)
					throw new ArgumentException(string.Format("The string argument \"{0}\" is not safe.", argumentName), argumentName);
			}

			public static void ThrowIfNotPassRegexp(string argument, string pattern, string argumentName)
			{
				Check.Arguments.ThrowIfStringNotSafe(argument, argumentName);
				Check.Arguments.ThrowIfStringNotSafe(pattern, "pattern");

				if (!Regex.IsMatch(argument, pattern, RegexOptions.Compiled))
					throw new ArgumentException(string.Format("The string argument \"{0}\" did not pass the regular expression validation. Regular expression pattern used was: \"{1}\".", argumentName, pattern), argumentName);
			}

			#endregion
		}

		#endregion
	}
}