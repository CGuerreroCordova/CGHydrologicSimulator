using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuladorInundaciones
{
    class Evapotranspiracion
    {
        public void ejecutarEvapotranspiracion(ref DataSet dataSetSimulador) 
        {

            dataSetSimulador.evaporacionEP = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            for (int x = 0; x < dataSetSimulador.anchoEjeX; x++)
            {
                for (int y = 0; y < dataSetSimulador.altoEjeY; y++)
                {
                    //Si hay agua superficial
                    if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] > 0.0)
                    {
                        //La evaporacion en ese punto se correspondera con el coeficiente de evaporacion.
                        //evaporacionEP.setValue(EP,x,y);
                        dataSetSimulador.evaporacionEP.matrizDEM_[y, x] = dataSetSimulador.coefEvaporacion;
                    }
                    //Si no hay agua superficial y la profundidad del suelo en ese punto no es nula
                    else if (dataSetSimulador.profundidadSuelos.matrizDEM_[y, x] > 0.0)
                    {
                        //La evaporacion en ese punto se traduce en:
                        dataSetSimulador.evaporacionEP.matrizDEM_[y, x] = dataSetSimulador.coefEvaporacion * 
                               (dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] / dataSetSimulador.profundidadSuelos.matrizDEM_[y, x]);
                        //Que se corresponde con la formula extraida del doc referente a Wolski y Overton.
                        //Si no hay agua en la capa 1 la evaporacion queda en 0.
                    }
                }
            }

        }

    }
}
