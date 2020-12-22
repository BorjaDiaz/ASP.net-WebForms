using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class WebFormBorrarAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_pagina();
            }
            txbApellidos.Enabled = false;
            txbCodAlu.Enabled = false;
            txbDNI.Enabled = false;
            txbNombre.Enabled = false;
        }

        public void cargar_pagina()
        {
            try
            {
                txbCodAlu.Text = Session["cod_alu"].ToString();
                txbDNI.Text = Session["DNI"].ToString();
                txbApellidos.Text = Session["apellidos"].ToString();
                txbNombre.Text = Session["nombre"].ToString();
            }
            catch(Exception)
            {
                literal1.Text = "Error al cargar los datos";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAlumno.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {

                    var nota = (from p in contexto.NOTAS where p.COD_ALU == txbCodAlu.Text select p).FirstOrDefault();
                    if (nota != null)
                    {
                        contexto.NOTAS.Remove(nota);
                        contexto.SaveChanges();
                    }

                    var alumno = (from p in contexto.ALUMNOS where p.COD_ALU == txbCodAlu.Text select p).FirstOrDefault();
                    if (alumno != null)
                    {
                        contexto.ALUMNOS.Remove(alumno);
                        contexto.SaveChanges();
                    }
                   
                   
                }
                Response.Redirect("WebFormAlumno.aspx");
            }
            catch (Exception)
            {
                literal1.Text = "Error al borrar el alumno";
            }

        }

        public void borrar()
        {

        }
    }
}