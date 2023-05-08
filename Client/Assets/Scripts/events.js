var connection = new signalR.HubConnectionBuilder().withUrl("/Events").build();

connection.on("DataDidUpdate", function () {
    api.triggerUpdate();
});

connection.start();