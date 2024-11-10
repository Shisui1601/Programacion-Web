window.leafletMap = {
    initMap: function (elementId, latitude, longitude, zoom) {
        // Inicializar el mapa y centrarlo en las coordenadas dadas
        var map = L.map(elementId).setView([latitude, longitude], zoom);

        // Agregar una capa de mapa base de OpenStreetMap
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);

        // Crear un marcador en el centro del mapa
        L.marker([latitude, longitude]).addTo(map)
            .bindPopup("Ubicación inicial")
            .openPopup();

        console.log("Map initialized with center:", latitude, longitude);

        // Guardar el mapa en la ventana global para usar en otras funciones
        window.leafletMap.map = map;
    },
    addMarker: function (latitude, longitude, popupText) {
        // Añadir un marcador al mapa en la posición dada
        if (window.leafletMap.map) {
            L.marker([latitude, longitude]).addTo(window.leafletMap.map)
                .bindPopup(popupText)
                .openPopup();
        }
    }
};
