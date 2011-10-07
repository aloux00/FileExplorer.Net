/*************** BEGIN:	CONFIG PLUGINS ***************/
/*************** END:	CONFIG PLUGINS ***************/

/*************** BEGIN:	ATTACH HANDLERS ***************/
/*************** END:	ATTACH HANDLERS ***************/

/*************** BEGIN:	METHODS ***************/
//
// Método:		adjustTreeviewLevelsPadding()
// Descrição:
//
var adjustTreeviewLevelsPadding = function () {
	var items = $('div.folder-view-container').find('li[class^=level]');

	items.each(function (idx, item) {
		var match = item.attributes['class'].value.match(/level-\d+/)[0];
		var level = parseInt(match.substring(match.lastIndexOf('-') + 1));
		var span = $(item).first('span');

		span.css({ 'padding-left': (level * 30) + 'px' });
	});
};
/*************** END:	METHODS ***************/

$(document).ready(function () {
	configLayout();
	renderFolderView();
});

var configLayout = function () {
	$('body').layout({
		north: {
			closable: false,
			resizable: false,
			size: 65
		},
		west: {
			fxName: "slide",
			fxSettings: {
				duration: 500,
				easing: "easeOutBounce"
			},
			minSize: 50,
			maxSize: 600,
			size: 300
		},
		center: {
			onresize: function (name, element, state, options, layout) {
				resizeArchiveView(element);
			}
		},
		south: {
			closable: false,
			resizable: false,
			size: 50
		}
	});

	resizeArchiveView($('div.ui-layout-center'));
};

var configFolderViewTreeview = function () {
	$('div.folder-view-container').find('ul:eq(0)').treeview({
		collapsed: true,
		animated: 'slow',
		control: 'ul.treeview-controls'
	});

	$('ul.treeview-controls').find('a.refresh').click(function () {
		renderFolderView(); return false;
	});

	$('div.folder-view-container').find('span.folder').each(function (idx, elem) {
		$(elem).click(function () {
			var path = $(elem).prev('input').prev('input[name=path]').val();
			var resource = $(elem).prev('input[name=resource_type]').val();

			renderArchiveView({ path: path, resource: resource });

			setSelectedFolderLocation(path);

			return false;
		});
	});
};

var renderFolderView = function () {
	$.ajax({
		beforeSend: function (jqXHR, settings) {
			$('div.ui-layout-west').block({ message: null });
		},
		cache: false,
		complete: function (jqXHR, textStatus) {
			$('div.ui-layout-west').unblock();
		},
		data: { ajax_call: 'render_folder_view' },
		dataType: 'html',
		success: function (data, textStatus, jqXHR) {
			$('div.folder-view-container').html(data);

			configFolderViewTreeview();
			adjustTreeviewLevelsPadding();
		},
		type: 'GET',
		url: 'FileBrowser.aspx'
	});
};

var renderArchiveView = function (params) {

	if (params.path === getSelectedFolderLocation() || params.resource === '') {
		return false;
	}

	$.ajax({
		beforeSend: function (jqXHR, settings) {
			$('div.archive-view-container').block({ message: null });
		},
		cache: false,
		complete: function (jqXHR, textStatus) {
			$('div.archive-view-container').unblock();
		},
		data: {
			ajax_call: 'render_archive_view',
			path: params.path,
			resource: params.resource
		},
		dataType: 'html',
		success: function (data, textStatus, jqXHR) {
			$('div.archive-view-container').html(data);

			configFixedThead();
			configLiveFilter();
		},
		type: 'GET',
		url: 'FileBrowser.aspx'
	});
};

var setSelectedFolderLocation = function (path) {
	$('p.selected-folder-location').html(path);
};

var getSelectedFolderLocation = function () {
	return $('p.selected-folder-location').html();
};

var configFixedThead = function () {
	$('table.fixed-thead').fixedThead();

	resizeArchiveView($('div.ui-layout-center'));
};

var configLiveFilter = function () {
	$('table.archive-view').liveFilter({
		delay: 400,
		defaultText: '',
		filterBox: 'div.search'
	})
};

var scrollWidth = function () {
	var inner = document.createElement('p');

	inner.style.width = "100%";
	inner.style.height = "200px";

	var outer = document.createElement('div');

	outer.style.position = "absolute";
	outer.style.top = "0px";
	outer.style.left = "0px";
	outer.style.visibility = "hidden";
	outer.style.width = "200px";
	outer.style.height = "150px";
	outer.style.overflow = "hidden";

	outer.appendChild(inner);

	document.body.appendChild(outer);

	var w1 = inner.offsetWidth;

	outer.style.overflow = 'scroll';

	var w2 = inner.offsetWidth;

	if (w1 == w2) w2 = outer.clientWidth;

	document.body.removeChild(outer);

	return (w1 - w2);
};

var resizeArchiveView = function (container) {
	var div = container.find('div.fixed-thead-container');

	if (div[0] == undefined) { return; }

	var pD = {
		height: container.height(),
		width: container.width()
	};
	var hD = {
		height: div.find('div.thead').height(),
		width: div.find('div.thead').width()
	};
	var fD = {
		height: div.find('div.tfoot').height(),
		width: div.find('div.tfoot').width()
	};

	var sW = scrollWidth();

	div.css({
		'height': pD.height + 'px',
		'min-height': pD.height + 'px',
		'min-width': pD.width + 'px',
		'width': pD.width + 'px'
	});

	div.find('div.thead, div.tbody, div.tfoot').css({
		'min-width': pD.width + 'px',
		'width': pD.width + 'px'
	});

	div.find('div.thead table, div.tbody table, div.tfoot table').css({
		'min-width': (pD.width - sW) + 'px',
		'width': (pD.width - sW) + 'px'
	});

	div.find('div.tbody').css({
		'height': (pD.height - (hD.height + fD.height)) + 'px',
		'min-height': (pD.height - (hD.height + fD.height)) + 'px'
	});
};