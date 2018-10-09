using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Drawing;

namespace SimuladorInundaciones
{
    class DataSet
    {        
        #region atributos

        public int anchoEjeX;
        public int altoEjeY;
        public float dimensionCelda;      

        public RasterDatos DEM;                                 // hss DEM
        public RasterDatos profundidadSuelos;                  // Archivo de Profundidad de Suelos.
        public RasterDatos alturaSueloPermeable;               // hs1 Desde el suelo impermeable hasta la superficie.
        public RasterDatos kConductividadHSuelo;               // Conductividad Hidraulica Suelo. 
        public RasterDatos capacidadAlmacenSuelo;              // c1 Archivo del agua alamcenable por el suelo
        public RasterDatos aguaSuperficie;                      // zs Archivo del agua en superficie
        public RasterDatos aguaCapaPermeable;                    // z1 Archivo del agua en la capa de suelo 1

        public RasterDatos lluvia;                              //Lluvia caida en cada paso.

        public RasterDatos flujoEnXSuperficie;                   // Qssx 
        public RasterDatos flujoEnYSuperficie;                    // Qssy
        public RasterDatos flujoResultanteSuperficie;             // Qss

        public RasterDatos flujoEnXCapaPermeable;                    // Qs1x 
        public RasterDatos flujoEnYCapaPermeable;                    // Qs1y
        public RasterDatos flujoResultanteCapaPerm;             // Qs1

        public RasterDatos evaporacionEP;                 // Qep

        public int periodoGrabSalidas;                             //Ver de donde se obtiene esto
        public float coefManning;                   // Coeficiente de Manning N
        public float coefEvaporacion;                   // Coeficiente de Evaporacion.

        public RasterDatos matrizCantVariaciones;
        public RasterDatos matrizClusters;

        public int maxCantidadVariaciones;

        #endregion atributos

        #region otros atributos

        //Necesaria para cargar temporalmente la altura de agua en la capa 1
        RasterDatos auxiliarAguaCapaPermeable;

        //Necesarios para detectar oscilaciones 20110801
        int[][,] arrayOfMatrizFlowsEnX = new int[301][,];
        int[][,] arrayOfMatrizFlowsEnY = new int[301][,];       


        //FOR CLUSTERING
        
        List<List<Tuple<int, int>>> listOfClusters = new List<List<Tuple<int,int>>>();



        #endregion otros atributos

        public DataSet() 
        {

        }

        public DataSet(ConfParameters configurationSet) 
        {
            anchoEjeX = configurationSet.anchoEjeX;
            altoEjeY = configurationSet.altoEjeY;
            dimensionCelda = configurationSet.dimensionCelda;

            DEM = new RasterDatos(configurationSet.pathDEM, anchoEjeX, altoEjeY);
            profundidadSuelos = new RasterDatos(configurationSet.pathProfSuelos, anchoEjeX, altoEjeY);

            alturaSueloPermeable = new RasterDatos(anchoEjeX, altoEjeY);
            matrizCantVariaciones = new RasterDatos(anchoEjeX, altoEjeY);

            for (int y = 0; y < altoEjeY; y++)
            {
                for (int x = 0; x < anchoEjeX; x++)
                {
                    alturaSueloPermeable.matrizDEM_[y, x] = DEM.matrizDEM_[y, x] - profundidadSuelos.matrizDEM_[y, x];                    
                }
            }

            kConductividadHSuelo = new RasterDatos(configurationSet.pathKConductividadHSuelo, anchoEjeX, altoEjeY);
            capacidadAlmacenSuelo = new RasterDatos(configurationSet.pathCapacidadAlmacenSuelo, anchoEjeX, altoEjeY);
            aguaSuperficie = new RasterDatos(configurationSet.pathAguaSuperficial, anchoEjeX, altoEjeY);

            auxiliarAguaCapaPermeable = new RasterDatos(configurationSet.pathAguaCapaPermeable, anchoEjeX, altoEjeY);

            aguaCapaPermeable = new RasterDatos(anchoEjeX, altoEjeY);

            //Llamado antes Normalizacion Inicial, el agua que se lee del archivo es sin tener en cuenta la porosidad
            //del suelo.
            for (int x = 0; x < anchoEjeX; x++)
            {
                for (int y = 0; y < altoEjeY; y++)
                {
                    if (capacidadAlmacenSuelo.matrizDEM_[y, x] > 0)
                    {                        
                        aguaCapaPermeable.matrizDEM_[y, x] = auxiliarAguaCapaPermeable.matrizDEM_[y, x] / capacidadAlmacenSuelo.matrizDEM_[y, x] 
                                                            * (DEM.matrizDEM_[y, x] - alturaSueloPermeable.matrizDEM_[y, x]);
                    }
                    else
                    {
                        aguaCapaPermeable.matrizDEM_[y, x] = 0.0f;
                    }
                }
            }

            coefEvaporacion = (float)configurationSet.coefEvaporacion;
            coefManning = configurationSet.coefManning;
            periodoGrabSalidas = configurationSet.periodoGrabacionResult;
            maxCantidadVariaciones = configurationSet.maxCantidadVariaciones;
        } 
    }
}

