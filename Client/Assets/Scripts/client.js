const client = {
    baseUrl: "/API",
    registeredCallbacks: [],
    connection: null,
    url: function (path) {
        return this.baseUrl + path;
    },
    update: function () {
        this.getDataBundle()
            .then(data => {
                this.registeredCallbacks.forEach(callback => {
                    callback(data);
                });
            });
    },
    getDataBundle: function () {
        return new Promise((resolve, reject) => {
            fetch(this.url("/Data"))
                .then(response => response.json())
                .then(payload => {
                    resolve(payload);
                })
                .catch(error => {
                    console.error(error);
                    reject(error);
                });
        });
    },
    subscribeEvents: function () {
        this.connection = new signalR.HubConnectionBuilder().withUrl("/Events").build();
        this.connection.on("DataDidUpdate", () => {
            this.update();
        });
        this.connection.start();
    },
    onDataDidUpdate: function (callback) {
        this.registeredCallbacks.push(callback);
    },
    init: function () {
        console.log("Starting VCCTools JS client.");
        this.update();
        this.subscribeEvents();
    }
};

window.onload = function () {
    client.init();
};