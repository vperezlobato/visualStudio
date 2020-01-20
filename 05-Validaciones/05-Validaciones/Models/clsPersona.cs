using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_Validaciones.Models
{
    public class clsPersona
    {

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public String nombre { set; get; }
        
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(40, ErrorMessage = "La longitud maxima es 40")]
        public String apellidos { set; get; }
        
        [MaxLength(200, ErrorMessage = "La longitud maxima es 200")]
        public String direccion { set; get; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fechaNacimiento { set; get; }
        
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        
        [RegularExpression(@"[679]{1}[0-9]{8}$", ErrorMessage = "Numero de telefono invalido")]
        public String telefono { get; set; }
        


        public clsPersona(int ID , String nombre, String apellidos, String direccion, DateTime fechaNacimiento,String telefono)
        {
            this.ID = ID;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
        }
        public clsPersona() { }
    }
}