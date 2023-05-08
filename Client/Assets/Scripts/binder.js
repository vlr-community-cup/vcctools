const binder = {
    keyLookup: function (obj, keys) {
        const splitKeys = keys.split('.');

        if (splitKeys.length === 1) {
            return obj[keys];
        }

        const currentKey = splitKeys.shift();

        return this.keyLookup(obj[currentKey], splitKeys.join('.'));
    },
    autoBind: function () {
        console.log("Auto-binding.");
        document.querySelectorAll(["[data-bind-property]"]).forEach(element => {
            client.onDataDidUpdate(data => {
                if (element.dataset.bindType == "html") {
                    element.innerHTML = this.keyLookup(data, element.dataset.bindProperty);
                }
                if (element.dataset.bindType == "value") {
                    element.value = this.keyLookup(data, element.dataset.bindProperty);
                }
                if (element.dataset.bindType == "date-html") {
                    let date = new Date(this.keyLookup(data, element.dataset.bindProperty));
                    element.innerHTML = date.toDateString();
                }
                if (element.dataset.bindType == "time-html") {
                    let time = new Date(this.keyLookup(data, element.dataset.bindProperty));
                    element.innerHTML = time.toLocaleTimeString([], { hour: "numeric", minute: "2-digit", timeZoneName: "short" });
                }
                if (element.dataset.bindType == "score") {
                    element.innerHTML = util.getTeamScore(element.dataset.bindProperty, this.keyLookup(data, "mapSeries"));
                }
            });
        });
    },
    bindInnerHTML: function (selector, property) {
        client.onDataDidUpdate(data => {
            document.querySelector(selector).innerHTML = this.keyLookup(data, property);
        });
    },
    bindCustom: function (property, handler) {
        client.onDataDidUpdate(data => {
            handler(this.keyLookup(data, property));
        });
    }
};