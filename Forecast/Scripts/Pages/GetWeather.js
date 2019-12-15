$(document).ready(function () {
    $("#btnGetWeather").click(function () {
        
        
        $.ajax({
            type: "GET",
            url: '/Home/GetWeatherInfo?CityName=' + $("#CityName").val(),
            //data: JSON.stringify(folder),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $.each(data, function (i, obj) {
                    document.getElementById("min").value = obj.min;
                    document.getElementById("max").value = obj.max;
                    document.getElementById("temperature").value = obj.temperature;
                    document.getElementById("pressure").value = obj.pressure;
                    document.getElementById("humidity").value = obj.humidity;
                    document.getElementById("Wind_Speed").value = obj.Wind_Speed;
                    document.getElementById("city").value = obj.city;
                    
                });
                
            },
            error: function () {
                alert("server Error while getting data");
            }
        });
        return false;
    });
    $("#Countries").change(function () {
        $.ajax({
            type: "GET",
            url: '/Home/GetWeatherInfo?CityName=' + $("#Countries").val(),
            //data: JSON.stringify(folder),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $.each(data, function (i, obj) {
                    document.getElementById("min").value = obj.min;
                    document.getElementById("max").value = obj.max;
                    document.getElementById("temperature").value = obj.temperature;
                    document.getElementById("pressure").value = obj.pressure;
                    document.getElementById("humidity").value = obj.humidity;
                    document.getElementById("Wind_Speed").value = obj.Wind_Speed;

                });

            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        return false;
    });

    $("#isCityText").change(function () {
        var checkbox = $(this), // Selected or current checkbox
            value = checkbox.val(); // Value of checkbox

        if (checkbox.is(':checked')) {
            $("#CityName").removeAttr("readonly");
            $("#CountriesListID").hide();
        } else {
            $("#CityName").attr("readonly", "readonly");
            $("#CountriesListID").show();
        }
    });
    
    
});