window.onload = inicializa;

function inicializa() {

    getDatos();

}

//Funcion que llama a la api de los superheroes y a la api de las misiones para recoger sus listados
function getDatos() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "http://localhost:59456/api/Superheroe");

    miLlamada.onreadystatechange = function () {

            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                var listadoSuperheroes = JSON.parse(miLlamada.responseText);

                var misionesLlamada = new XMLHttpRequest();

                misionesLlamada.open("GET", "http://localhost:59456/api/Misiones/");

                misionesLlamada.onreadystatechange = function () {

                    if (misionesLlamada.readyState == 4 && misionesLlamada.status == 200) {

                        var listadoMisiones = JSON.parse(misionesLlamada.responseText);
                        createTable(listadoSuperheroes, listadoMisiones);
                    }
                }

                misionesLlamada.send();
            }
        };

        miLlamada.send();
}

//Este metodo sirve para crear la tabla con los checkboxes
function createTable(listadoSuperheroes, listadoMisiones) {
    this.col = [];
    var div = document.getElementById('container');
    for (var i = 0; i < listadoSuperheroes.length; i++) {
        for (var key in listadoSuperheroes[i]) {
            if (this.col.indexOf(key) === -1) {
                this.col.push(key);
            }
        }
    }

    var table = document.createElement('table'); //crea la tabla
    table.setAttribute('id', 'tablaSuperheroes');   

    var tr = table.insertRow(-1);             

    for (var h = 0; h < this.col.length - 1; h++) {

        var th = document.createElement('th');
        if (h == 0) { //mientras la va creando omite mostrar los id´s
            th.innerHTML = "Superheroe";
        }
            
        tr.appendChild(th);
    }

    for (var i = 0; i < listadoSuperheroes.length; i++) {

        tr = table.insertRow(-1);   

        for (var j = 1; j < this.col.length - 1; j++) {
            var tabCell = tr.insertCell(-1);

            tabCell.innerHTML = listadoSuperheroes[i][this.col[j]];

        }


        this.td = document.createElement('td');

        tr.appendChild(td);

        //se crean los checkbox y se meten en la tabla
        var checkbox = document.createElement('input');
        checkbox.setAttribute('type', 'checkbox');
        checkbox.setAttribute('value', listadoSuperheroes[i].idSuperheroe);
        checkbox.setAttribute('id', listadoSuperheroes[i].idSuperheroe);
        checkbox.setAttribute('class', 'CHE');
        this.td.appendChild(checkbox);

        //añadimos la tabla al div con el id de container        
        div.innerHTML = '';
        div.appendChild(table);       
    }
    //añadimos el boton para ver las misiones del superheroe
    var btnVerMision = document.createElement('input');
    btnVerMision.setAttribute('id', 'btnVerMision');
    btnVerMision.setAttribute('value', 'Ver Mision');
    btnVerMision.setAttribute('type', 'button');
    btnVerMision.setAttribute('style', 'background-color:#44CCEB');
    btnVerMision.addEventListener('click', function () { mostrarMisiones(listadoSuperheroes, listadoMisiones) });
    div.appendChild(btnVerMision);
}

//Este sera el metodo al que llamara el boton ver mision
function mostrarMisiones(listadoSuperheroes, listadoMisiones) {
    var superheroesSeleccionados = [];
    var checkbox = document.getElementsByClassName('CHE');
    var contadorSuperheroesSeleccionados = 0;
    for (var i = 0, cblength = checkbox.length; i < cblength; i++) {
        if (checkbox[i].checked) { //comprueba si el checkbox ha sido marcado
            superheroesSeleccionados[i] = obtenerSuperheroePorId(checkbox[i].value, listadoSuperheroes);
            contadorSuperheroesSeleccionados++;
        }
    }
    if (contadorSuperheroesSeleccionados < 1) { //Si no se ha seleccionado ningun superheroe avisa al usuario
        alert("No se ha seleccionado ningun superheroe");
    }else
        misionesDeSuperheroes(superheroesSeleccionados, listadoMisiones);
}

//Este metodo sirve para recoger los heroes segun el checkbox que ha sido marcado
function obtenerSuperheroePorId(idCheckbox,listadoSuperheroes) {

    for (var i = 0; i < listadoSuperheroes.length; i++) {
        if (listadoSuperheroes[i].idSuperheroe == idCheckbox) {
            return listadoSuperheroes[i];
        }
    }
}

//Este metodo es el que se va usar para mostrar las misiones del superheroe en caso de que tenga
//Si no tiene mision se mostrara un mensaje indicandolo
function misionesDeSuperheroes(superheroesSeleccionados, listadoMisiones) {
    var misionesDelSuperheroe = [];
    var div = document.getElementById('verMision');
    div.innerHTML = "";
    for (var i = 0; i < superheroesSeleccionados.length; i++) {

        if (superheroesSeleccionados[i] != undefined) {
            var divSuperheroe = document.createElement('h1');
            divSuperheroe.innerHTML = superheroesSeleccionados[i].nombreSuperheroe;
            div.appendChild(divSuperheroe);
            misionesDelSuperheroe[i] = buscarMisionesPorSuperheroeSeleccionado(superheroesSeleccionados[i].idSuperheroe, listadoMisiones);

            for (var j = 0; j < misionesDelSuperheroe[i].length; j++) {

                if (misionesDelSuperheroe[i][j] != undefined) {
                    
                    var divTexto = document.createElement('tr');                    
                    divTexto.innerHTML = misionesDelSuperheroe[i][j].tituloMision;
                    div.appendChild(divTexto);
                }

            }

            if (misionesDelSuperheroe[i].length == 0) {

                var divTexto = document.createElement('tr');
                divTexto.innerHTML = "No tiene reservada ninguna mision";

                div.appendChild(divTexto);
            }
            var hr = document.createElement('hr');
            div.appendChild(hr);
        }

    }
}

//Este metodo sirve para recoger todas las misiones del heroe que ha sido marcado
function buscarMisionesPorSuperheroeSeleccionado(idSuperheroe, listadoMisiones) {
    var misiones = [];
    for (var i = 0; i < listadoMisiones.length; i++) {
        if (listadoMisiones[i].idSuperheroe == idSuperheroe) {
            misiones[i] = listadoMisiones[i];
        }
    }
    return misiones;
}