using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAerofeliz.Models
{
    public class TipoDestinoViewModel
    {
        public Planes Plane { get; set; }
        public List<Tipo_Destino> TipoDestinos { get; set; }
 
    }
}