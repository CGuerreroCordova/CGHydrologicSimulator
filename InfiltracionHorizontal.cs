using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuladorInundaciones
{
    class InfiltracionHorizontal
    {
        public void ejecutarInfiltracionHorizontal(ref DataSet dataSetSimulador)         
        {
            float tempValue;

            dataSetSimulador.flujoResultanteCapaPerm = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            infiltracionHorizontalEnX(ref dataSetSimulador);

            infiltracionHorizontalEnY(ref dataSetSimulador);

            for (int x = 1; x < dataSetSimulador.anchoEjeX - 1; x++)
            {
                for (int y = 1; y < dataSetSimulador.altoEjeY - 1; y++)
                {
                    tempValue = (float)(dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] +
                                                    (dataSetSimulador.flujoEnXCapaPermeable.matrizDEM_[y, x - 1] - dataSetSimulador.flujoEnXCapaPermeable.matrizDEM_[y, x] +
                                                     dataSetSimulador.flujoEnYCapaPermeable.matrizDEM_[y - 1, x] - dataSetSimulador.flujoEnYCapaPermeable.matrizDEM_[y, x]) / Math.Pow(dataSetSimulador.dimensionCelda, 2.0));
                    dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] = tempValue;                    
                }
            }

        }

        private void infiltracionHorizontalEnX(ref DataSet dataSetSimulador)
        {
            float tempValue;

            dataSetSimulador.flujoEnXCapaPermeable = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            for (int x = 0; x < dataSetSimulador.anchoEjeX - 1; x++)
            {
                for (int y = 0; y < dataSetSimulador.altoEjeY; y++)
                {
                    //Si hay agua en el punto (x,y) o en el punto (x+1,y) y la capacidad de almacenamiento del suelo
                    //es mayor que cero en ambos puntos
                    if ((dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] > 0.0 || dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x + 1] > 0.0) &&
                        dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x] > 0.0 && dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x + 1] > 0.0)
                    {
                        tempValue = (float)((dataSetSimulador.kConductividadHSuelo.matrizDEM_[y, x] + dataSetSimulador.kConductividadHSuelo.matrizDEM_[y, x + 1]) / 2.0 *
                                                        ((dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x + 1] - dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x]) +
                                                         (dataSetSimulador.alturaSueloPermeable.matrizDEM_[y, x + 1] - dataSetSimulador.alturaSueloPermeable.matrizDEM_[y, x])) *
                                                        (dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x + 1] + dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x]) / 2.0);
                        dataSetSimulador.flujoEnXCapaPermeable.matrizDEM_[y, x] = tempValue;                        
                    }
                }
            }
        }

        private void infiltracionHorizontalEnY(ref DataSet dataSetSimulador)
        {
            float tempValue;
            dataSetSimulador.flujoEnYCapaPermeable = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            for (int x = 0; x < dataSetSimulador.anchoEjeX; x++)
            {
                for (int y = 0; y < dataSetSimulador.altoEjeY - 1; y++)
                {
                    //Si hay agua en el punto (x,y) o en el punto (x+1,y) y la capacidad de almacenamiento del suelo
                    //es mayor que cero en ambos puntos
                    if ((dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] > 0.0 || dataSetSimulador.aguaCapaPermeable.matrizDEM_[y + 1, x] > 0.0) &&
                        dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x] > 0.0 && dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y + 1, x] > 0.0)
                    {
                        //No coincide con la formula??? O como se explica esto??? Grafica en papel.
                        tempValue = (dataSetSimulador.kConductividadHSuelo.matrizDEM_[y, x] + dataSetSimulador.kConductividadHSuelo.matrizDEM_[y + 1, x]) / 2.0f *
                                                        ((dataSetSimulador.aguaCapaPermeable.matrizDEM_[y + 1, x] - dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x]) +
                                                         (dataSetSimulador.alturaSueloPermeable.matrizDEM_[y + 1, x] - dataSetSimulador.alturaSueloPermeable.matrizDEM_[y, x])) *
                                                        (dataSetSimulador.aguaCapaPermeable.matrizDEM_[y + 1, x] + dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x]) / 2.0f;
                        dataSetSimulador.flujoEnYCapaPermeable.matrizDEM_[y, x] = tempValue;                        
                    }
                }
            }

        }


    }
}
