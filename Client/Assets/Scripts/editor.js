const editor = {
    gameInfoEditor: {
        form: () => document.querySelector("#game-info-editor"),
        onFormSubmit: function (event) {
            event.preventDefault();
            this.update();
        },
        update: function () {
            const data = util.formToJson(this.form());
            const options = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data)
            };
            fetch(client.url("/Edit/Game"), options)
                .catch(error => {
                    console.error(error);
                });
        }
    },
    teamInfoEditor: {
        form: () => document.querySelector("#team-info-editor"),
        onFormSubmit: function (event) {
            event.preventDefault();
            this.update();
        },
        update: function () {
            const data = util.formToJson(this.form());
            const options = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data)
            };
            fetch(client.url("/Edit/Teams"), options)
                .catch(error => {
                    console.error(error);
                });
        }
    }
};