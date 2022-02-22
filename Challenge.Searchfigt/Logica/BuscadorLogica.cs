using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Challenge.Searchfigt.Entidades;

namespace Challenge.Searchfigt.Logica
{
    public class BuscadorLogica
    {
        private HttpClient _httpClient;

        public  BuscadorLogica(int flag){

            if (flag == 1)
                this._httpClient = new HttpClient();
        }

        public void AgregarHeader(string llave, string valor) {

            try {

                _httpClient.DefaultRequestHeaders.Add(llave, valor);

            }catch(Exception ex){
                throw ex;
            }
        }

        public int BuscarResultados(Buscador buscador) {

            int cantidadResultados = 0;
            string resultado = string.Empty;

            try
            {
                resultado = ObtenerRespuesta(buscador.urlBuscador);

                int inicio = resultado.IndexOf(buscador.campoInicioResultado);
                int fin = resultado.IndexOf(buscador.campoFinResultado);

                string sub = resultado.Substring(inicio, fin - inicio);

                cantidadResultados = Convert.ToInt32(Regex.Replace(sub, @"[^\d]", ""));

                return cantidadResultados;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public string ObtenerRespuesta(string url)
        {
            try
            {
                var data = _httpClient.GetStringAsync(url).Result;

                return data;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public string ObtenerGanadorBuscador(List<Buscador> listaBusquedas, string buscador) {

            string textoGanador = string.Empty;
            int cantidadGanador = 0;

            try {

                foreach (var busqueda in listaBusquedas) {

                    if (busqueda.nombreBuscador == buscador && busqueda.cantidadResultados >= cantidadGanador) {
                        textoGanador = busqueda.textoABuscar;
                        cantidadGanador = busqueda.cantidadResultados;
                    }
                }

                return buscador + " Winner : " + textoGanador;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public string ObtenerGanadorGeneral(List<Buscador> listaBusquedas)
        {

            string textoGanador = string.Empty;
            int cantidadGanador = 0;

            try
            {

                foreach (var busqueda in listaBusquedas)
                {

                    if (busqueda.cantidadResultados >= cantidadGanador)
                    {
                        textoGanador = busqueda.textoABuscar;
                        cantidadGanador = busqueda.cantidadResultados;
                    }
                }

                return "Total Winner : " + textoGanador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
