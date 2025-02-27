﻿using ProyectoIntegradoVerde.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using ProyectoIntegradoVerde.RecursosLocalizables;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ProyectoIntegradoVerde.Formularios
{
    public partial class FrmFuncionalidades : Form
    {
        private Usuario user;
        private int numPag;
        bool lang;
        bool luz;
        
        public int NumPag { get => numPag; set => numPag = value; }
        public Usuario User { get => user; set => user = value; }



        public void RellenarDataGrid()
        {

            // Tareas sin asignar

            dgvTareasPendientes.Rows.Clear();
            dgvTareasSinAsignar.Rows.Clear();
            dgvReuniones.Rows.Clear();

            List<Tarea> list = new List<Tarea>();
            list = Tarea.ListadoTareas();

            for (int i = 0; i < list.Count; i++)
            {
                dgvTareasSinAsignar.Rows.Add(list[i].Id, list[i].Titulo, list[i].FPublicacion.ToString("dd-MM-yyyy"), list[i].FLimite.ToString("dd-MM-yyyy"), list[i].Puntos);
            }

            // Tareas asignadas

            List<Tarea> list2 = new List<Tarea>();
            list2 = Tarea.ListadoTareasAsignadas(user.Id);
            for (int i = 0; i < list2.Count; i++)
            {
                dgvTareasPendientes.Rows.Add(list2[i].Id, list2[i].Titulo, list2[i].FPublicacion.ToString("dd-MM-yyyy"), list2[i].FLimite.ToString("dd-MM-yyyy"), list2[i].Puntos);
            }

            // Correo
            List<Correo> correos;
            correos = Correo.Bandeja(user.Correo);
            for (int i = 0; i < correos.Count; i++)
            {
                dgvBandeja.Rows.Add(correos[i].Id, correos[i].Asunto, correos[i].Cuerpo, correos[i].Remitente, correos[i].Fecha);
            }

            //Productos
            List<Tienda> list4 = new List<Tienda>();
            list4 = Tienda.Catalogo();
            for (int i = 0; i < list4.Count; i++)
            {
                dgvProductos.Rows.Add(list4[i].Id_prod, list4[i].Nombre, list4[i].Coste, list4[i].Descripcion, list4[i].Codigo);
            }

            // Reuniones

            List<Reuniones> list3 = new List<Reuniones>();
            list3 = Reuniones.ListadoReuniones(user.Id);
            for (int i = 0; i < list3.Count; i++)
            {
                string f = list3[i].Fecha.ToString("dd-MM-yyyy") + " // " + list3[i].Hora.ToString("HH:mm");
                dgvReuniones.Rows.Add(list3[i].Id, list3[i].Nombre, list3[i].Descripcion, f);
            }
            conexion.CerrarConexion();
        }
        public FrmFuncionalidades(bool lu, bool lan )
        {
            
            InitializeComponent();
            luz = lu;
            lang = lan;
            luzForm();
            formLang();

        }

        private void FrmFuncionalidades_Load(object sender, EventArgs e)
        {
            this.dgvProductos.Columns["codigo"].Visible = false;
            lblPuntos.Text = user.Puntos.ToString();
            this.tabControl1.SelectTab(numPag);
            try
            {
                if (conexion.Conexion != null)
                {

                    conexion.AbrirConexion();
                    RellenarDataGrid();

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

            if (user.Cargo != "Administrador")
            {
                btnCrearTarea.Visible = false;
            }
        }



        private void dgvTareasSinAsignar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string idTarea = dgvTareasSinAsignar.CurrentRow.Cells[0].Value.ToString();

            try
            {
                if (conexion.Conexion != null)
                {

                    conexion.AbrirConexion();
                    Tarea.AsignarTarea(idTarea, User.Id);
                    RellenarDataGrid();

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





        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.AbrirConexion();
            RellenarDataGrid();
            conexion.CerrarConexion();
        }

        private void btnActualizarReuniones_Click(object sender, EventArgs e)
        {
            conexion.AbrirConexion();
            RellenarDataGrid();
            conexion.CerrarConexion();
        }
        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            conexion.AbrirConexion();
            if (Correo.YaEsta(txtDest.Text) == false)
            {
                MessageBox.Show("El destinatario ha sido introducido incorrectamente o no existe.");
                conexion.CerrarConexion();
            }
            else if (Usuario.ComprobarBorrado("correo", txtDest.Text) == true)
            {
                MessageBox.Show("El usuario al que intenta mandar el correo está eliminado.");
                conexion.CerrarConexion();
            }
            else
            {
                conexion.CerrarConexion();
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");


                Correo cor = new Correo();

                cor.Asunto = txtAsunto.Text;
                cor.Cuerpo = txtCuerpo.Text;
                cor.Recipiente = txtDest.Text;
                cor.Remitente = user.Correo;
                cor.Fecha = sqlFormattedDate;


                conexion.AbrirConexion();
                Correo.AgregarCorreo(cor,user.Id);
                conexion.CerrarConexion();
                MessageBox.Show("Correo enviado con éxito.");
                txtAsunto.Text = "";
                txtCuerpo.Text = "";
                txtDest.Text = "";
            }
        }



        private void btnCrearReunion_Click(object sender, EventArgs e)
        {
            CrearReunion reu = new CrearReunion(user,luz,lang);
            reu.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtAsunto.Text = "";
            txtCuerpo.Text = "";
            txtDest.Text = "";
        }



        private void dgvTareasPendientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvTareasPendientes.Rows[e.RowIndex].Cells[4].Value != null)
            {
                int puntos = Convert.ToInt32(dgvTareasPendientes.Rows[e.RowIndex].Cells[4].Value);
                int id = Convert.ToInt32(dgvTareasPendientes.Rows[e.RowIndex].Cells[0].Value);

                user.Puntos = user.Puntos + puntos;
                conexion.AbrirConexion();
                Tarea.EliminarTarea(id);
                Tarea.AñadirPuntos(user);
                RellenarDataGrid();
                conexion.CerrarConexion();
                MessageBox.Show("Tarea completada, puntos actuales: "+user.Puntos.ToString());
                lblPuntos.Text = user.Puntos.ToString();

            }
              
        }

        private void dgvBandeja_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBandeja.Rows[e.RowIndex].Cells[2].Value != null)
            {
                MessageBox.Show(dgvBandeja.Rows[e.RowIndex].Cells[2].Value.ToString(), "Cuerpo: ");

            }
        }

       

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

                string p_prod = dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
                string cod = dgvProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
                int p_produ = Convert.ToInt32(p_prod);


            if (user.Puntos >= p_produ)
            {
                conexion.AbrirConexion();
                user.Puntos = user.Puntos - p_produ;
                lblPuntos.Text = User.Puntos.ToString();
                Tienda.RestarPuntos(user.Id, user.Puntos);
                ;
                MessageBox.Show(cod, "Codigo :", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                conexion.CerrarConexion();
            }
            else
                MessageBox.Show("Puntos insuficientes");


            
        }

        private void btnCrearTarea_Click(object sender, EventArgs e)
        {
            AgregarTarea tar = new AgregarTarea(user, luz, lang);
            tar.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void formLang()
        {
            if (!lang)
            {

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("");

            }
            else
            {

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("EN");


            }

            AplicarIdioma();
        }

        private void AplicarIdioma()
        {

            lblAsunt.Text = StringRecursos.fun_lblAsunt;
            lblComProd.Text = StringRecursos.fun_lblComProd;
            lblDestin.Text = StringRecursos.fun_lblDestin;
            lblDispo.Text = StringRecursos.fun_lblDispo;
            lblDobleClick.Text = StringRecursos.fun_lblDobleClick;
            lblDobleClick2.Text = StringRecursos.fun_lblDobleClick2;
            lblEmail.Text = StringRecursos.fun_lblEmail;
            lblInfo1.Text = StringRecursos.fun_lblInfo1;
            lblInfo2.Text = StringRecursos.fun_lblInfo2;
            btnActualizarReuniones.Text = StringRecursos.fun_btnActualizarReuniones;
            btnCrearReunion.Text = StringRecursos.fun_btnCrearReunion;
            btnCrearTarea.Text = StringRecursos.fun_btnCrearTarea;
            btnLimpiar.Text = StringRecursos.fun_btnLimpiar;

            dgvTareasSinAsignar.Columns[0].HeaderText = StringRecursos.fun_dgv1_1;
            dgvTareasSinAsignar.Columns[1].HeaderText = StringRecursos.fun_dgv1_2;
            dgvTareasSinAsignar.Columns[2].HeaderText = StringRecursos.fun_dgv1_3;
            dgvTareasSinAsignar.Columns[3].HeaderText = StringRecursos.fun_dgv1_5;
            dgvTareasSinAsignar.Columns[4].HeaderText = StringRecursos.fun_dgv1_4;

            dgvTareasPendientes.Columns[0].HeaderText = StringRecursos.fun_dgv1_1;
            dgvTareasPendientes.Columns[1].HeaderText = StringRecursos.fun_dgv1_2;
            dgvTareasPendientes.Columns[2].HeaderText = StringRecursos.fun_dgv1_3;
            dgvTareasPendientes.Columns[3].HeaderText = StringRecursos.fun_dgv1_5;
            dgvTareasPendientes.Columns[4].HeaderText = StringRecursos.fun_dgv1_4;

            dgvReuniones.Columns[1].HeaderText = StringRecursos.fun_dgv2_1;
            dgvReuniones.Columns[2].HeaderText = StringRecursos.fun_dgv2_2;
            dgvReuniones.Columns[3].HeaderText = StringRecursos.fun_dgv2_3;

            dgvBandeja.Columns[1].HeaderText = StringRecursos.fun_dgv3_1;
            dgvBandeja.Columns[2].HeaderText = StringRecursos.fun_dgv3_2;
            dgvBandeja.Columns[3].HeaderText = StringRecursos.fun_dgv3_3;
            dgvBandeja.Columns[4].HeaderText = StringRecursos.fun_dgv3_4;

            dgvProductos.Columns[1].HeaderText = StringRecursos.fun_dgv4_1;
            dgvProductos.Columns[2].HeaderText = StringRecursos.fun_dgv4_2;
            dgvProductos.Columns[3].HeaderText = StringRecursos.fun_dgv4_3;
            dgvProductos.Columns[4].HeaderText = StringRecursos.fun_dgv4_4;
            

            tabControl1.TabPages[0].Text = StringRecursos.fun_tc_1;
            tabControl1.TabPages[1].Text = StringRecursos.fun_tc_2;
            tabControl1.TabPages[2].Text = StringRecursos.fun_tc_3;
            tabControl1.TabPages[3].Text = StringRecursos.fun_tc_4;
            tabControl1.TabPages[4].Text = StringRecursos.fun_tc_5;

            this.Text = StringRecursos.fun_prinTitle;
            
            



        }
        private void luzForm()
        {

            if (luz)
            {


                this.BackColor = Color.FromArgb(255, 255, 255);
                lblEmail.ForeColor = Color.FromArgb(0, 0, 122);
                lblAsunt.ForeColor = Color.FromArgb(0, 0, 122);
                lblDestin.ForeColor = Color.FromArgb(0, 0, 122);
                lblComProd.ForeColor = Color.FromArgb(0, 0, 122);
                lblDispo.ForeColor = Color.FromArgb(0, 0, 122);
                lblDobleClick.ForeColor = Color.FromArgb(0, 0, 122);
                lblDobleClick2.ForeColor = Color.FromArgb(0, 0, 122);


            }
            else
            {

               
                this.BackColor = Color.FromArgb(255, 255, 255);
                lblEmail.ForeColor = Color.FromArgb(255, 255, 255);
                lblAsunt.ForeColor = Color.FromArgb(255, 255, 255);
                lblDestin.ForeColor = Color.FromArgb(255, 255, 255);
                lblComProd.ForeColor = Color.FromArgb(255, 255, 255);
                lblDispo.ForeColor = Color.FromArgb(255, 255, 255);
                lblDobleClick.ForeColor = Color.FromArgb(255, 255, 255);
                lblDobleClick2.ForeColor = Color.FromArgb(255, 255, 255);

                lblInfo1.ForeColor = Color.FromArgb(255, 255, 255);
                lblInfo2.ForeColor = Color.FromArgb(255, 255, 255);
                btnActualizarReuniones.ForeColor = Color.FromArgb(255, 255, 255);
                btnCrearReunion.ForeColor = Color.FromArgb(255, 255, 255);
                btnCrearTarea.ForeColor = Color.FromArgb(255, 255, 255);
                btnLimpiar.ForeColor = Color.FromArgb(255, 255, 255);
                panel1.BackColor = Color.FromArgb(255, 255, 255);
                panel2.BackColor = Color.FromArgb(255, 255, 255);
                tabPage1.BackColor= Color.FromArgb(0, 0, 122);
                tabPage2.BackColor = Color.FromArgb(0, 0, 122);
                tabPage3.BackColor= Color.FromArgb(0, 0, 122);
                tabPage4.BackColor = Color.FromArgb(0, 0, 122);
                tabPage5.BackColor = Color.FromArgb(0, 0, 122);
                lblPuntos.ForeColor = Color.FromArgb(255, 255, 255);
               


            }

        }

        private void dgvBandeja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

