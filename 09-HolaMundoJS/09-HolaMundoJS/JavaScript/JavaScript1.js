class Persona {
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }

    saludar() {
        alert(this.nombre + " " + this.apellidos);
    }
}
