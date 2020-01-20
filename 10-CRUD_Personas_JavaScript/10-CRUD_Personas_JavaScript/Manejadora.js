window.onload = inicializa;

function inicializa() {
    recogerPersonas();
}

function recogerPersonas() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasAPI/");

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {

            document.getElementById("divApellido").innerHTML = "Cargando...";

        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                var arrayPersonas = JSON.parse(miLlamada.responseText);
                genera_tabla(arrayPersonas);

            }

    };

    miLlamada.send();

}


