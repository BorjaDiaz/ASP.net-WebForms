using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class WebFormAltaAlumnoCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_pagina();
            }
            txbApellidos.Enabled = false;
            txbDNI.Enabled = false;
            txbNombre.Enabled = false;
        }

        public void cargar_pagina()
        {
            
            using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
            {
                var alumno = (from p in contexto.ALUMNOS select p.COD_ALU).ToList();
                ddAlumnos.DataSource = alumno;
                ddAlumnos.DataBind();
                ddAlumnos.ClearSelection();


                var nota = (from p in contexto.CURSOS select p.COD_CUR).ToList();
                ddCursos.DataSource = nota;
                ddCursos.DataBind();
                ddCursos.ClearSelection();

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    NOTAS nota = new NOTAS();
                    nota.COD_ALU = ddAlumnos.Text;
                    nota.COD_CUR = ddCursos.Text;
                    nota.NOTA1 = 0;
                    nota.NOTA2 = 0;
                    nota.NOTA3 = 0;
                    nota.MEDIA = 0;
                    contexto.NOTAS.Add(nota);
                    contexto.SaveChanges();
                }
            }
            catch(Exception)
            {
                literal1.Text = "El alumno ya se encuentra en el curso";
                return;
            }
            Response.Redirect("WebFormAlumno.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAlumno.aspx");
        }

        protected void ddAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
            {
                var alumno = (from p in contexto.ALUMNOS
                              where p.COD_ALU == ddAlumnos.SelectedValue
                              select p).First();

                txbDNI.Text = alumno.DNI;
                txbApellidos.Text = alumno.APELLIDOS.ToString();
                txbNombre.Text = alumno.NOMBRE.ToString();
            }
           


        }
    }
}