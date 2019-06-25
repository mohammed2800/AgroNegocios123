function initMap() {
	var map = new google.maps.Map(document.getElementById('GoogleMap'), {
		zoom: 3.2,
		center: { lat: 41.325, lng: 10.070 }
	});

	setMarkers(map);
}

var Countries = [
	['Israel', 31.046051, 34.851612],
	['Russia', 62.524010, 95.318756],
	['Egypt', 26.820553, 30.802498],
	['Iraq', 33.223190, 43.679291],
	['Azerbaijan', 40.143105, 47.576927],
	['Hungary', 47.162495, 19.503304],
	['Albania', 41.153332, 20.168331],
	['Italy', 43.071941, 12.567380],
	['Netherlands', 52.132633, 5.291266],
	['Nicaragua', 12.865416, -85.207230],
	['Honduras', 33.223190, -86.241905],
	['Mexico', 23.634501, -102.552788],
	['Cambodia', 12.565679, 104.990967],
	['Saudi Arabia', 23.885942, 45.079163],
	['Maldives', 0.202778, 73.220680],
	['Dominican Republic', 18.735693, -70.162651],
	['Ethiopia', 9.145000, 40.489674],
	['Vietnam', 14.058324, 108.277199],
	['Colombia', 4.570868, -73.297333]
];

function setMarkers(map) {
	// Adds markers to the map.
	for (var i = 0; i < Countries.length; i++) {

		var Country = Countries[i];

		var marker = new google.maps.Marker({
			map: map,
			draggable: true,
			animation: google.maps.Animation.BOUNCE,
			position: { lat: Country[1], lng: Country[2] },
			title: Country[0]
		});
	}
}