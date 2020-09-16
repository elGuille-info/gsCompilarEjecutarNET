/*
'------------------------------------------------------------------------------
' Opciones de la aplicación de compilar y ejecutar
'
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsCompilarEjecutarNET_cs
{
    public partial class OpcionesForm : Form
    {
        public OpcionesForm()
        {
            InitializeComponent();
        }

        public bool CargarUltimo;
        public bool ColorearAlCargar;

        public OpcionesForm(List<string> colFics)
        {

            // Esta llamada es exigida por el diseñador.
            InitializeComponent();

            // Agregue cualquier inicialización después de la llamada a InitializeComponent().
            this.ColFics.AddRange(colFics);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpcionesForm_FormClosing);
            this.Load += new System.EventHandler(this.OpcionesForm_Load);
        }

        public List<string> ColFics { get; set; } = new List<string>();

        private void OpcionesForm_Load(object sender, EventArgs e)
        {
            chkCargarUltimo.Checked = CargarUltimo;
            chkColorearCargar.Checked = ColorearAlCargar;
            AñadirEventos();
            AsignarItems();
        }

        private void OpcionesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                this.DialogResult = DialogResult.Cancel;
        }

        private void AsignarItems()
        {
            lstFics.Items.Clear();
            for (var i = 0; i <= ColFics.Count - 1; i++)
                lstFics.Items.Add(ColFics[i]);
        }

        private void AñadirEventos()
        {
            lstFics.KeyDown += lstFics_KeyDown;
            btnCancelar.Click += (object s, EventArgs e) => this.DialogResult = DialogResult.Cancel;

            btnAceptar.Click += (object s, EventArgs e) =>
                                    {
                                        this.CargarUltimo = chkCargarUltimo.Checked;
                                        this.ColorearAlCargar = chkColorearCargar.Checked;
                                        this.DialogResult = DialogResult.OK;
                                    };
            btnQuitar.Click += (object s, EventArgs e) => QuitarSeleccionados();
            btnOrdenar.Click += (object s, EventArgs e) =>
                                    {
                                        ColFics.Sort();
                                        AsignarItems();
                                    };
            lstFics.SelectedIndexChanged += (object s, EventArgs e) => 
                                                txtFic.Text = (lstFics.SelectedItem == null 
                                                                ? txtFic.Text 
                                                                : lstFics.SelectedItem.ToString()
                                                               );
        }

        private void lstFics_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                QuitarSeleccionados();
            }
        }

        private void QuitarSeleccionados()
        {
            if (lstFics.SelectedIndices.Count == 0)
                return;

            for (var i = lstFics.SelectedIndices.Count - 1; i >= 0; i += -1)
                lstFics.Items.RemoveAt(lstFics.SelectedIndices[i]);

            ColFics.Clear();

            for (var i = 0; i <= lstFics.Items.Count - 1; i++)
                ColFics.Add(lstFics.Items[i].ToString());
        }
    }
}
