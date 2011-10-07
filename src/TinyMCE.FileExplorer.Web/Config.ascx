<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="TinyMCE.FileExplorer.Web.Core.Config" %>
<%@ Import Namespace="TinyMCE.FileExplorer.Web.Core.Infrastructure" %>
<%@ Import Namespace="TinyMCE.FileExplorer.Web.Core.Settings" %>

<script type="text/C#" runat="server">

	public override bool IsAuthenticated()
	{
		return true;
	}

	public override void Configure()
	{
		this.Settings.Access.SetRoles("*");

		this.Settings.Directory
			.SetBaseVirtualDirectory("~/tinymce_fileexplorer/content/")
			.SetUserVirtualDirectory("~/tinymce_fileexplorer/user/");

		this.Settings.File
			.SetThumbPrefix("thumb_")
			.SetThumbHeight(64)
			.SetThumbWidth(64);

		var generalResources = ResourcesSettings.General
			.SetFileMaxSize(FileSize.Big)
			.SetAllowedExtensions(".7z", ".doc", ".docx", ".gz", ".gzip", ".ods", ".odt", ".pdf", ".ppt", ".pptx", ".pxd", ".rar", ".rtf", ".sdc", ".sitd", ".sxc", ".sxw", ".tar", ".tgz", ".tif", ".tiff", ".txt", ".vsd", ".xls", ".xlsx", ".zip");

		var mediaResources = new ResourcesSettings("Medias")
			.SetFileMaxSize(FileSize.Huge)
			.SetAllowedExtensions(".aiff", ".asf", ".avi", ".fla", ".flv", ".mid", ".mov", ".mp3", ".mp4", ".mpc", ".mpeg", ".mpg", ".qt", ".ram", ".rm", ".rmi", ".rmvb", ".swf", ".wav", ".wma", ".wmv");

		var imageResources = new ResourcesSettings("Images")
			.SetFileMaxSize(FileSize.Big)
			.SetAllowedExtensions(".bmp", ".gif", ".jpeg", ".jpg", ".png");

		this.Settings.SetResources(generalResources
			, mediaResources
			, imageResources);
	}

</script>