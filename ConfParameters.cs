using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuladorInundaciones
{
    public class ConfParameters
    {
        #region Atributos

        public string carpetaDatosEntrada;
        public string pathProfSuelos;
        public string pathDEM;
        public string pathKConductividadHSuelo;
        public string pathCapacidadAlmacenSuelo;
        public string pathAguaSuperficial;
        public string pathAguaCapaPermeable;
        public string pathLluvia;
        public float coefManning;
        public double coefEvaporacion;
        public int escSupPasosNts;
        public int tiempoSimulacionHoras;
        public int periodoGrabacionResult;
        public string carpetaResultados;
        public string carpetaArchivoLog;
        public int maxCantidadVariaciones;

        public int anchoEjeX;
        public int altoEjeY;
        public float dimensionCelda;

        public bool debugEnablePlanchado;

        public bool nohacerPlanchado;
        public bool imprimitMatrizClusters;
        
        #endregion Atributos

        public ConfParameters()
        {
            carpetaDatosEntrada = System.Configuration.ConfigurationManager.AppSettings["carpetaDatosEntrada"];

            pathProfSuelos = carpetaDatosEntrada + "\\" + System.Configuration.ConfigurationManager.AppSettings["profundidadCapaPermeable"];
            pathDEM = carpetaDatosEntrada + "\\" + System.Configuration.ConfigurationManager.AppSettings["DEM"];
            pathKConductividadHSuelo = carpetaDatosEntrada + "\\" + System.Configuration.ConfigurationManager.AppSettings["kConductividadHSuelo"];
            pathCapacidadAlmacenSuelo = carpetaDatosEntrada + "\\" + System.Configuration.ConfigurationManager.AppSettings["capacidadAlmacenSuelo"];
            pathAguaSuperficial = carpetaDatosEntrada + "\\" + System.Configuration.ConfigurationManager.AppSettings["aguaSuperfEntradaDefault"];
            pathAguaCapaPermeable = carpetaDatosEntrada + "\\" + System.Configuration.ConfigurationManager.AppSettings["aguaCapa1EntradaDefault"];
            pathLluvia = System.Configuration.ConfigurationManager.AppSettings["lluvia"];
            coefManning = float.Parse(System.Configuration.ConfigurationManager.AppSettings["coefManning"]);
            coefEvaporacion = double.Parse(System.Configuration.ConfigurationManager.AppSettings["coefEvaporacion"]);
            escSupPasosNts = int.Parse(System.Configuration.ConfigurationManager.AppSettings["maxEscSupPasosNts"]);
            tiempoSimulacionHoras = int.Parse(System.Configuration.ConfigurationManager.AppSettings["tiempoSimulacionHoras"]);
            periodoGrabacionResult = int.Parse(System.Configuration.ConfigurationManager.AppSettings["periodoGrabacionResult"]);
            carpetaResultados = System.Configuration.ConfigurationManager.AppSettings["carpetaResultados"];
            carpetaArchivoLog = System.Configuration.ConfigurationManager.AppSettings["carpetaArchivoLog"];

            anchoEjeX = int.Parse(System.Configuration.ConfigurationManager.AppSettings["anchoEjeX"]);
            altoEjeY = int.Parse(System.Configuration.ConfigurationManager.AppSettings["altoEjeY"]);
            dimensionCelda = float.Parse(System.Configuration.ConfigurationManager.AppSettings["dimensionCelda"]);
            maxCantidadVariaciones = int.Parse(System.Configuration.ConfigurationManager.AppSettings["maxCantidadVariaciones"]);

            debugEnablePlanchado = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["debugPlanchadoOption"]);

        }
    }
}
