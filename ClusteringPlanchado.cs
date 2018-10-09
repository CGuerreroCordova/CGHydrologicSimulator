using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuladorInundaciones
{
    class ClusteringPlanchado
    {

        List<List<Tuple<int, int>>> listOfClusters = new List<List<Tuple<int, int>>>();
        int variacionesMax;

        public void ejecutarClusteringPlanchado(ref DataSet dataSetSimulador) 
        {
            variacionesMax = dataSetSimulador.maxCantidadVariaciones;
            clustering(ref dataSetSimulador);
            planchado(ref dataSetSimulador);            
        }


        void clustering(ref DataSet dataSetSimulador)
        {
            int numberClusterCreated = 0;
            dataSetSimulador.matrizClusters = new RasterDatos(dataSetSimulador.anchoEjeX, dataSetSimulador.altoEjeY);

            List<Tuple<int, int>> tempCluster = new List<Tuple<int, int>>();
            listOfClusters.Add(tempCluster);

            float numberClusterAssignedNew = 0;

            Tuple<int, int> tempParPixel;

            //recorrer toda la matriz de cantidad de variaciones
            for (int j = 0; j < dataSetSimulador.altoEjeY; j++)
            {
                for (int i = 0; i < dataSetSimulador.anchoEjeX; i++)
                {                   
                    numberClusterAssignedNew = 0;
                    //si el pixel tiene valor de cantidad de variaciones mayor que el definido
                    //debo determinar un valor de cluster al cual pertenece
                    if (dataSetSimulador.matrizCantVariaciones.matrizDEM_[j, i] > variacionesMax)
                    {
                        if (j > 257 && i > 282)
                        {
                            int g = 0;                 
                        }
                        //si ES un pixel del borde izquierdo superior, o sea que no tiene vecinos a los que se le haya podido asignar
                        //un cluster previamente
                        if (i == 0 && j == 0)
                        {   
                            numberClusterCreated++;

                            //Cuando se crea un nuevo indice de nuevo cluster se crea la nueva lista que almacenara
                            //los pares 
                            tempCluster = new List<Tuple<int, int>>();
                            listOfClusters.Add(tempCluster);

                            numberClusterAssignedNew = numberClusterCreated;
                        }
                        else
                        {
                            if (i != 0)
                            {
                                //si la matriz de asignacion de clusters tiene un cluster asignado para el vecino i-1, j
                                if (dataSetSimulador.matrizClusters.matrizDEM_[j, i - 1] != 0.0)
                                {
                                    //asignar ese cluster al nuevo pixel
                                    numberClusterAssignedNew = dataSetSimulador.matrizClusters.matrizDEM_[j, i - 1];
                                }
                                //si no tiene un cluster asignado para el vecino i-1, j
                                else
                                {
                                    if (j != 0)
                                    {
                                        if (dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i - 1] != 0.0)
                                        {
                                            //asignar ese cluster al nuevo pixel
                                            numberClusterAssignedNew = dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i - 1];
                                        }
                                    }
                                }
                            }
                            if (j != 0 && numberClusterAssignedNew == 0.0)
                            {
                                if (dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i] != 0.0)
                                {
                                    //asignar ese cluster al nuevo pixel
                                    numberClusterAssignedNew = dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i];
                                }
                                //si no tiene un cluster asignado para el vecino i + 1, j - 1
                                else
                                {
                                    if (dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i + 1] != 0.0)
                                    {
                                        //asignar ese cluster al nuevo pixel
                                        numberClusterAssignedNew = dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i + 1];
                                    }
                                }
                            }
                        }
                        //Si es el pixel superior izquierdo o no salio del ciclo por haber encontrado un vecino con cluster asignado
                        if (numberClusterAssignedNew == 0.0)
                        {
                            numberClusterCreated++;

                            tempCluster = new List<Tuple<int, int>>();
                            listOfClusters.Add(tempCluster);

                            numberClusterAssignedNew = numberClusterCreated;
                        }

                        //Cuando esta por asignar el nuevo cluster al cual pertenece el pixel tengo que ver si alguno de los
                        //otros vecinos tiene asignado un cluster diferente

                        bool different = false;
                        float differentValue = 0;

                        if (i != 0)
                        {
                            if (dataSetSimulador.matrizClusters.matrizDEM_[j, i - 1] != 0.0 &&
                                numberClusterAssignedNew != dataSetSimulador.matrizClusters.matrizDEM_[j, i - 1])
                            {
                                different = true;
                                differentValue = dataSetSimulador.matrizClusters.matrizDEM_[j, i - 1];
                            }

                            if (j != 0)
                            {
                                if (dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i - 1] != 0.0 &&
                                    numberClusterAssignedNew != dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i - 1])
                                {
                                    different = true;
                                    differentValue = dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i - 1];
                                }
                            }
                        }

                        if (j != 0)
                        {
                            if (dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i] != 0.0 &&
                                numberClusterAssignedNew != dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i])
                            {
                                different = true;
                                differentValue = dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i];
                            }
                            else if (i != dataSetSimulador.anchoEjeX - 1)
                            {
                                if (dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i + 1] != 0.0 &&
                                numberClusterAssignedNew != dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i + 1])
                                {
                                    different = true;
                                    differentValue = dataSetSimulador.matrizClusters.matrizDEM_[j - 1, i + 1];
                                }
                            }
                        }
                        if (different)
                        {
                            //Seteo en la matriz de clusters los valores correspondiente
                            for (int n = 0; n < listOfClusters[(int)differentValue].Count; n++)
                            {
                                dataSetSimulador.matrizClusters.matrizDEM_[listOfClusters[(int)differentValue][n].Item1,
                                                          listOfClusters[(int)differentValue][n].Item2] = numberClusterAssignedNew;
                            }

                            //Cambio los elementos de Cluster
                            int elementos = listOfClusters[(int)differentValue].Count;
                            for (int m = 0; m < elementos; m++)
                            {
                                listOfClusters[(int)numberClusterAssignedNew].Add(listOfClusters[(int)differentValue][m]);
                            }

                            listOfClusters[(int)differentValue].Clear();
                        }

                        different = false;

                        //Primero deberias crear el arreglo de clusters
                        tempParPixel = new Tuple<int, int>(j, i);

                        listOfClusters[(int)numberClusterAssignedNew].Add(tempParPixel);
                        //Estos es para poder visualizar el cluster, para desarrollo, puede ser omitido tal vez
                        dataSetSimulador.matrizClusters.matrizDEM_[j, i] = numberClusterAssignedNew;
                    }
                }
            }
        }

        void planchado(ref DataSet dataSetSimulador)
        {
            Tuple<int, int> tempParPixel;
            List<Tuple<int, int>> tempCluster;

            List<Tuple<double, Tuple<int, int>>> listAlturasDem = new List<Tuple<double, Tuple<int, int>>>();
            Tuple<double, Tuple<int, int>> tempAltura;
            double alturaDemTemp = 0.0f;

            //Altura media calculada en la que tiene que quedar el agua
            double media = 0.0;
            //agua total
            double aguaTotal = 0.0;
            //DEM total
            double DEMTotal = 0.0;
            //temporario de agua pixel
            double tempAguaPixel = 0.0;
            double tempDemPixel = 0.0;
            //Cantidad de pixeles en los que se divide el agua
            int pixelesN;

            List<float> verificacion = new List<float>();

            for (int g = 1; g < listOfClusters.Count; g++)
            {
                if (listOfClusters[g].Count != 0)
                {
                    tempCluster = listOfClusters[g];
                    pixelesN = tempCluster.Count;
                    //Se obtienen el agua
                    for (int h = 0; h < pixelesN; h++)
                    {
                        tempParPixel = tempCluster[h];
                        //Agua del pixel en cuestion
                        tempAguaPixel = dataSetSimulador.aguaSuperficie.matrizDEM_[tempParPixel.Item1, tempParPixel.Item2];
                        //Altura del pixel en cuestion
                        tempDemPixel = dataSetSimulador.DEM.matrizDEM_[tempParPixel.Item1, tempParPixel.Item2];
                        //AGUA TOTAL: Sumo el agua que corresponde al pixel total al total de agua
                        aguaTotal += tempAguaPixel;
                        //DEM TOTAL
                        DEMTotal += tempDemPixel;
                        //Se crea el nuevo elemento que contiene (altura de dem, pixeles)
                        tempAltura = new Tuple<double, Tuple<int, int>>(tempDemPixel, tempParPixel);
                        //Agrego 
                        listAlturasDem.Add(tempAltura);
                    }

                    listAlturasDem.Sort((a, b) => a.Item1.CompareTo(b.Item1));
                    listAlturasDem.Reverse();

                    //obtener la media
                    media = (aguaTotal + DEMTotal) / pixelesN;

                    //Sacar el elemento mas grande
                    alturaDemTemp = listAlturasDem[0].Item1;

                    //Elimino de la lista los elementos del dem que dieron por encima de la media
                    while (media < alturaDemTemp)
                    {
                        DEMTotal = DEMTotal - alturaDemTemp;
                        pixelesN = pixelesN - 1;
                        media = (aguaTotal + DEMTotal) / pixelesN;
                        //Sacarle el agua a los pixeles cuya altura del DEM supere
                        tempParPixel = listAlturasDem[0].Item2;
                        dataSetSimulador.aguaSuperficie.matrizDEM_[tempParPixel.Item1, tempParPixel.Item2] = 0.0f;
                        //Se lo saca de la lista y se toma el siguiente elemento
                        listAlturasDem.RemoveAt(0);
                        alturaDemTemp = listAlturasDem[0].Item1;

                    }
                    //Acá distribuir el agua en los pixeles los cuales el DEM dio por debajo de la media.
                    for (int i = 0; i < listAlturasDem.Count; i++)
                    {
                        tempAltura = listAlturasDem[i];
                        tempParPixel = tempAltura.Item2;
                        dataSetSimulador.aguaSuperficie.matrizDEM_[tempParPixel.Item1, tempParPixel.Item2] = (float)(media - tempAltura.Item1);
                        aguaTotal = aguaTotal - (media - tempAltura.Item1);
                    }
                    listAlturasDem.Clear();

                    aguaTotal = 0.0f;
                    DEMTotal = 0.0f;
                }
            }
            listOfClusters.Clear();
        }
    }
}
