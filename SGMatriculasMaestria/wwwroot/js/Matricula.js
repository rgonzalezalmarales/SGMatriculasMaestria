$("#FacultadesSelect").change(function () {
    var facultad = $("#FacultadesSelect").val();
    var url = "/Maestrias/GetMaestriasByFacultad";

    $.getJSON(url, { facultad: facultad }, function (data) {
        var item = "";
        $("#MaestriasSelect").empty();
        $.each(data, function (i, selectmaestrias) {
            item += '<option value="' + selectmaestrias.value + '">' + selectmaestrias.text + '</option>'
        });
        $("#MaestriasSelect").html(item);
    });
});
$("#ExtraerDatos").click(function () {
    var industry = $("#industrylist").val();
    var url = "/api/AudienceSource/GetSubIndustrias";

    $.getJSON(url, { industria: industry }, function (data) {
        var item = "";
        $("#subindustry").empty();
        $.each(data, function (i, subindustria) {
            item += '<option value="' + subindustria.value + '">' + subindustria.text + '</option>'
        });
        $("#subindustry").html(item);
    });
});
function checkdateini() {
    var fechini = $("#matriculafechaini").val();
    var date = fechini.split("-");
    var fechactual = new Date();
    var fechainiselect = new Date(date[0], date[1]-1,date[2]);
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
    }

}
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

}