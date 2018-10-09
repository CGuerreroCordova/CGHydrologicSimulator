using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimuladorInundaciones
{
    class InfiltracionVertical
    {
        public void ejecutarInfiltracionVertical(ref DataSet dataSetSimulador)
        {
            //Para cada punto de la cuadricula
            for (int x = 0; x < dataSetSimulador.anchoEjeX; x++)
            {
                for (int y = 0; y < dataSetSimulador.altoEjeY; y++)
                {
                    float alturaEquivCapa1 = 0.0f;
                    float alturaLibreCapa1 = 0.0f;
                    float aguaCabeCapa1 = 0.0f;

                    float maxFluxSupCapa1 = 0.0f;

                    float auxiliar2 = 0.0f;

                    //Si hay agua en la superficie y hay lugar para agua en la capa 1
                    if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] > 0 &&
                        dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] < dataSetSimulador.profundidadSuelos.matrizDEM_[y, x])
                    {
                        //Calculo la maxima agua que puede pasar de la superficia a la capa 1
                        maxFluxSupCapa1 = 2 * dataSetSimulador.kConductividadHSuelo.matrizDEM_[y, x];

                        //Guardo la altura libre de agua que hay en la capa 1
                        alturaLibreCapa1 = dataSetSimulador.profundidadSuelos.matrizDEM_[y, x] - dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x];

                        auxiliar2 = alturaLibreCapa1;
                        aguaCabeCapa1 = alturaLibreCapa1 * dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x] / dataSetSimulador.profundidadSuelos.matrizDEM_[y, x];

                        if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] <= maxFluxSupCapa1)
                        {
                            //Si el agua en superficie es menor que el maximo que se le puede sacar y ese maximo es menor que la que cantidad que cabe en la capa 1
                            if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] < aguaCabeCapa1)
                            {
                                //Altura equivalente en capa 1
                                alturaEquivCapa1 = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] *
                                    dataSetSimulador.profundidadSuelos.matrizDEM_[y, x] / dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x];

                                auxiliar2 = alturaEquivCapa1;

                                //Agua en superficie
                                aguaCabeCapa1 = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x];
                            }

                            //El agua en superficie se actualiza con lo que sale                        
                            dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] - aguaCabeCapa1; ;
                            //El agua en la capa 1 se actualiza con lo que le entra                        
                            dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] + auxiliar2;
                        }
                        else
                        {
                            if (maxFluxSupCapa1 < aguaCabeCapa1)
                            {
                                //Altura equivalente en capa 1
                                alturaEquivCapa1 = maxFluxSupCapa1 * dataSetSimulador.profundidadSuelos.matrizDEM_[y, x] / dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x];

                                auxiliar2 = alturaEquivCapa1;

                                //Agua en superficie
                                aguaCabeCapa1 = maxFluxSupCapa1;
                            }

                            //El agua en superficie se actualiza con lo que sale                        
                            dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] - aguaCabeCapa1; ;
                            //El agua en la capa 1 se actualiza con lo que le entra                        
                            dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] + auxiliar2;
                        }
                    }
                }
            }
        }        
    }
}
