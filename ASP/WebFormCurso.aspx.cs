using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            cargar_pagina();
            
        }

        public void cargar_pagina()
        {
            if (!IsPostBack)
            {
                Session["nuevo"] = 0;
                try
                {
                    using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                    {
                        var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).First();

                        this.TxtboxCurso.Text = curso.COD_CUR.ToString();
                        TxtboxDescripcion.Text = curso.DESCRIPCION.ToString();
                        TxtboxHoras.Text = curso.HORAS.ToString();
                        TxtboxTutor.Text = curso.TUTOR.ToString();

                    }
                }
                catch (Exception)
                {
                    literal1.Text = "Error al cargar los datos";
                }

            }
        }

        protected void BtnPrimero_Click(object sender, EventArgs e)
        {
            int posi = Convert.ToInt32(Session["posicion"]);
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).First();
                    this.TxtboxCurso.Text = curso.COD_CUR.ToString();
                    TxtboxDescripcion.Text = curso.DESCRIPCION.ToString();
                    TxtboxHoras.Text = curso.HORAS.ToString();
                    TxtboxTutor.Text = curso.TUTOR.ToString();
                }
                posi = 0;
            }
            catch (Exception ex)
            {
                literal1.Text = ex.ToString();
            }
            Session["posicion"] = posi.ToString();
            Session["nuevo"] = 0;
        }

        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            int posi = Convert.ToInt32(Session["posicion"]);
            posi--;
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).Skip(posi).First();
                    this.TxtboxCurso.Text = curso.COD_CUR.ToString();
                    TxtboxDescripcion.Text = curso.DESCRIPCION.ToString();
                    TxtboxHoras.Text = curso.HORAS.ToString();
                    TxtboxTutor.Text = curso.TUTOR.ToString();
                }
            }
            catch (Exception)
            {
                posi++;
            }

            Session["posicion"] = posi.ToString();
            Session["nuevo"] = 0;
        }

        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {
            int posi = Convert.ToInt32(Session["posicion"]);
            posi++;
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).Skip(posi).First();
                    this.TxtboxCurso.Text = curso.COD_CUR.ToString();
                    TxtboxDescripcion.Text = curso.DESCRIPCION.ToString();
                    TxtboxHoras.Text = curso.HORAS.ToString();
                    TxtboxTutor.Text = curso.TUTOR.ToString();
                }
            }
            catch (Exception)
            {
                posi--;
            }

            Session["posicion"] = posi.ToString();
            Session["nuevo"] = 0;
        }

        protected void BtnUltimo_Click(object sender, EventArgs e)
        {
            int posi = Convert.ToInt32(Session["posicion"]);
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var curs = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p);
                    posi = curs.Count() - 1;

                    var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).Skip(posi).First();
                    this.TxtboxCurso.Text = curso.COD_CUR.ToString();
                    TxtboxDescripcion.Text = curso.DESCRIPCION.ToString();
                    TxtboxHoras.Text = curso.HORAS.ToString();
                    TxtboxTutor.Text = curso.TUTOR.ToString();

                }
            }
            catch (Exception ex)
            {
                literal1.Text = ex.ToString();
            }
            Session["posicion"] = posi.ToString();
            Session["nuevo"] = 0;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {


                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {

                    CURSOS curso = (from p in contexto.CURSOS
                                    where p.COD_CUR == TxtboxCurso.Text
                                    select p).First();
                    curso.COD_CUR = TxtboxCurso.Text;
                    curso.DESCRIPCION = TxtboxDescripcion.Text;
                    curso.HORAS = Int32.Parse(TxtboxHoras.Text);
                    curso.TUTOR = TxtboxTutor.Text;
                    contexto.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                literal1.Text = ex.ToString();
            }
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {

                    var nota = (from p in contexto.NOTAS where p.COD_CUR == TxtboxCurso.Text select p);
                    if (nota != null)
                    {
                        contexto.NOTAS.RemoveRange(nota);
                        contexto.SaveChanges();
                    }

                    var curso = (from p in contexto.CURSOS where p.COD_CUR == TxtboxCurso.Text select p).FirstOrDefault();
                    if (curso != null)
                    {
                        contexto.CURSOS.Remove(curso);
                        contexto.SaveChanges();
                    }
                }
            }
            catch (SqlException ex)
            {
                literal1.Text = ex.ToString();
            }
            catch (Exception ex)
            {
                literal1.Text = ex.ToString();
            }
           
            TxtboxCurso.Text = "";
            TxtboxDescripcion.Text = "";
            TxtboxHoras.Text = "";
            TxtboxTutor.Text = "";
            cargar_pagina();
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(Session["nuevo"])==0)
            {
                TxtboxCurso.ReadOnly=false;
                TxtboxCurso.Text = "";
                TxtboxDescripcion.Text = "";
                TxtboxHoras.Text = "";
                TxtboxTutor.Text = "";


                Session["nuevo"] = 1;
                return;
            }

            if (Convert.ToInt32(Session["nuevo"]) == 1)
            {
                try
                {
                    using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                    {
                        CURSOS curso = new CURSOS();
                        curso.COD_CUR = TxtboxCurso.Text;
                        curso.DESCRIPCION = TxtboxDescripcion.Text;
                        curso.HORAS = Int32.Parse(TxtboxHoras.Text);
                        curso.TUTOR = TxtboxTutor.Text;
                        curso.NOTAS = curso.NOTAS;
                        contexto.CURSOS.Add(curso);
                        contexto.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    literal1.Text = "Codigo de curso ya en uso";
                }

                Session["nuevo"] = 0;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            int posi = Convert.ToInt32(Session["posicion"]);
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var curso = (from p in contexto.CURSOS orderby p.COD_CUR ascending select p).Skip(posi).First();
                    this.TxtboxCurso.Text = curso.COD_CUR.ToString();
                    TxtboxDescripcion.Text = curso.DESCRIPCION.ToString();
                    TxtboxHoras.Text = curso.HORAS.ToString();
                    TxtboxTutor.Text = curso.TUTOR.ToString();
                }
            }
            catch (Exception ex)
            {
                literal1.Text = ex.ToString();
            }
            Session["posicion"] = posi.ToString();

        }
    }
}