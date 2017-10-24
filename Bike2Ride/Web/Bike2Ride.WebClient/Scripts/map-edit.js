var mapProperty = function() {
    var center;
    var zoomLevel;
    var stations;
    var newStations = [];

    return {
        center,
        zoomLevel,
        stations,
        newStations
    }
}();

var map;

function initMap() {
    var markers = [];

    var centerPoint = mapProperty.center;
    var zoomLevel = mapProperty.zoomLevel;
    var stations = mapProperty.stations;

    map = new google.maps.Map(document.getElementById('map'), {
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

    map.addListener('click', function (event) {
        addMarker(event.latLng);
    });

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

function addMarker(location) {
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });

    mapProperty.newStations.push(marker);
}

function setMapOnAll(map) {
    for (var k = 0; k < mapProperty.newStations.length; k++) {
        mapProperty.newStations[k].setMap(map);
    }
}

function clearMarkers() {
    setMapOnAll(null);
}

function showMarkers() {
    setMapOnAll(map);
}

function deleteMarkers() {
    clearMarkers();
    mapProperty.newStation = [];
}