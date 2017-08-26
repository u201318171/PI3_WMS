var averages = [];
var ranges = [];

var muestras = [];

function llenaMuestras(element) {
    if(muestras.length == 0)
    {
        $.ajax({
            url: '/Muestra/getMuestras',
            type: 'GET',
            success: function(data){
                console.log(data);
                muestras = data;
                cargaComboMuestras(element);
            },
            error: function(error){
                console.log(error);
            }
        })
    }
    else {
        cargaComboMuestras(element);
    }
};

function cargaComboMuestras(element){
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Seleccionar'));
    $.each(muestras, function(i, val){
        $ele.append($('<option/>').val(val.IdMuestra).text(val.IdMuestra));
    })
};

function llenaDatos(){
    $.ajax({
        url: '/CadenaCustodia/getEBIData',
        type: 'GET',
        success: function(data){
            var i = 0;
            data.forEach(function(item) {
                //llenar array de averages
                averages[i] = [ new Date(item.FechaMuestra).getTime(),item.EBIValor];
                //llenar array de ranges
                ranges[i] = [new Date(item.FechaMuestra).getTime(),item.RangoInferior, item.RangoSuperior];
                //incrementar el index
                i++;
            })
        }
    })
};

//asignar los arrays a high charts
Highcharts.chart('container', {
    
        title: {
            text: 'Grafica EBI'
        },
    
        xAxis: {
            type: 'datetime'
        },
    
        yAxis: {
            title: {
                text: null
            }
        },
    
        tooltip: {
            crosshairs: true,
            shared: true,
            valueSuffix: '°C'
        },
    
        legend: {
        },
    
        series: [{
            name: 'Fechas de Muestras',
            data: averages,
            zIndex: 1,
            marker: {
                fillColor: 'white',
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[0]
            }
        }, {
            name: 'EBI',
            data: ranges,
            type: 'arearange',
            lineWidth: 0,
            linkedTo: ':previous',
            color: Highcharts.getOptions().colors[0],
            fillOpacity: 0.3,
            zIndex: 0,
            marker: {
                enabled: false
            }
        }]
});

llenaMuestras($('#listaMuestras'));

