using SisAcademico.Entities;
using SisAcademico.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisAcademico.UI
{
    public partial class Frm_Estudiante : Form
    {
        public Frm_Estudiante()
        {
            InitializeComponent();
        }

        EstudianteNegocio objNegocio = new EstudianteNegocio();
        Estudiante objEstudiante = new Estudiante();

        void Limpiar()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
        }

        bool validar(String p1, string p2, string p3)
        {
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0)
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
            {
                DataEstudiantes.DataSource = objNegocio.ListarEstudiantes();
            }
            else
            {
                DataEstudiantes.DataSource = objNegocio.ListarEstudiantesxNombre(txtBuscar.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validar(txtNum_doc.Text, txtNombres.Text, txtEmail.Text) == true)
            {
                objEstudiante.Num_doc = txtNum_doc.Text;
                objEstudiante.Nombres = txtNombres.Text;
                objEstudiante.Email = txtEmail.Text;
                objEstudiante.Estado = (this.chkEstado.Checked == true) ? true : false;

                try
                {
                    objNegocio.Agregar(objEstudiante);
                    MessageBox.Show("Se ha registrado un nuevo estudiante");
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los Datos");
            }
        }

        private void DataEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = DataEstudiantes.CurrentRow.Cells[0].Value.ToString(); 
            txtNum_doc.Text = DataEstudiantes.CurrentRow.Cells[1].Value.ToString();
            txtNombres.Text = DataEstudiantes.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = DataEstudiantes.CurrentRow.Cells[3].Value.ToString();
            if (DataEstudiantes.CurrentRow.Cells[4].Value is true)
            {
                this.chkEstado.Checked = true;
            }
            else
            {
                this.chkEstado.Checked = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validar(txtNum_doc.Text, txtNombres.Text, txtEmail.Text) == true)
            {
                objEstudiante = objNegocio.Buscar(Convert.ToInt32(txtId.Text));
                objEstudiante.Num_doc = txtNum_doc.Text;
                objEstudiante.Nombres = txtNombres.Text;
                objEstudiante.Email = txtEmail.Text;
                objEstudiante.Estado = (this.chkEstado.Checked == true) ? true : false;

                try
                {
                    objNegocio.Actualizar(objEstudiante);
                    MessageBox.Show("Se ha actualizado la categoria");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Primero selecciona el registro que quieres actualizar");
            }
        }
    }
}
