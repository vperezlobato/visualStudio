window.onload = inicializa;

function inicializa() {
    document.getElementById("btnSaludar").addEventListener('click', pedirSaludo);
    document.getElementById("btnPedirApellido").addEventListener('click', pedirApellido);
    document.getElementById("btnBorrarPersona").addEventListener('click', borrarPersona);
}

function pedirSaludo() {
        var miLlamada = new XMLHttpRequest();
        miLlamada.open("GET", "../Html/Hola.html");

        //Definicion estados
        miLlamada.onreadystatechange = function () {
            if (miLlamada.readyState < 4) {

                document.getElementById("divSaludo").innerHTML = "Cargando...";

            }
            else
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                    var mensaje = miLlamada.responseText;
                    document.getElementById("divSaludo").innerHTML = mensaje;

                }

        };

        miLlamada.send();
   
} 

function pedirApellido() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasAPI");

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {

            document.getElementById("divApellido").innerHTML = "Cargando...";

        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                var arrayPersonas = JSON.parse(miLlamada.responseText);

                document.getElementById("divApellido").innerHTML = arrayPersonas[0].apellidos;

            }

    };

    miLlamada.send();

} 

function borrarPersona() {
    var miLlamada = new XMLHttpRequest();
    var idPersona = document.getElementById("borrarPersona").value;
    miLlamada.open("Delete", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasAPI/"+idPersona);

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {

            document.getElementById("divApellido").innerHTML = "Cargando...";

        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 204) {

                alert("Persona borrada con exito");
                document.getElementById("divApellido").innerHTML = "";
            }

    };

    miLlamada.send();

} 

