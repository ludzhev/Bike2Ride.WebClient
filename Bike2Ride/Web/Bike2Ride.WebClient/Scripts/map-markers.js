var mapProperty = function () {
    var center;
    var zoomLevel;
    var stations;

    return {
        center,
        zoomLevel,
        stations
    }
}

function initMap() {
    var markers = [];
    var centerPoint = mapProperty.center;
    var zoomLevel = mapProperty.zoomLevel;
    var stations = mapProperty.stations;

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: zoomLevel,
        center: { lat: centerPoint.lat, lng: centerPoint.lng }
    });

    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
    markers = [];

    for (var j = 0; j < stations.length; j++) {
        addMarkerWithTimeout(stations[j], j * 200);
    }

    function addMarkerWithTimeout(position, timeout) {
        window.setTimeout(function () {
            markers.push(new google.maps.Marker({
                position: position,
                map: map,
                animation: google.maps.Animation.DROP
            }));
        }, timeout);
    }
}
