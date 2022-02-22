using System;
using System.Collections.Generic;
using System.Text;
using Challenge.Searchfigt.Interfaces;

namespace Challenge.Searchfigt.ServiciosBuscador
{
    public class GoogleBuscador : InterfaceBuscador
    {
        private string url;
        private string key;
        private string campoInicioResultado;
        private string campoFinResultado;

        public GoogleBuscador() {
            this.key = "AIzaSyAYKBLINxMWiEeXSjNeyFxzGjYKBfLwpnE&cx=006469441686315824696:jlvbuea85y8";
            this.campoInicioResultado = "\"totalResults\":";
            this.campoFinResultado = "\"searchTerms\":";
        }
        public string ObtenerKey()
        {
            return this.key;
        }

        public string ObtenerCampoInicioResultado() {
            return this.campoInicioResultado;
        }

        public string ObtenerCampoFinResultado()
        {
            return this.campoFinResultado;
        }

        public string ObtenerUrl(string texto) {

            try
            {
                return "https://www.googleapis.com/customsearch/v1?key=" + this.key + "&q=" + texto;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

    }
}
