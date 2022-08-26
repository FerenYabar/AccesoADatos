using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWeb
{
    public partial class Escuela : System.Web.UI.Page
    {
        //acceder al servicio web
        private static ServiceReference1.WebService1Soap servicio = new ServiceReference1.WebService1SoapClient();

        private void Listar() {
            gvEscuela.DataSource = servicio.Listar().Tables[0];
            gvEscuela.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string codEscuela = txtCodEscuela.Text.Trim();
            string escuela = txtEscuela.Text.Trim();
            string facultad = txtFacultad.Text.Trim();
            bool rsta = servicio.Agregar(codEscuela, escuela, facultad);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se agergo Escuela');</script>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string codEscuela = txtCodEscuela.Text.Trim();
            bool rsta = servicio.Eliminar(codEscuela);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se elimino Escuela');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string codEscuela = txtCodEscuela.Text.Trim();
            string escuela = txtEscuela.Text.Trim();
            string facultad = txtFacultad.Text.Trim();
            bool rsta = servicio.Actualizar(codEscuela, escuela, facultad);
            if (rsta)
            {
                Listar();
            }
            else Response.Write("<script>alert('No se actualizo Escuela');</script>");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = Buscar.Text.Trim();
            string criterio = Busqueda.SelectedItem.Text;

            gvEscuela.DataSource = servicio.Buscar(texto, criterio);
            gvEscuela.DataBind();
        }
    }
}