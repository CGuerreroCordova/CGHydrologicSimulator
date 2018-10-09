using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SimuladorInundaciones
{
    public partial class GUIModelEjecForm : Form
    {
        public delegate void updateInfoLog(string textLog);
        public updateInfoLog delegadoLog;

        public delegate void updateStepExecution(string stepExecution);
        public updateStepExecution delegadoStep;

        ConfParameters parametrosEjecucion;
        ControlEjecucionProc ejecutadorProcesos;
        Thread ejecucion;

        public GUIModelEjecForm(ConfParameters parameConfToEjec)
        {
            InitializeComponent();

            parametrosEjecucion = parameConfToEjec;
            ejecutadorProcesos = new ControlEjecucionProc(parametrosEjecucion, this);

            AguaSupInicValor.Text = parametrosEjecucion.pathAguaSuperficial;
            TextAguaCapaPermInic.Text = parametrosEjecucion.pathAguaCapaPermeable;
            TextDEM.Text = parametrosEjecucion.pathDEM;
            TextProfAguaPerm.Text = parametrosEjecucion.pathProfSuelos;
            TextCondHidraulica.Text = parametrosEjecucion.pathKConductividadHSuelo;
            TextAlmCapaPermeable.Text = parametrosEjecucion.pathCapacidadAlmacenSuelo;
            TextNts.Text = parametrosEjecucion.escSupPasosNts.ToString();
            TextNt.Text = parametrosEjecucion.tiempoSimulacionHoras.ToString();
            TextTg.Text = parametrosEjecucion.periodoGrabacionResult.ToString();

            totalStepsExecution.Text = TextNt.Text;

            delegadoLog = new updateInfoLog(UpdateTextLog);
            delegadoStep = new updateStepExecution(UpdateStepExecution);
        }

        public void ejecucionSimulacion() 
        {
            ejecucion = new Thread(new ThreadStart(ejecutadorProcesos.ejecucionSimulacion));
            ejecucion.Start();
        }

        public void UpdateTextLog(string msg)
        {
            textFieldLog.Text += msg + "\r\n";
            textFieldLog.SelectionLength = 0;

            textFieldLog.SelectionStart = textFieldLog.Text.Length;
            textFieldLog.ScrollToCaret();
            textFieldLog.Refresh();
        }

        public void UpdateStepExecution(string step)
        {
            stepExecution.Text = step;
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            ejecucion.Abort();
            textFieldLog.Text += "\r\nCancelada por el usuario.\r\n";
            button2.Enabled = false;
            buttonCerrar.Enabled = true;
            button2.BackColor = SystemColors.Control;
            buttonCerrar.BackColor = Color.SeaGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textFieldLog.Text = "";
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GUIModelEjecForm_FormClosed(object sender, EventArgs e)
        {
            ejecucion.Abort();
        }

        private void GUIModelEjecForm_Load(object sender, EventArgs e)
        {

        }

        private void textFieldLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
