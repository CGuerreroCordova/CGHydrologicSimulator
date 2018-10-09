using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SimuladorInundaciones
{
    public partial class GUIModelConfForm : Form
    {        
        
        public ConfParameters parametrosConfiguracion;
        public GUIModelEjecForm ejecVentana;


        public GUIModelConfForm()
        {
            parametrosConfiguracion = new ConfParameters();

            InitializeComponent();
            
            openFDAguaSuperficial.InitialDirectory = parametrosConfiguracion.carpetaDatosEntrada;
            openFDAguaCapa1.InitialDirectory = parametrosConfiguracion.carpetaDatosEntrada;

            textBoxOpenAguaSuperficial.Text = parametrosConfiguracion.pathAguaSuperficial;
            textBoxOpenAguaPermeable.Text = parametrosConfiguracion.pathAguaCapaPermeable;

            textBoxCapacAlmSuelo.Text = parametrosConfiguracion.pathCapacidadAlmacenSuelo;
            textBoxConducHidrSuelo.Text = parametrosConfiguracion.pathKConductividadHSuelo;
            textBoxDEM.Text = parametrosConfiguracion.pathDEM;
            textBoxProfCapaPermeable.Text = parametrosConfiguracion.pathProfSuelos;
            textBoxLluvia.Text = parametrosConfiguracion.pathLluvia;

            textBoxNts.Text = parametrosConfiguracion.escSupPasosNts.ToString();
            textBoxNt.Text = parametrosConfiguracion.tiempoSimulacionHoras.ToString();                
            textBoxTg.Text = parametrosConfiguracion.periodoGrabacionResult.ToString();

            checkBox1.Visible = parametrosConfiguracion.debugEnablePlanchado;
            checkBox2.Visible = parametrosConfiguracion.debugEnablePlanchado;
        }


        private void buttonBrowseAguaSup_Click(object sender, EventArgs e)
        {
            openFDAguaSuperficial.ShowDialog();
            if (openFDAguaSuperficial.FileName != "")
            {
                textBoxOpenAguaSuperficial.Text = openFDAguaSuperficial.FileName;
                parametrosConfiguracion.pathAguaSuperficial = openFDAguaSuperficial.FileName;
            }
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            openFDAguaCapa1.ShowDialog();
            if (openFDAguaCapa1.FileName != "")
            {
                textBoxOpenAguaPermeable.Text = openFDAguaCapa1.FileName;
                parametrosConfiguracion.pathAguaCapaPermeable = openFDAguaCapa1.FileName;
            }
        }

        private void buttonBrowseDem_Click(object sender, EventArgs e)
        {
            openFDDEM.ShowDialog();
            if (openFDDEM.FileName != "")
            {
                textBoxDEM.Text = openFDDEM.FileName;
                parametrosConfiguracion.pathDEM = openFDDEM.FileName;
            }
        }

        private void buttonBrowseProfCapPerm_Click(object sender, EventArgs e)
        {
            openFDProfCapaPermeable.ShowDialog();
            if (openFDProfCapaPermeable.FileName != "")
            {
                textBoxProfCapaPermeable.Text = openFDProfCapaPermeable.FileName;
                parametrosConfiguracion.pathProfSuelos = openFDProfCapaPermeable.FileName;
            }
        }

        private void buttonBrowseConducHSuelo_Click(object sender, EventArgs e)
        {
            openFDCondHSuelo.ShowDialog();
            if (openFDCondHSuelo.FileName != "")
            {
                textBoxConducHidrSuelo.Text = openFDCondHSuelo.FileName;
                parametrosConfiguracion.pathKConductividadHSuelo = openFDCondHSuelo.FileName;
            }
        }

        private void buttonBrowseCapacAlmSuelo_Click(object sender, EventArgs e)
        {
            openFDCapAlmSuelo.ShowDialog();

            if (openFDCapAlmSuelo.FileName != "")
            {
                textBoxCapacAlmSuelo.Text = openFDCapAlmSuelo.FileName;
                parametrosConfiguracion.pathCapacidadAlmacenSuelo = openFDCapAlmSuelo.FileName;
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            parametrosConfiguracion.escSupPasosNts = int.Parse(textBoxNts.Text);
            parametrosConfiguracion.tiempoSimulacionHoras = int.Parse(textBoxNt.Text);
            parametrosConfiguracion.periodoGrabacionResult = int.Parse(textBoxTg.Text);
            ejecVentana = new GUIModelEjecForm(parametrosConfiguracion);
            ejecVentana.Show();
            ejecVentana.ejecucionSimulacion();
            ejecVentana.FormClosed +=new FormClosedEventHandler(ejecVentana_FormClosed);
            this.Enabled = false;
            this.Hide();
        }



        void ejecVentana_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            this.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            parametrosConfiguracion.nohacerPlanchado = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
            }
            else 
            {
                checkBox2.Enabled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            parametrosConfiguracion.imprimitMatrizClusters = checkBox2.Checked;
        }

        private void buttonOpenFolderLluvia_Click(object sender, EventArgs e)
        {

            folderBrowserLluvia.ShowDialog();
            if (folderBrowserLluvia.SelectedPath != "") 
            {
                textBoxLluvia.Text = folderBrowserLluvia.SelectedPath;
            }
            
            if (openFDDEM.FileName != "")
            {
                textBoxDEM.Text = openFDDEM.FileName;
                parametrosConfiguracion.pathDEM = openFDDEM.FileName;
            }
        }

        private void textBoxOpenAguaSuperficial_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}