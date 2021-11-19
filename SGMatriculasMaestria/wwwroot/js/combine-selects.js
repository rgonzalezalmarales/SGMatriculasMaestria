var combineSelect = function(parentId, childId, url, queryName, default_option, id = "id", name = "nombre"){

    $(parentId).change(function () {
        var queryParams = {};
        queryParams[queryName] = $(parentId).val()
        /*console.log('params', queryParams)
        console.log('eval', eval(`{ ${queryName} : $(parentId).val() }`))*/
        console.log('OnChangeParentCombined', $(parentId).val());
        $.get(url, queryParams, function (data) {
            //Vaciamos el DropList Municipios
            $(childId).empty();

            $(childId).append(`<option value="-1"> -- ${default_option} --</option >`);
            console.log('loaded data', data);
            $.each(data, function (index, row) {
                $(childId).append(`<option value="${row[id]}">${row[name]}</option>`)
            });

            $(childId).trigger("change");
        });
    });
}


$(document).ready(function () {

    console.log('pais val', $("#PaisAspiranteSelect").val())
    combineSelect("#PaisAspiranteSelect",
        "#ProvinciaAspiranteSelect",
        "/Provincias/GetProvinciasByPaisJson",
        "paisId",
        "Seleccione una provincia");

    combineSelect("#ProvinciaAspiranteSelect",
        "#MunicipioAspiranteSelect",
        "/Municipios/GetMinucipiosByProvinciaJson",
        "provinciaId",
        "Seleccione un municipio");   
    
});



/*$("#ProvinciaAspiranteSelect").change(function () {
    $.get("/Municipios/GetMinucipiosByProvinciaJson", { provinciaId: $("#ProvinciaAspiranteSelect").val() }, function (data) {
        //Vaciamos el DropList Municipios
        $("#MunicipioAspiranteSelect").empty();
        //Adicionamos el nuevo label con el nombre del elemento seleccionado
        //$("#MunicipioAspiranteSelect").append(`<option value="">-- Seleccione un municipio de ${$("#ProvinciaAspiranteSelect option:selected").text()} --</option>`);
        console.log("data", data)
        $("#MunicipioAspiranteSelect").append(`<option value = ""> --Seleccione un municipio--</option >`);
        $.each(data, function (index, row) {
            $("#MunicipioAspiranteSelect").append(`<option value="${row.id}">${row.nombre}</option>`)
        });
    });
});*/
    