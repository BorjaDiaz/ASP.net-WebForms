using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class WebFormAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_pagina();
        }

        public void cargar_pagina()
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var alumno = (from p in contexto.ALUMNOS orderby p.COD_ALU ascending select p).ToList();
                    gridAlumno.DataSource = alumno;
                    gridAlumno.DataBind();

                }
            }
            catch (Exception)
            {
                literal1.Text = "Error al cargar los datos";
            }
        }

        protected void gridAlumno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int n = Convert.ToInt32(e.CommandArgument);
            Session["cod_alu"] = gridAlumno.Rows[n].Cells[0].Text.ToString();
            Session["DNI"] = gridAlumno.Rows[n].Cells[1].Text.ToString();
            Session["apellidos"] = gridAlumno.Rows[n].Cells[2].Text.ToString();
            Session["nombre"] = gridAlumno.Rows[n].Cells[3].Text.ToString();
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("WebFormModificarAlumno.aspx");
            }
            if(e.CommandName == "Borrar")
            {
                Response.Redirect("WebFormBorrarAlumno.aspx");
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAltaAlumno.aspx");
        }

        protected void btnAltaCurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAltaAlumnoCurso.aspx");
        }
    }
}