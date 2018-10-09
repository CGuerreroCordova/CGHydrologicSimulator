using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SimuladorInundaciones
{
    public partial class Form1 : Form
    {        

        Data dataSetSimulador, dataSetSimulador2;
        DateTime tiempo1;
        DateTime tiempo2;

        DateTime tiempo3;
        DateTime tiempo4;

        TimeSpan total;

        int NT = 1440; //1440;
        int Nts = 300;  //Cantidad de pasos de ejecucion de escurrimiento superficial por cada paso 
        float dts = 0.0f;
        float dt0 = 1.0f;


        string outputFiles;
        string inputFiles;
        string aguaSuperfEntradaDefault;

        string chosenFileAguaSup;
        string chosenFileAguaCap1;

        int largoXDefault;
        int altoYDefault;
        int offsetXDefault;
        int offsetYDefault;
        int ejeXRealImage;
        int ejeYRealImage;

        //Ingresados Dinamicamente
        int anchoXInput = 0;
        int altoYInput = 0;
        int offsetXInput = 0;
        int offsetYInput = 0;

        int anchoX;
        int altoY;

        int offsetX;
        int offsetY;

        public Form1()
        {
            InitializeComponent();
            inputFiles = System.Configuration.ConfigurationSettings.AppSettings["carpetaDatosEntrada"];            

            outputFiles = System.Configuration.ConfigurationSettings.AppSettings["outputFiles"];
            ejeXRealImage = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["ejeXRealImage"]);
            ejeYRealImage = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["ejeYRealImage"]);
            largoXDefault = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["largoXDefault"]);
            altoYDefault = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["altoYDefault"]);
            offsetXDefault = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["offsetXDefault"]);
            offsetYDefault = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["offsetYDefault"]);

            openFDAguaSuperficial.InitialDirectory = inputFiles;
            openFDAguaCapa1.InitialDirectory = inputFiles;

            textBoxOpenAguaSuperficial.Text = inputFiles + "\\" + System.Configuration.ConfigurationSettings.AppSettings["aguaSuperfEntradaDefault"];
            textBoxOpenAguaPermeable.Text = inputFiles + "\\" + System.Configuration.ConfigurationSettings.AppSettings["aguaCapa1EntradaDefault"];

            textBoxCapacAlmSuelo.Text = inputFiles + "\\" + System.Configuration.ConfigurationSettings.AppSettings["capacidadAlmacenSuelo"];
            textBoxConducHidrSuelo.Text = inputFiles + "\\" + System.Configuration.ConfigurationSettings.AppSettings["kConductividadHSuelo"];
            textBoxDEM.Text = inputFiles + "\\" + System.Configuration.ConfigurationSettings.AppSettings["DEM"];
            textBoxProfCapaPermeable.Text = inputFiles + "\\" + System.Configuration.ConfigurationSettings.AppSettings["profundidadCapaPermeable"];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (anchoXInput != 0)
            {
                anchoX = anchoXInput;
            }
            else 
            {
                anchoX = largoXDefault;
            }

            if (altoYInput != 0)
            {
                altoY = altoYInput;
            }
            else
            {
                altoY = altoYDefault;
            }


            if (offsetXInput != 0)
            {
                offsetX = offsetXInput;
            }
            else
            {
                offsetX = offsetXDefault;
            }

            if (offsetYInput != 0)
            {
                offsetY = offsetYInput;
            }
            else
            {
                offsetY = offsetYDefault;
            }

            dataSetSimulador = new Data(inputFiles, anchoX, altoY, 90.0f, offsetX, offsetY, ejeXRealImage, ejeYRealImage);

            dataSetSimulador.outputFiles = outputFiles;
            dataSetSimulador.inputFiles = inputFiles;            

            dataSetSimulador.normalizacionInicial();

            dataSetSimulador.infiltracionVertical();
           

            Nts = 300; //Cantidad de pasos de ejecucion de escurrimiento superficial por cada paso 
            NT = 1440; //Cantidad de horas total de ejecucion de la simulación

         
            for (int t = 1; t <= NT; t++) 
            {
                dataSetSimulador.LogMessageToFile("t = " + t.ToString());

                if (Nts > 1)
                {
                    dts = dt0 / Nts * 3600;
                }
                else 
                {
                    dts = dt0 * 3600;
                    Nts = 1;
                }

                dataSetSimulador.LogMessageToFile("dts = " + dts.ToString());
                dataSetSimulador.LogMessageToFile("Nts = " + Nts.ToString());

                dataSetSimulador.calculosescurrimientoSuperficial(dts, t);

                Nts = dataSetSimulador.calculoNts();

                for (int ts = 1; ts <= Nts; ts++)
                {
                    dataSetSimulador.asignarAlturasAgua(dts);
                    dataSetSimulador.calculosescurrimientoSuperficial(dts, t);                                        
                    dataSetSimulador.crearMatrizFlujos(ts - 1, dataSetSimulador.flujoResultante.anchoEjeX_, dataSetSimulador.flujoResultante.altoEjeY_);                    
                }                

                //dataSetSimulador.matrizCantVariaciones.writeDataMatrix(@"D:\Tesis\Datos\ResultadosMios\MatriVariac_" + t.ToString());
                
                dataSetSimulador.planchado();                                
                
                //Nts = dataSetSimulador.calculoNts();
                dataSetSimulador.LogMessageToFile("\tNts CALCULADO = " + Nts.ToString());

                dataSetSimulador.doEvaporacionInfiltHorizontal();

                dataSetSimulador.recalculoVariables();
                dataSetSimulador.infiltracionVertical();

                dataSetSimulador.grabaResultados(outputFiles);

            }

            dataSetSimulador.grabaResultados(@"D:\Tesis\Datos\ResultadosMios");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataSetSimulador = new Data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            anchoXInput = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            altoYInput = int.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            offsetXInput = int.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            offsetYInput = int.Parse(textBox4.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = System.Configuration.ConfigurationSettings.AppSettings["largoXDefault"];
            textBox2.Text = System.Configuration.ConfigurationSettings.AppSettings["altoYDefault"];
            textBox3.Text = System.Configuration.ConfigurationSettings.AppSettings["offsetXDefault"];
            textBox4.Text = System.Configuration.ConfigurationSettings.AppSettings["offsetYDefault"];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonBrowseAguaSup_Click(object sender, EventArgs e)
        {
            openFDAguaSuperficial.ShowDialog();            
            textBoxOpenAguaSuperficial.Text = openFDAguaSuperficial.FileName;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            openFDAguaCapa1.ShowDialog();
            textBoxOpenAguaPermeable.Text = openFDAguaCapa1.FileName;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonBrowseDem_Click(object sender, EventArgs e)
        {
            openFDDEM.ShowDialog();
            textBoxDEM.Text = openFDDEM.FileName;
        }

        private void buttonBrowseProfCapPerm_Click(object sender, EventArgs e)
        {
            openFDProfCapaPermeable.ShowDialog();
            textBoxProfCapaPermeable.Text = openFDProfCapaPermeable.FileName;
        }

        private void buttonBrowseConducHSuelo_Click(object sender, EventArgs e)
        {
            openFDCondHSuelo.ShowDialog();
            textBoxConducHidrSuelo.Text = openFDCondHSuelo.FileName;
        }

        private void buttonBrowseCapacAlmSuelo_Click(object sender, EventArgs e)
        {
            openFDCapAlmSuelo.ShowDialog();
            textBoxCapacAlmSuelo.Text = openFDCapAlmSuelo.FileName;
        }

    }
}