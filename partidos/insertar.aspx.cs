using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.partidos
{
    public partial class insertar : System.Web.UI.Page
    {
        public static Equipo equ = new Equipo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dd1.DataSource = equ.Equipos();
                dd1.DataValueField = "id_equipo";
                dd1.DataTextField = "nombre";
                dd1.DataBind();

                SinEnfrentar();
            }
        }
        protected void SeleccionLocal(object sender, EventArgs e)
        {
            SinEnfrentar();
        }

        public void SinEnfrentar()
        {
            dd2.Enabled = true;
            Equipo local = new Equipo(Convert.ToInt32(dd1.SelectedValue));

            dd2.DataSource = local.EquiposSinEnfrentar();
            dd2.DataValueField = "id_equipo";
            dd2.DataTextField = "nombre";
            dd2.DataBind();
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

        protected void Insertar(object sender, EventArgs e)
        {
            if(fecha.SelectedDate.Date != DateTime.MinValue.Date)
            {
                string fh = fecha.SelectedDate.ToString("yyyy-MM-dd") + " " + hora.Value;

                Partido par = new Partido(Convert.ToInt32(dd1.SelectedValue), Convert.ToInt32(dd2.SelectedValue), fh);

                int res = par.Insertar();

                if (res == 0)
                {
                    lbl1.CssClass = "text-success";
                    lbl1.Text = "Partido registrado";
                    SinEnfrentar();
                }
                else if (res == 1)
                {
                    lbl1.CssClass = "text-danger";
                    lbl1.Text = "Equipo local no tiene 5 jugadores mínimo";
                }
                else if (res == 2)
                {
                    lbl1.CssClass = "text-danger";
                    lbl1.Text = "Equipo visitante no tiene 5 jugadores mínimo";
                }
                else
                {
                    lbl1.CssClass = "text-danger";
                    lbl1.Text = "Problema con registro";
                }
            }
            else
            {
                lbl2.Text = "Asigna fecha";
            }
        }
    }
}