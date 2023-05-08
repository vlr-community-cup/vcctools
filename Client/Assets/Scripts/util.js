function formToJson(formId) {
    const formData = new FormData(document.getElementById(formId));
    const json = {};

    for (const [key, value] of formData.entries()) {
        json[key] = value;
    }

    return json;
}

const flipTeam = team => team == 1 ? 2 : 1;