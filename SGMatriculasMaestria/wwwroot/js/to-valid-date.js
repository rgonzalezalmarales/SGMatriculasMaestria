
function checkDateLassThen() {
    /*var fechini = $("#matriculafechaini").val();
    var date = fechini.split("-");
    var fechactual = new Date();
    var fechainiselect = new Date(date[0], date[1] - 1, date[2]);
    const msgerr = document.querySelector("#msgerror");

    if (fechainiselect < fechactual) {
        $("#msgerror").val("La fecha de inicio debe ser mayor fecha actual");
        $("#matriculafechaini").val("dd/mm/aaaa");
        if (msgerr.classList.contains('d-none')) {
            msgerr.classList.remove('d-none');
        }
    }
    else if (!msgerr.classList.contains('d-none')) {
        msgerr.classList.add('d-none');
    }*/
    $("#aspirante-fecha-graduado").change(function () {
        var messageError = "No se permiten fechas mayores que hoy";
        var currentDate = new Date(Date.now());
        var selectedDate = new Date($("#aspirante-fecha-graduado").val());
        if (selectedDate > currentDate) {
            $("#error-fecha-graduacion").html(`<span id="aspirante-fecha-graduado-error">${messageError}</span>`);
        }
    });
}
$(document).ready(function () {
    checkDateLassThen()
});
/*
function checkdatefin() {
    var fechini = $("#matriculafechaini").val();
    var date = fechini.split("-");
    var fechainiselect = new Date(date[0], date[1] - 1, date[2]);
    var fechfin = $("#matriculafechafin").val();
    var datefin = fechfin.split("-");
    var fechafinselect = new Date(datefin[0], datefin[1] - 1, datefin[2]);
    const msgerr = document.querySelector("#msgerrorfin");

    if (fechafinselect <= fechainiselect) {
        $("#matriculafechafin").val("dd/mm/aaaa");
        if (msgerr.classList.contains('d-none')) {
            msgerr.classList.remove('d-none');
        }
    }
    else if (!msgerr.classList.contains('d-none')) {
        msgerr.classList.add('d-none');
    }

}*/