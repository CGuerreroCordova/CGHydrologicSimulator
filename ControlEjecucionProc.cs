using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SimuladorInundaciones
{
    class ControlEjecucionProc
    {

        #region Atributos

        ConfParameters parametrosSimulador;
        DataSet dataSetSimulador;
        InfiltracionVertical infiltradorVertical;
        EscurrimientoSuperficial escurridorSuperficial;
        ClusteringPlanchado clusterizadorPlanchador;
        Evapotranspiracion evaporador;
        InfiltracionHorizontal infiltradorHorizontal;

        float cotaInferior = 0.000001f;

        int escSupPasosNts;

        #endregion Atributos

        int[][,] arrayOfMatrizFlowsEnX;
        int[][,] arrayOfMatrizFlowsEnY;
        int diaEejecucion = 1;
        GUIModelEjecForm formPadre;


        public ControlEjecucionProc(ConfParameters parametrosSimulacion, GUIModelEjecForm formEjec)
        {

            formPadre = formEjec;
            parametrosSimulador = parametrosSimulacion;
            dataSetSimulador = new DataSet(parametrosSimulacion);
            arrayOfMatrizFlowsEnX = new int[parametrosSimulador.escSupPasosNts + 1][,];
            arrayOfMatrizFlowsEnY = new int[parametrosSimulador.escSupPasosNts + 1][,];            
            infiltradorVertical = new InfiltracionVertical();
            escurridorSuperficial = new EscurrimientoSuperficial();
            clusterizadorPlanchador = new ClusteringPlanchado();
            evaporador = new Evapotranspiracion();
            infiltradorHorizontal = new InfiltracionHorizontal();
        }

        public void ejecucionSimulacion()
        {
            infiltradorVertical.ejecutarInfiltracionVertical(ref dataSetSimulador);            

            int NT = parametrosSimulador.tiempoSimulacionHoras;
            int Nts = parametrosSimulador.escSupPasosNts;
            float dts;
            float dt0 = 1.0f;

            logEvents("Comienzo de Simulacion");

            //To register execution time of tasks.
            Stopwatch stopWatch = new Stopwatch();

            for (int t = 1; t <= NT; t++) 
            {
                stopWatch.Start();

                logEvents("\n");
                logEvents(t.ToString() + " horas de simulación.");

                //Actualiza el paso de ejecucion t en el formulario.
                formPadre.Invoke(formPadre.delegadoStep, new Object[] { t.ToString() });
                asignarLluviaASuperficie(t);

                if (Nts > 1)
                {
                    dts = dt0 / Nts * 3600;
                }
                else 
                {
                    dts = dt0 * 3600;
                    Nts = 1;
                }

                //dataSetSimulador.aguaSuperficie.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\AguaSuperficie_Prueba_orig_antes.agu");

                //Se pasa como ref para que guarde todos los cambios en el conjunto de datos
                escurridorSuperficial.ejecutarEscurrimientoSuperficial(ref dataSetSimulador, dts);

                //dataSetSimulador.flujoResultanteSuperficie.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\FlujoResultante_Superficie_New.agu");

                //dataSetSimulador.flujoEnXSuperficie.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\FlujoX_Superficie_New.agu");
                //dataSetSimulador.flujoEnYSuperficie.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\FlujoY_Superficie_New.agu");

                Nts = calcPasosEscSupNts(dts, dt0);                

                for (int ts = 1; ts <= Nts; ts++)
                {
                    asignarAlturasAgua(dts);
                    escurridorSuperficial.ejecutarEscurrimientoSuperficial(ref dataSetSimulador, dts);                                        
                    crearMatrizFlujos(ts - 1, dataSetSimulador.flujoResultanteSuperficie.anchoEjeX_, dataSetSimulador.flujoResultanteSuperficie.altoEjeY_);
                }

                if (!parametrosSimulador.nohacerPlanchado)
                {
                    // dataSetSimulador.matrizCantVariaciones.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\Variaciones_" + diaEejecucion.ToString() + ".var");
                    clusterizadorPlanchador.ejecutarClusteringPlanchado(ref dataSetSimulador);
                    // dataSetSimulador.matrizClusters.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\Clusters_" + diaEejecucion.ToString() + ".clu");                    
                }
                evaporador.ejecutarEvapotranspiracion(ref dataSetSimulador);
                infiltradorHorizontal.ejecutarInfiltracionHorizontal(ref dataSetSimulador);                
                recalculoVariables(dt0);                
                infiltradorVertical.ejecutarInfiltracionVertical(ref dataSetSimulador);                
                escribirResultado(t);

                //Finish of watching execution time.
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan tst = stopWatch.Elapsed;
                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    tst.Hours, tst.Minutes, tst.Seconds,
                    tst.Milliseconds / 10);

                logEvents("RunTime: " + elapsedTime);
            }           
        }

        //Para cada celda suma el valor de lluvia del nuevo archivo al del agua superficial.
        private void asignarLluviaASuperficie(int pasoEjecucion) 
        {
            if (File.Exists(parametrosSimulador.pathLluvia + @"\lluvia_" + pasoEjecucion.ToString() + ".agu"))
            {
                dataSetSimulador.lluvia = new RasterDatos(parametrosSimulador.pathLluvia + @"\lluvia_" + pasoEjecucion.ToString() + ".agu",
                                            dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

                for (int x = 1; x < dataSetSimulador.anchoEjeX - 1; x++)
                {
                    for (int y = 1; y < dataSetSimulador.altoEjeY - 1; y++)
                    {
                        dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] += dataSetSimulador.lluvia.matrizDEM_[y, x];
                    }
                }
            }
        }

        
        private void asignarAlturasAgua(float dts)
        {
            for (int x = 1; x < dataSetSimulador.anchoEjeX - 1; x++)
            {
                for (int y = 1; y < dataSetSimulador.altoEjeY - 1; y++)
                {
                    dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x]
                                                                + dataSetSimulador.flujoResultanteSuperficie.matrizDEM_[y, x] * dts;

                    //Necesariamente Hay Que Asignarle 0 Si Es Menor Que La Cota Inferior. Justificar.
                    if (Math.Abs(dataSetSimulador.aguaSuperficie.matrizDEM_[y, x]) < cotaInferior)
                    {
                        dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = 0.0f;
                    }

                    try
                    {
                        if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] < 0.0)
                        {
                            dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = 0.0f;
                            //RESOLVER *** Ver bien como resolver esto
                            //throw new Exception("Error En Calculos: Agua Superficial final no puede ser menor que 0");
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        private int calcPasosEscSupNts(float dts, float dt0)
        {
            float maxFlow = 0.0f;
            float aux = 0.0f;

            int xAux = 0;
            int yAux = 0;

            int Nts = 0;

            for (int x = 3; x < dataSetSimulador.anchoEjeX - 3; x++)
            {
                for (int y = 3; y < dataSetSimulador.altoEjeY - 3; y++)
                {
                    aux = Math.Abs(dataSetSimulador.flujoResultanteSuperficie.matrizDEM_[y, x]);

                    if (aux > maxFlow)
                    {
                        maxFlow = aux;
                        xAux = x;
                        yAux = y;
                    }
                }
            }
            
            Nts = (int)(3600.0 * dt0 / (0.1 / maxFlow));   //variacion de un 10% por paso. El 3600 es para pasar de s a h

            logEvents("Máximo flujo de escurrimiento superficial del último paso: Celda [" + xAux + ", " + yAux + "] = " + maxFlow );
            logEvents("Cantidad de pasos calculados para escurrimiento superficial. Nts = " + Nts.ToString());            

            if (Nts > parametrosSimulador.escSupPasosNts)
            {
                Nts = parametrosSimulador.escSupPasosNts;
                logEvents("La cantidad de pasos de escurrimiento superficial esta limitada a " + Nts.ToString() + " =>  Nts = " + Nts.ToString());
            }

            return Nts;
        }

        private void recalculoVariables(float dt0)
        {            
            float auxiliar = 0.0f;
            float tempValue;

            for (int x = 0; x < dataSetSimulador.anchoEjeX; x++)
            {
                for (int y = 0; y < dataSetSimulador.altoEjeY; y++)
                {
                    //Este Bloque Debe Quedar
                    if (dataSetSimulador.evaporacionEP.matrizDEM_[y, x] <= 0.0)
                    {
                        tempValue = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] + dataSetSimulador.evaporacionEP.matrizDEM_[y, x] * dt0;
                        dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = tempValue;
                        auxiliar = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x];

                        if (auxiliar < 0.0)
                        {
                            dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = 0.0f;
                            tempValue = dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] + auxiliar;
                            dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = tempValue;

                            if (dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] < 0.0)
                            {
                                dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = 0.0f;
                            }
                        }
                    }

                    auxiliar = 0.0f;

                    if (Math.Abs(dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x]) >= Math.Abs(dataSetSimulador.coefEvaporacion / 10.0))
                    {
                        auxiliar = (float)(dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] / (dataSetSimulador.coefEvaporacion / 10.0));
                        tempValue = (float)(dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] + auxiliar * (dataSetSimulador.coefEvaporacion / 10.0) * dt0);
                        dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = tempValue;

                        if (dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] > 0.0)
                        {
                            tempValue = (float)(dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] + auxiliar * Math.Abs(dataSetSimulador.coefEvaporacion / 10.0));
                            dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] = tempValue;
                        }
                        else
                        {
                            tempValue = (float)(dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] + auxiliar * Math.Abs(dataSetSimulador.coefEvaporacion / 10.0));
                            dataSetSimulador.flujoResultanteCapaPerm.matrizDEM_[y, x] = tempValue;
                        }

                        tempValue = dataSetSimulador.profundidadSuelos.matrizDEM_[y, x];
                        auxiliar = dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] - dataSetSimulador.profundidadSuelos.matrizDEM_[y, x];

                        if (auxiliar > 0.0) 
                        {
                            dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = tempValue;
                            tempValue = dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] + auxiliar * dataSetSimulador.capacidadAlmacenSuelo.matrizDEM_[y, x] / dataSetSimulador.profundidadSuelos.matrizDEM_[y, x];
                            dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = tempValue;
                        }                        
                        
                        //Porque poner una cota superior para la cantidad de agua en la capa Superficial?? 10.0
                        //RESOLVER ****
                        /*
                        if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] < 0.0 || dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] < 0.0 || dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] > 10.0)
                        {
                            throw new Exception("Error en calculo de variables");
                        }*/
                        if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] < 0.0) 
                        {
                            dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] = 0.0f;
                        }
                        else if (dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] < 0.0) 
                        {
                            dataSetSimulador.aguaCapaPermeable.matrizDEM_[y, x] = 0.0f;
                        }
                        else if (dataSetSimulador.aguaSuperficie.matrizDEM_[y, x] > 50.0) 
                        {
                            var result = MessageBox.Show("El agua en superficie para la celda: [" + x.ToString() + "," + y.ToString() + "] excede los 50 mts de altura. Presione \" Cancelar Simulación\" en el cuadro de ejecución para Abortar", "Simulador Hidrológico", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                    }
                }
            }
        }
            
        private void crearMatrizFlujos(int posicion, int ejeX, int ejeY)
        {
            //Se crean dos matrices diferentes para el guardado de los +1, -1 segun el signo de variacion
            //una para el eje x, otra para el eje y
            int[,] newMatrizFlujosEnX = new int[ejeY, ejeX];
            int[,] newMatrizFlujosEnY = new int[ejeY, ejeX];

            for (int i = 0; i < ejeX - 1; i++)
            {
                for (int j = 0; j < ejeY; j++)
                {
                    if (dataSetSimulador.flujoEnXSuperficie.matrizDEM_[j, i] > 0.01f)
                    {
                        newMatrizFlujosEnX[j, i] = 1;
                    }
                    else if (dataSetSimulador.flujoEnXSuperficie.matrizDEM_[j, i] < 0.01f)
                    {
                        newMatrizFlujosEnX[j, i] = -1;
                    }
                }
            }
            for (int i = 0; i < ejeX; i++)
            {
                for (int j = 0; j < ejeY - 1; j++)
                {
                    if (dataSetSimulador.flujoEnYSuperficie.matrizDEM_[j, i] > 0.01f)
                    {
                        newMatrizFlujosEnY[j, i] = 1;
                    }
                    else if (dataSetSimulador.flujoEnYSuperficie.matrizDEM_[j, i] < 0.01f)
                    {
                        newMatrizFlujosEnY[j, i] = -1;
                    }
                }
            }

            arrayOfMatrizFlowsEnX[posicion] = newMatrizFlujosEnX;
            arrayOfMatrizFlowsEnY[posicion] = newMatrizFlujosEnY;

            if (posicion == 0)
            {
                for (int i = 0; i < ejeX; i++)
                {
                    for (int j = 0; j < ejeY; j++)
                    {
                        dataSetSimulador.matrizCantVariaciones.matrizDEM_[j, i] = 0.0f;
                    }
                }

            }
            else if (posicion > 0)
            {
                if (posicion > 1)
                {
                    arrayOfMatrizFlowsEnX[posicion - 2] = null;
                    arrayOfMatrizFlowsEnY[posicion - 2] = null;
                }
                for (int i = 0; i < ejeX - 1; i++)
                {
                    for (int j = 0; j < ejeY; j++)
                    {
                        if ((arrayOfMatrizFlowsEnX[posicion][j, i] > 0 && arrayOfMatrizFlowsEnX[posicion - 1][j, i] < 0)
                            || (arrayOfMatrizFlowsEnX[posicion][j, i] < 0 && arrayOfMatrizFlowsEnX[posicion - 1][j, i] > 0))
                        {
                            dataSetSimulador.matrizCantVariaciones.matrizDEM_[j, i]++;
                            dataSetSimulador.matrizCantVariaciones.matrizDEM_[j, i + 1]++;
                        }

                        if ((arrayOfMatrizFlowsEnY[posicion][j, i] > 0 && arrayOfMatrizFlowsEnY[posicion - 1][j, i] < 0)
                            || (arrayOfMatrizFlowsEnY[posicion][j, i] < 0 && arrayOfMatrizFlowsEnY[posicion - 1][j, i] > 0))
                        {
                            dataSetSimulador.matrizCantVariaciones.matrizDEM_[j, i]++;
                            dataSetSimulador.matrizCantVariaciones.matrizDEM_[j + 1, i]++;
                        }

                    }
                }
            }

        }
        
        private void escribirResultado(int t)
        {           

            if ((t % parametrosSimulador.periodoGrabacionResult) == 0)
            {                              
                dataSetSimulador.aguaSuperficie.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\AguaSuperficie_" + diaEejecucion.ToString() + ".agu");

                //dataSetSimulador.aguaCapaPermeable.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\AguaCapaPermeable_" + diaEejecucion.ToString() + ".agu");


                if (parametrosSimulador.imprimitMatrizClusters)
                {
                    dataSetSimulador.matrizClusters.writeDataMatrix(parametrosSimulador.carpetaResultados + @"\MatrizClusters_" + diaEejecucion.ToString() + ".clu");
                }
                //logEvents("Escritura de estado de agua para el paso " + t.ToString() + ". " + parametrosSimulador.carpetaResultados + @"\AguaSuperficie_" + diaEejecucion.ToString() + ".agu\t" + 
                //    parametrosSimulador.carpetaResultados + @"\AguaCapaPermeable_" + diaEejecucion.ToString() + ".agu");

                diaEejecucion++;
            }
        }

        private void logEvents(string msg)
        {

            System.IO.StreamWriter sw = System.IO.File.AppendText(parametrosSimulador.carpetaArchivoLog +  "\\" + "SimuladorHidrologico.log");
            try
            {
                string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
                formPadre.Invoke(formPadre.delegadoLog, new Object[] { logLine });

            }
            finally
            {
                sw.Close();
            }
        }
    }   
}
