function realEstateAgency () {
	let apartmentRent = $('input[name=apartmentRent]');
	let apartmentType = $('input[name=apartmentType]');
	let agencyCommission = $('input[name=agencyCommission]');	
	let regOfferBtn = $('button[name=regOffer]');

	let familyBudget = $('input[name=familyBudget]');
	let familyApartmentType = $('input[name=familyApartmentType]');
	let familyName = $('input[name=familyName]');
	let findOfferBtn = $('button[name=findOffer]');

	let message = $('#message');
	let building = $('#building');
	let profit = $('#roof');

	let totalProfit = 0;

	regOfferBtn.on('click', function() {
		let rentValue = +apartmentRent.val();
		let typeValue = apartmentType.val();
		let commisionValue = +agencyCommission.val();
		
		let outputMessage;
		if(rentValue && commisionValue && rentValue > 0 && commisionValue >= 0 &&
			commisionValue <= 100 && typeValue !== "" && typeValue.indexOf(":") < 0) {

			let apartment = $('<div>').addClass("apartment");
			let rentElement = $('<p>').text(`Rent: ${rentValue}`);
			let typeElement = $('<p>').text(`Type: ${typeValue}`);
			let commisionElement = $('<p>').text(`Commission: ${commisionValue}`);

			apartment.append(rentElement, typeElement, commisionElement);

			building.append(apartment);

			outputMessage = 'Your offer was created successfully.';

		} else {
			outputMessage = 'Your offer registration went wrong, try again.';
		}

		message.text(outputMessage);

		apartmentRent.val("");
		apartmentType.val("");
		agencyCommission.val("");
	});

	findOfferBtn.on('click', function() {	
		let budgetValue = +familyBudget.val();
		let apartmentTypeValue = familyApartmentType.val().trim();
		let nameValue = familyName.val();
		let apartments = $('.apartment');
		
		if(budgetValue && budgetValue > 0 && apartmentTypeValue !== "" && nameValue !== "") {
			for (let element of apartments) {
				let apartment = $(element);

				let childrens = apartment.children();
				let currentApartmentRent = +childrens.eq(0).text().substring(6);
				let currentApartmentType = childrens.eq(1).text().substring(6).trim();
				let currentApartmentComission = +childrens.eq(2).text().substring(11);

				let percents = currentApartmentComission / 100;

				let totalPrice = currentApartmentRent + (currentApartmentRent * percents);

				if(currentApartmentType === apartmentTypeValue && totalPrice <= budgetValue) {
					apartment.html("");

					apartment.css("border: 2px solid red;");
					apartment.append($('<p>').text(nameValue));
					apartment.append($('<p>').text('live here now'));
					apartment.append($('<button>')
						.text('MoveOut')
						.on('click', function(ev) {
							let target = $(ev.target);
							target.parent().remove();
							message.text(`They had found cockroaches in ${nameValue}'s apartment`);
						}));

					console.log(currentApartmentRent, currentApartmentRent * percents);
					totalProfit += (currentApartmentRent * percents) * 2;

					profit.html($('<h1>').text(`Agency profit: ${totalProfit} lv.`));
					message.text(`Enjoy your new home! :))`);
					return;
				}			
			}
		}

		message.text('We were unable to find you a home, so sorry :(');
		familyBudget.val("");
		familyApartmentType.val("");
		familyName.val("");
	});
}