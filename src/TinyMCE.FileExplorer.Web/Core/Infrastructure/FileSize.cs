using System;

namespace TinyMCE.FileExplorer.Web.Core.Infrastructure
{
	[Flags]
	public enum FileSize : int
	{
		/// <summary>
		/// 0 bits (0 Mb)
		/// </summary>
		Empty = 0,
		/// <summary>
		/// 1.048.576 bits (1 Mb)
		/// </summary>
		Smallest = 1048576,
		/// <summary>
		/// 2.097.152 bits (2 Mb)
		/// </summary>
		Small = 2097152,
		/// <summary>
		/// 4.194.304 bits (4 Mb)
		/// </summary>
		Medium = 4194304,
		/// <summary>
		/// 8.388.608 bits (8 Mb)
		/// </summary>
		Big = 8388608,
		/// <summary>
		/// 16.777.216 bits (16 Mb)
		/// </summary>
		Bigest = 16777216,
		/// <summary>
		/// 134.217.728 bits (128 Mb)
		/// </summary>
		Huge = 134217728
	}
}