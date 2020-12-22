using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ASP
{
    public partial class WebFormModificarAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txbCodAlu.Enabled = false;

                txbCodAlu.Text = Session["cod_alu"].ToString();
                txbDNI.Text = Session["DNI"].ToString();
                txbApellidos.Text = Session["apellidos"].ToString();
                txbNombre.Text = Session["nombre"].ToString();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    ALUMNOS alumno = (from p in contexto.ALUMNOS
                                      where p.COD_ALU == txbCodAlu.Text
                                      select p).First();
                    alumno.COD_ALU = txbCodAlu.Text;
                    alumno.DNI = txbDNI.Text;
                    alumno.APELLIDOS = txbApellidos.Text;
                    alumno.NOMBRE = txbNombre.Text;
                    contexto.SaveChanges();
                    Response.Redirect("WebFormAlumno.aspx");
                }
            }
            catch (SqlException ex)
            {
                literal1.Text = ex.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAlumno.aspx");
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            txbCodAlu.Text = Session["cod_alu"].ToString();
            txbDNI.Text = Session["DNI"].ToString();
            txbApellidos.Text = Session["apellidos"].ToString();
            txbNombre.Text = Session["nombre"].ToString();
        }
    }
}