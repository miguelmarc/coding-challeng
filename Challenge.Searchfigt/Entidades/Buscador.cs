using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Searchfigt.Entidades
{
    public class Buscador
    {
        public string nombreBuscador { get; set; }
        public string urlBuscador { get; set; }
        public string keyBuscador { get; set; }
        public string textoABuscar { get; set; }
        public int cantidadResultados { get; set; }
        public string campoInicioResultado { get; set; }
        public string campoFinResultado { get; set; }
        public string header { get; set; }
    }
}
