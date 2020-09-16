using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsCompilarEjecutarNET_cs
{
    partial class OpcionesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFic = new System.Windows.Forms.TextBox();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lstFics = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.chkCargarUltimo = new System.Windows.Forms.CheckBox();
            this.chkColorearCargar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtFic);
            this.groupBox1.Controls.Add(this.btnOrdenar);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.lstFics);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de ficheros abiertos recientemente";
            // 
            // txtFic
            // 
            this.txtFic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFic.Location = new System.Drawing.Point(6, 200);
            this.txtFic.Name = "txtFic";
            this.txtFic.Size = new System.Drawing.Size(266, 23);
            this.txtFic.TabIndex = 2;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenar.Location = new System.Drawing.Point(278, 199);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(75, 23);
            this.btnOrdenar.TabIndex = 3;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitar.AutoSize = true;
            this.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitar.Location = new System.Drawing.Point(359, 198);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(127, 25);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "Quitar seleccionados";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // lstFics
            // 
            this.lstFics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFics.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstFics.FormattingEnabled = true;
            this.lstFics.ItemHeight = 14;
            this.lstFics.Location = new System.Drawing.Point(6, 45);
            this.lstFics.Name = "lstFics";
            this.lstFics.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFics.Size = new System.Drawing.Size(480, 144);
            this.lstFics.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona los que quieras borrar o clasifícalos usando los botones";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(429, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(348, 276);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // chkCargarUltimo
            // 
            this.chkCargarUltimo.AutoSize = true;
            this.chkCargarUltimo.Location = new System.Drawing.Point(18, 241);
            this.chkCargarUltimo.Name = "chkCargarUltimo";
            this.chkCargarUltimo.Size = new System.Drawing.Size(233, 19);
            this.chkCargarUltimo.TabIndex = 1;
            this.chkCargarUltimo.Text = "Al iniciar cargar el último fichero &usado";
            this.chkCargarUltimo.UseVisualStyleBackColor = true;
            // 
            // chkColorearCargar
            // 
            this.chkColorearCargar.AutoSize = true;
            this.chkColorearCargar.Location = new System.Drawing.Point(18, 266);
            this.chkColorearCargar.Name = "chkColorearCargar";
            this.chkColorearCargar.Size = new System.Drawing.Size(171, 19);
            this.chkColorearCargar.TabIndex = 2;
            this.chkColorearCargar.Text = "&Colorear al cargar el fichero";
            this.chkColorearCargar.UseVisualStyleBackColor = true;
            // 
            // OpcionesForm
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(516, 311);
            this.Controls.Add(this.chkColorearCargar);
            this.Controls.Add(this.chkCargarUltimo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 320);
            this.Name = "OpcionesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnQuitar;
        private ListBox lstFics;
        private Label label1;
        private Button btnCancelar;
        private Button btnAceptar;
        private Button btnOrdenar;
        private TextBox txtFic;
        private CheckBox chkCargarUltimo;
        private CheckBox chkColorearCargar;
    }
}