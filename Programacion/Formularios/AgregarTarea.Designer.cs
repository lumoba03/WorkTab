﻿namespace ProyectoIntegradoVerde.Formularios
{
    partial class AgregarTarea
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
            this.lblAgregarT = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.nudPuntos = new System.Windows.Forms.NumericUpDown();
            this.lblFLimite = new System.Windows.Forms.Label();
            this.dtpFL = new System.Windows.Forms.DateTimePicker();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAgregarT
            // 
            this.lblAgregarT.AutoSize = true;
            this.lblAgregarT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblAgregarT.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAgregarT.Location = new System.Drawing.Point(289, 64);
            this.lblAgregarT.Name = "lblAgregarT";
            this.lblAgregarT.Size = new System.Drawing.Size(249, 39);
            this.lblAgregarT.TabIndex = 0;
            this.lblAgregarT.Text = "Agregar Tarea";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitulo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitulo.Location = new System.Drawing.Point(178, 123);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(71, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Título: ";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDesc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDesc.Location = new System.Drawing.Point(124, 241);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(125, 25);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Descripción: ";
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPuntos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPuntos.Location = new System.Drawing.Point(165, 182);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(84, 25);
            this.lblPuntos.TabIndex = 3;
            this.lblPuntos.Text = "Puntos: ";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDesc.Location = new System.Drawing.Point(296, 245);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(368, 121);
            this.txtDesc.TabIndex = 4;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTitulo.Location = new System.Drawing.Point(296, 126);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(168, 26);
            this.txtTitulo.TabIndex = 6;
            // 
            // nudPuntos
            // 
            this.nudPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nudPuntos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPuntos.Location = new System.Drawing.Point(296, 181);
            this.nudPuntos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPuntos.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPuntos.Name = "nudPuntos";
            this.nudPuntos.ReadOnly = true;
            this.nudPuntos.Size = new System.Drawing.Size(101, 26);
            this.nudPuntos.TabIndex = 8;
            this.nudPuntos.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblFLimite
            // 
            this.lblFLimite.AutoSize = true;
            this.lblFLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFLimite.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFLimite.Location = new System.Drawing.Point(115, 397);
            this.lblFLimite.Name = "lblFLimite";
            this.lblFLimite.Size = new System.Drawing.Size(134, 25);
            this.lblFLimite.TabIndex = 9;
            this.lblFLimite.Text = "Fecha Límite: ";
            // 
            // dtpFL
            // 
            this.dtpFL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFL.Location = new System.Drawing.Point(296, 400);
            this.dtpFL.Name = "dtpFL";
            this.dtpFL.Size = new System.Drawing.Size(332, 26);
            this.dtpFL.TabIndex = 10;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEnviar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEnviar.Location = new System.Drawing.Point(298, 467);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(115, 44);
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCerrar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Location = new System.Drawing.Point(450, 467);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 44);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 54);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Location = new System.Drawing.Point(-1, 534);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(937, 53);
            this.panel2.TabIndex = 14;
            // 
            // AgregarTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dtpFL);
            this.Controls.Add(this.lblFLimite);
            this.Controls.Add(this.nudPuntos);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblPuntos);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblAgregarT);
            this.Name = "AgregarTarea";
            this.Text = "Agregar Tarea";
            this.Load += new System.EventHandler(this.AgregarTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAgregarT;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.NumericUpDown nudPuntos;
        private System.Windows.Forms.Label lblFLimite;
        private System.Windows.Forms.DateTimePicker dtpFL;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}