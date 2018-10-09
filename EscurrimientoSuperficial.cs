using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SimuladorInundaciones
{
    class EscurrimientoSuperficial
    {
        float cotaInferior = 0.000001f;

        public void ejecutarEscurrimientoSuperficial(ref DataSet dataSetSimulador, float dts)
        {
            float tempValue;

            //Se hace una copia de los datos que seran leidos para procesar. Ya que no acepta valores por referencia.
            DataSet copyDataSetSimulador = dataSetSimulador;




            //Se generan datos 
            RasterDatos tempFlujoEnX = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);
            RasterDatos tempFlujoEnY = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            int anchoEjeX = dataSetSimulador.anchoEjeX;
            int altoEjeY = dataSetSimulador.altoEjeY;

            Parallel.Invoke(
                () =>
                {
                    tempFlujoEnX = escurrimientoSuperficialEnX(copyDataSetSimulador, dts, 0, anchoEjeX, 0, altoEjeY);
                },  // close first Action

                () =>
                {
                    tempFlujoEnY = escurrimientoSuperficialEnY(copyDataSetSimulador, dts, 0, anchoEjeX, 0, altoEjeY);
                } //close second Action

            ); //close parallel.invoke


            dataSetSimulador.flujoEnXSuperficie = tempFlujoEnX;
            dataSetSimulador.flujoEnYSuperficie = tempFlujoEnY;

            /*
            dataSetSimulador.flujoEnXSuperficie = escurrimientoSuperficialEnX(dataSetSimulador, dts);
            dataSetSimulador.flujoEnYSuperficie = escurrimientoSuperficialEnY(dataSetSimulador, dts);*/

            dataSetSimulador.flujoResultanteSuperficie = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            for (int x = 1; x < dataSetSimulador.anchoEjeX - 1; x++)
            {
                for (int y = 1; y < dataSetSimulador.altoEjeY - 1; y++)
                {

                    tempValue = (float)((dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x - 1] - dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x]
                                        + dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y - 1, x] - dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y, x]) / Math.Pow(dataSetSimulador.dimensionCelda, 2.0));

                    dataSetSimulador.flujoResultanteSuperficie.matrizDEM_[y, x] = tempValue;
                }
            }            

        }

        private RasterDatos escurrimientoSuperficialEnX(DataSet dataSetSimulador, float dts, int startEjeX, int endEjeX, int startEjeY, int endEjeY)
        {
            float Slope = 0.0f;
            float auxiliar1 = 0.0f;
            float CSArea = 0.0f;
            float WettedPerimeter = 0.0f;

            float aguaSupxy = 0.0f;
            float aguaSupx1y = 0.0f;

            float tempValue;

            //Se calculan los anchos y altos de las matrices.
            int anchoEjeX = endEjeX - startEjeX;
            int altoEjeY = endEjeY - startEjeY;

            //Se crea el Raster del tamaño adecuado.
            dataSetSimulador.flujoEnXSuperficie = new RasterDatos(anchoEjeX, altoEjeY);


            //Parallel.For(startEjeX, endEjeX - 1, delegate( int x )
            for (int x = startEjeX; x < endEjeX - 1; x++)
            {
                for (int y = startEjeY; y < endEjeY; y++)
                {
                    //Seteo el valor 0 a la casilla [x,y]
                    dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x] = 0.0f;
                    aguaSupxy = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x];
                    aguaSupx1y = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x + 1];

                    //Si hay agua superficial en alguna de las dos celdas, x o x+1
                    if (aguaSupxy > 0.0 || aguaSupx1y > 0.0)
                    {
                        //(Altura suelo + agua en x    - (menos)  Altura suelo + agua en x+1) dividido el otro cateto y obtengo la hipotenusa
                        // o pendiente o slope.
                        Slope = ((dataSetSimulador.DEM.matrizDEM_[y, x] + aguaSupxy) - (dataSetSimulador.DEM.matrizDEM_[y, x + 1] + aguaSupx1y)) / dataSetSimulador.dimensionCelda;

                        //Esto es, si la diferenca de agua entre las capaz es significativa.
                        //Se le pone el valor absoluto ya que no me importa que sentido sea la diferencia.
                        if (Math.Abs(Slope) >= cotaInferior)
                        {
                            //Se toma el promedio de las dos alturas.
                            auxiliar1 = (aguaSupxy + aguaSupx1y) / 2;
                            CSArea = auxiliar1 * dataSetSimulador.dimensionCelda;

                            WettedPerimeter = dataSetSimulador.dimensionCelda + 2 * auxiliar1;

                            //Calculo del flujo
                            tempValue = (float)(Math.Pow(CSArea, 5.0f / 3.0f) * Math.Pow(Math.Abs(Slope), 1.5f) / Slope / Math.Pow(WettedPerimeter, 2.0f / 3.0f) / dataSetSimulador.coefManning);

                            //Si el flujo es mayor que 0.
                            if (tempValue > 0.0)
                            {
                                if (aguaSupxy > cotaInferior)
                                {
                                    auxiliar1 = (float)(aguaSupxy / dts * Math.Pow(dataSetSimulador.dimensionCelda, 2.0f) / 4.0f);
                                    if (tempValue > auxiliar1)
                                    {
                                        dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x] = auxiliar1;
                                    }
                                    else
                                    {
                                        dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x] = tempValue;
                                    }
                                }
                            }

                            if (tempValue < 0.0)
                            {
                                //En esta parte implementar las mismas modificaciones que para el caso anterior
                                if (aguaSupx1y > cotaInferior)
                                {
                                    auxiliar1 = (float)(aguaSupx1y / dts * Math.Pow(dataSetSimulador.dimensionCelda, 2.0f) / 4.0f);
                                    if (-tempValue > auxiliar1)
                                    {
                                        dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x] = -auxiliar1;
                                    }
                                    else
                                    {
                                        dataSetSimulador.flujoEnXSuperficie.matrizDEM_[y, x] = tempValue;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            return dataSetSimulador.flujoEnXSuperficie;
        }

        private RasterDatos escurrimientoSuperficialEnY(DataSet dataSetSimulador, float dts, int startEjeX, int endEjeX, int startEjeY, int endEjeY)
        {
            float Slope = 0.0f;
            float auxiliar1 = 0.0f;
            float CSArea = 0.0f;
            float RadiusHydraulic = 0.0f;
            float tempValue;

            //Se calculan los anchos y altos de las matrices.
            int anchoEjeX = endEjeX - startEjeX;
            int altoEjeY = endEjeY - startEjeY;

            dataSetSimulador.flujoEnYSuperficie = new RasterDatos(anchoEjeX, altoEjeY);

            //Parallel.For(startEjeX, anchoEjeX, x =>
            for (int x = startEjeX; x < anchoEjeX; x++)
            {
                for (int y = startEjeY; y < altoEjeY - 1; y++)
                {
                    //Se va a armar una matriz de flujo de agua en X                    
                    dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y, x] = 0.0f;

                    //Si hay agua superficial en alguna de las dos celdas, y o y+1
                    if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] > 0.0 || dataSetSimulador.aguaSuperficie.matrizDEM_[y + 1, x] > 0.0)
                    {
                        //Diferencias de las altura del DEM del x + agua superficial - lo mismo de x + 1
                        Slope = ((dataSetSimulador.DEM.matrizDEM_[y, x] + dataSetSimulador.aguaSuperficie.matrizDEM_[y, x]) -
                            (dataSetSimulador.DEM.matrizDEM_[y + 1, x] + dataSetSimulador.aguaSuperficie.matrizDEM_[y + 1, x])) / dataSetSimulador.dimensionCelda;

                        //Esto es, si la diferenca de agua entre las capaz es significativa
                        if (Math.Abs(Slope) >= cotaInferior)
                        {
                            //MUCHAS DUDAS DE CORRESPONDENCIA CON LA FORMULA TEORICA 

                            auxiliar1 = (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] + dataSetSimulador.aguaSuperficie.matrizDEM_[y + 1, x]) / 2;
                            CSArea = auxiliar1 * dataSetSimulador.dimensionCelda;
                            RadiusHydraulic = dataSetSimulador.dimensionCelda + 2 * auxiliar1;
                            //Algo se entiende de la formula, porque hacerla de esta forma complicada lo del Slope?
                            tempValue = (float)(Math.Pow(CSArea, 5.0f / 3.0f) * Math.Pow(Math.Abs(Slope), 1.5f) / Slope / Math.Pow(RadiusHydraulic, 2.0f / 3.0f) / dataSetSimulador.coefManning);
                            //flujoEnY.setValue(tempValue,x,y); 

                            if (tempValue > 0.0)
                            {
                                //NO ENTIENDO QUE HACE ACA - DE QUE FORMULA SALE? Segun lo que haga aca se crea una matriz inicial con todo esto
                                //Para no recalcular para los dos flujos                                

                                //Supongo que <= seria casi igual que < varia mas abajo
                                //Esta condicion no se va a cumplir nunca pues si el flujo de agua es positivo significa que el agua inicial
                                //en X es mayor que el agua inicial en X+1 por lo que no puede haber entrado al ciclo pasando las dos condiciones
                                //sobre la cota inferior, el cambio se ve en Modificacion 2.
                                if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] > cotaInferior)
                                {

                                    auxiliar1 = (float)(dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] / dts
                                        * Math.Pow(dataSetSimulador.dimensionCelda, 2.0f) / 4.0f);
                                    if (tempValue > auxiliar1)
                                    {
                                        dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y, x] = auxiliar1;
                                    }
                                    else
                                    {
                                        dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y, x] = tempValue;
                                    }
                                }
                            }

                            if (tempValue < 0.0)
                            {
                                if (dataSetSimulador.aguaSuperficie.matrizDEM_[y + 1, x] > cotaInferior)
                                {
                                    auxiliar1 = (float)(dataSetSimulador.aguaSuperficie.matrizDEM_[y + 1, x] / dts * Math.Pow(dataSetSimulador.dimensionCelda, 2.0f) / 4.0f);
                                    if (-tempValue > auxiliar1)
                                    {
                                        dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y, x] = -auxiliar1;
                                    }
                                    else
                                    {
                                        dataSetSimulador.flujoEnYSuperficie.matrizDEM_[y, x] = tempValue;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return dataSetSimulador.flujoEnYSuperficie;
        }
    }
}