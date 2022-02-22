using System;
using System.Collections.Generic;
using System.Text;
using Challenge.Searchfigt.Interfaces;

namespace Challenge.Searchfigt.ServiciosBuscador
{
    public class BingBuscador : InterfaceBuscador
    {
        private string url;
        private string key;
        private string campoInicioResultado;
        private string campoFinResultado;
        private string header;

        public BingBuscador() {
            this.key = "dfdc2c99146c4e22b95412984e76ac40";
            this.header = "Ocp-Apim-Subscription-Key";
            this.campoInicioResultado = "\"totalEstimatedMatches\":";
            this.campoFinResultado = "\"value\":";
        }

        public string ObtenerHeader() {
            return this.header;
        }

        public string ObtenerKey() {

            return this.key;
        }

        public string ObtenerCampoInicioResultado()
        {
            return this.campoInicioResultado;
        }

        public string ObtenerCampoFinResultado()
        {
            return this.campoFinResultado;
        }

        public string ObtenerUrl(string texto)
        {

            try
            {
                return "https://api.cognitive.microsoft.com/bingcustomsearch/v7.0/search" + "?q=" + texto + "&customconfig=0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
