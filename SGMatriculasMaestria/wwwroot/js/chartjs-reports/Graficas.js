$(document).ready(function () {

    $.ajax({
        url: "/Reportes/GraficaPorSexo",
        type: 'POST',
        dataType: 'json',
        success: function (data) {

            const ctx = document.getElementById('myChart').getContext('2d');
            const myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: [`Mujeres (${data.mujeres})`, `Hombres (${data.hombres})`],
                    datasets: [{
                        label: 'Aspirantes por sexo',
                        data: [data.mujeres, data.hombres],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });

        }
    });




    const ctx1 = document.getElementById('provincia-chart').getContext('2d');
    const myChart1 = new Chart(ctx1, {
        type: 'pie',
        data: {
            labels: [],
            datasets: [{
                label: 'Aspirantes por provincia',
                data: [],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgb(255, 99, 132, 0.2)',
                    'rgb(255, 159, 64, 0.2)',
                    'rgb(255, 205, 86, 0.2)',
                    'rgb(75, 192, 192, 0.2)',
                    'rgb(54, 162, 235, 0.2)',
                    'rgb(153, 102, 255, 0.2)',
                    'rgb(201, 203, 207, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });


    $.ajax({
        url: "/Reportes/GraficaPorProv",
        type: 'POST',
        dataType: 'json',
        //data: { search: request.term },
        success: function (data) {
            console.log(data)
            data.forEach((value, index) => {
                if (value.value > 0) {
                    myChart1.data.labels.push(`${value.key} (${value.value})`);
                    myChart1.data.datasets[0].data.push(value.value);
                }
            });

            myChart1.update();
        }
    });


    

    const ctx2 = document.getElementById('municipios-chart').getContext('2d');
    const municipiosChart = new Chart(ctx2, {
        type: 'pie',
        data: {
            labels: [],
            datasets: [{
                label: 'Aspirantes por provincia',
                data: [],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgb(255, 99, 132, 0.2)',
                    'rgb(255, 159, 64, 0.2)',
                    'rgb(255, 205, 86, 0.2)',
                    'rgb(75, 192, 192, 0.2)',
                    'rgb(54, 162, 235, 0.2)',
                    'rgb(153, 102, 255, 0.2)',
                    'rgb(201, 203, 207, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });


    var loadMunicipios = function (provinciaId) {
        $.ajax({
            url: "/Reportes/GraficaPorMunic",
            type: 'POST',
            dataType: 'json',
            data: { provinciaId: provinciaId },
            success: function (data) {
                municipiosChart.data.datasets[0].data = [];
                municipiosChart.data.labels = [];
                console.log("municios", data);
                data.forEach((value, index) => {
                    if (value.value > 0) {
                        municipiosChart.data.labels.push(`${value.key} (${value.value})`);
                        municipiosChart.data.datasets[0].data.push(value.value);
                    }
                });

                municipiosChart.update();
            }
        });
    }

    $("#provincia-select").change(function () {
        val = $("#provincia-select").val();
        if (val > 0) {
            //data: { search: request.term },

            loadMunicipios(val)

        }
    });








});