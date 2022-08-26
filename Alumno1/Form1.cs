using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alumno1
{
    public partial class Form1 : Form
    {
        private static ServiceReference1.WebService3SoapClient servicio = new ServiceReference1.WebService3SoapClient();

        private void Listar()
        {

            dgvAlumno.DataSource = servicio.ListarAlumnos().Tables[0];
        }
        public Form1()
        {
            InitializeComponent();
            Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugarNacimiento = txtLugardeNacimiento.Text.Trim();
            DateTime fechaNacimiento = dtpFechadeNacimiento.Value.Date;
            string codEscuela = txtCodEscuela.Text.Trim();
            // ir al servicio y obtener la respuesta del mismo
            string[] rsta = servicio.AgregarAlumno(codAlumno, apellidos, nombres, lugarNacimiento, fechaNacimiento, codEscuela).ToArray();
            if (rsta[0] == "0")
            {
                dgvAlumno.DataSource = servicio.ListarAlumnos().Tables[0];
            }
            MessageBox.Show(rsta[1]);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugarNacimiento = txtLugardeNacimiento.Text.Trim();
            DateTime fechaNacimiento = dtpFechadeNacimiento.Value.Date;
            string codEscuela = txtCodEscuela.Text.Trim();
            string[] rsta = servicio.EliminarAlumno(codAlumno, apellidos, nombres, lugarNacimiento, fechaNacimiento, codEscuela).ToArray();
            if (rsta[0] == "0")
            {
                dgvAlumno.DataSource = servicio.ListarAlumnos().Tables[0];
            }
            MessageBox.Show(rsta[1]);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codAlumno = txtCodAlumno.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string lugarNacimiento = txtLugardeNacimiento.Text.Trim();
            DateTime fechaNacimiento = dtpFechadeNacimiento.Value.Date;
            string codEscuela = txtCodEscuela.Text.Trim();
            string[] rsta = servicio.ActualizarAlumno(codAlumno, apellidos, nombres, lugarNacimiento, fechaNacimiento, codEscuela).ToArray();
            if (rsta[0] == "0")
            {
                dgvAlumno.DataSource = servicio.ListarAlumnos().Tables[0];
            }
            MessageBox.Show(rsta[1]);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            string criterio = cbCriterio.SelectedItem.ToString();

            dgvAlumno.DataSource = servicio.BuscarAlumno(texto, criterio).Tables[0];
            
        }

        
    } 
    }
