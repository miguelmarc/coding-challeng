using System;
using Challenge.Searchfigt.Entidades;
using Challenge.Searchfigt.Logica;
using Challenge.Searchfigt.ServiciosBuscador;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Searchfigt
{
    class Program
    {
        static void Main(string[] args)
        {
            Buscador buscador;
            BuscadorLogica logica;
            GoogleBuscador googleBuscador = new GoogleBuscador();
            BingBuscador bingBuscador = new BingBuscador();
            string busqueda = string.Empty;
            List<string> listaPalabras = new List<string>();
            List<Buscador> listaBusquedas = new List<Buscador>();

            try
            {
                Console.WriteLine("Escriba una lista de palabrasa buscar: ");
                string palabras = Console.ReadLine();
                listaPalabras = ObtenerTextos(palabras);

                foreach (var palabra in listaPalabras)
                {

                    buscador = new Buscador();
                    logica = new BuscadorLogica(1);

                    busqueda = string.Empty;

                    buscador.nombreBuscador = "GOOGLE";
                    buscador.textoABuscar = palabra;
                    buscador.urlBuscador = googleBuscador.ObtenerUrl(buscador.textoABuscar);
                    buscador.campoInicioResultado = googleBuscador.ObtenerCampoInicioResultado();
                    buscador.campoFinResultado = googleBuscador.ObtenerCampoFinResultado();
                    buscador.cantidadResultados = logica.BuscarResultados(buscador);

                    listaBusquedas.Add(buscador);
                    busqueda += palabra + " : " + buscador.nombreBuscador + " : " + buscador.cantidadResultados.ToString() + ", ";

                    buscador = new Buscador();
                    logica = new BuscadorLogica(1);

                    buscador.nombreBuscador = "BING";
                    buscador.textoABuscar = palabra;
                    buscador.urlBuscador = bingBuscador.ObtenerUrl(buscador.textoABuscar);
                    buscador.campoInicioResultado = bingBuscador.ObtenerCampoInicioResultado();
                    buscador.campoFinResultado = bingBuscador.ObtenerCampoFinResultado();
                    buscador.keyBuscador = bingBuscador.ObtenerKey();
                    buscador.header = bingBuscador.ObtenerHeader();
                    logica.AgregarHeader(buscador.header, buscador.keyBuscador);
                    buscador.cantidadResultados = logica.BuscarResultados(buscador);

                    listaBusquedas.Add(buscador);
                    busqueda += buscador.nombreBuscador + " : " + buscador.cantidadResultados.ToString();

                    Console.WriteLine(busqueda);

                }

                logica = new BuscadorLogica(0);

                Console.WriteLine(logica.ObtenerGanadorBuscador(listaBusquedas, "GOOGLE"));
                Console.WriteLine(logica.ObtenerGanadorBuscador(listaBusquedas, "BING"));
                Console.WriteLine(logica.ObtenerGanadorGeneral(listaBusquedas));

            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }

        }

        public static List<string> ObtenerTextos(string palabras) {

            List<string> listaPalabras = new List<string>();
            string palabraTemp = string.Empty;
            bool indicadorComillas = false;
            int i = 0;

            try
            {               
                while(i<palabras.Length){

                    palabraTemp = "";

                    if (palabras[i] != '"')
                    {
                        while (palabras[i] != ' ') {
                            palabraTemp += palabras[i];
                            i++;

                            if (i == palabras.Length)
                                break;
                                
                        }
                        i++;

                        if(palabraTemp != "")
                            listaPalabras.Add(palabraTemp.Trim());
                    }
                    else if (palabras[i] == '"' && indicadorComillas == false)
                    {
                        i++;
                        while (palabras[i] != '"')
                        {
                            palabraTemp += palabras[i];
                            i++;

                            if (i == palabras.Length)
                                break;
                        }
                        i++;

                        if(palabraTemp != "")
                            listaPalabras.Add(palabraTemp.Trim());
                    }
                }              

                return listaPalabras;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
