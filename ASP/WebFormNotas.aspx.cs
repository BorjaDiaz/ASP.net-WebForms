using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP
{
    public partial class WebFormNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelNotas.Visible = false;
            txbCodAlu.Visible = false;
            txbCodCur.Visible = false;
            txbApellidos.Enabled = false;
            txbNombre.Enabled = false;
            txbMedia.Enabled = false;

            if (!IsPostBack)
            {
                cargar_pagina();
            }

        }

        public void cargar_pagina()
        {
            try
            {
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {
                    var nota = (from p in contexto.CURSOS select p.DESCRIPCION).ToList();
                    dropNotasCurso.DataSource = nota;
                    dropNotasCurso.DataBind();
                    dropNotasCurso.ClearSelection();

                }
            }
            catch (Exception)
            {
                literal1.Text = "Error al cargar los datos";
            }
        }

        protected void dropNotas_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
            {
                var notas = (from p in contexto.ALUMNOS
                             join p1 in contexto.NOTAS on p.COD_ALU equals p1.COD_ALU
                             join p2 in contexto.CURSOS on p1.COD_CUR equals p2.COD_CUR
                             where p2.DESCRIPCION == dropNotasCurso.SelectedValue
                             select new { p1.COD_CUR, p1.COD_ALU, p.APELLIDOS, p.NOMBRE, p1.NOTA1, p1.NOTA2, p1.NOTA3, p1.MEDIA }).ToList();
                GridviewNota.DataSource = notas;
                GridviewNota.DataBind();
            }

        }

        protected void GridviewNota_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int n = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                txbCodAlu.Text = GridviewNota.Rows[n].Cells[0].Text.ToString();
                txbCodCur.Text = GridviewNota.Rows[n].Cells[1].Text.ToString();
                txbApellidos.Text = GridviewNota.Rows[n].Cells[2].Text.ToString();
                txbNombre.Text = GridviewNota.Rows[n].Cells[3].Text.ToString();
                txbNota1.Text = GridviewNota.Rows[n].Cells[4].Text.ToString();
                txbNota2.Text = GridviewNota.Rows[n].Cells[5].Text.ToString();
                txbNota3.Text = GridviewNota.Rows[n].Cells[6].Text.ToString();
                txbMedia.Text = GridviewNota.Rows[n].Cells[7].Text.ToString();
                PanelNotas.Visible = true;

            }
            if (e.CommandName == "Borrar")
            {
                var id = GridviewNota.Rows[n].Cells[1].Text.ToString();
                using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
                {                  
                    var nota = (from p in contexto.NOTAS where p.COD_CUR == id select p).FirstOrDefault();
                    if (nota != null)
                    {
                        contexto.NOTAS.Remove(nota);
                        contexto.SaveChanges();
                        dropNotasCurso.ClearSelection();
                        GridviewNota.DataBind();

                    }
                }

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
            {
                NOTAS nota = (from p in contexto.NOTAS
                              where p.COD_CUR == txbCodCur.Text && p.COD_ALU == txbCodAlu.Text
                              select p).First();
                nota.COD_CUR = txbCodCur.Text;
                nota.COD_ALU = txbCodAlu.Text;
                nota.ALUMNOS.APELLIDOS = txbApellidos.Text;
                nota.ALUMNOS.NOMBRE = txbNombre.Text;
                nota.NOTA1 = Int32.Parse(txbNota1.Text);
                nota.NOTA2 = Int32.Parse(txbNota2.Text);
                nota.NOTA3 = Int32.Parse(txbNota3.Text);
                nota.MEDIA = Int32.Parse(txbMedia.Text);
                contexto.SaveChanges();
                dropNotasCurso.ClearSelection();
                GridviewNota.DataBind();
            }
        }

        protected void MediaNota_Click(object sender, EventArgs e)
        {
            int nota1, nota2, nota3, media;
            nota1 = int.Parse(txbNota1.Text);
            nota2 = int.Parse(txbNota2.Text);
            nota3 = int.Parse(txbNota3.Text);
            media = int.Parse(txbMedia.Text);
            media = (nota1 + nota2 + nota3) / 3;
            txbMedia.Text = Convert.ToString(media);
            PanelNotas.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            using (ModeloOcupacional1 contexto = new ModeloOcupacional1())
            {
                NOTAS nota = (from p in contexto.NOTAS
                              where p.COD_ALU == txbCodAlu.Text && p.COD_CUR == txbCodCur.Text
                              select p).First();
                txbNota1.Text = nota.NOTA1.ToString();
                txbNota2.Text = nota.NOTA2.ToString();
                txbNota3.Text = nota.NOTA3.ToString();
                txbMedia.Text = nota.MEDIA.ToString();

            }
        }
    }
}