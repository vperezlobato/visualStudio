window.onload = inicializa;

function inicializa() {
    //alert("Hola Mundo");
    document.getElementById("btnPulsar").addEventListener('click', cambiarTexto, false);
    document.getElementById("btnAlerta").addEventListener('click', mostrarAlerta, false);
    
}

function cambiarTexto() {
    //alert("Hola Mundo");
    document.getElementById("divTexto").innerHTML = "Hola Mundo";
}

function mostrarAlerta() {
    var nombre = document.getElementById("nombre").value;
    var apellidos = document.getElementById("apellidos").value;
    var persona = new Persona(nombre, apellidos);
    persona.saludar();

}
