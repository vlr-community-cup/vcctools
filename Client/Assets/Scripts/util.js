const util = {
    getTeamScore: function (teamId, mapSeries) {
        let score = 0;
        mapSeries.forEach(mapPick => {
            if (mapPick.team == teamId && mapPick.result == 1) {
                score += 1;
            }
            if (mapPick.team != teamId && mapPick.result == 2) {
                score += 1;
            }
        });
        return score;
    },
    getMapPickString: function (mapPick, teamA, teamB) {
        if (mapPick.map == "TBD" || mapPick.team == 0 || mapPick.type == 0) {
            return "TBD";
        }

        let map = mapPick.map;
        let team = mapPick.team == 1 ? teamA : teamB;

        if (mapPick.type == 2) {
            return `${team} ban ${map}`;
        }

        let side = mapPick.isAttacking ? "attack" : "defend";

        return `${team} ${side} ${map}`;
    },
    getNextMap: function (mapSeries) {
        for (var i = 0; i < mapSeries.length; i++) {
            if (mapSeries[i].type == 1 && mapSeries[i].result == 0) {
                return mapSeries[i];
            }
        }
    },
    formToJson: function (form) {
        const formData = new FormData(form);
        const json = {};

        for (const [key, value] of formData.entries()) {
            json[key] = value;
        }

        return json;
    }
};