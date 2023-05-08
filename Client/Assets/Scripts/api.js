const api = {
    callbacks: [],
    onDataUpdate: function (callback) {
        this.callbacks.push(callback);
        this.triggerUpdate();
    },
    triggerUpdate: function () {
        fetch("/API/Data")
            .then(response => response.json())
            .then(payload => {
                this.callbacks.forEach(c => c(payload));
            })
            .catch(error => {
                console.error(error);
            });
    },
    editGameInfo: function (gameInfo, callback) {
        fetch("/API/Edit/Game", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(gameInfo)
        })
            .catch(error => {
                console.error(error);
            })
            .finally(() => {
                this.triggerUpdate();
                if (callback) callback();
            });
    },
    editTeams: function (teamInfo, callback) {
        fetch("/API/Edit/Teams", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(teamInfo)
        })
            .catch(error => {
                console.error(error);
            })
            .finally(() => {
                this.triggerUpdate();
                if (callback) callback();
            });
    },
    editMapPick: function (index, mapPick, callback) {
        fetch("/API/Edit/Map/" + index, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(mapPick)
        })
            .catch(error => {
                console.error(error);
            })
            .finally(() => {
                this.triggerUpdate();
                if (callback) callback();
            });
    },
    editMapWinner: function (index, teamId, callback) {
        fetch("/API/Edit/Map/" + index + "/" + teamId)
            .catch(error => {
                console.error(error);
            })
            .finally(() => {
                this.triggerUpdate();
                if (callback) callback();
            });
    }
};