﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProyectoIntegradoVerde;
using ProyectoIntegradoVerde.Formularios;

namespace Programacion
{
   
    public partial class Login : Form
    {
        bool luz = true;
        public Login()
        {
            InitializeComponent();
        }

        Usuario user = new Usuario();


        private void btnIniSesion_Click(object sender, EventArgs e)
        {
            if (Usuario.compNif(txtNif.Text))
            {
                try
                {
                    if (conexion.Conexion != null)
                    {
                        conexion.AbrirConexion();
                        Usuario user = Usuario.BuscarUsuario(txtNif.Text);
                        
                        if (user.Nif == txtNif.Text && user.Password == txtPassword.Text)
                        {                           
                                                    
                            FrmPrincipal princ = new FrmPrincipal(user.Id,luz);
                            this.Hide();
                            princ.Show();
                        }
                        else
                        {
                            MessageBox.Show("NIF o contraseña incorrectos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            else
            {
                MessageBox.Show("El NIF no es válido");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtNif_TextChanged(object sender, EventArgs e)
        {
            txtNif.Text = txtNif.Text.ToUpper();
        }

        private void pcbLuz_Click(object sender, EventArgs e)
        {

            if (luz)
            {

                luz = false;
                this.BackColor = Color.FromArgb(0, 0,122);
                lblLang.ForeColor = Color.FromArgb(255, 255, 255);
                lblNIF.ForeColor = Color.FromArgb(255, 255, 255);
                lblPsw.ForeColor = Color.FromArgb(255, 255, 255);
                lblNotif.LinkColor = Color.FromArgb(255, 255, 255);
                lblOlvidoCont.LinkColor = Color.FromArgb(255, 255, 255);

            }
            else
            {
                luz = true;
                this.BackColor = Color.FromArgb(255, 255, 255);
                lblLang.ForeColor = Color.FromArgb(0, 0, 0);
                lblNIF.ForeColor = Color.FromArgb(0, 0, 0);
                lblPsw.ForeColor = Color.FromArgb(0, 0, 0);
                lblNotif.LinkColor = Color.FromArgb(0, 0, 204);
                lblOlvidoCont.LinkColor = Color.FromArgb(0, 0, 204);

            }

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (Usuario.compNif(txtNif.Text))
            {
                try
                {
                    if (conexion.Conexion != null)
                    {
                        conexion.AbrirConexion();
                        Usuario usu = Usuario.BuscarUsuario(txtNif.Text);
                        if (usu.Cargo == "Administrador" || usu.Cargo == "Jefe" && usu.Password == txtPassword.Text)
                        {
                            Registro reg = new Registro();
                            reg.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos o El Usuario no tiene permisos para esta acción");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    conexion.CerrarConexion();
                }
            }
            else
            {
                MessageBox.Show("El NIF no es válido");
            }
        }
    }
}