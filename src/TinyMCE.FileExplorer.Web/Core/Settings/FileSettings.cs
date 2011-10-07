using System.Collections.Generic;
using System.Linq;
using TinyMCE.FileExplorer.Web.Core.Extensions;

namespace TinyMCE.FileExplorer.Web.Core.Settings
{
	public class FileSettings
	{
		#region Private Constants

		private const string DEFAULT_THUMB_PREFIX = "thumb_";
		private const int MIN_THUMB_HEIGHT = 64;
		private const int MIN_THUMB_WIDTH = 64;

		#endregion

		#region Private Fields

		private string _thumbPrefix;
		private int _thumbHeight;
		private int _thumbWidth;

		#endregion

		#region Private Read-Only Fields

		private readonly HashSet<string> _hideExtensions = new HashSet<string>();

		#endregion

		#region Public Methods

		public string GetThumbPrefix()
		{
			return (this._thumbPrefix.IsSafe() ? this._thumbPrefix : FileSettings.DEFAULT_THUMB_PREFIX);
		}

		public FileSettings SetThumbPrefix(string thumbPrefix)
		{
			if (thumbPrefix.IsSafe())
				this._thumbPrefix = thumbPrefix;

			return this;
		}

		public int GetThumbHeight()
		{
			return (this._thumbHeight >= FileSettings.MIN_THUMB_HEIGHT ? this._thumbHeight : FileSettings.MIN_THUMB_HEIGHT);
		}

		public FileSettings SetThumbHeight(int thumbHeight)
		{
			if (thumbHeight >= FileSettings.MIN_THUMB_HEIGHT)
				this._thumbHeight = thumbHeight;

			return this;
		}

		public int GetThumbWidth()
		{
			return (this._thumbWidth >= FileSettings.MIN_THUMB_WIDTH ? this._thumbWidth : FileSettings.MIN_THUMB_WIDTH);
		}

		public FileSettings SetThumbWidth(int thumbWidth)
		{
			if (thumbWidth >= FileSettings.MIN_THUMB_WIDTH)
				this._thumbWidth = thumbWidth;

			return this;
		}

		public string[] GetHideExtensions()
		{
			return this._hideExtensions.ToArray();
		}

		public FileSettings SetHideExtensions(params string[] extensions)
		{
			if (!extensions.IsNullOrEmpty())
				foreach (var extension in extensions)
					this._hideExtensions.Add(extension);

			return this;
		}

		#endregion
	}
}