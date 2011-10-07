(function ($) {
	$.fn.fixedThead = function (options) {

		var _self = this;

		var settings = {
			minHeight: 300,
			minWidth: 600,
			autoResize: false,
			headToFoot: false
		};

		if (options) {
			$.extend(settings, options);
		}

		var _validElement = function (elem) {
			// Caso o item não seja uma tabela, loga no console e passa para o próximo item.
			if (!elem.is('table')) {
				if (console) { console.log('item is not a table.'); }
				return false;
			}

			// Caso não tenha thead ou tbody, loga no console e passa para o próximo item.
			if (elem.find('thead')[0] == undefined || elem.find('tbody')[0] == undefined) {
				if (console) { console.log('thead or tbody not found.'); }
				return false;
			}

			return true;
		};

		var _scrollWidth = function () {
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

		var _render = function (container, table, section, as) {
			var innerContainer = $('<div class="' + as + '" />');
			var innerTable = $('<table />');
			var innerContent = $('<' + as + '/>');
			var wrap = false;

			if (table.find(section)[0] == undefined) { return; }

			// Adiciona atributos da tabela
			$.each(table[0].attributes, function (idx, item) {
				innerTable.attr(item.name, item.value);
			});

			// Adiciona atributos do conteúdo
			$.each(table.find(section)[0].attributes, function (idx, item) {
				innerContent.attr(item.name, item.value);
			});

			if (section === 'tbody') {
				innerContainer.css({
					'overflow': 'hidden',
					'overflow-y': 'auto'
				});
			}

			innerContent.html(table.find(section).html());

			wrap = innerTable.wrapInner(innerContent);
			wrap = innerContainer.wrapInner(innerTable);

			container.append(wrap);
		};

		var _resize = function (container, parent) {
			var pD = {
				height: parent.height(),
				width: parent.width()
			};
			var hD = {
				height: container.find('div.thead').height(),
				width: container.find('div.thead').width()
			};
			var fD = {
				height: container.find('div.tfoot').height(),
				width: container.find('div.tfoot').width()
			};

			var sW = _scrollWidth();

			container.css({
				'height': pD.height + 'px',
				'min-height': pD.height + 'px',
				'min-width': pD.width + 'px',
				'width': pD.width + 'px'
			});

			container.find('div.thead, div.tbody, div.tfoot').css({
				'min-width': pD.width + 'px',
				'width': pD.width + 'px'
			});

			container.find('div.thead table, div.tbody table, div.tfoot table').css({
				'min-width': (pD.width - sW) + 'px',
				'width': (pD.width - sW) + 'px'
			});

			container.find('div.tbody').css({
				'height': (pD.height - (hD.height + fD.height)) + 'px',
				'min-height': (pD.height - (hD.height + fD.height)) + 'px'
			});
		};

		$.each(_self, function (idx, item) {

			var table = $(item);
			var parent = table.parent();

			if (!_validElement(table)) { return true; }

			var container = $('<div id="fixed_thead_' + idx + '" class="fixed-thead-container" />');

			container.css({
				'display': 'block',
				'height': settings.minHeight + 'px',
				'min-height': settings.minHeight + 'px',
				'min-width': settings.minWidth + 'px',
				'overflow': 'hidden',
				'width': settings.minWidth + 'px'
			});

			_render(container, table, 'thead', 'thead');
			_render(container, table, 'tbody', 'tbody');
			_render(container, table, (settings.headToFoot ? 'thead' : 'tfoot'), 'tfoot');

			table.replaceWith(container);

			if (settings.autoResize) {
				_resize(container, parent);
				$(window).resize(function () { _resize(container, parent); });
			}
		});
	}
})(jQuery);