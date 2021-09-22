$("#FacultadesSelect").change(function () {
    var facultad = $("#FacultadesSelect").val();
    var url = "../Maestrias/GetMaestriasByFacultad";

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