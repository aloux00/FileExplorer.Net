/***********************************************************/
/*                    LiveFilter Plugin                    */
/*                      Version: 1.4                       */
/*                      Mike Merritt                       */
/*             	   Updated: Mar 04, 2011                   */
/***********************************************************/

/************************************************************/
/*	Version: 1.4MARK										*/
/*	Modified by: Marco Antonio								*/
/*	Updated: Sep 19, 2011									*/
/************************************************************/

(function ($) {
	$.fn.liveFilter = function (options) {

		// Default settings
		var defaults = {
			delay: 0,
			defaultText: 'Type to Filter:',
			hideDefault: false,
			zebra: '#E1E1E1',
			zBase: '#EFEFEF',
			filterBox: false
		};

		// Overwrite default settings with user provided ones.
		var options = $.extend({}, defaults, options);

		// Cache our wrapper element and determine what target we are going to be filtering,
		// also declare a couple more vars for global use.
		var filterTarget = $(this);
		var keyDelay;
		var filter;
		var child;

		// Determine what sub elements we are going to be showing/hiding depending on 
		// what our filter target is.
		if (filterTarget.is('ul') || filterTarget.is('ol')) {
			child = 'li';
		} else if (filterTarget.is('table')) {
			child = 'tbody tr';
		}

		// Hide the list/table by default. If not being hidden apply zebra striping if needed.
		if (options.hideDefault === true) {
			$(filterTarget).find(child).hide()
		} else if (options.hideDefault === false && options.zebra != false) {
			zebraStriping();
		}

		// Cache all of our list/table elements so we don't have to select them over and over again.
		var cache = $(filterTarget).find(child);
		var box = $(options.filterBox);

		// Text input keyup event
		box.find('input[type=text]').keyup(function () {

			// For use in the following callback.
			var input = $(this);

			// Used to reset the timeout so we can start over again if another key is pressed
			// before our current timeout has expired.
			clearTimeout(keyDelay);

			// Adding a timeout before we do any iterating or showing/hiding to help with performance
			// when the user types very quickly.
			keyDelay = setTimeout(function () {

				// Getting the text to filter.
				filter = input.val().toLowerCase();

				// Iterate through our cache of elements and match our supplied filter to the text of the element.
				cache.each(function (i) {
					text = $(this).text().toLowerCase();
					if (text.indexOf(filter) >= 0) {
						$(this).show();
					} else {
						$(this).hide();
					}
				});

				if (options.zebra != false) {
					zebraStriping();
				}

				clearTimeout(keyDelay);

			}, options.delay);


		});

		// Used to reset our text input and show all items in the filtered list
		box.find('input[type=reset]').click(function () {

			if (options.defaultText === false) {

				box.find('input[type=text]').attr('value', '');

				if (options.hideDefault === false) {
					cache.each(function (i) {
						$(this).show();
					});
				} else if (options.hideDefault === true) {
					cache.each(function (i) {
						$(this).hide();
					});
				}

			} else {

				box.find('input[type=text]').attr('value', options.defaultText);

				if (options.hideDefault === false) {
					cache.each(function (i) {
						$(this).show();
					});
				} else if (options.hideDefault === true) {
					cache.each(function (i) {
						$(this).hide();
					});
				}

			}

			return false;

		});


		// Used to set the default text of the text input if there is any
		if (options.defaultText != false) {
			var input = box.find('input[type=text]');

			input.attr('value', options.defaultText);

			input.focus(function () {

				var curVal = $(this).attr('value');

				if (curVal === options.defaultText) {
					$(this).attr('value', '');
				}

			});

			input.blur(function () {

				var curVal = $(this).attr('value');

				if (curVal === '') {
					$(this).attr('value', options.defaultText);
				}

			});

		}

		// Used for zebra striping list/table.
		function zebraStriping() {

			$(filterTarget).find(child + ':visible:odd').css({ background: options.zebra });
			$(filterTarget).find(child + ':visible:even').css({ background: options.zBase });
		}

	}
})(jQuery);