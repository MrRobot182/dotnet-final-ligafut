using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.estadisticas
{
    public partial class jugadores : System.Web.UI.Page
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
            }            
        }

        protected void MostrarJugadores(object sender, EventArgs e)
        {
            DataSet jugadores = jug.JugadoresEquipo(dd1.SelectedValue);
            if (jugadores.Tables[0].Rows.Count != 0)
            {
                gv1.DataSource = jugadores;
                jugVal.Visible = false;
            }
            else
            {
                jugVal.Visible = true;
            }
            gv1.DataBind();
        }
    }
}