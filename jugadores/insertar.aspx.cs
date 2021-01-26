using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.jugadores
{
    public partial class insertar : System.Web.UI.Page
    {
        Equipo equ = new Equipo();
        Jugador jug = new Jugador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dd1.DataSource = equ.Equipos();
                dd1.DataValueField = "id_equipo";
                dd1.DataTextField = "nombre";
                dd1.DataBind();

                dd2.DataSource = jug.Posiciones();
                dd2.DataValueField = "id_posicion";
                dd2.DataTextField = "descripcion";
                dd2.DataBind();
            }
        }

        protected void Insertar(object sender, EventArgs e)
        {
            Jugador jug = new Jugador(Convert.ToInt32(dd1.SelectedValue), txtNum.Value, txtNom.Text.ToUpper(), txtApp.Text.ToUpper(), txtApm.Text.ToUpper(), dateFn.Value, Convert.ToInt32(dd2.SelectedValue));
            
            int res = jug.Insertar();

            if (res == 0)
            {
                lbl1.CssClass = "text-success";
                lbl1.Text = "Jugador registrado";
            }
            else if (res == 1)
            {
                lbl1.CssClass = "text-danger";
                lbl1.Text = "Otro jugador del equipo tiene el mismo número";
            }
            else if (res == 2)
            {
                lbl1.CssClass = "text-danger";
                lbl1.Text = "Ya hay 10 jugadores en este equipo";
            }
            else
            {
                lbl1.CssClass = "text-danger";
                lbl1.Text = "Problema con registro";
            }
            
        }
    }
}