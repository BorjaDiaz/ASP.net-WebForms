using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class WebFormAltaAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    ALUMNOS alumno = new ALUMNOS();
                    alumno.COD_ALU = txbCodAlu.Text;
                    alumno.NOTAS = alumno.NOTAS;
                    alumno.DNI = txbDNI.Text;
                    alumno.APELLIDOS = txbApellidos.Text;
                    alumno.NOMBRE = txbNombre.Text;
                    contexto.ALUMNOS.Add(alumno);
                    contexto.SaveChanges();

                    Response.Redirect("WebFormAlumno.aspx");
                }
            }
            catch (Exception)
            {
                literal1.Text = "La clave del alumno ya esta siendo utilizada";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAlumno.aspx");
        }
    }
}