function acceptance() {
	let shippingCompany = $('input[name=shippingCompany]');
	let productName = $('input[name=productName]');
	let productQuantity = $('input[name=productQuantity]');
	let productScrape = $('input[name=productScrape]');
	
	if(shippingCompany.val() && productName.val() && 
		+productQuantity.val() && +productScrape.val()) {

		let pieces = +productQuantity.val() - +productScrape.val();

		if(pieces > 0) {
			let div = $('<div>');
			let p = $('<p>')
				.text(`[${shippingCompany.val()}] ${productName.val()} - ${pieces} pieces`);
			let button = $('<button>')
				.attr('type', 'button')
				.text('Out of stock')
				.on('click', function(ev) {
					let target = $(ev.target);

					target.parent().remove();
				});

			div.append(p, button);

			$('#warehouse').append(div);

			shippingCompany.val("");
			productName.val("");
			productQuantity.val("");
			productScrape.val("");
		}
	}	
}