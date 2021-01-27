using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.partidos
{
    public partial class consultar : System.Web.UI.Page
    {
        Partido par = new Partido();
        public static int editId;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet partidos = par.Partidos();
            gv1.DataSource = partidos;
            gv1.DataBind();      
        }

        protected void PanelEditar(object sender, EventArgs e)
        {
            pan4.Visible = true;
            pan1.Visible = false;
            pan3.Visible = false;
            title.InnerText = "Editar fecha";
            editId = Convert.ToInt32(gv1.DataKeys[Convert.ToInt32((sender as Button).CommandArgument)].Values[0]);
            Partido par = new Partido(editId);

            DataSet partido = par.ConsultaPartido();

            txtLocal.Text = partido.Tables[0].Rows[0][1].ToString();
            txtVisita.Text = partido.Tables[0].Rows[0][5].ToString();
        }
        protected void PanelJugar(object sender, EventArgs e)
        {
            pan4.Visible = false;
            pan1.Visible = false;
            pan3.Visible = true;

            title.InnerText = "Registro de incidentes";
            editId = Convert.ToInt32(gv1.DataKeys[Convert.ToInt32((sender as Button).CommandArgument)].Values[0]);
            Partido par = new Partido(editId);

            DataSet partido = par.ConsultaPartido();
            DataSet equipos = par.EquiposPartido();

            gv2.DataSource = partido;
            gv2.DataBind();

            Jugador jugL = new Jugador(Convert.ToInt32(equipos.Tables[0].Rows[0][0]));

            ddjl.DataSource = jugL.NumeroJugador();
            ddjl.DataTextField = "nombre_completo";
            ddjl.DataValueField = "id_jugador";
            ddjl.DataBind();

            ddi1.DataSource = jugL.Incidentes();
            ddi1.DataTextField = "descripcion";
            ddi1.DataValueField = "id_incidente";
            ddi1.DataBind();

            Jugador jugV = new Jugador(Convert.ToInt32(equipos.Tables[0].Rows[0][1]));

            ddjv.DataSource = jugV.NumeroJugador();
            ddjv.DataTextField = "nombre_completo";
            ddjv.DataValueField = "id_jugador";
            ddjv.DataBind();

            ddi2.DataSource = jugV.Incidentes();
            ddi2.DataTextField = "descripcion";
            ddi2.DataValueField = "id_incidente";
            ddi2.DataBind();
        }

        protected void IncidenteLocal(object sender, EventArgs e)
        {
            Estadisticas est = new Estadisticas();
            est.Incidentes(editId, Convert.ToInt32(ddi1.SelectedValue), Convert.ToInt32(ddjl.SelectedValue), Convert.ToInt32(min1.Value));

            Partido par = new Partido(editId);
            DataSet partido = par.ConsultaPartido();

            gv2.DataSource = partido;
            gv2.DataBind();

        }

        protected void IncidenteVisita(object sender, EventArgs e)
        {
            Estadisticas est = new Estadisticas();
            est.Incidentes(editId, Convert.ToInt32(ddi2.SelectedValue), Convert.ToInt32(ddjv.SelectedValue), Convert.ToInt32(min2.Value));

            Partido par = new Partido(editId);
            DataSet partido = par.ConsultaPartido();

            gv2.DataSource = partido;
            gv2.DataBind();
        }

        protected void Actualizar(object sender, EventArgs e)
        {
            if (fecha.SelectedDate.Date != DateTime.MinValue.Date)
            {
                string fh = fecha.SelectedDate.ToString("yyyy-MM-dd") + " " + hora.Value;
                Partido par = new Partido(editId, fh);
                par.Actualizar();
                
                Page.Response.Redirect("consultar.aspx");
            }
            else
                lbl42.Text = "Asigna fecha";
        }

        protected void Finalizar(object sender, EventArgs e)
        {
            Partido par = new Partido(editId);
            par.Finalizar();
            Page.Response.Redirect("consultar.aspx");
        }

            protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.DayOfWeek != DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }

        }

        protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String finalizado = e.Row.Cells[8].Text.ToString();

                var btn1 = e.Row.FindControl("btn1") as Label;
                var btn2 = e.Row.FindControl("btn2") as Button;
                var btn3 = e.Row.FindControl("btn3") as Button;

                if (finalizado == "True")
                {
                    btn1.Visible = true;
                    btn2.Visible = false;
                    btn3.Visible = false;
                }
                else if (finalizado == "False")
                {
                    btn1.Visible = false;
                    btn2.Visible = true;
                    btn3.Visible = true;
                }

            }
        }
    }
}