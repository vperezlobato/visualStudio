window.onload = inicializa;

function inicializa() {

    getDatos();
    
}
// Hace una peticion GET a la api y ejecuta la funcion crearTabla a partir del resultado obtenido (GET)
function getDatos() {

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasApi/");

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            var listadoPersonas = JSON.parse(miLlamada.responseText);

            var departamentosLlamada = new XMLHttpRequest();

            departamentosLlamada.open("GET", "https://crudpersonasui-victor.azurewebsites.net/api/departamentosapi");

            departamentosLlamada.onreadystatechange = function () {

                if (departamentosLlamada.readyState == 4 && departamentosLlamada.status == 200) {

                    var listadoDepartamentos = JSON.parse(departamentosLlamada.responseText);
                    createTable(listadoPersonas, listadoDepartamentos)
                }
            }

            departamentosLlamada.send();
        }
    };

    miLlamada.send();
}

// Hace una peticion PUT a la api
function llamadaPUT(objPersona) {
    var persona = JSON.stringify(objPersona);

    var putPersona = new XMLHttpRequest();

    putPersona.open("PUT", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasApi/" + objPersona.idPersona, true);
    putPersona.setRequestHeader('Content-Type', 'application/json');

    putPersona.onreadystatechange = function () {

        if (putPersona.readyState == 4) {

            if (putPersona.status == 204) {

                alert("Persona actualizada");
            }
            else {
                alert("Error al actualizar persona");
            }


        }
    };

    putPersona.send(persona);
}

function llamadaPOST(objPersona) {
    var persona = JSON.stringify(objPersona);

    var postPersona = new XMLHttpRequest();

    postPersona.open("POST", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasApi/", true);
    postPersona.setRequestHeader('Content-Type', 'application/json');

    postPersona.onreadystatechange = function () {

        if (postPersona.readyState == 4) {

            if (postPersona.status == 204) {
                alert("Persona creada correctamente");
            }
            else {
                alert("Error al crear persona");
            }
        }
    };

    postPersona.send(persona);
}

function llamadaDELETE(idPersona) {

    var deletePersona = new XMLHttpRequest();

    deletePersona.open("DELETE", "https://crudpersonasui-victor.azurewebsites.net/api/PersonasApi/" + idPersona, true);
    deletePersona.setRequestHeader('Content-Type', 'application/json');

    deletePersona.onreadystatechange = function () {

        if (deletePersona.readyState == 4) {

            if (deletePersona.status == 204) {
                alert("Persona borrada de la existencia correctamente");

            }
            else {
                alert("Error al borrar persona");
            }

        }
    };

    deletePersona.send(idPersona);
}


function buscarDepartamento(idDepartamento, listadoDepartamentos) {
        for (var i = 0; i < listadoDepartamentos.length; i++) {
            if (listadoDepartamentos[i].id == idDepartamento) {
                return listadoDepartamentos[i];
            }
        }
    
}

function buscarDepartamentoPorNombre(nombre, listadoDepartamentos) {
    for (var i = 0; i < listadoDepartamentos.length; i++) {
        if (listadoDepartamentos[i].nombre === nombre) {
            return listadoDepartamentos[i].id;
        }
    }
}

function createTable(listadoPersonas, listadoDepartamentos) {    
    
    this.col = [];
    // EXTRACT VALUE FOR TABLE HEADER.
    for (var i = 0; i < listadoPersonas.length; i++) {
        for (var key in listadoPersonas[i]) {
            if (this.col.indexOf(key) === -1) {
                this.col.push(key);
            }
        }
    }

    // CREATE A TABLE.
    var table = document.createElement('table');
    table.setAttribute('id', 'tablaPersonas');     // SET TABLE ID.

    var tr = table.insertRow(-1);               // CREATE A ROW (FOR HEADER).

    for (var h = 0; h < this.col.length-1; h++) {
            // ADD TABLE HEADER.
        var th = document.createElement('th');
        if (h != 4) {           
            if (h == 7) {
                //No pintamos el idDepartamento
            } else
                th.innerHTML = this.col[h].replace('_', ' ');
        } else
            th.innerHTML = "Departamento";
        tr.appendChild(th);
    }

    // ADD ROWS USING JSON DATA.
    for (var i = 0; i < listadoPersonas.length; i++) {

        tr = table.insertRow(-1);           // CREATE A NEW ROW.

        for (var j = 0; j < this.col.length-1; j++) {
            var tabCell = tr.insertCell(-1);
            switch (j) {
                case 3:
                    if (listadoPersonas[i].fechaNacimiento != undefined) {
                        var x = new Date(listadoPersonas[i].fechaNacimiento);
                        var dd = x.getDate();
                        var mm = x.getMonth() + 1;
                        var yy = x.getFullYear();
                        if (mm < 10) {
                            if (dd < 10) {
                                tabCell.innerHTML = yy + "-0" + mm + "-0" + dd;
                            } else
                                tabCell.innerHTML = yy + "-0" + mm + "-" + dd;
                        } else {
                            if (dd < 10) {
                                tabCell.innerHTML = yy + "-" + mm + "-0" + dd;
                            } else
                                tabCell.innerHTML = yy + "-" + mm + "-" + dd;
                        }
                    }
                    break;
                case 4:
                    if (listadoPersonas[i].idDepartamento != undefined) { 
                        var departamento = buscarDepartamento(listadoPersonas[i].idDepartamento, listadoDepartamentos);
                        tabCell.innerHTML = departamento.nombre;
                    }

                    break;
                case 5:
                    var telefono = document.createElement('input');
                    telefono.setAttribute('type', 'number');
                    if (listadoPersonas[i][this.col[j]] != undefined) {
                        tabCell.innerHTML = listadoPersonas[i][this.col[j]];
                    }
                    break;
                case 6:
                    var img = document.createElement('img');
                    img.src = "data:image/jpg;base64," + listadoPersonas[i][this.col[j]];
                    img.height = 30;
                    img.width = 30;
                    tabCell.appendChild(img);
                break;
                default:
                    if (listadoPersonas[i][this.col[j]] != undefined) {
                        tabCell.innerHTML = listadoPersonas[i][this.col[j]];
                    }
                break;
            }
        }

        // DYNAMICALLY CREATE AND ADD ELEMENTS TO TABLE CELLS WITH EVENTS.

        this.td = document.createElement('td');

        // *** cancelar OPTION.
        tr.appendChild(this.td);
        var lblcancelar = document.createElement('label');
        lblcancelar.innerHTML = '✖';        
        lblcancelar.setAttribute('style', 'display:none;');
        lblcancelar.setAttribute('title', 'cancelar');
        lblcancelar.setAttribute('id', 'cancelar' + i);
        lblcancelar.addEventListener('click', function () { cancelar(col, listadoPersonas, listadoDepartamentos,this)});
        this.td.appendChild(lblcancelar);

        // *** guardar.
        tr.appendChild(this.td);
        var btguardar = document.createElement('input');

        btguardar.setAttribute('type', 'button');      // SET ATTRIBUTES.
        btguardar.setAttribute('value', 'Guardar');
        btguardar.setAttribute('id', 'guardar' + i);
        btguardar.setAttribute('style', 'display:none;');
        btguardar.addEventListener('click', function () { guardar(this, col, listadoPersonas, listadoDepartamentos) }) ;       // ADD THE BUTTON's 'onclick' EVENT.
        this.td.appendChild(btguardar);

        // *** editar.
        tr.appendChild(this.td);
        var bteditar = document.createElement('input');

        bteditar.setAttribute('type', 'button');    // SET ATTRIBUTES.
        bteditar.setAttribute('value', 'editar');
        bteditar.setAttribute('id', 'Editar' + i);
        bteditar.setAttribute('style', 'background-color:#44CCEB;');
        bteditar.addEventListener('click', function () { editar(listadoDepartamentos,this) });   // ADD THE BUTTON's 'onclick' EVENT.
        this.td.appendChild(bteditar);

        // *** borrar.
        this.td = document.createElement('th');
        tr.appendChild(this.td);
        var btborrar = document.createElement('input');
        btborrar.setAttribute('type', 'button');    // SET INPUT ATTRIBUTE.
        btborrar.setAttribute('value', 'Borrar');
        btborrar.setAttribute('style', 'background-color:#ED5650;');
        btborrar.addEventListener('click', function () { borrar(this, listadoPersonas, listadoDepartamentos) });   // ADD THE BUTTON's 'onclick' EVENT.
        this.td.appendChild(btborrar);
     
        }

        tr = table.insertRow(-1);// CREATE THE LAST ROW.

        for (var j = 0; j < col.length-1; j++) {
            var newCell = tr.insertCell(-1);
            
        
        }

        this.td = document.createElement('td');
        tr.appendChild(this.td);

        var btNew = document.createElement('input');

        btNew.setAttribute('type', 'button');       // SET ATTRIBUTES.
        btNew.setAttribute('value', 'Crear');
        btNew.setAttribute('id', 'crear' + i);
        btNew.setAttribute('style', 'background-color:#207DD1;');
        btNew.addEventListener('click', function () { crear(this, col, listadoDepartamentos)});       // ADD THE BUTTON's 'onclick' EVENT.
        this.td.appendChild(btNew);

        var cancel = document.createElement('label');

        cancel.setAttribute('type', 'button');       // SET ATTRIBUTES.
        cancel.innerHTML = '✖';
        cancel.setAttribute('id', 'cancelarDeConfirmar' + i);
        cancel.setAttribute('style', 'display:none;');
        cancel.addEventListener('click', function () { cancelarDeConfirmar(this, col) });
        this.td.appendChild(cancel);

        var confirm= document.createElement('input');

        confirm.setAttribute('type', 'button');       // SET ATTRIBUTES.
        confirm.setAttribute('value', 'Confirmar');
        confirm.setAttribute('id', 'confirmar' + i);
        confirm.setAttribute('style', 'display:none;');
        confirm.addEventListener('click', function () { confirmar(this, col, listadoPersonas, listadoDepartamentos) });       // ADD THE BUTTON's 'onclick' EVENT.
        this.td.appendChild(confirm);

        var div = document.getElementById('container');
        div.innerHTML = '';
        div.appendChild(table);// ADD THE TABLE TO THE WEB PAGE.

}


function cancelar(col,listadoPersonas,listadoDepartamentos,boton) {

    // HIDE THIS BUTTON.
    boton.setAttribute('style', 'display:none; float:none;');

    var activeRow = boton.parentNode.parentNode.rowIndex;

    // HIDE THE guardar BUTTON.
    var btguardar = document.getElementById('guardar' + (activeRow - 1));
    btguardar.setAttribute('style', 'display:none;');

    // SHOW THE editar BUTTON AGAIN.
    var bteditar = document.getElementById('Editar' + (activeRow - 1));
    bteditar.setAttribute('style', 'display:block; margin:0 auto; background-color:#44CCEB;');

    var tab = document.getElementById('tablaPersonas').rows[activeRow];

    for (i = 0; i < col.length-1; i++) {
        var td = tab.getElementsByTagName("td")[i];
        if (i == 3) {
            var x = new Date(listadoPersonas[(activeRow - 1)].fechaNacimiento);
            var dd = x.getDate();
            var mm = x.getMonth() + 1;
            var yy = x.getFullYear();
            if (mm < 10) {
                if (dd < 10) {
                    td.innerHTML = yy + "-0" + mm + "-0" + dd;
                } else
                    td.innerHTML = yy + "-0" + mm + "-" + dd;
            } else {
                if (dd < 10) {
                    td.innerHTML = yy + "-" + mm + "-0" + dd;
                } else
                    td.innerHTML = yy + "-" + mm + "-" + dd;
            }
        } else if (i == 4) {
            var departamento = buscarDepartamento(listadoPersonas[(activeRow - 1)].idDepartamento, listadoDepartamentos);
            td.innerHTML = departamento.nombre;
        } else if (i == 6) {
            var element = document.getElementById('inputfile');
            element.parentNode.removeChild(element);
            var img = document.createElement('img');
            img.src = "data:image/jpg;base64," + listadoPersonas[(activeRow - 1)][col[i]]; //Esto es para convertir el array de bytes a input file
            img.height = 30;
            img.width = 30;
            td.appendChild(img);
        } else
            td.innerHTML = listadoPersonas[(activeRow - 1)][col[i]];

    }
}


// EDIT DATA.
function editar(listadoDepartamentos,boton) {
    
    var activeRow = boton.parentNode.parentNode.rowIndex;

    var tab = document.getElementById('tablaPersonas').rows[activeRow];

    // SHOW A DROPDOWN LIST WITH A LIST OF CATEGORIES.
    for (var i = 0; i <= 6; i++) {
        var td = tab.getElementsByTagName("td")[i];
        switch (i) {
            case 3:
                var ele = document.createElement('input');      // INPUT FILE.
                ele.setAttribute('type', 'date');
                ele.setAttribute('id', 'inputdate');
                ele.setAttribute('value', td.innerText);
                td.innerText = '';
                td.appendChild(ele);
                break;
            case 4:            
                var ele = document.createElement('select');      // DROPDOWN LIST.
                //ele.innerHTML = '<option value="' + td.innerText + '">' + td.innerText + '</option>';
                for (k = 0; k < listadoDepartamentos.length; k++) {
                    ele.innerHTML = ele.innerHTML +
                        '<option value="' + listadoDepartamentos[k].nombre + '">' + listadoDepartamentos[k].nombre + '</option>';
                }
                td.innerText = '';
                td.appendChild(ele);
                break;
            case 5:
                var ele = document.createElement('input');      // INPUT FILE.
                ele.setAttribute('type', 'number');
                ele.setAttribute('value', td.innerText);
                td.innerText = '';
                td.appendChild(ele);
                break;
            case 6:
                var ele = document.createElement('input');      // INPUT FILE.
                ele.setAttribute('type', 'file');
                ele.setAttribute('id', 'inputfile');               
                td.innerText = '';
                td.appendChild(ele);
                break;

            default:
                var ele = document.createElement('input');      // TEXTBOX.
                ele.setAttribute('type', 'text');
                ele.setAttribute('value', td.innerText);
                td.innerText = '';
                td.appendChild(ele);
            break;
        }
    }

    var lblcancelar = document.getElementById('cancelar' + (activeRow - 1));
    lblcancelar.setAttribute('style', 'cursor:pointer; display:block; width:20px; float:left; position: absolute;');

    var btguardar = document.getElementById('guardar' + (activeRow - 1));
    btguardar.setAttribute('style', 'display:block; margin-left:30px; float:left; background-color:#2DBF64;');

    // HIDE THIS BUTTON.
    boton.setAttribute('style', 'display:none;');
};

// borrar DATA.
function borrar(oButton, listadoPersonas,listadoDepartamentos) {
        var activeRow = oButton.parentNode.parentNode.rowIndex;
        var r = confirm("¿Estas seguro de que deseas eliminar esta persona?");
        if (r == true) {
            if (listadoPersonas[activeRow - 1].idPersona == undefined) {
                /*
                 * El problema es basicamente que el CRUD no conoce el id de las ultimas personas creadas ya que la BBDD le da un ID autogenerado y como solo se piden las personas
                 * al principio cuando se ejecuta el CRUD pues no es posible conocer su ID hasta que no volvamos a ejecutar.
                 */
                alert("Ups parece que esta persona ha sido creada recientemente, deberias probar a ejecutar de nuevo ya que puede que recargar la pagina no solucione tu problema.")
            } else {
                llamadaDELETE(listadoPersonas[activeRow - 1].idPersona);
                listadoPersonas.splice((activeRow - 1), 1);
            }
        }
        // borrar THE ACTIVE ROW.    
    createTable(listadoPersonas, listadoDepartamentos);// REFRESH THE TABLE.
};

// guardar DATA.
function guardar(oButton, col, listadoPersonas, listadoDepartamentos) {
    var activeRow = oButton.parentNode.parentNode.rowIndex;
    var tab = document.getElementById('tablaPersonas').rows[activeRow];

    var persona = new clsPersona();

    // editar myBooks ARRAY WITH VALUES.
    for (i = 0; i < col.length-1; i++) {
        var td = tab.getElementsByTagName("td")[i];
        if (td.childNodes[0].getAttribute('type') == 'text' || td.childNodes[0].tagName == 'SELECT') {// CHECK IF ELEMENT IS A TEXTBOX OR SELECT.
            if (td.childNodes[0].tagName == 'SELECT') {
                var idDepartamento = buscarDepartamentoPorNombre(td.childNodes[0].value, listadoDepartamentos);
                listadoPersonas[(activeRow - 1)].idDepartamento = idDepartamento;
                persona.idDepartamento = idDepartamento;
            } else {
                listadoPersonas[(activeRow - 1)][col[i]] = td.childNodes[0].value;
                persona[col[i]] = td.childNodes[0].value;
            }// guardar THE VALUE.
        } else
            if (td.childNodes[0].getAttribute('type') == 'date') {
                var fecha = new Date(td.childNodes[0].value);
                listadoPersonas[(activeRow - 1)][col[i]] = fecha;
                persona.fechaNacimiento = fecha;
            } else if (td.childNodes[0].getAttribute('type') == 'file') {
                if (document.getElementById('inputfile').files[0] != null) {
                    var file = document.getElementById('inputfile').files[0];
                    var reader = new FileReader();
                    reader.readAsDataURL(file);
                    listadoPersonas[(activeRow - 1)][col[i]] = async function () {
                        var byteArray = await toBase64(file);
                        return byteArray;
                    }

                }
            } else if (td.childNodes[0].getAttribute('type') == 'number') {
                listadoPersonas[(activeRow - 1)][col[i]] = td.childNodes[0].value;
                persona[col[i]] = td.childNodes[0].value;
            }
    }
    persona.idPersona = listadoPersonas[activeRow - 1].idPersona;
    llamadaPUT(persona); 
    createTable(listadoPersonas, listadoDepartamentos); // REFRESH THE TABLE.
}

const toBase64 = file => new Promise((resolve) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
});

// CREATE NEW.
function crear(oButton, col, listadoDepartamentos) {
    var activeRow = oButton.parentNode.parentNode.rowIndex;
    var tab = document.getElementById('tablaPersonas').rows[activeRow];

    var cancelar = document.getElementById('cancelarDeConfirmar' + (activeRow - 1));
    cancelar.setAttribute('style', 'cursor:pointer; display:block; width:20px; float:left; position: absolute;');

    var confirmar = document.getElementById('confirmar' + (activeRow - 1));
    confirmar.setAttribute('style', 'display:block; margin-left:30px; float:left; background-color:#2DBF64;');

    oButton.setAttribute('style', 'display:none;');

    for (var j = 0; j < col.length - 1; j++) {
        var td = tab.getElementsByTagName("td")[j];
        switch (j) {
            case 3:
                var ele = document.createElement('input');      // TEXTBOX.
                ele.setAttribute('type', 'date');
                ele.setAttribute('id', 'inputdatecreate');
                td.innerText = '';
                td.appendChild(ele);
                break;
            case 4:    // WE'LL ADD A DROPDOWN LIST AT THE SECOND COLUMN (FOR listadoDepartamentos).

                var select = document.createElement('select');      // CREATE AND ADD A DROPDOWN LIST.
                select.innerHTML = '<option value=""></option>';
                for (k = 0; k < listadoDepartamentos.length; k++) {
                    select.innerHTML = select.innerHTML +
                        '<option value="' + listadoDepartamentos[k].nombre + '">' + listadoDepartamentos[k].nombre + '</option>';
                }
                td.innerText = '';
                td.appendChild(select);
                break;
            case 6:
                var ele = document.createElement('input');      // TEXTBOX.
                ele.setAttribute('type', 'file');
                ele.setAttribute('id', 'inputfilecreate');
                td.innerText = '';
                td.appendChild(ele);
                break;
            case 5:
                var telefono = document.createElement('input');
                telefono.setAttribute('type', 'number');
                td.appendChild(telefono);
                break;
            default:
                var tBox = document.createElement('input');          // CREATE AND ADD A TEXTBOX.
                tBox.setAttribute('type', 'text');
                tBox.setAttribute('value', '');
                td.innerText = '';
                td.appendChild(tBox);
                break;

        }             
    }
    
}

function confirmar(oButton, col, listadoPersonas, listadoDepartamentos) {
    var activeRow = oButton.parentNode.parentNode.rowIndex;
    var tab = document.getElementById('tablaPersonas').rows[activeRow];

    var persona = new clsPersona();
    var sePuedeInsertar = true;
    // ADD NEW VALUE TO myBooks ARRAY.
    for (i = 0; i < col.length-1; i++) {
        var td = tab.getElementsByTagName("td")[i];
        if (td.childNodes[0].getAttribute('type') == 'text' || td.childNodes[0].tagName == 'SELECT') {      // CHECK IF ELEMENT IS A TEXTBOX OR SELECT.
            var txtVal = td.childNodes[0].value;
            if (txtVal != '') {
                if (td.childNodes[0].tagName == 'SELECT') {
                    var idDepartamento = buscarDepartamentoPorNombre(txtVal, listadoDepartamentos);
                    persona.idDepartamento = idDepartamento;
                } else
                    persona[col[i]] = txtVal.trim();

            } else
                sePuedeInsertar = false;
        } else
            if (td.childNodes[0].getAttribute('type') == 'date') {
                if (td.childNodes[0].value != '') {
                    var fecha = new Date(td.childNodes[0].value);
                    persona.fechaNacimiento = fecha;
                } else
                    sePuedeInsertar = false;
            } else if (td.childNodes[0].getAttribute('type') == 'file') {
                if (document.getElementById('inputfilecreate').files[0] != null) {
                    var file = document.getElementById('inputfilecreate').files[0];
                    var reader = new FileReader();
                    reader.readAsDataURL(file);
                    reader.onloadend = function () {
                        persona.foto = reader.result;

                    };


                }
            } else if (td.childNodes[0].getAttribute('type') == 'number') {
                persona[col[i]] = td.childNodes[0].value;
            }
    }

    if (sePuedeInsertar == true) {
        llamadaPOST(persona);

        if (Object.keys(persona).length > 0) {      // CHECK IF OBJECT IS NOT EMPTY.
            listadoPersonas.push(persona);             // PUSH (ADD) DATA TO THE JSON ARRAY.
            createTable(listadoPersonas, listadoDepartamentos);
        }// REFRESH THE TABLE.
    } else
        alert("Has dejado algun campo sin rellenar");
}

function cancelarDeConfirmar(boton, col) {
    // HIDE THIS BUTTON.
    boton.setAttribute('style', 'display:none; float:none;');

    var activeRow = boton.parentNode.parentNode.rowIndex;

    // HIDE THE guardar BUTTON.
    var btConfirmar = document.getElementById('confirmar' + (activeRow - 1));
    btConfirmar.setAttribute('style', 'display:none;');

    // SHOW THE editar BUTTON AGAIN.
    var btcrear = document.getElementById('crear' + (activeRow - 1));
    btcrear.setAttribute('style', 'display:block; margin:0 auto; background-color:#207DD1;');

    var tab = document.getElementById('tablaPersonas').rows[activeRow];

    for (var j = 0; j < col.length - 1; j++) {
        var td = tab.getElementsByTagName("td")[j];
        td.innerText = '';
       
    }
}
        // ****** OPERATIONS END.
    