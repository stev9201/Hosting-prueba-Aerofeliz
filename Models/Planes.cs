namespace ProyectoAerofeliz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Planes // Paso 1: editar la clase 
    {
        [Display(Name="#")] //El atributo Display(Name="#") se utiliza para definir el nombre que se mostrará en la interfaz de usuario para este campo.
        public int Id { get; set; } 

        [Display(Name = "Telefono")] // El atributo Display(Name="Telefono") se utiliza para definir el nombre que se mostrará en la interfaz de usuario para este campo.
        public Nullable<int> Telefono { get; set; }

        [Display(Name = "Correo Electronico")] // El atributo Display(Name="Correo Electronico") se utiliza para definir el nombre que se mostrará en la interfaz de usuario para este campo.
        public string Correo { get; set; }

        [Display(Name = "Id_Destino")] // El atributo Display(Name="Id_Destino") se utiliza para definir el nombre que se mostrará en la interfaz de usuario para este campo.
        public Nullable<int> Id_Tipo_destino { get; set; }

        [Display(Name = "Peticion del cliente")] // El atributo Display(Name="Peticion del cliente") se utiliza para definir el nombre que se mostrará en la interfaz de usuario para este campo.
        public string Mensaje { get; set; }
    }
} 

/* En el paso 1 lo que se hizo fue editar la clase Planes, asignandole a los campos Id, Telefono, 
   Correo, Id_Tipo_Destino y Mensaje otro nombre mas adecuado o personalizado en la interfaz, agregando 
   una (data annotations) con el [Display(Name = "mensaje en la interfaz")] */

